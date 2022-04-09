CREATE DATABASE  IF NOT EXISTS `companiarea` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `companiarea`;
-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: mtis
-- ------------------------------------------------------
-- Server version	8.0.21

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
-- Table structure for table `hotel`
--

DROP TABLE IF EXISTS `hotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hotel` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `precioNoche` double DEFAULT NULL,
  `numeroPersonas` int DEFAULT NULL,
  `puntuacion` int DEFAULT NULL,
  `disponibilidad` boolean DEFAULT NULL,
  `lugar` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hotel`
--

LOCK TABLES `hotel` WRITE;
/*!40000 ALTER TABLE `hotel` DISABLE KEYS */;
/*!40000 ALTER TABLE `hotel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `coche`
--

DROP TABLE IF EXISTS `coche`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `coche` (
  `id` int NOT NULL AUTO_INCREMENT,
  `marca` varchar(255) DEFAULT NULL,
  `modelo` varchar(255) DEFAULT NULL,
  `num_puertas` int DEFAULT NULL,
  `puntuacion` int DEFAULT NULL,
  `precio_Dia` double DEFAULT NULL,
  `numPlazas` int DEFAULT NULL,
  `disponible` boolean DEFAULT NULL,
  `lugar` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `coche`
--

LOCK TABLES `coche` WRITE;
/*!40000 ALTER TABLE `coche` DISABLE KEYS */;
/*!40000 ALTER TABLE `coche` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `billete`
--

DROP TABLE IF EXISTS `billete`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `billete` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `precio` double DEFAULT NULL,
  `numeroPersonas` int DEFAULT NULL,
  `puntuacion` int DEFAULT NULL,
  `disponibilidad` boolean DEFAULT NULL,
  `lugar` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `billete`
--

LOCK TABLES `billete` WRITE;
/*!40000 ALTER TABLE `billete` DISABLE KEYS */;
/*!40000 ALTER TABLE `billete` ENABLE KEYS */;
UNLOCK TABLES;


--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `dni` varchar(255),
  `name` varchar(255) DEFAULT NULL,
  `lastname` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`dni`),
  UNIQUE KEY dni (dni)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;



--
-- Table structure for table `reservaHotel`
--

DROP TABLE IF EXISTS `reservaHotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reservaHotel` (
  `idReserva` int NOT NULL AUTO_INCREMENT,
  `codigoHotel` int DEFAULT NULL,
  `dniCliente` varchar(255) DEFAULT NULL,
  `precioTotal` double DEFAULT NULL,
  `fechaInicio` int DEFAULT NULL,
  `fechaFin` int DEFAULT NULL,
  PRIMARY KEY (`idReserva`),
  foreign key (codigoHotel) references hotel(id),
  foreign key (dniCliente) references cliente(dni)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservaHotel`
--

LOCK TABLES `reservaHotel` WRITE;
/*!40000 ALTER TABLE `reservaHotel` DISABLE KEYS */;
/*!40000 ALTER TABLE `reservaHotel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resrevaCoche`
--

DROP TABLE IF EXISTS `resrevaCoche`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `resrevaCoche` (
  `idReserva` int NOT NULL AUTO_INCREMENT,
  `codigoCoche` int DEFAULT NULL,
  `dniCliente` varchar(255) DEFAULT NULL,
  `precioTotal` double DEFAULT NULL,
  `fechaInicio` int DEFAULT NULL,
  `fechaFin` int DEFAULT NULL,
  PRIMARY KEY (`idReserva`),
  foreign key (codigoCoche) references coche(id),
  foreign key (dniCliente) references cliente(dni)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservaCoche`
--

LOCK TABLES `resrevaCoche` WRITE;
/*!40000 ALTER TABLE `resrevaCoche` DISABLE KEYS */;
/*!40000 ALTER TABLE `resrevaCoche` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservaBillete`
--

DROP TABLE IF EXISTS `reservaBillete`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reservaBillete` (
  `idReserva` int NOT NULL AUTO_INCREMENT,
  `codigoBillete` int DEFAULT NULL,
  `dniCliente` varchar(255) DEFAULT NULL,
  `precioTotal` double DEFAULT NULL,
  `fechaInicio` int DEFAULT NULL,
  `fechaFin` int DEFAULT NULL,
  PRIMARY KEY (`idReserva`),
  foreign key (codigoBillete) references billete(id),
  foreign key (dniCliente) references cliente(dni)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservaBillete`
--

LOCK TABLES `reservaBillete` WRITE;
/*!40000 ALTER TABLE `reservaBillete` DISABLE KEYS */;
/*!40000 ALTER TABLE `reservaBillete` ENABLE KEYS */;
UNLOCK TABLES;