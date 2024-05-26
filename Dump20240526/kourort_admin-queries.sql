-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: kourort
-- ------------------------------------------------------
-- Server version	8.0.36

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
-- Table structure for table `admin-queries`
--

DROP TABLE IF EXISTS `admin-queries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `admin-queries` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `process` varchar(100) NOT NULL,
  `query` varchar(500) NOT NULL,
  `user_ID` int NOT NULL,
  `user_post_ID` int NOT NULL,
  `kourort_ID` int DEFAULT NULL,
  `type` int NOT NULL,
  PRIMARY KEY (`ID`,`user_ID`,`user_post_ID`),
  KEY `fk_amdin-queries_user1_idx` (`user_ID`,`user_post_ID`),
  KEY `fk_amdin-queries_kourort1_idx` (`kourort_ID`),
  CONSTRAINT `fk_amdin-queries_kourort1` FOREIGN KEY (`kourort_ID`) REFERENCES `kourort` (`ID`),
  CONSTRAINT `fk_amdin-queries_user1` FOREIGN KEY (`user_ID`, `user_post_ID`) REFERENCES `user` (`ID`, `post_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin-queries`
--

LOCK TABLES `admin-queries` WRITE;
/*!40000 ALTER TABLE `admin-queries` DISABLE KEYS */;
INSERT INTO `admin-queries` VALUES (1,'Принято','Прошу зачислить меня, как представителя организации.',2,2,2,1),(2,'Принято','Прошу зарегестрировать организацию  и зачислить меня, как ее представителя.',2,2,NULL,2),(3,'Отклонено','Прошу зачислить меня, как представителя организацииЛьвовский.',2,2,2,1),(4,'Принято','Прошу зачислить меня, как представителя организации \"Львовский\".',2,2,2,1),(5,'Отклонено','Прошу зачислить меня, как представителя организации \"Ивановский\".',2,2,1,1),(6,'Принято','Прошу зарегестрировать организацию wadfawf и зачислить меня, как ее представителя.',6,2,NULL,2),(7,'Не рассмотрено','Прошу зарегестрировать организацию werf и зачислить меня, как ее представителя.',6,2,NULL,2),(8,'Не рассмотрено','Прошу зачислить меня, как представителя организации \"Ивановский\".',6,2,1,1);
/*!40000 ALTER TABLE `admin-queries` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-26  3:16:42
