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
-- Table structure for table `kourort-queries`
--

DROP TABLE IF EXISTS `kourort-queries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kourort-queries` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `process` varchar(45) NOT NULL,
  `query` varchar(400) NOT NULL,
  `kourort_ID` int NOT NULL,
  `children_ID` int NOT NULL,
  PRIMARY KEY (`ID`,`kourort_ID`,`children_ID`),
  KEY `fk_kourort-queries_kourort1_idx` (`kourort_ID`),
  KEY `fk_kourort-queries_children1_idx` (`children_ID`),
  CONSTRAINT `fk_kourort-queries_children1` FOREIGN KEY (`children_ID`) REFERENCES `children` (`ID`),
  CONSTRAINT `fk_kourort-queries_kourort1` FOREIGN KEY (`kourort_ID`) REFERENCES `kourort` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kourort-queries`
--

LOCK TABLES `kourort-queries` WRITE;
/*!40000 ALTER TABLE `kourort-queries` DISABLE KEYS */;
INSERT INTO `kourort-queries` VALUES (1,'Отказано','фыв',1,1),(2,'На рассмотрении','Прошу зачислить моего сына,5  5 5, возраста 5 лет',1,8),(2,'Отказано','выа',2,2),(2,'На рассмотрении','Прошу зачислить моего сына,1123123  123123 123123, возраста 123123 лет',2,9),(2,'На рассмотрении','Прошу зачислить моего сына,4  4 4, возраста 4 лет',2,10);
/*!40000 ALTER TABLE `kourort-queries` ENABLE KEYS */;
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
