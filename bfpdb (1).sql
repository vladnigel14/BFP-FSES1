-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Dec 10, 2018 at 07:51 AM
-- Server version: 5.7.19-log
-- PHP Version: 7.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bfpdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `establisments_table`
--

CREATE TABLE `establisments_table` (
  `BIN` varchar(255) DEFAULT NULL,
  `establishment_name` varchar(255) DEFAULT NULL,
  `establishment_address` varchar(255) DEFAULT NULL,
  `establishment_owner` varchar(255) DEFAULT NULL,
  `establishment_status` varchar(255) NOT NULL,
  `nob` varchar(255) NOT NULL COMMENT 'nature of business',
  `occupancy_id` varchar(255) NOT NULL,
  `storey_no` varchar(255) NOT NULL,
  `portion_occupied` varchar(255) NOT NULL,
  `floor_area` varchar(255) NOT NULL,
  `violation_id` varchar(255) NOT NULL COMMENT 'notes of violations',
  `fsiid` varchar(255) NOT NULL COMMENT 'fire safety inspectors',
  `cmid` varchar(255) NOT NULL COMMENT 'construction materials '
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `fire_inspectors_table`
--

CREATE TABLE `fire_inspectors_table` (
  `fsiid` varchar(255) NOT NULL,
  `inspectors` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `fsic_table`
--

CREATE TABLE `fsic_table` (
  `fsic_no` varchar(255) NOT NULL,
  `BIN` varchar(255) NOT NULL,
  `orid` varchar(255) NOT NULL,
  `ioid` varchar(255) NOT NULL,
  `date` varchar(255) NOT NULL,
  `application_status` varchar(255) NOT NULL,
  `amount` varchar(255) NOT NULL,
  `date_inspected` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `io_table`
--

CREATE TABLE `io_table` (
  `ioid` varchar(255) NOT NULL,
  `IO` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `occupancy_table`
--

CREATE TABLE `occupancy_table` (
  `occupancy_id` varchar(255) NOT NULL,
  `occupancy_title` varchar(255) NOT NULL,
  `occupancy_description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `or_table`
--

CREATE TABLE `or_table` (
  `orid` varchar(255) NOT NULL,
  `OR` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `establisments_table`
--
ALTER TABLE `establisments_table`
  ADD UNIQUE KEY `businessid` (`BIN`);

--
-- Indexes for table `fire_inspectors_table`
--
ALTER TABLE `fire_inspectors_table`
  ADD UNIQUE KEY `fsiid` (`fsiid`);

--
-- Indexes for table `fsic_table`
--
ALTER TABLE `fsic_table`
  ADD UNIQUE KEY `fsic_no` (`fsic_no`);

--
-- Indexes for table `io_table`
--
ALTER TABLE `io_table`
  ADD UNIQUE KEY `ioid` (`ioid`);

--
-- Indexes for table `occupancy_table`
--
ALTER TABLE `occupancy_table`
  ADD UNIQUE KEY `occid` (`occupancy_id`);

--
-- Indexes for table `or_table`
--
ALTER TABLE `or_table`
  ADD UNIQUE KEY `or` (`orid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
