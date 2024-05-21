-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Apr 10, 2022 at 08:40 PM
-- Server version: 10.5.4-MariaDB
-- PHP Version: 7.3.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

--
-- Database: `vizsga-konyvklub`
--

-- --------------------------------------------------------

--
-- Table structure for table `members`
--

CREATE TABLE `members` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `gender` enum('M','F') COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `birth_date` date NOT NULL,
  `banned` tinyint(1) NOT NULL DEFAULT 0,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `members`
--

INSERT INTO `members` (`id`, `name`, `gender`, `birth_date`, `banned`, `created_at`, `updated_at`) VALUES
(1, 'Hajdu Mátyás', 'M', '2007-02-12', 0, '2022-01-03 07:17:01', '2022-04-10 18:35:20'),
(2, 'Orsós Kornél PhD', 'M', '2006-05-19', 0, '2022-03-05 12:49:04', '2022-04-10 18:35:20'),
(3, 'id. Novák Szandra PhD', 'F', '1995-10-29', 0, '2022-03-18 08:12:05', '2022-04-10 18:35:20'),
(4, 'Török Géza PhD', 'M', '1997-04-04', 0, '2022-01-06 21:57:16', '2022-04-10 18:35:20'),
(5, 'id. Balla Gréta', 'F', '2006-02-18', 0, '2022-01-15 22:00:08', '2022-04-10 18:35:20'),
(6, 'Dr. Hegedüs Zoltán PhD', 'M', '1984-10-18', 0, '2022-03-24 17:02:29', '2022-04-10 18:35:20'),
(7, 'ifj. Balogh Endrené', NULL, '2007-01-04', 0, '2022-04-01 02:31:09', '2022-04-10 18:35:20'),
(8, 'Prof. Fehér Kevin PhD', NULL, '1992-05-12', 0, '2022-03-17 00:16:55', '2022-04-10 18:35:20'),
(9, 'id. Török Zsóka PhD', 'F', '1978-01-06', 0, '2022-03-09 15:15:21', '2022-04-10 18:35:20'),
(10, 'Szalai Mátyás PhD', 'M', '1988-11-07', 0, '2022-02-13 00:55:22', '2022-04-10 18:35:20');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `members`
--
ALTER TABLE `members`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `members`
--
ALTER TABLE `members`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;
