/* Copyright (C) 2021 Shamim Ahamed - All Rights Reserved
 * Contact: pavel123@outlook.in
 * Any modification of this file must contain the above copyright notice.
 */
using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace Server {
    public class Database {
        public static ConnPool ConnectionPool;
        public static void Connect(string conn_string) {  
            ConnectionPool = new Server.ConnPool(conn_string);
        }
    }
    
    public static class MySqlUtility {
        public static string ConvertTo_MySqlDate(DateTime dateTime) {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
    
    public static class DAL {
        private static async Task<MySqlCommand> _prepareCmd(string query, object[,] parameters) {
            MySqlConnection cnn = await Database.ConnectionPool.GetConnectionAsync();
            
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            for(int i = 0; i < (parameters.Length / 2); i++) {
                cmd.Parameters.AddWithValue(parameters[i,0].ToString(), parameters[i,1]);
            }
            return cmd;
        }
        
        public static async Task<bool> IsExist(string query, object[,] parameters) {
            var cmd = await _prepareCmd(query, parameters);
            
            bool res = false;
            try {
                var reader = await cmd.ExecuteReaderAsync();
                if(reader.HasRows) {
                    res = true;
                }
                await reader.CloseAsync();
            }
            catch(Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            
            Database.ConnectionPool.PutConnection(cmd.Connection);
            return res;
        }
        
        public static async Task<List<T>> ExecuteReaderAsync<T>(string query, string[,] parameters) {
            var cmd = await _prepareCmd(query, parameters);
            List<T> res = new List<T>();
            PropertyInfo[] properties = typeof(T).GetProperties();
            
            try {
                using (var reader = await cmd.ExecuteReaderAsync()){
                    while(await reader.ReadAsync()) {
                        T i = (T)Activator.CreateInstance(typeof(T));
                        foreach(var v in properties) {
                            var r = reader[v.Name];
                            v.SetValue(i, r);
                        }
                        res.Add(i);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            
            Database.ConnectionPool.PutConnection(cmd.Connection);
            return res;
        }
        
        public static async Task<bool> ExecuteNonQueryAsync(string query, string[,] parameters) {
            var cmd = await _prepareCmd(query, parameters);
            
            bool res = false;
            try {
                await cmd.ExecuteNonQueryAsync();
                res = true;
            }
            catch(Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            
            Database.ConnectionPool.PutConnection(cmd.Connection);
            return res;
        }
        
        public static async Task<object> ExecuteScalarAsync(string query, string[,] parameters) {
            var cmd = await _prepareCmd(query, parameters);
            
            object res = new object();
            try {
                res = await cmd.ExecuteScalarAsync();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            Database.ConnectionPool.PutConnection(cmd.Connection);
            return res;
        }
    }
    
    public class ConnPool
    {
        // MySql Connection Pool
        private volatile object pool_lock = new object();
        private List<MySqlConnection> pool = new List<MySqlConnection>();
        
        // Queued Connection Get Request
        private volatile object request_queue_lock = new object();
        private volatile List<TaskCompletionSource<MySqlConnection>> request_queue = 
            new List<TaskCompletionSource<MySqlConnection>>(); 
        
        private string conn_str = string.Empty;
        private int pool_size = 0;
        
        public ConnPool (string conn_str, int pool_size = 32) {
            this.conn_str = conn_str;
            this.pool_size = pool_size;
            
            // Initialize pool
            for(int i = 0; i < pool_size; i++) {
                MySqlConnection mscnn = new MySqlConnection(conn_str);
                try{
                    mscnn.Open();
                }
                catch (Exception ex){
                    System.Console.WriteLine(ex.Message);
                }
                pool.Add(mscnn);
            }
        }
        
        public async Task<MySqlConnection> GetConnectionAsync() 
        {  
            // Access safely to Connection Pool
            lock(pool_lock) 
            {
                if(pool.Count > 0) {
                    var v = pool[0];
                    pool.RemoveAt(0);
                    
                    if(v.State == ConnectionState.Closed || 
                        v.State == ConnectionState.Broken)
                    {
                        try {
                            v.Open();
                        }
                        catch { }
                    }
                    return v;
                }
            }
            
            // Pool is empty. Wait for new free connection
            var taskCompletion = new TaskCompletionSource<MySqlConnection>();
            
            // Register connection get request
            lock(request_queue_lock){
                request_queue.Add(taskCompletion);
            }
            
            // Block Execution untill a connection is free.
            Task<MySqlConnection> task = taskCompletion.Task;
            await task;
            
            //Console.WriteLine("Connection passed to queued request");
            return task.Result;
        }
        
        public void PutConnection(MySqlConnection cnn) {
            // Do not add to pool if it's already full
            if(pool.Count > pool_size) return;
            
            // If connection is closed try to open it
            if(cnn.State == ConnectionState.Closed || 
                cnn.State == ConnectionState.Broken) 
            {
                try {
                    cnn.Open();
                }
                catch{ }
            }
            
            // Check if any pending request need connection
            lock(request_queue_lock) {
                if(request_queue.Count != 0) {
                    var v = request_queue[0];
                    request_queue.RemoveAt(0);
                    v.SetResult(cnn);
                    //Console.WriteLine("Dequeued. Curr Len: " + request_queue.Count);
                    return;
                }
            }
            
            // No pending request. Return to pool
            lock(pool_lock) {
                pool.Add(cnn);
            }
        }
    }
}
