-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Ápr 19. 10:00
-- Kiszolgáló verziója: 10.4.22-MariaDB
-- PHP verzió: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `vizsga-2022`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `cars`
--

CREATE TABLE `cars` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `license_plate_number` varchar(20) DEFAULT NULL,
  `brand` varchar(255) DEFAULT NULL,
  `model` varchar(255) DEFAULT NULL,
  `daily_cost` int(11) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- A tábla adatainak kiíratása `cars`
--

INSERT INTO `cars` (`id`, `license_plate_number`, `brand`, `model`, `daily_cost`, `created_at`, `updated_at`) VALUES
(1, 'IOA-699', 'Ford', 'Chile', 24000, '2022-04-19 04:09:18', '2022-04-19 04:09:18'),
(2, 'ABY-945', 'Ford', 'CX727', 24000, '2022-04-19 04:09:18', '2022-04-19 04:09:18'),
(3, 'NTJ-242', 'Ford', 'Evos', 20000, '2022-04-19 04:09:18', '2022-04-19 04:09:18'),
(4, 'OKG-375', 'Ford', 'Fiesta', 22000, '2022-04-19 04:09:18', '2022-04-19 04:09:18'),
(5, 'UCS-211', 'Ford', 'Focus', 27000, '2022-04-19 04:09:18', '2022-04-19 04:09:18'),
(6, 'NEK-649', 'Ford', 'Galaxy', 20000, '2022-04-19 04:09:18', '2022-04-19 04:09:18'),
(7, 'LXK-572', 'Ford', 'Kuga', 21000, '2022-04-19 04:09:18', '2022-04-19 04:09:18'),
(8, 'HOL-474', 'Ford', 'Mondeo', 18000, '2022-04-19 04:09:18', '2022-04-19 04:09:18'),
(9, 'TTJ-745', 'Ford', 'Explorer', 22000, '2022-04-19 04:09:18', '2022-04-19 04:09:18'),
(10, 'AUO-561', 'Peugeot', '208gt', 19000, '2022-04-19 04:09:18', '2022-04-19 04:09:18'),
(11, 'VRK-253', 'Renault', 'Clio', 21000, '2022-04-19 04:09:18', '2022-04-19 04:09:18');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `cars`
--
ALTER TABLE `cars`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `cars`
--
ALTER TABLE `cars`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
