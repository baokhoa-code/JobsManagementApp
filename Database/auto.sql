-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 17, 2022 at 01:37 PM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `job`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `ID` int(11) NOT NULL,
  `NAME` varchar(100) NOT NULL,
  `GENDER` varchar(30) NOT NULL,
  `D_O_B` varchar(100) NOT NULL,
  `PHONE` varchar(10) NOT NULL,
  `ADDRESS` varchar(200) NOT NULL,
  `NATIONALITY` varchar(50) NOT NULL,
  `ORGANIZATION` varchar(100) NOT NULL,
  `POSITION` varchar(100) NOT NULL,
  `AVATAR` longblob DEFAULT NULL,
  `EMAIL` varchar(50) NOT NULL,
  `USERNAME` varchar(50) NOT NULL,
  `PASS` varchar(50) NOT NULL,
  `QUESTION` varchar(200) NOT NULL,
  `ANSWER` varchar(200) NOT NULL,
  `TOTAL_WORKING_HOUR` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`ID`, `NAME`, `GENDER`, `D_O_B`, `PHONE`, `ADDRESS`, `NATIONALITY`, `ORGANIZATION`, `POSITION`, `AVATAR`, `EMAIL`, `USERNAME`, `PASS`, `QUESTION`, `ANSWER`, `TOTAL_WORKING_HOUR`) VALUES
(1, 'HUYNH HUU BAO KHOA', 'NAM', '14-11-2001', '0372753988', '2, TAN AN, THI TRAN CAI TAC, HAU GIANG', 'VIET NAM', 'DAI HOC CAN THO', 'HIEU TRUONG', 0x433a2f78616d70702f6874646f63732f62616e6b2f696d616765732f6176617461722f312e6a7067, 'ADMIN@GMAIL.COM', 'ADMIN', 'ADMIN', 'WHAT YOUR NAME?', 'KHOA', 0);

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `NAME` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`NAME`) VALUES
('CA NHAN'),
('DAY HOC'),
('DU AN'),
('LAO DONG'),
('XA HOI');

-- --------------------------------------------------------

--
-- Table structure for table `job`
--

