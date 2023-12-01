-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 05, 2023 at 09:22 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ashop`
--

-- --------------------------------------------------------

--
-- Table structure for table `bugun`
--

CREATE TABLE `bugun` (
  `no` int(11) NOT NULL,
  `ady` varchar(25) NOT NULL,
  `baha` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `bugun`
--

INSERT INTO `bugun` (`no`, `ady`, `baha`) VALUES
(5, 'bugun', '2.9.2023');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `no` int(11) NOT NULL,
  `productID` int(11) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `alnanBahasy` decimal(18,2) DEFAULT NULL,
  `satuwBahasy` decimal(18,2) DEFAULT NULL,
  `mukdar` decimal(18,2) DEFAULT NULL,
  `jemi` decimal(18,2) DEFAULT NULL,
  `obshyJemi` decimal(18,2) DEFAULT NULL,
  `chykdayjy` decimal(18,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`no`, `productID`, `name`, `alnanBahasy`, `satuwBahasy`, `mukdar`, `jemi`, `obshyJemi`, `chykdayjy`) VALUES
(1, 1, 'Kepek', '2.40', '2.70', '0.00', NULL, NULL, NULL),
(2, 2, 'Bugdaý_galyndy_2', '2.60', '3.00', '0.00', NULL, NULL, NULL),
(3, 3, 'Arpa', '3.00', '3.60', '0.00', NULL, NULL, NULL),
(4, 4, 'Bugdaý_galyndy_1', '3.00', '3.40', '0.00', NULL, NULL, NULL),
(5, 5, 'Şulha', '2.80', '3.20', '0.00', NULL, NULL, NULL),
(6, 6, 'Mary_şrop', '4.40', '5.00', '0.00', NULL, NULL, NULL),
(7, 7, 'Bugdaý', '3.60', '4.20', '0.00', NULL, NULL, NULL),
(8, 8, 'Çärjew_şrop', '4.00', '4.40', '0.00', NULL, NULL, NULL),
(9, 9, 'Sement', '28.60', '30.00', '0.00', NULL, NULL, NULL),
(10, 10, 'Hek', '6.00', '7.00', '0.00', NULL, NULL, NULL),
(11, 11, 'Çagyl', '0.60', '0.70', '0.00', NULL, NULL, NULL),
(12, 12, 'Myty', '0.70', '1.00', '0.00', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `satylan`
--

CREATE TABLE `satylan` (
  `no` int(10) NOT NULL,
  `productID` int(10) DEFAULT NULL,
  `name` varchar(225) DEFAULT NULL,
  `mukdar` float(18,2) DEFAULT NULL,
  `alnanBahasy` float(18,2) DEFAULT NULL,
  `satuwBahasy` float(18,2) DEFAULT NULL,
  `girdeyji` double(18,2) DEFAULT NULL,
  `arassaGirdeyji` float(18,2) DEFAULT NULL,
  `sene` varchar(10) NOT NULL,
  `yagdayy` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `satylan`
--

INSERT INTO `satylan` (`no`, `productID`, `name`, `mukdar`, `alnanBahasy`, `satuwBahasy`, `girdeyji`, `arassaGirdeyji`, `sene`, `yagdayy`) VALUES
(16, 8, 'Çärjew_şrop', 100.00, 4.00, 4.40, 440.00, 40.00, '2.9.2023', 'satdym');

-- --------------------------------------------------------

--
-- Table structure for table `ulanyjylar`
--

CREATE TABLE `ulanyjylar` (
  `no` int(15) NOT NULL,
  `at` varchar(255) NOT NULL,
  `wezipe` varchar(255) NOT NULL,
  `status` varchar(250) NOT NULL,
  `u_ad` varchar(255) NOT NULL,
  `parol` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ulanyjylar`
--

INSERT INTO `ulanyjylar` (`no`, `at`, `wezipe`, `status`, `u_ad`, `parol`) VALUES
(0, 'afss', 'fsdfsdf', 'sdfsdfsd', 'fsdf', 'züçz'),
(1, 'N.Azadow', 'Programmer', 'admin', 'user', 'user');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bugun`
--
ALTER TABLE `bugun`
  ADD PRIMARY KEY (`no`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`no`);

--
-- Indexes for table `satylan`
--
ALTER TABLE `satylan`
  ADD PRIMARY KEY (`no`);

--
-- Indexes for table `ulanyjylar`
--
ALTER TABLE `ulanyjylar`
  ADD PRIMARY KEY (`no`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bugun`
--
ALTER TABLE `bugun`
  MODIFY `no` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `no` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `satylan`
--
ALTER TABLE `satylan`
  MODIFY `no` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
