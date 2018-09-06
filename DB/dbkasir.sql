-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 06, 2018 at 07:54 PM
-- Server version: 10.1.25-MariaDB
-- PHP Version: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbkasir`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbadmin`
--

CREATE TABLE `tbadmin` (
  `id_admin` char(10) NOT NULL,
  `nama_admin` varchar(25) NOT NULL,
  `alamat_admin` varchar(20) NOT NULL,
  `jk_admin` varchar(20) NOT NULL,
  `no` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbadmin`
--

INSERT INTO `tbadmin` (`id_admin`, `nama_admin`, `alamat_admin`, `jk_admin`, `no`) VALUES
('A02', 'Bayu Saputra', 'Surakarta', 'Laki-laki', '085725309162'),
('A04', 'Renaldy', 'Sragen', 'Laki-laki', '081904087239'),
('A05', 'Ratna Ayu', 'Surakarta', 'Perempuan', '08773613266'),
('A08', 'Zaid Iskandar', 'Sukoharjo', 'Laki-laki', '08712387971'),
('A09', 'DRUPADI', 'SOLO', 'Perempuan', '082136726465'),
('A19', 'Fachriyan', 'Sukoharjo', 'Laki-laki', '085725309178'),
('A20', 'DRUPADI CANTIK', 'SOLO', 'Perempuan', '082136726465'),
('A32', 'Umar', 'Solo', 'Laki-laki', '08976587986');

-- --------------------------------------------------------

--
-- Table structure for table `tbbarang`
--

CREATE TABLE `tbbarang` (
  `kode_barang` char(10) NOT NULL,
  `nama_barang` varchar(25) NOT NULL,
  `harga` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbbarang`
--

INSERT INTO `tbbarang` (`kode_barang`, `nama_barang`, `harga`) VALUES
('B012', 'Baju', 70000),
('B013', 'Tas', 250000),
('B026', 'Botol Minum', 35000),
('B03', 'Kaos Oblong', 39000),
('B032', 'Tas Selempang', 87000),
('B05', 'Sepatu Kerja', 400000),
('B1', 'Laptop', 3000000),
('BA09', 'Sandal Gunung', 155000),
('BK04', 'Sandal Swallow', 11000),
('BK08', 'Kemeja', 87000),
('K002', 'Celana Panjang', 170000),
('K009', 'Jas Hujan', 168000),
('K02', 'Kaos Kaki', 8000),
('K09', 'Jaket', 340000),
('K10', 'Kemeja', 17000);

-- --------------------------------------------------------

--
-- Table structure for table `tbtransaksi`
--

CREATE TABLE `tbtransaksi` (
  `kode_transaksi` char(10) NOT NULL,
  `tanggal` varchar(35) NOT NULL,
  `id_admin` char(10) NOT NULL,
  `kode_barang` char(10) NOT NULL,
  `nama_barang` varchar(20) NOT NULL,
  `jumlah` int(10) NOT NULL,
  `total` int(10) NOT NULL,
  `pembayaran` int(10) NOT NULL,
  `kembalian` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbtransaksi`
--

INSERT INTO `tbtransaksi` (`kode_transaksi`, `tanggal`, `id_admin`, `kode_barang`, `nama_barang`, `jumlah`, `total`, `pembayaran`, `kembalian`) VALUES
('K000121', 'Monday, 11 Desember, 2017', 'A04', 'B013', 'Tas', 3, 750000, 1000000, 250000),
('K000128', 'Thursday, 11 January, 2018', 'A20', 'B1', 'Laptop', 2, 6000000, 7000000, 1000000),
('K001112', 'Friday, 22 Desember, 2017', 'A08', 'B03', 'Kaos Oblong', 3, 117000, 200000, 83000),
('K002210', 'Wednesday, 27 December, 2017', 'A02', 'B012', 'Baju', 2, 70000, 100000, 30000),
('K00376', 'Wednesday, 6 December, 2017', 'A09', 'B05', 'Sepatu Kerja', 4, 1600000, 2000000, 400000),
('K01', 'Thursday, 11 January, 2018', 'A08', 'B1', 'Laptop', 1, 3000000, 3200000, 200000),
('K011232', 'Wednesday, 27 December, 2017', 'A05', 'B026', 'Botol Minum', 10, 350000, 400000, 50000),
('KC0021', 'Friday, 29 December, 2017', 'A05', 'BK08', 'Kemeja', 4, 348000, 500000, 152000);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbadmin`
--
ALTER TABLE `tbadmin`
  ADD PRIMARY KEY (`id_admin`);

--
-- Indexes for table `tbbarang`
--
ALTER TABLE `tbbarang`
  ADD PRIMARY KEY (`kode_barang`);

--
-- Indexes for table `tbtransaksi`
--
ALTER TABLE `tbtransaksi`
  ADD PRIMARY KEY (`kode_transaksi`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
