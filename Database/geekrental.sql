-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 14, 2020 at 08:01 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `geekrental`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id_admin` int(11) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `nama` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id_admin`, `username`, `password`, `nama`) VALUES
(1, 'admin', 'admin', 'Demo Admin');

-- --------------------------------------------------------

--
-- Table structure for table `mobil`
--

CREATE TABLE `mobil` (
  `id_mobil` int(11) NOT NULL,
  `tipe_mobil` varchar(100) NOT NULL,
  `merek` varchar(300) NOT NULL,
  `no_plat` varchar(300) NOT NULL,
  `thn_pembuatan` year(4) NOT NULL,
  `status_mobil` varchar(100) NOT NULL,
  `harga` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `mobil`
--

INSERT INTO `mobil` (`id_mobil`, `tipe_mobil`, `merek`, `no_plat`, `thn_pembuatan`, `status_mobil`, `harga`) VALUES
(25, 'Minivan', 'Test', 'b 1234 cvd', 2025, 'Ready', 350000),
(26, 'Sedan', 'ser', 'B 1234 ABS', 2000, 'Ready', 600000),
(34, 'Convertible', 'waw', 'awa', 2010, 'Ready', 150000),
(37, 'Convertible', 'Apa', 'B 1 CD', 2020, 'Ready', 250000),
(38, 'Convertible', '', 'B 1 CD', 0000, 'Ready', 200000),
(39, 'Convertible', '', 'B 1 CD', 2000, 'Ready', 500000),
(40, 'Hatcback', 'Becak Super', 'B CAK 69', 2020, 'Ready', 100000);

-- --------------------------------------------------------

--
-- Table structure for table `pelanggan`
--

CREATE TABLE `pelanggan` (
  `id_pelanggan` int(11) NOT NULL,
  `nm_pelanggan` varchar(250) NOT NULL,
  `alamat` varchar(150) NOT NULL,
  `no_ktp` varchar(100) NOT NULL,
  `no_hp` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pelanggan`
--

INSERT INTO `pelanggan` (`id_pelanggan`, `nm_pelanggan`, `alamat`, `no_ktp`, `no_hp`) VALUES
(1, 'Muhammad Surya', 'Jl. Kalimalang', '12345', '087880209043'),
(3, 'Aldi Mulia Wijaya', 'Jl. Sunter', '15486', '087880209045'),
(7, 'Ahmad Muzaki', 'Jl.Kalibata', '987654', '258369');

-- --------------------------------------------------------

--
-- Table structure for table `statusmobil`
--

CREATE TABLE `statusmobil` (
  `id_status` int(11) NOT NULL,
  `nm_status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `statusmobil`
--

INSERT INTO `statusmobil` (`id_status`, `nm_status`) VALUES
(2, 'Dipinjamkan'),
(1, 'Ready');

-- --------------------------------------------------------

--
-- Table structure for table `tipemobil`
--

CREATE TABLE `tipemobil` (
  `id_tipe` int(11) NOT NULL,
  `tipe` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tipemobil`
--

INSERT INTO `tipemobil` (`id_tipe`, `tipe`) VALUES
(1, 'Convertible'),
(2, 'Coupe'),
(3, 'Hatcback'),
(4, 'Minivan'),
(5, 'Sedan'),
(6, 'Sports'),
(8, 'Station Wagon'),
(7, 'SUV');

-- --------------------------------------------------------

--
-- Table structure for table `transaksi`
--

CREATE TABLE `transaksi` (
  `id_transaksi` int(11) NOT NULL,
  `id_pelanggan` int(11) NOT NULL,
  `id_mobil` int(11) NOT NULL,
  `tgl_sewa` date NOT NULL,
  `tgl_kembali` date NOT NULL,
  `total_sewa` int(11) NOT NULL,
  `status_transaksi` varchar(150) NOT NULL DEFAULT 'Sewa'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `transaksi`
--

INSERT INTO `transaksi` (`id_transaksi`, `id_pelanggan`, `id_mobil`, `tgl_sewa`, `tgl_kembali`, `total_sewa`, `status_transaksi`) VALUES
(25, 1, 38, '2020-06-14', '2020-06-19', 1000000, 'Kembali'),
(34, 3, 26, '2020-06-14', '2020-06-17', 1800000, 'Kembali'),
(35, 7, 39, '2020-06-14', '2020-06-18', 2000000, 'Kembali');

--
-- Triggers `transaksi`
--
DELIMITER $$
CREATE TRIGGER `KeluarGantiStatus` AFTER INSERT ON `transaksi` FOR EACH ROW UPDATE mobil SET status_mobil='Dipinjamkan' WHERE id_mobil = new.id_mobil
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `MasukGantiStatus` AFTER UPDATE ON `transaksi` FOR EACH ROW IF OLD.status_transaksi = NEW.status_transaksi = 'Kembali' THEN
    UPDATE mobil SET status_mobil = 'Ready' 	WHERE id_mobil = new.id_mobil;
END IF
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `SewaDelete` AFTER DELETE ON `transaksi` FOR EACH ROW UPDATE mobil SET status_mobil='Ready' WHERE id_mobil = old.id_mobil
$$
DELIMITER ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id_admin`);

--
-- Indexes for table `mobil`
--
ALTER TABLE `mobil`
  ADD PRIMARY KEY (`id_mobil`),
  ADD KEY `StatusMobil` (`status_mobil`),
  ADD KEY `TipeMobil` (`tipe_mobil`),
  ADD KEY `merek` (`merek`);

--
-- Indexes for table `pelanggan`
--
ALTER TABLE `pelanggan`
  ADD PRIMARY KEY (`id_pelanggan`),
  ADD UNIQUE KEY `no_ktp` (`no_ktp`);

--
-- Indexes for table `statusmobil`
--
ALTER TABLE `statusmobil`
  ADD PRIMARY KEY (`nm_status`);

--
-- Indexes for table `tipemobil`
--
ALTER TABLE `tipemobil`
  ADD PRIMARY KEY (`id_tipe`),
  ADD UNIQUE KEY `tipe` (`tipe`);

--
-- Indexes for table `transaksi`
--
ALTER TABLE `transaksi`
  ADD PRIMARY KEY (`id_transaksi`),
  ADD KEY `Pelanggan` (`id_pelanggan`),
  ADD KEY `DataMobil` (`id_mobil`),
  ADD KEY `status` (`status_transaksi`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id_admin` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `mobil`
--
ALTER TABLE `mobil`
  MODIFY `id_mobil` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `pelanggan`
--
ALTER TABLE `pelanggan`
  MODIFY `id_pelanggan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `tipemobil`
--
ALTER TABLE `tipemobil`
  MODIFY `id_tipe` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `transaksi`
--
ALTER TABLE `transaksi`
  MODIFY `id_transaksi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=49;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `mobil`
--
ALTER TABLE `mobil`
  ADD CONSTRAINT `StatusMobil` FOREIGN KEY (`status_mobil`) REFERENCES `statusmobil` (`nm_status`),
  ADD CONSTRAINT `TipeMobil` FOREIGN KEY (`tipe_mobil`) REFERENCES `tipemobil` (`tipe`);

--
-- Constraints for table `transaksi`
--
ALTER TABLE `transaksi`
  ADD CONSTRAINT `DataMobil` FOREIGN KEY (`id_mobil`) REFERENCES `mobil` (`id_mobil`),
  ADD CONSTRAINT `Pelanggan` FOREIGN KEY (`id_pelanggan`) REFERENCES `pelanggan` (`id_pelanggan`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