CREATE TABLE `job` (
  `ID` int(11) NOT NULL,
  `DEPENDENCY_ID` int(11) NOT NULL,
  `DEPENDENCY_NAME` varchar(100) NOT NULL,
  `NAME` varchar(100) NOT NULL,
  `DESCRIPTION` varchar(400) NOT NULL,
  `CATEGORY` varchar(100) NOT NULL,
  `START_DATE` varchar(1000) NOT NULL,
  `DUE_DATE` varchar(100) NOT NULL,
  `END_DATE` varchar(100) NOT NULL,
  `REQUIRED_HOUR` int(11) NOT NULL,
  `WORKED_HOUR` int(11) NOT NULL,
  `PERCENT` int(11) NOT NULL,
  `STAGE` varchar(30) NOT NULL,
  `ASSIGNOR_ID` int(11) NOT NULL,
  `ASSIGNOR_TYPE` varchar(100) NOT NULL,
  `ASSIGNOR_NAME` varchar(100) NOT NULL,
  `ASSIGNEE_ID` int(11) NOT NULL,
  `ASSIGNEE_TYPE` varchar(100) NOT NULL,
  `ASSIGNEE_NAME` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `job`
--

INSERT INTO `job` (`ID`, `DEPENDENCY_ID`, `DEPENDENCY_NAME`, `NAME`, `DESCRIPTION`, `CATEGORY`, `START_DATE`, `DUE_DATE`, `END_DATE`, `REQUIRED_HOUR`, `WORKED_HOUR`, `PERCENT`, `STAGE`, `ASSIGNOR_ID`, `ASSIGNOR_TYPE`, `ASSIGNOR_NAME`, `ASSIGNEE_ID`, `ASSIGNEE_TYPE`, `ASSIGNEE_NAME`) VALUES
(1, -1, 'NONE', 'CT209H', 'DAY HOC O PHONG 110 CHO LOP CT209H', 'DAY HOC', '04-11-2022', '04-03-2023', 'NONE', 70, 34, 49, 'PENDING', 1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'USER', 'HUYNH HUU BAO KHOA'),
(2, -1, 'NONE', 'LAB05 CT105H', 'HOANG THANH LAB05 MON CT105H', 'DAY HOC', '02-11-2022', '04-11-2022', '03-11-2022', 2, 1, 100, 'COMPLETE SOON', 1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'USER', 'HUYNH HUU BAO KHOA'),
(3, -1, 'NONE', 'NLCN', 'CODE PROJECT QUAN LY CONG VIEC NLCN', 'CA NHAN', '10-07-2022', '15-12-2022', 'NONE', 300, 200, 80, 'PENDING', 1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'USER', 'HUYNH HUU BAO KHOA'),
(4, 3, 'NLCN', 'BACKEND NLCN', 'THIET KET CSDL VA SERVER', 'CA NHAN', '12-07-2022', '15-07-2022', '13-07-2022', 8, 6, 100, 'COMPLETE SOON', 1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'USER', 'HUYNH HUU BAO KHOA'),
(5, -1, 'NONE', 'LAO DONG SAN TRUONG', 'DON VE SINH SAN TRUONG KHOA CNTT', 'XA HOI', '04-11-2022', '04-11-2022', '05-11-2022', 2, 2, 100, 'COMPLETE LATE', 1, 'USER', 'HUYNH HUU BAO KHOA', 1, 'USER', 'HUYNH HUU BAO KHOA'),
(6, -1, 'NONE', 'LAO DONG KHOA KINH TE', 'DON VE SINH SANH KHOA KINH TE', 'XA HOI', '14-11-2022', '14-11-2022', 'NONE', 2, 0, 0, 'LATE', 1, 'USER', 'HUYNH HUU BAO KHOA', 1, 'USER', 'HUYNH HUU BAO KHOA'),
(7, -1, 'NONE', 'HO TRO NGUOI NGHEO', 'THAM GIA HO TRO NGUOI NGHEO HAU GIANG, CHAU THANH', 'XA HOI', '20-01-2023', '25-01-2023', 'NONE', 20, 0, 0, 'WAITING', 1, 'USER', 'HUYNH HUU BAO KHOA', 1, 'USER', 'HUYNH HUU BAO KHOA');

-- --------------------------------------------------------

--
-- Table structure for table `organization`
--

CREATE TABLE `organization` (
  `NAME` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `organization`
--

INSERT INTO `organization` (`NAME`) VALUES
('DAI HOC CAN THO'),
('KHOA CONG NGHE'),
('KHOA CONG NGHE THONG TIN VA TRUYEN THONG'),
('KHOA KINH TE'),
('KHOA XA HOI');

-- --------------------------------------------------------

--
-- Table structure for table `organization_position`
--

CREATE TABLE `organization_position` (
  `ORGANIZATION_NAME` varchar(100) NOT NULL,
  `NAME` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `organization_position`
--

INSERT INTO `organization_position` (`ORGANIZATION_NAME`, `NAME`) VALUES
('DAI HOC CAN THO', 'HIEU PHO'),
('DAI HOC CAN THO', 'HIEU TRUONG'),
('KHOA CONG NGHE', 'PHO KHOA'),
('KHOA CONG NGHE', 'TRUONG KHOA'),
('KHOA CONG NGHE THONG TIN VA TRUYEN THONG', 'PHO KHOA'),
('KHOA CONG NGHE THONG TIN VA TRUYEN THONG', 'TRUONG KHOA'),
('KHOA KINH TE', 'PHO KHOA'),
('KHOA KINH TE', 'TRUONG KHOA'),
('KHOA XA HOI', 'PHO KHOA'),
('KHOA XA HOI', 'TRUONG KHOA');

-- --------------------------------------------------------

--
-- Table structure for table `question`
--

CREATE TABLE `question` (
  `NAME` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `question`
--

INSERT INTO `question` (`NAME`) VALUES
('WHAT IS THE NAME OF THE TOWN WHERE YOU WERE BORN?'),
('WHAT IS THE NAME OF YOUR FIRST PET?'),
('WHAT WAS YOUR CHILDHOOD NICKNAME?'),
('WHAT WAS YOUR FIRST MOTOBILE?'),
('WHAT YOUR NAME?\"');

-- --------------------------------------------------------

--
-- Table structure for table `report`
--

CREATE TABLE `report` (
  `ID` int(11) NOT NULL,
  `JOB_ID` int(11) DEFAULT NULL,
  `TILE` varchar(100) NOT NULL,
  `DESCRIPTION` varchar(400) NOT NULL,
  `AMOUNT_OF_TIME` int(11) NOT NULL,
  `CREATED_TIME` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `ID` int(11) NOT NULL,
  `NAME` varchar(100) NOT NULL,
  `GENDER` varchar(30) NOT NULL,
  `D_O_B` varchar(100) NOT NULL,
  `PHONE` varchar(10) NOT NULL,
  `ADDRESS` varchar(200) NOT NULL,
  `NATIONALITY` varchar(50) NOT NULL,
  `ORGANIZATION` varchar(50) NOT NULL,
  `POSITION` varchar(50) NOT NULL,
  `AVATAR` longblob NOT NULL,
  `EMAIL` varchar(50) NOT NULL,
  `USERNAME` varchar(50) NOT NULL,
  `PASS` varchar(50) NOT NULL,
  `QUESTION` varchar(200) NOT NULL,
  `ANSWER` varchar(200) NOT NULL,
  `TOTAL_WORKING_HOUR` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`ID`, `NAME`, `GENDER`, `D_O_B`, `PHONE`, `ADDRESS`, `NATIONALITY`, `ORGANIZATION`, `POSITION`, `AVATAR`, `EMAIL`, `USERNAME`, `PASS`, `QUESTION`, `ANSWER`, `TOTAL_WORKING_HOUR`) VALUES
(1, 'HUYNH HUU BAO KHOA', 'NAM', '14-11-2001', '0372753988', '2, TAN AN, THI TRAN CAI TAC, HAU GIANG', 'VIET NAM', 'DAI HOC CAN THO', 'HIEU TRUONG', 0x433a2f78616d70702f6874646f63732f62616e6b2f696d616765732f6176617461722f312e6a7067, 'USER1@GMAIL.COM', 'USER1', 'USER1', 'WHAT YOUR NAME?', 'KHOA', 243),
(2, 'HUYNH HUU BAO KHOA', 'NAM', '14-11-2001', '0372753988', '2, TAN AN, THI TRAN CAI TAC, HAU GIANG', 'VIET NAM', 'DAI HOC CAN THO', 'HIEU PHO', 0x433a2f78616d70702f6874646f63732f62616e6b2f696d616765732f6176617461722f312e6a7067, 'USER2@GMAIL.COM', 'USER2', 'USER2', 'WHAT YOUR NAME?', 'KHOA', 0),
(3, 'HUYNH HUU BAO KHOA', 'NAM', '14-11-2001', '0372753988', '2, TAN AN, THI TRAN CAI TAC, HAU GIANG', 'VIET NAM', 'KHOA CONG NGHE THONG TIN VA TRUYEN THONG', 'TRUONG KHOA', 0x433a2f78616d70702f6874646f63732f62616e6b2f696d616765732f6176617461722f312e6a7067, 'USER3@GMAIL.COM', 'USER3', 'USER3', 'WHAT YOUR NAME?', 'KHOA', 0),
(4, 'HUYNH HUU BAO KHOA', 'NAM', '14-11-2001', '0372753988', '2, TAN AN, THI TRAN CAI TAC, HAU GIANG', 'VIET NAM', 'KHOA CONG NGHE THONG TIN VA TRUYEN THONG', 'PHO KHOA', 0x433a2f78616d70702f6874646f63732f62616e6b2f696d616765732f6176617461722f312e6a7067, 'USER4@GMAIL.COM', 'USER4', 'USER4', 'WHAT YOUR NAME?', 'KHOA', 0);

--
-- Triggers `user`
--
DELIMITER $$
CREATE TRIGGER `AUTO_DEL_JOB_WHEN_DEL_USER` AFTER DELETE ON `user` FOR EACH ROW BEGIN  
DELETE FROM JOB WHERE (ASSIGNOR_TYPE = 'USER' AND ASSIGNOR_ID = OLD.ID) OR (ASSIGNEE_TYPE = 'USER' AND ASSIGNEE_ID = OLD.ID);

END
$$
DELIMITER ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `EMAIL` (`EMAIL`),
  ADD UNIQUE KEY `USERNAME` (`USERNAME`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`NAME`);

--
-- Indexes for table `job`
--
ALTER TABLE `job`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `organization`
--
ALTER TABLE `organization`
  ADD PRIMARY KEY (`NAME`);

--
-- Indexes for table `organization_position`
--
ALTER TABLE `organization_position`
  ADD PRIMARY KEY (`ORGANIZATION_NAME`,`NAME`);

--
-- Indexes for table `question`
--
ALTER TABLE `question`
  ADD PRIMARY KEY (`NAME`);

--
-- Indexes for table `report`
--
ALTER TABLE `report`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `fk_REPORT` (`JOB_ID`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `EMAIL` (`EMAIL`),
  ADD UNIQUE KEY `USERNAME` (`USERNAME`),
  ADD KEY `fk_USER2` (`ORGANIZATION`,`POSITION`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `job`
--
ALTER TABLE `job`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `report`
--
ALTER TABLE `report`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `organization_position`
--
ALTER TABLE `organization_position`
  ADD CONSTRAINT `fk_ORGANIZATION_POSITION` FOREIGN KEY (`ORGANIZATION_NAME`) REFERENCES `organization` (`NAME`) ON DELETE CASCADE;

--
-- Constraints for table `report`
--
ALTER TABLE `report`
  ADD CONSTRAINT `fk_REPORT` FOREIGN KEY (`JOB_ID`) REFERENCES `job` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `fk_USER1` FOREIGN KEY (`ORGANIZATION`) REFERENCES `organization` (`NAME`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_USER2` FOREIGN KEY (`ORGANIZATION`,`POSITION`) REFERENCES `organization_position` (`ORGANIZATION_NAME`, `NAME`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
