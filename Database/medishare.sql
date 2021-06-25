-- MySQL dump 10.13  Distrib 8.0.25, for Linux (x86_64)
--
-- Host: 127.0.0.1    Database: MediShare_DB
-- ------------------------------------------------------
-- Server version	8.0.25-0ubuntu0.20.04.1

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
  PRIMARY KEY (`product_id`,`user_shop_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_list`
--

LOCK TABLES `product_list` WRITE;
/*!40000 ALTER TABLE `product_list` DISABLE KEYS */;
INSERT INTO `product_list` VALUES ('6e0kq3716ihb','Napa Plus','Everyday Drugs',10,'2021-05-22 00:55:24',0,'pending','CfLyRZmVdstrrK8Y'),('i10GKkMQLT6G','Ace Plus','Everyday Drugs',30,'2021-05-22 01:20:45',0,'pending','CfLyRZmVdstrrK8Y'),('i10GKkMQLT6Ge','Ace Plus','Everyday Drugs',NULL,'2021-05-22 01:20:45',0,'pending','CfLyRZmVdstrrK8YAAA');
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
  `created` varchar(30) DEFAULT NULL,
  `last_login` varchar(30) DEFAULT NULL,
  `user_status` varchar(30) DEFAULT NULL,
  `wrong_login_attempt` varchar(45) DEFAULT NULL,
  `role` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('34LDV3Ut2j0aAfPD','alaminbdgbtttt@gmail.com','saajshfgvashjfgajshfgb','saajshfgvashjfgajshfgb',NULL,'Abdullah','Al-Amin','no','l3cXTfw1lAIWQhmn','2021-05-20 13:04:40',NULL,NULL,NULL,'client'),('46tNnU2EOSSnODzP','sdadvvasd@gmail.com','$2b$12$ab5GqiiR3POLQgNmSTloj.uwcHMfnV27pq29lmgmswT5itrRDC4Jq','$2b$12$ab5GqiiR3POLQgNmSTloj.uwcHMfnV27pq29lmgmswT5itrRDC4Jq',NULL,'MD','Ratul','no','F0WIxfXcYY3abmJB','2021-02-16 23:13:47',NULL,NULL,NULL,'client'),('CfLyRZmVdstrrK8Y','alaminbdgbb@gmail.com','$2b$12$zrTYON54xVK3Tt5fqxphpeffbhz4Gj/fkqdyIjVenw/gSwTxY5omu','$2b$12$zrTYON54xVK3Tt5fqxphpeffbhz4Gj/fkqdyIjVenw/gSwTxY5omu',NULL,'Abdullah','Al-Amin','yes','mBLmTiUBo98BsVkU','2021-05-21 22:42:10',NULL,NULL,NULL,'client'),('JsWD4wmW4GYygn3H','sdadasd@gmail.com','$2b$12$IbE1FmMDp9pXIJAQjQeP7.VQHC9PVO.6IjWHMBikuj9lBmtvfGBTC','$2b$12$IbE1FmMDp9pXIJAQjQeP7.VQHC9PVO.6IjWHMBikuj9lBmtvfGBTC',NULL,'Abdul','Aziz','no','ebB3JGmQkYUNXJOh','2021-02-16 23:13:16',NULL,NULL,NULL,'client'),('OybzqNXbQoUzasYx','sdadasnnnnnd@gmail.com','$2b$12$0BIxEx9ULwMOeF9ufYy/j.sE9M40opfBGwXRbNLQIyTzm/barV9o.','$2b$12$0BIxEx9ULwMOeF9ufYy/j.sE9M40opfBGwXRbNLQIyTzm/barV9o.',NULL,'Abdullah','Al-Amina','no','JidVRhUp7fakrQNW','2021-02-16 23:24:58',NULL,NULL,NULL,'client'),('P5AsDj3gKgTfQXwq','alaminbdgb@gmail.com','$2b$12$87Tvq2nYKhMP6RNbL4JgLeUoCfgyZPde6CkzShCrf1actSa2sw3qC','$2b$12$87Tvq2nYKhMP6RNbL4JgLeUoCfgyZPde6CkzShCrf1actSa2sw3qC',NULL,'Abdullah','Al-Amin','yes','lApvc8cwT3UGym2y','2021-02-16 15:40:02',NULL,NULL,NULL,'admin'),('RyhUF84dVQnW6xa3','sdadvvfffasd@gmail.com','$2b$12$ubQTLaws9yudKaaFXmQlTOTspn5YlIBWPJZ6lz/PaABrdMQu3Y0TS','$2b$12$ubQTLaws9yudKaaFXmQlTOTspn5YlIBWPJZ6lz/PaABrdMQu3Y0TS',NULL,'MD','Ratul Br','no','7mtY3Cv4j2NN6CeT','2021-02-16 23:14:07',NULL,NULL,NULL,'client'),('S1TZcEuxFEO6BpGH','alamin1707027@outlook.com','$2b$12$NdhQKnb0/IUOKOTGJPcY8uAMzjVjL.fduviAxKoweFz5buCQunM6S','$2b$12$NdhQKnb0/IUOKOTGJPcY8uAMzjVjL.fduviAxKoweFz5buCQunM6S',NULL,'Abdullah','Al-Amin','no','ObpFRVTGxGq8OsK8','2021-05-21 14:25:53',NULL,NULL,NULL,'client');
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

-- Dump completed on 2021-05-23 19:14:04
