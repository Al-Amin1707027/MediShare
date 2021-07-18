-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: medishare
-- ------------------------------------------------------
-- Server version	8.0.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cart`
--

DROP TABLE IF EXISTS `cart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cart` (
  `user_id` varchar(100) NOT NULL,
  `product_id` varchar(100) NOT NULL,
  `price` int DEFAULT NULL,
  `file_name` varchar(145) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `product_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`user_id`,`product_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cart`
--

LOCK TABLES `cart` WRITE;
/*!40000 ALTER TABLE `cart` DISABLE KEYS */;
/*!40000 ALTER TABLE `cart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `product_id` varchar(500) NOT NULL,
  `product_name` varchar(11145) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `order_date` varchar(45) DEFAULT NULL,
  `user_id` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`product_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES ('miAY4F5vXfRR','Penicillin',2,'Payment Completed','2021-07-18 20:36:36','P5AsDj3gKgTfQXwq');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_list`
--

DROP TABLE IF EXISTS `product_list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_list` (
  `product_id` varchar(100) NOT NULL,
  `product_name` varchar(45) DEFAULT NULL,
  `category` varchar(45) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `upload_date` varchar(45) DEFAULT NULL,
  `number_of_orders` int DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `user_shop_id` varchar(45) NOT NULL,
  `per_unit_price` int DEFAULT NULL,
  `remark` varchar(20) DEFAULT NULL,
  `file_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`product_id`,`user_shop_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_list`
--

LOCK TABLES `product_list` WRITE;
/*!40000 ALTER TABLE `product_list` DISABLE KEYS */;
INSERT INTO `product_list` VALUES ('bQOLG7R5E0zM','napa extra','Everyday Drugs',30,'2021-07-04 13:25:51',0,'pending','P5AsDj3gKgTfQXwq',1,'sale','637610019515155295.jpg'),('bvabreO8Vrfk','Ace Plus','Everyday Drugs',10,'2021-07-04 14:07:19',0,'pending','P5AsDj3gKgTfQXwq',4,'sale','637610044390650975.jpg'),('miAY4F5vXfRR','Penicillin','Other Drugs',10,'2021-07-05 14:15:02',0,'pending','P5AsDj3gKgTfQXwq',135,'sale','637610913021718624.jpg'),('UBezsTjiO422','Antacid','Everyday Drugs',50,'2021-07-05 13:10:47',0,'pending','P5AsDj3gKgTfQXwq',3,'sale','637610874478512665.jpg'),('XbrAJF0UbCIT','Olmesan plus','Heart Drugs',199,'2021-07-04 14:09:26',0,'pending','P5AsDj3gKgTfQXwq',9,'sale','637610045666514817.jpg');
/*!40000 ALTER TABLE `product_list` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` varchar(500) NOT NULL,
  `email` varchar(45) NOT NULL,
  `password` varchar(1000) NOT NULL,
  `old_password` varchar(1000) DEFAULT NULL,
  `phone` varchar(15) DEFAULT NULL,
  `first_name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  `is_verified` varchar(8) NOT NULL,
  `verify_code` varchar(1000) NOT NULL,
  `user_address` varchar(3000) DEFAULT NULL,
  `role` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('34LDV3Ut2j0aAfPD','alaminbdgbtttt@gmail.com','saajshfgvashjfgajshfgb','saajshfgvashjfgajshfgb','N/A','Abdullah','Al-Amin','no','l3cXTfw1lAIWQhmn','N/A','client'),('46tNnU2EOSSnODzP','sdadvvasd@gmail.com','$2b$12$ab5GqiiR3POLQgNmSTloj.uwcHMfnV27pq29lmgmswT5itrRDC4Jq','$2b$12$ab5GqiiR3POLQgNmSTloj.uwcHMfnV27pq29lmgmswT5itrRDC4Jq','N/A','MD','Ratul','no','F0WIxfXcYY3abmJB','N/A','client'),('b0cdGgDSoOQG8Pbq','alaminb7777dd7dgb@gmail.com','$2b$12$NUY0VUwwX1NpXdGBviT25uEvfwefgzZupOS3w2wGcjYwdNyoHioWq','$2b$12$NUY0VUwwX1NpXdGBviT25uEvfwefgzZupOS3w2wGcjYwdNyoHioWq','N/A','Abdullah','Al-Amin','No','hvcO4zw5JMeu3N3Z','N/A','client'),('CfLyRZmVdstrrK8Y','alaminbdgbb@gmail.com','$2b$12$zrTYON54xVK3Tt5fqxphpeffbhz4Gj/fkqdyIjVenw/gSwTxY5omu','$2b$12$zrTYON54xVK3Tt5fqxphpeffbhz4Gj/fkqdyIjVenw/gSwTxY5omu','N/A','Abdullah','Al-Amin','yes','mBLmTiUBo98BsVkU','N/A','client'),('ElmhmD8N4DCNxmOZ','alaminb77777dgb@gmail.com','$2b$12$iS24eVpqZDT/hjMakWleX.IZK8mIAed0e359wipDMhcXUPr6C0zKm','$2b$12$iS24eVpqZDT/hjMakWleX.IZK8mIAed0e359wipDMhcXUPr6C0zKm','N/A','Abdullah','Al-Amin','No','wAVMvIFjTmFsIkOv','N/A','client'),('JsWD4wmW4GYygn3H','sdadasd@gmail.com','$2b$12$IbE1FmMDp9pXIJAQjQeP7.VQHC9PVO.6IjWHMBikuj9lBmtvfGBTC','$2b$12$IbE1FmMDp9pXIJAQjQeP7.VQHC9PVO.6IjWHMBikuj9lBmtvfGBTC','N/A','Abdul','Aziz','no','ebB3JGmQkYUNXJOh','N/A','client'),('k6kKZ1oG2JuL7isQ','alaminbdghjk8655b@gmail.com','$2b$12$Y7WgzQhwSSz49vj5jhSA3.qVSB48X4R6oZ6pDizVCe2QugQhROWta','$2b$12$Y7WgzQhwSSz49vj5jhSA3.qVSB48X4R6oZ6pDizVCe2QugQhROWta','N/A','Abdullah','Al-Amin','No','EtzjdEJKkvqfmnsE','N/A','client'),('nKrcJ19Lgn88exxb','alaminbtdgb@gmail.com','$2b$12$LoOP0O2O0EMRzZ3w20eSWOI4CIDCtwV/lsHdNcznsVjzEsvuBFVE6','$2b$12$LoOP0O2O0EMRzZ3w20eSWOI4CIDCtwV/lsHdNcznsVjzEsvuBFVE6','N/A','Abdullah','Al-Amin','No','jBfhHolWtnadn0LI','N/A','client'),('OybzqNXbQoUzasYx','sdadasnnnnnd@gmail.com','$2b$12$0BIxEx9ULwMOeF9ufYy/j.sE9M40opfBGwXRbNLQIyTzm/barV9o.','$2b$12$0BIxEx9ULwMOeF9ufYy/j.sE9M40opfBGwXRbNLQIyTzm/barV9o.','N/A','Abdullah','Al-Amina','no','JidVRhUp7fakrQNW','N/A','client'),('P5AsDj3gKgTfQXwq','alaminbdgb@gmail.com','$2b$12$87Tvq2nYKhMP6RNbL4JgLeUoCfgyZPde6CkzShCrf1actSa2sw3qC','$2b$12$87Tvq2nYKhMP6RNbL4JgLeUoCfgyZPde6CkzShCrf1actSa2sw3qC','0167261526526','Abdullah','Al-Amin','yes','lApvc8cwT3UGym2y','sasas<br>saasdas<br>asdasd','admin'),('RyhUF84dVQnW6xa3','sdadvvfffasd@gmail.com','$2b$12$ubQTLaws9yudKaaFXmQlTOTspn5YlIBWPJZ6lz/PaABrdMQu3Y0TS','$2b$12$ubQTLaws9yudKaaFXmQlTOTspn5YlIBWPJZ6lz/PaABrdMQu3Y0TS','N/A','MD','Ratul Br','no','7mtY3Cv4j2NN6CeT','N/A','client'),('S1TZcEuxFEO6BpGH','alamin1707027@outlook.com','$2b$12$NdhQKnb0/IUOKOTGJPcY8uAMzjVjL.fduviAxKoweFz5buCQunM6S','$2b$12$NdhQKnb0/IUOKOTGJPcY8uAMzjVjL.fduviAxKoweFz5buCQunM6S','N/A','Abdullah','Al-Amin','no','ObpFRVTGxGq8OsK8','N/A','client'),('vMVO8CBrr8GQeqKQ','alaminbdgkkkkb@gmail.com','$2b$12$IVV1LuaGdXkFICxcXou5W.C8rFQmDrKU2PLeXWi.qhs.XSeT9pat.','$2b$12$IVV1LuaGdXkFICxcXou5W.C8rFQmDrKU2PLeXWi.qhs.XSeT9pat.','N/A','Abdullah','Al-Amin','No','8PxrngLBccYdtAUo','N/A','client');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-07-18 20:46:39
