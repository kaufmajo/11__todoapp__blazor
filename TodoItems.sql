-- phpMyAdmin SQL Dump
-- version 5.2.2
-- https://www.phpmyadmin.net/
--
-- Host: mariadb:3306
-- Erstellungszeit: 05. Mai 2025 um 08:31
-- Server-Version: 11.7.2-MariaDB-ubu2404
-- PHP-Version: 8.2.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `app10`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `TodoItems`
--

CREATE TABLE `TodoItems` (
  `Id` int(11) NOT NULL,
  `Title` varchar(255) NOT NULL,
  `IsCompleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `TodoItems`
--

INSERT INTO `TodoItems` (`Id`, `Title`, `IsCompleted`) VALUES
(76, 'dddd', NULL),
(77, 'sss', NULL),
(78, 'Test', NULL),
(79, 'test', NULL),
(80, 'test', NULL);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `TodoItems`
--
ALTER TABLE `TodoItems`
  ADD PRIMARY KEY (`Id`) USING BTREE;

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `TodoItems`
--
ALTER TABLE `TodoItems`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=81;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
