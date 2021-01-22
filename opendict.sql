-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 22 Oca 2021, 16:12:26
-- Sunucu sürümü: 10.4.14-MariaDB
-- PHP Sürümü: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `opendict`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `language`
--

CREATE TABLE `language` (
  `Id` int(11) NOT NULL,
  `Language` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Tablo döküm verisi `language`
--

INSERT INTO `language` (`Id`, `Language`) VALUES
(1, 'English'),
(2, 'Turkish');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `localestringresources`
--

CREATE TABLE `localestringresources` (
  `Id` int(11) NOT NULL,
  `LocaleString` varchar(55) NOT NULL,
  `LanguageId` int(11) NOT NULL,
  `Text` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Tablo döküm verisi `localestringresources`
--

INSERT INTO `localestringresources` (`Id`, `LocaleString`, `LanguageId`, `Text`) VALUES
(1, 'common.test.teststring', 1, 'Test String'),
(2, 'common.test.teststring', 2, 'Test İçeriği'),
(3, 'navbar.brand.title', 1, 'OpenDict'),
(4, 'navbar.brand.title', 2, 'AçıkSözlük'),
(5, 'Login.Text.UserLogin', 1, 'User Login'),
(6, 'Login.Text.UserLogin', 2, 'Kullanıcı Girişi'),
(7, 'Login.Text.Username', 1, 'Username'),
(9, 'Login.Text.Password', 1, 'Password'),
(10, 'Login.Text.Password', 2, 'Şifre'),
(11, 'Login.Text.Forgot', 1, 'Forgot?'),
(12, 'Login.Text.Forgot', 2, 'Şifreyi Unuttum'),
(13, 'Login.Text.Register', 1, 'Register'),
(14, 'Login.Text.Register', 2, 'Kayıt Ol'),
(15, 'Login.Text.Login', 1, 'Login'),
(16, 'Login.Text.Login', 2, 'Giriş'),
(17, 'navbar.brand.login', 1, 'Login'),
(18, 'navbar.brand.login', 2, 'Giriş'),
(19, 'navbar.brand.register', 1, 'Register'),
(20, 'navbar.brand.register', 2, 'Kayıt Ol'),
(21, 'navbar.searchbar.search', 1, 'Search'),
(22, 'navbar.searchbar.search', 2, 'Ara'),
(23, 'Login.Text.Register', 1, 'Register'),
(24, 'Login.Text.Register', 2, 'Kayıt Ol'),
(25, 'Login.Register.Username', 1, 'Username'),
(26, 'Login.Register.Username', 2, 'Kullanıcı Adı'),
(27, 'Login.Register.Password', 1, 'Password'),
(28, 'Login.Register.Password', 2, 'Şifre'),
(29, 'Login.Register.Email', 1, 'Email'),
(30, 'Login.Register.Email', 2, 'Email'),
(31, 'Login.Register.RegisterText', 1, 'Register'),
(32, 'Login.Register.RegisterText', 2, 'Kayıt Ol'),
(33, 'Login.Register.AlreadyRegistered', 1, 'Already Registered?'),
(34, 'Login.Register.AlreadyRegistered', 2, 'Zaten bir hesabım var'),
(35, 'Login.Text.Username', 2, 'Kullanıcı Adı');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `usergroup`
--

CREATE TABLE `usergroup` (
  `Id` int(11) NOT NULL,
  `UserGroup` varchar(20) NOT NULL,
  `Language` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `Username` varchar(55) NOT NULL,
  `Email` varchar(55) NOT NULL,
  `Password` varchar(55) NOT NULL,
  `Token` varchar(55) NOT NULL,
  `RegisterDate` datetime NOT NULL,
  `RegisterIp` varchar(55) NOT NULL,
  `UserGroupId` int(11) NOT NULL,
  `EntryCount` int(11) NOT NULL,
  `UserStatusId` int(11) NOT NULL,
  `LastOnlineDate` datetime NOT NULL,
  `Activation` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `userstatus`
--

CREATE TABLE `userstatus` (
  `Id` int(11) NOT NULL,
  `UserStatus` varchar(55) NOT NULL,
  `Language` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `language`
--
ALTER TABLE `language`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `localestringresources`
--
ALTER TABLE `localestringresources`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `usergroup`
--
ALTER TABLE `usergroup`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `userstatus`
--
ALTER TABLE `userstatus`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `language`
--
ALTER TABLE `language`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `localestringresources`
--
ALTER TABLE `localestringresources`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- Tablo için AUTO_INCREMENT değeri `usergroup`
--
ALTER TABLE `usergroup`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `userstatus`
--
ALTER TABLE `userstatus`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
