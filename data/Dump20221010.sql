-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: whitelist
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `wl_customers`
--

DROP TABLE IF EXISTS `wl_customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `wl_customers` (
  `ID` int NOT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `DiscordID` double DEFAULT NULL,
  `RobloxID` double DEFAULT NULL,
  `Key` varchar(128) DEFAULT NULL,
  `AccountStrikes` int DEFAULT '0',
  `AccountBanned` tinyint DEFAULT '0',
  `ActivatedGames` varchar(256) DEFAULT NULL,
  `CurrentWhitelistCount` int DEFAULT '0',
  `MaxWhitelistsAllowed` int DEFAULT '0',
  `ProductTier` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wl_customers`
--

LOCK TABLES `wl_customers` WRITE;
/*!40000 ALTER TABLE `wl_customers` DISABLE KEYS */;
INSERT INTO `wl_customers` VALUES (1,'bsugiyama',9.710714658584289e17,3358452160,'15C5578C-B32F-42D2-B658-784F85603C38',0,0,NULL,0,0,NULL);
/*!40000 ALTER TABLE `wl_customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wl_staff`
--

DROP TABLE IF EXISTS `wl_staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `wl_staff` (
  `ID` int NOT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `DiscordID` double DEFAULT NULL,
  `RobloxID` double DEFAULT NULL,
  `PasswordHash` varchar(128) DEFAULT NULL,
  `CurrentAccessToken` varchar(512) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wl_staff`
--

LOCK TABLES `wl_staff` WRITE;
/*!40000 ALTER TABLE `wl_staff` DISABLE KEYS */;
INSERT INTO `wl_staff` VALUES (1,'bsugiyama',9.710714658584289e17,NULL,NULL,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6ImJzdWdpeWFtYSIsImlkIjoiMSIsInBhc3N3b3JkSGFzaCI6IiJ9.tCybxlRRpMgdoFCiArzwXDxMr14nQBngYouwEFuchyw');
/*!40000 ALTER TABLE `wl_staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wl_users`
--

DROP TABLE IF EXISTS `wl_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `wl_users` (
  `ID` int NOT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `UserID` double DEFAULT NULL,
  `Customer` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wl_users`
--

LOCK TABLES `wl_users` WRITE;
/*!40000 ALTER TABLE `wl_users` DISABLE KEYS */;
INSERT INTO `wl_users` VALUES (1,'foobar2035',3358452160,'15C5578C-B32F-42D2-B658-784F85603C38');
/*!40000 ALTER TABLE `wl_users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-10-10 20:59:14
