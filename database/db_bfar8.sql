-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 27, 2026 at 04:28 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_bfar8`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_account_codes`
--

CREATE TABLE `tbl_account_codes` (
  `id` int(11) NOT NULL,
  `codeNo` varchar(50) NOT NULL,
  `accountName` varchar(150) NOT NULL,
  `expensesCategoryID` int(10) NOT NULL,
  `expensesClassID` int(10) NOT NULL,
  `hasSubAccountCode` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_account_codes`
--

INSERT INTO `tbl_account_codes` (`id`, `codeNo`, `accountName`, `expensesCategoryID`, `expensesClassID`, `hasSubAccountCode`) VALUES
(1, '50101010-01', 'Basic Salary - Civilian', 1, 1, 0),
(2, '50101020-00', 'Salaries and Wages - Casual/ Contractual', 1, 1, 0),
(3, '50102010-01', 'Personnel Economic Relief Allowance - Civilian', 2, 1, 0),
(4, '50102020-00', 'Representation Allowance', 2, 1, 0),
(5, '50102030-01', 'Transportation Allowance', 2, 1, 0),
(6, '50102040-01', 'Clothing/ Uniform Allowance - Civilian', 2, 1, 0),
(7, '50102050-00', 'Subsistence  Allowance', 2, 1, 1),
(8, '50102060-00', 'Laundry Allowance', 2, 1, 1),
(9, '50102070-00', 'Quarters Allowance', 2, 1, 1),
(10, '50102080-01', 'Productivity Incentive Allowance - Civilian', 2, 1, 0),
(11, '50102090-01', 'Overseas Allowance - Civilian', 2, 1, 0),
(12, '50102100-00', 'Honoraria', 2, 1, 1),
(13, '50102110-00', 'Hazard Pay', 2, 1, 1),
(14, '50102120-00', 'Longevity Pay', 2, 1, 1),
(15, '50102130-00', 'Overtime and Night Pay', 2, 1, 1),
(16, '50102140-01', 'Year End Bonus - Civilian', 2, 1, 0),
(17, '50102160-01', 'Mid Year Bonus - Civilian', 2, 1, 0),
(18, '50102150-01', 'Cash Gift - Civilian', 2, 1, 0),
(19, '50102110-00', 'Other Bonuses and Allowances', 2, 1, 1),
(20, '50103020-01', 'PAG-IBIG Contributions - Civilian', 3, 1, 0),
(21, '50103030-01', 'PhilHealth Contributions - Civilian', 3, 1, 0),
(22, '50103040-01', 'Employees Compensation Insurance Premiums - Civilian', 3, 1, 0),
(23, '50104990-01', 'Lump-sum for Creation of New Positions - Civilian', 4, 1, 0),
(24, '50104990-10', 'Lump-sum for Step Increment - Length of Service', 4, 1, 0),
(25, '50104990-11', 'Lump-sum for Step Increment - Meritorious Performance', 4, 1, 0),
(26, '50104990-15', 'Loyalty Award - Civilian', 4, 1, 0),
(27, '50104990-99', 'Other Personnel Benefits', 4, 1, 0),
(28, '50104010-01', 'Pension Benefits - Civilian', 4, 1, 0),
(29, '50104020-01', 'Retirement Gratuity - Civilian', 4, 1, 0),
(30, '50104030-01', 'Terminal Leave Benefits - Civilian', 4, 1, 0),
(31, '50201010-00', 'Travelling Expenses - Local', 5, 2, 0),
(32, '50201020-00', 'Travelling Expenses - Foreign', 5, 2, 0),
(33, '50202010-00', 'Training Expenses', 6, 2, 1),
(34, '50202020-00', 'Scholarship Grants Expenses', 6, 2, 0),
(35, '50203010-00', 'Office Supplies Expenses', 7, 2, 1),
(36, '50203020-00', 'Accountable Forms Expenses', 7, 2, 0),
(37, '50203030-00', 'Non-Accountable Forms Expenses', 7, 2, 0),
(38, '50203040-00', 'Animal / Zoological Supplies Expenses', 7, 2, 0),
(39, '50203050-00', 'Food Supplies Expenses', 7, 2, 0),
(40, '50203070-00', 'Drugs and Medicines Expenses', 7, 2, 0),
(41, '50203080-00', 'Medical, Dental and Laboratory Supplies Expenses', 7, 2, 0),
(42, '50203090-00', 'Fuel, Oil and Lubricants Expenses', 7, 2, 0),
(43, '50203100-00', 'Agricultural and Marine Supplies Expenses', 7, 2, 0),
(44, '50203110-01', 'Textbooks and Instructional Materials Expenses', 7, 2, 1),
(45, '50203130-00', 'Chemical and Filtering Supplies Expenses', 7, 2, 0),
(46, '50203210-00', 'Semi-Expendable Machineries and Equipment Expenses', 7, 2, 1),
(47, '50203220-00', 'Semi-Expendable Furniture, Fixtures and Book Expenses', 7, 2, 1),
(48, '50203990-00', 'Other Supplies and Materials Expenses', 7, 2, 0),
(51, '50204010-00', 'Water Expenses', 8, 2, 0),
(52, '50204020-00', 'Electricity Expenses', 8, 2, 0),
(53, '50204030-00', 'Gas Heating Expenses\r\n', 8, 2, 0),
(54, '50204990-00', 'Other Utility Expenses', 8, 2, 0),
(55, '50205010-00', 'Postage and Courier Services', 9, 2, 0),
(56, '50205020-00', 'Telephone Expenses', 9, 2, 1),
(57, '50205030-00', 'Internet Subscription Expenses', 9, 2, 0),
(58, '50205040-00', 'Cable, Satellite, Telegraph and Radio Expenses', 9, 2, 0),
(59, '50206010-00', 'Awards and Rewards Expenses', 10, 2, 1),
(60, '50206020-00', 'Prizes', 10, 2, 0),
(61, '50206030-00', 'Indemnities', 10, 2, 0),
(62, '50207010-00', 'Survey Expenses', 11, 2, 1),
(63, '50207020-00', 'Research, Exploration and Development Expenses', 11, 2, 1),
(64, '50208010-00', 'Demolition and Relocation Expenses', 12, 2, 0),
(65, '50208020-00', 'Desilting, Drilling and Dredging Expenses', 12, 2, 0),
(66, '50209010-01', 'ICT Generation, Transmission and Distribution Expenses', 13, 2, 0),
(67, '50209010-02', 'Generation, Transmission and Distribution Expenses', 13, 2, 0),
(68, '50210010-00', 'Confidential Expenses', 14, 2, 0),
(69, '50210020-00', 'Intelligence Expenses', 14, 2, 0),
(70, '50210030-00', 'Extraordinary and Miscellaneous Expenses', 14, 2, 0),
(71, '50211010-00', 'Legal Services', 15, 2, 0),
(72, '50211020-00', 'Auditing Services', 15, 2, 0),
(73, '50211030-00', 'Consultancy Services', 15, 2, 1),
(74, '50211990-00', 'Other Professional Services', 15, 2, 0),
(75, '50212010-00', 'Environment and Sanitary Services', 16, 2, 0),
(76, '50212020-00', 'Janitorial Services', 16, 2, 0),
(77, '50212030-00', 'Security Services', 16, 2, 0),
(78, '50212990-00', 'Other  General Services', 16, 2, 0),
(79, '50213010-00', 'Investment Property', 17, 2, 0),
(80, '50213020-00', 'Land Improvements', 17, 2, 1),
(81, '50213030-00', 'Infrastructure Assets', 17, 2, 1),
(82, '50213040-00', 'Building and Other Structures', 17, 2, 1),
(83, '50213050-00', 'Machinery and Equipment', 17, 2, 1),
(84, '50213060-00', 'Transportation Equipment', 17, 2, 1),
(85, '50213070-00', 'Furniture and Fixtures', 17, 2, 0),
(86, '50213080-00', 'Leased Assets', 17, 2, 1),
(87, '50213090-00', 'Leased Assets Improvement', 17, 2, 1),
(88, '50213210-00', 'Semi-Expendable Machineries and Equipment Expenses', 17, 2, 1),
(89, '50213220-00', 'Semi-Expendable Furniture, Fixtures and Book Expenses', 17, 2, 1),
(90, '50213980-00', 'Others', 17, 2, 0),
(91, '50213990-00', 'Other Property, Plant and Equipment', 17, 2, 1),
(92, '50214010-00', 'Subsidy to NGAs', 18, 2, 0),
(93, '50214020-00', 'Financial Assistance to NGAs', 18, 2, 0),
(94, '50214030-00', 'Financial Assistance to LGUs', 18, 2, 1),
(95, '50214040-00', 'Budgetary Support to GOCCs', 18, 2, 1),
(96, '50214050-00', 'Financial Assistance to NGOs/Pos', 18, 2, 0),
(97, '50214070-00', 'Subsidies to Regional Offices/Staff Bureaus', 18, 2, 0),
(98, '50214080-00', 'Subsidies to Operating Units', 18, 2, 0),
(99, '50214070-00', 'Subsidies to Other Funds', 18, 2, 0),
(100, '50214990-00', 'Other Subsidies', 18, 2, 0),
(101, '50215010-00', 'Taxes, Duties and Licenses', 19, 2, 1),
(102, '50215020-00', 'Fidelity Bond Premiums', 19, 2, 0),
(103, '50215030-00', 'Insurance Expenses', 19, 2, 0),
(104, '50216010-00', 'Labor and Wages', 20, 2, 0),
(105, '50299010-00', 'Advertising, Promotional and Marketing Expenses', 21, 2, 0),
(106, '50299020-00', 'Printing and Publication Expenses', 21, 2, 0),
(107, '50299030-00', 'Representation Expenses', 21, 2, 0),
(108, '50299040-00', 'Transportation and Delivery Expenses', 21, 2, 0),
(109, '50299050-00', 'Rent and Lease Expenses', 21, 2, 1),
(110, '50299060-00', 'Membership Dues and Contributions to Organizations', 21, 2, 0),
(111, '50299070-00', 'Subscription Expenses', 21, 2, 1),
(112, '50299080-00', 'Donations', 21, 2, 0),
(113, '50299090-00', 'Litigation and Acquired Assets Expenses', 21, 2, 0),
(114, '50299100-00', 'Loss on Guaranty', 21, 2, 0),
(115, '50299210-00', 'Legal Defense Expense', 21, 2, 0),
(116, '50299220-00', 'Bank Transaction Fee', 21, 2, 0),
(117, '50299990-00', 'Other Maintenance and Operating Expenses', 21, 2, 1),
(125, '50604020-00', 'Land Improvement Outlays\r\n', 22, 6, 1),
(126, '50604030-00', 'Infrastructure Outlays', 22, 6, 1),
(127, '50604040-00', 'Building and Other Structures Outlay', 22, 6, 1),
(128, '50604050-00', 'Machinery and Equipment', 22, 6, 1),
(129, '50604060-00', 'Transportation Equipment Outlay', 22, 6, 1),
(130, '50604070-00', 'Furniture, Fixtures and Books Outlay', 22, 6, 1),
(131, '50604090-99', 'Other Property, Plant and Equipments', 22, 6, 0),
(132, '50605010-00', 'Bearer Biological Assets Outlays', 23, 6, 1),
(133, '50605020-00', 'Consumable Biological Assets Outlay', 23, 6, 1),
(134, '50606010-01', 'Patents and Copyright', 24, 6, 0),
(135, '50606010-02', 'Computer Software', 24, 6, 0),
(136, '50606010-99', 'Other Intangible Assets', 24, 6, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_activity`
--

CREATE TABLE `tbl_activity` (
  `id` int(11) NOT NULL,
  `activity_code` varchar(50) NOT NULL,
  `activity_name` varchar(255) NOT NULL,
  `project_sub_category_code` varchar(50) NOT NULL,
  `project_category_code` varchar(50) NOT NULL,
  `project_code` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_activity`
--

INSERT INTO `tbl_activity` (`id`, `activity_code`, `activity_name`, `project_sub_category_code`, `project_category_code`, `project_code`) VALUES
(1, '1-0-00-00-1-00001-001', 'Operation of BFAR Central and Regional Offices', '100000100001', '0', '1000000000'),
(2, '1-0-00-00-1-00001-002', 'Operation of BFAR Provincial/City Fishery Offices', '100000100001', '0', '1000000000'),
(3, '3-1-01-02-1-00002-002', 'Number of hatcheries established/maintained', '100000100001', '0', '1000000000'),
(4, '2-0-00-00-1-00001-002-01', 'Number of Local consultations/ Workshops/ Meetings conducted', '200000100001', '0', '2000000000'),
(5, '2-0-00-00-1-00001-002-02', 'Number of Local consultations/ Workshops/ Meetings attended', '200000100001', '0', '2000000000'),
(6, '2-0-00-00-1-00001-002-03', 'Number of International consultations/ Workshops/ Meetings attended', '200000100001', '0', '2000000000'),
(7, '2-0-00-00-1-00001-002-04', 'FIMC Operated (National/Regional)', '200000100001', '0', '2000000000'),
(8, '2-0-00-00-1-00001-002-04', 'Systems Developed/maintained', '200000100001', '0', '2000000000'),
(9, '2-0-00-00-1-00001-003-01', 'Number of Field visits conducted', '200000100001', '0', '2000000000'),
(10, '2-0-00-00-1-00001-003-02', 'Number of agency reports prepared and submitted (monthly/ Quarterly/ Annual', '200000100001', '0', '2000000000'),
(11, '2-0-00-00-1-00001-002-00', 'Number Fishery cased resolved/setled', '200000100003', '0', '2000000000'),
(12, '2-0-00-00-1-00003-001', 'Number of Legal and advisory services rendered', '200000100003', '0', '2000000000'),
(13, '3-1-01-01-1-00001-000-21', 'Others', '310101100001', '310101000000', '310100000000'),
(14, '3-1-01-01-1-00001-001', 'Payao', '310101100001', '310101000000', '310100000000'),
(15, '3-1-01-01-1-00001-002', 'Hook and Line Gears', '310101100001', '310101000000', '310100000000'),
(16, '3-1-01-01-1-00001-003', 'Net Gears', '310101100001', '310101000000', '310100000000'),
(17, '3-1-01-01-1-00001-004', 'Motorized Boat', '310101100001', '310101000000', '310100000000'),
(18, '3-1-01-02-1-00001-001', 'Milkfish broodstocks maintained (pcs)', '310102100001', '310102000000', '310100000000'),
(19, '3-1-01-02-1-00001-001', 'Others broodstocks maintained (pcs)', '310102100001', '310102000000', '310100000000'),
(20, '3-1-01-02-1-00001-001', 'Tilapia broodstocks distributed (pcs)', '310102100001', '310102000000', '310100000000'),
(21, '3-1-01-02-1-00001-001', 'Tilapia broodstocks maintained (pcs)', '310102100001', '310102000000', '310100000000'),
(22, '3-1-01-02-1-00001-002', 'Milkfish fingerlings/seed stocks distributed (in M)', '310102100001', '310102000000', '310100000000'),
(23, '3-1-01-02-1-00001-002', 'Milkfish FRY/seed stocks produced (in M)', '310102100001', '310102000000', '310100000000'),
(24, '3-1-01-02-1-00001-002', 'Others fingerlings/seed stocks distributed (in M)', '310102100001', '310102000000', '310100000000'),
(25, '3-1-01-02-1-00001-002', 'Others FRY/seed stocks produced (in M)', '310102100001', '310102000000', '310100000000'),
(26, '3-1-01-02-1-00001-002', 'Tilapia fingerlings/seed stocks distributed (in M)', '310102100001', '310102000000', '310100000000'),
(27, '3-1-01-02-1-00001-002-01', 'Tilapia  fingerlings/seed stocks produced (in M)', '310102100001', '310102000000', '310100000000'),
(28, '3-1-01-02-1-00001-002-02', 'Milkfish  fingerlings/seed stocks procured (in M)', '310102100001', '310102000000', '310100000000'),
(29, '3-1-01-02-1-00001-002-02', 'Milkfish  fingerlings/seed stocks produced (in M)', '310102100001', '310102000000', '310100000000'),
(30, '3-1-01-02-1-00001-003', 'Number of seaweed farm implements distributed', '310102100001', '310102000000', '310100000000'),
(31, '3-1-01-02-1-00001-004', 'Number of seaweed nurseries established', '310102100001', '310102000000', '310100000000'),
(32, '3-1-01-02-1-00001-005', 'Number of seaweed nurseries maintained', '310102100001', '310102000000', '310100000000'),
(33, '3-1-01-02-1-00001-006', 'Number of seaweed culture laboratory maintained', '310102100001', '310102000000', '310100000000'),
(34, '3-1-01-02-1-00001-007', 'Number of mariculture parks established/maintained/expanded', '310102100001', '310102000000 ', '310100000000'),
(35, '3-1-01-02-1-00001-008', 'Number of cages for livelihood distributed', '310102100001', '310102000000', '310100000000'),
(36, '3-1-01-02-1-00001-009', 'Number of Environmental Monitoring Conducted', '310102100001', '310102000000', '310100000000'),
(37, '3-1-01-02-1-00002-001', 'Number of Technology Stations operated/maintained', '310102100002', '310102000000', '310100000000'),
(38, '3-1-01-02-1-00002-002', 'Number of hatcheries established/maintained', '310102100002', '310102000000', '310100000000'),
(39, '3-1-01-03-1-00001-001', 'Others', '310103100001', '310103000000', '310100000000'),
(40, '3-1-01-03-1-00001-005', 'Vacuum sealer/packer', '310103100001', '310103000000', '310100000000'),
(41, '3-1-01-04-1-00001-001', 'Number of Business/ market/credit facilitation', '310104100001', '310104000000', '310100000000'),
(42, '3-1-01-04-1-00001-001', 'Number of market monitoring conducted', '310104100001', '310104000000', '310100000000'),
(43, '3-1-01-04-1-00001-002', 'Nnumber of Agri-aqua fair/exhibit participated', '310104100001', '310104000000', '310100000000'),
(44, '3-1-01-05-2-00001-000-01', 'Marketing Assistance and Enterprise Development', '310105200001', '310105200000', '310100000000'),
(45, '3-1-01-05-2-00001-000-01', 'Number of Livelihood Projects distributed', '310105200001', '310105200000', '310100000000'),
(46, '3-1-01-05-2-00001-000-01', 'Program Management', '310105200001', '310105200000', '310100000000'),
(47, '3-1-01-05-2-00001-000-01', 'Social Preparation', '310105200001', '310105200000', '310100000000'),
(48, '3-1-01-02-1-00001-005', 'Number of seaweed nurseries maintained', '310105200013', '310105200000', '310100000000'),
(49, '3-1-01-02-1-00001-006', 'Number of seaweed culture laboratory maintained', '310105200013', '310105200000', '310100000000'),
(50, '310105200013', 'Fuel Assistance to the Fisherfolk', '310105200013', '310105200000', '310100000000'),
(51, '3-1-02-00-1-00004-000-01', 'Number of fisheries sanctuaries/reserve/refuge assess', '310200100004', '310200100000', '310200000000'),
(52, '3-1-02-00-1-00004-000-01', 'Number of LGU assisted', '310200100004', '310200100000', '310200000000'),
(53, '3-1-02-00-1-00004-000-01', 'Number of SAG established  and operational', '310200100004', '310200100000', '310200000000'),
(54, '3-1-02-00-1-00004-000-02', 'Number of Management Areas Enhanced', '310200100004', '310200100000', '310200000000'),
(55, '3-1-02-00-1-00001-001', 'Number of  Vessels Monitoring System operated', '310200100001', '310200100000', '310200000000'),
(56, '3-1-02-00-1-00001-001', 'Number of fishing vessels tracked/monitored', '310200100001', '310200100000', '310200000000'),
(57, '3-1-02-00-1-00001-001', 'Number of FRPG operations conducted - Land-based', '310200100001', '310200100000', '310200000000'),
(58, '3-1-02-00-1-00001-001', 'Number of FRPG operations conducted - Sea-borne', '310200100001', '310200100000', '310200000000'),
(59, '3-1-02-00-1-00001-001', 'Number of MCS and Patrol Vessels operated', '310200100001', '310200100000', '310200000000'),
(60, '3-1-02-00-1-00001-002', 'Number of Harmful Algal Bloom (HAB) laboratories maintained', '310200100001', '310200100000', '310200000000'),
(61, '3-1-02-00-1-00001-002', 'Number of Harmful Algal Bloom (HAB) monitoring conducted', '310200100001', '310200100000', '310200000000'),
(62, '3-1-02-00-1-00002-001', 'Number of disease sampling, detection, and analysis conducted Facilities', '310200100002', '310200100000', '310200000000'),
(63, '3-1-02-00-1-00002-001', 'Number of facility monitoring conducted', '310200100002', '310200100000', '310200000000'),
(64, '3-1-02-00-1-00002-001', 'Number of Laboratories maintained/operated Facilities', '310200100002', '310200100000', '310200000000'),
(65, '3-1-02-00-1-00002-002', 'Number of analysis conducted Products', '310200100002', '310200100000', '310200000000'),
(66, '3-1-02-00-1-00002-002', 'Number of fishery products monitoring conducted Products', '310200100002', '310200100000', '310200000000'),
(67, '3-1-02-00-1-00002-002', 'Number of laboraties maintained/operated Products', '310200100002', '310200100002', '310200000000'),
(68, '3-1-02-00-1-00003-001', 'Commercial Fishing Vessels and Gears (Inspection Conducted)', '310200100003', '310200100000', '310200000000'),
(69, '3-1-02-00-1-00003-001', 'Commercial Fishing Vessels and Gears (Permit Issuance)', '310200100003', '310200100000', '310200000000'),
(70, '3-1-02-00-1-00003-001', 'Fish and Fisheries Products (Permit Issuance)', '310200100003', '310200100000', '310200000000'),
(71, '3-1-02-00-1-00003-001', 'FLA and Aquasilviculture covered areas (Inspection Conducted)', '310200100003', '310200100000', '310200000000'),
(72, '3-1-02-00-1-00003-001-01', 'Fish and Fisheries Products (Inspection Conducted)', '310200100003', '310200100000', '310200000000'),
(73, '3-1-02-00-1-00003-001-21', 'COMPONENT 3: Support to Project Implementation and Management', '310200300001', '310200300000', '310200000000'),
(74, '3-1-02-00-1-00003-001-22', 'Sub-component 1.1: Ecosystem Approach to Fisheries Management Planning and Institutions', '310200300001', '310200300000', '310200000000'),
(75, '3-1-02-00-1-00003-001-23', 'Sub-component 1.2: Aquaculture Development and Management', '310200300001', '310200300000', '310200000000'),
(76, '3-1-02-00-1-00003-001-24', 'Sub-component 1.3: Strengthening Management of Coastal Resources in Municipal Waters', '310200300001', '310200300000', '310200000000'),
(77, '3-1-02-00-1-00003-001-25', 'Sub-component 2.1: Fishers\' Livelihood Diversification and Development', '310200300001', '310200300000', '310200000000'),
(78, '3-1-02-00-1-00003-001-26', 'Sub-component 2.2: Aquaculture Fisheries and Enterprise Development', '310200300001', '310200300000', '310200000000'),
(79, '3-1-02-00-1-00003-001-26', 'Sub-component 2.3: Aquaculture Fisheries Infrastructure', '310200300001', '310200300000', '310200000000'),
(80, '3-1-03-00-1-00001-001', 'Operation of Regional Fisheries Training Centers and Asian Fisheries Academy', '310300100001', '310300100000', '310300000000'),
(81, '3-1-03-00-1-00001-001-01', 'Number of trainings conducted Aquaculture', '310300100001', '310300100000', '310300000000'),
(82, '3-1-03-00-1-00001-001-01', 'Number of trainings conducted Municipal', '310300100001', '310300100000', '310300000000'),
(83, '3-1-03-00-1-00001-001-01', 'Number of trainings conducted Others', '310300100001', '310300100000', '310300000000'),
(84, '3-1-03-00-1-00001-001-01', 'Number of trainings conducted Post Harvest', '310300100001', '310300100000', '310300000000'),
(85, '3-1-03-00-1-00001-001-01', 'Number of trainings conducted Regulatory', '310300100001', '310300100000', '310300000000'),
(86, '3-1-03-00-1-00001-001-02', 'Number of technical assistance provided Aquaculture', '310300100001', '310300100000', '310300000000'),
(87, '3-1-03-00-1-00001-001-02', 'Number of technical assistance provided Municipal', '310300100001', '310300100000', '310300000000'),
(88, '3-1-03-00-1-00001-001-02', 'Number of technical assistance provided Others', '310300100001', '310300100000', '310300000000'),
(89, '3-1-03-00-1-00001-001-02', 'Number of technical assistance provided Post Harvest', '310300100001', '310300100000', ' 310300000000'),
(90, '3-1-03-00-1-00001-001-02', 'Number of technical assistance provided Regulatory', '310300100001', '310300100000', '310300000000'),
(91, '3-1-03-00-1-00001-002-01', 'Number of technology demonstrations established Aquaculture', '310300100001', '310300100000', '310300000000'),
(92, '3-1-03-00-1-00001-003-01', 'Number of IEC activities conducted', '310300100001', '310300100000', '310300000000'),
(93, '3-1-03-00-1-00001-003-01', 'Number of IEC materials developed/produced', '310300100001', '310300100000', '310300000000'),
(94, '3-1-03-00-1-00001-004-01', 'No. of fisherfolk Children provided with scholarship', '310300100001', '310300100000', '310300000000'),
(95, '3-1-03-00-1-00001-004-01', 'No. of Fisherfolk Operations Center FARMC PMC operated', '310300100001', '310300100000', '310300000000'),
(96, '3-1-03-00-1-00001-004-01', 'No. of LGU Technicians assisted', '310300100001', '310300100000', '310300000000'),
(97, '3-1-03-00-1-00001-004-02', 'Number of FARMCs strengthened', '310300100001', '310300100000', '310300000000'),
(98, '3-1-04-00-1-00001-001', 'Policy formulation/recommendation', '310400100001', '310400100001', '310400000000');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_class_expenses`
--

CREATE TABLE `tbl_class_expenses` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_class_expenses`
--

INSERT INTO `tbl_class_expenses` (`id`, `name`) VALUES
(1, 'Personnel Services'),
(2, 'Maintenance and Other Operating Expenses'),
(6, 'Capital Outlay');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_department_code`
--

CREATE TABLE `tbl_department_code` (
  `id` int(11) NOT NULL,
  `department_code` varchar(150) NOT NULL,
  `agency_code` varchar(150) NOT NULL,
  `operating_unit` varchar(150) NOT NULL,
  `lower_operating_unit` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_department_code`
--

INSERT INTO `tbl_department_code` (`id`, `department_code`, `agency_code`, `operating_unit`, `lower_operating_unit`) VALUES
(5, '05-000-00-00000 - Department of Agriculture', '05-003-00-00000 - BUREAU OF FISHERIES AND AQUATIC RESOURCES', '05-003-03-00000 - Regional Offices', '05-003-03-00008 - Region VIII');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_document_type`
--

CREATE TABLE `tbl_document_type` (
  `id` int(11) NOT NULL,
  `doc_name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_document_type`
--

INSERT INTO `tbl_document_type` (`id`, `doc_name`) VALUES
(1, 'Travel Expenses'),
(2, 'Payroll'),
(3, 'Stipend');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_earmarks`
--

CREATE TABLE `tbl_earmarks` (
  `id` int(11) NOT NULL,
  `month` varchar(10) NOT NULL,
  `day` varchar(10) NOT NULL,
  `year` varchar(5) NOT NULL,
  `quarter` varchar(15) NOT NULL,
  `pr_no` varchar(10) NOT NULL,
  `particulars` text NOT NULL,
  `fund_cluster` varchar(100) NOT NULL,
  `financing_source` varchar(100) NOT NULL,
  `authorization_code` varchar(100) NOT NULL,
  `fund_category` varchar(100) NOT NULL,
  `full_funding_code` varchar(100) NOT NULL,
  `department_code` varchar(100) NOT NULL,
  `agency_code` varchar(100) NOT NULL,
  `operating_unit_classification` varchar(100) NOT NULL,
  `lower_level_unit` varchar(100) NOT NULL,
  `responsibility_center` varchar(10) NOT NULL,
  `signatory` varchar(50) NOT NULL,
  `position` varchar(50) NOT NULL,
  `program_project` varchar(100) NOT NULL,
  `project_category` varchar(100) NOT NULL,
  `project_sub_category` varchar(100) NOT NULL,
  `activity_level` varchar(100) NOT NULL,
  `expense_class` varchar(50) NOT NULL,
  `expense_type` varchar(100) NOT NULL,
  `account_code` varchar(100) NOT NULL,
  `amount_earmarked` double(17,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_earmarks`
--

INSERT INTO `tbl_earmarks` (`id`, `month`, `day`, `year`, `quarter`, `pr_no`, `particulars`, `fund_cluster`, `financing_source`, `authorization_code`, `fund_category`, `full_funding_code`, `department_code`, `agency_code`, `operating_unit_classification`, `lower_level_unit`, `responsibility_center`, `signatory`, `position`, `program_project`, `project_category`, `project_sub_category`, `activity_level`, `expense_class`, `expense_type`, `account_code`, `amount_earmarked`) VALUES
(1, 'January', '23', '2026', '1st Quarter', '25-12-1043', 'Procurement of Labor and Materials for Pond Improvements for use in Grouper Broodstock Maintenance at GMFDC Station', '01000000 - Regular Agency Fund', '01100000 - General Fund', '01101000 - New General Approriations', '01101101 - Specific Budget of the Agency (Current)', '01101101', '05-000-00-00000 - Department of Agriculture', '05-003-00-00000 - BUREAU OF FISHERIES AND AQUATIC RESOURCES', '05-003-03-00000 - Regional Offices', '05-003-03-00008 - Region VIII', 'SAAD-Leyte', 'LOREGINIA P. BRIONES', 'PFO, Leyte', '310100000000 - Fisheries Development Program', '310105200000 - Locally-Funded Sub-Program', '310105200001 - Special Areas for Agricultural Development (SAAD) Program', '3-1-01-05-2-00001-000-01 - Number of Livelihood Projects distributed', '2 - Maintenance and Other Operating Expenses', '17 - Repairs and Maintenance', '50213020-01 - Land Improvements - Aquaculture Structures', 229215.00),
(2, 'January', '23', '2026', '1st Quarter', '25-11-1023', 'Procurement of Tilapia Finisher (Floater), atleast 30% CP, 25kg/bag, Tilapia Fry mash and other supplies for Tilapia Grow out production in Brackishwater Fishpen for use in Grouper Broodstock Maintenance at GMFDC Station', '01000000 - Regular Agency Fund', '01100000 - General Fund', '01101000 - New General Approriations', '01101101 - Specific Budget of the Agency (Current)', '01101101', '05-000-00-00000 - Department of Agriculture', '05-003-00-00000 - BUREAU OF FISHERIES AND AQUATIC RESOURCES', '05-003-03-00000 - Regional Offices', '05-003-03-00008 - Region VIII', 'TOS-SRAPC(', 'JACKIE L. LIM', 'OIC, SRAPC', '310100000000 - Fisheries Development Program', '310105200000 - Locally-Funded Sub-Program', '310105200001 - Special Areas for Agricultural Development (SAAD) Program', '3-1-01-05-2-00001-000-01 - Program Management', '2 - Maintenance and Other Operating Expenses', '7 - Supplies and Materials', '50203100-00 - Agricultural and Marine Supplies Expenses', 161548.00);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_end_user`
--

CREATE TABLE `tbl_end_user` (
  `id` int(11) NOT NULL,
  `signatory` varchar(100) NOT NULL,
  `position` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_end_user`
--

INSERT INTO `tbl_end_user` (`id`, `signatory`, `position`) VALUES
(1, 'ABRAHAM S. CERA', 'BASIL Focal'),
(2, 'ATTY. DUKE LESTER B. CHUA', 'Atty. II/ Legal Officer'),
(3, 'ATTY. GRACE FENILDA NUGUIT', 'OIC, PMES'),
(4, 'ATTY. KIM MARIE R. BABIANO', 'OIC, Adjudication'),
(5, 'ATTY. REA ABIGAIL M. CANDIDO', 'Chief, FMRED'),
(6, 'CHARM G. GOLTIANO', 'OIC, RFIQU'),
(7, 'CHRISTINE N. GRESOLA', 'OIC, IEC'),
(8, 'CRISTINE JAY C. REDOÑA', 'OIC, EMU'),
(9, 'CYLET SALVACION C. LLUZ', 'Chief, Aquaculturist'),
(10, 'DAN DE SAN MIGUEL', 'PFO-Eastern Samar'),
(11, 'DOMINADOR G. MAPUTOL', 'OIC, Regional Director'),
(12, 'DR. HANNIBAL M. CHAVEZ', 'Regional Director'),
(13, 'EDMAR KRISTOPHER PETALLANA', 'ERMCSOC Chief'),
(14, 'ELMER T. BAUTISTA', 'OIC, RFIMC'),
(15, 'FELIPE G. BALLETA', 'OIC, RBAPC'),
(16, 'FLOREMIE G. AMORA', 'Laboratory Analyst'),
(17, 'ISIDRO G. BAJAR JR.', 'OIC, FIQS'),
(18, 'JACKIE L. LIM', 'OIC, SRAPC'),
(19, 'JENNIFER G. CHAN', 'OIC, GSU'),
(20, 'JOHAN MANOEL G. AVORQUE', 'Capture-Focal Person'),
(21, 'JONAS E. ESTORBA', 'OIC, UEPTH'),
(22, 'JOVEN O. NORCIO', 'OIC, Borongan Tilapia Hatchery'),
(23, 'JULIUS CEASAR R. CABALLES', 'OIC, FPSSD'),
(24, 'KARLEEN R. DESTURA', 'Chief, FAS'),
(25, 'KHE JEAN T. DELIZON', 'OIC, LMSH'),
(26, 'LEA A. TUMABIENE', 'OIC- Chief, RFTFCD'),
(27, 'LOREGINIA P. BRIONES', 'PFO, Leyte'),
(28, 'LOURDES D. CHAVEZ', 'OIC, HRMO'),
(29, 'LUZVIMINDA H. ROBIN', 'PFO-Biliran'),
(30, 'MA. MYRNA C. LOCANDO', 'Disbursement Officer'),
(31, 'MAIDA G. DELA CRUZ', 'PFO, Northern Samar'),
(32, 'MANILYN O. LLENARES', 'OIC, GMFDC'),
(33, 'MARGIE RUTH C. ACABAL', 'Head, PHMS'),
(34, 'MARIE DARYL G. BAÑO', 'OIC-PHMS'),
(35, 'MARLON C. SALE', 'PFO-Western Samar'),
(36, 'MOLITO A. PACLIAN', 'OIC, JAPTC'),
(37, 'NELIA GABON- TOMAYAO', 'Supervisor for Station Facilities'),
(38, 'PRIVY JANE C. CADLUM', 'OIC, Borongan Tilapia Hatchery'),
(39, 'REINAFIL C. BERNAL', 'OIC, RFAPC'),
(40, 'RIZA P. TAPDASAN', 'Chief, RFIL'),
(41, 'RONNIE P. ESMEÑA', 'OIC, FRMS'),
(42, 'ROSARIO B. ORBETA', 'Head, BAC Secreatariat'),
(43, 'ROWVIC B. DOCENA', 'PFO, Southern Leyte'),
(44, 'VICENTA Z. PROJIMO', 'Regional Seaweed Coordinator');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_expenses_category`
--

CREATE TABLE `tbl_expenses_category` (
  `id` int(11) NOT NULL,
  `expenses_category` varchar(150) NOT NULL,
  `expenses_class_id` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_expenses_category`
--

INSERT INTO `tbl_expenses_category` (`id`, `expenses_category`, `expenses_class_id`) VALUES
(1, 'Salaries and Wages', 1),
(2, 'Other Compensation', 1),
(3, 'Personnel Benefit Contributions', 1),
(4, 'Other Personnel Benefit', 1),
(5, 'Travelling Expenses', 2),
(6, 'Training and Scholarship Expenses', 2),
(7, 'Supplies and Materials', 2),
(8, 'Utility Expenses', 2),
(9, 'Communication Expenses', 2),
(10, 'Awards, Rewards and Prizes', 2),
(11, 'Survey, Research, Exploration and Development Expenses', 2),
(12, 'Demolition, Relocation and Drilling Expenses', 2),
(13, 'Generation, Transmission and Distribution Expenses', 2),
(14, 'Confidential, Intelligence and Extraordinary Expenses', 2),
(15, 'Profissional Expenses', 2),
(16, 'General Services', 2),
(17, 'Repairs and Maintenance', 2),
(18, 'Financial Assistance Subsidy', 2),
(19, 'Taxes, Insurance Premiums and Other Fees', 2),
(20, 'Labor and Wages', 2),
(21, 'Other Maintenance and Other Operating Expenses', 2),
(22, 'Property, Plant, and Equipment Outlay', 6),
(23, 'Biological Assets Outlay', 6),
(24, 'Intangible Outlays', 6);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_fund_cluster`
--

CREATE TABLE `tbl_fund_cluster` (
  `id` int(11) NOT NULL,
  `fund_cluster` varchar(150) NOT NULL,
  `financing_source` varchar(150) NOT NULL,
  `authorization_code` varchar(150) NOT NULL,
  `fund_category` varchar(150) NOT NULL,
  `full_funding_code` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_fund_cluster`
--

INSERT INTO `tbl_fund_cluster` (`id`, `fund_cluster`, `financing_source`, `authorization_code`, `fund_category`, `full_funding_code`) VALUES
(1, '01000000 - Regular Agency Fund', '01100000 - General Fund', '01101000 - New General Approriations', '01101101 - Specific Budget of the Agency (Current)', '01101101'),
(2, '01000000 - Regular Agency Fund', '01100000 - General Fund', '01101000 - Unprogrammed Funds', '01101163 - Support to Foreign-Assisted Projects', '01101163'),
(3, '01000000 - Regular Agency Fund', '01100000 - General Fund', '01101000 - New General Approriations', '01101406 - Miscellaneous Personnel Benefits Fund (MPBF)', '01101406'),
(4, '01000000 - Regular Agency Fund', '01100000 - General Fund', '01102000 - Continuing Appropriations', '01102101 - Specific Budget of the Agency (Continuing)', '01102101'),
(5, '01000000 - Regular Agency Fund', '01100000 - General Fund', '01102000 - Unprogrammed Funds', '01102428 - Support to Foreign-Assisted Projects', '01102428'),
(6, '01000000 - Regular Agency Fund', '01100000 - General Fund', '01102000 - Unprogrammed Funds', '01102564 - Support to Foreign-Assisted Projects', '01102564'),
(7, '01000000 - Regular Agency Fund', '01100000 - General Fund', '01104000 - Automatic Appropriations', '01104102 - Retirement and Life Insurance Premiums', '01104102'),
(8, '02000000 - Foreign Assisted Fund', '01100000 - General Fund', '02101000 - New General Approriations', '02101151 - GOP Counterpart Funds', '02101151'),
(9, '02000000 - Foreign Assisted Fund', '01100000 - General Fund', '02101000 - New General Approriations', '02101163 - International Bank for Reconstruction and Development (IBRD)', '02101163');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_obligations`
--

CREATE TABLE `tbl_obligations` (
  `id` int(11) NOT NULL,
  `month` varchar(20) NOT NULL,
  `day` varchar(10) NOT NULL,
  `year` varchar(10) NOT NULL,
  `quarter` varchar(20) NOT NULL,
  `orsNo` varchar(20) NOT NULL,
  `payee` varchar(150) NOT NULL,
  `creditorType` varchar(20) NOT NULL,
  `particulars` text NOT NULL,
  `fund_cluster` varchar(100) NOT NULL,
  `financing_source` varchar(100) NOT NULL,
  `authorization_code` varchar(100) NOT NULL,
  `fund_category` varchar(100) NOT NULL,
  `full_funding_code` varchar(50) NOT NULL,
  `department_code` varchar(100) NOT NULL,
  `agency_code` varchar(100) NOT NULL,
  `operating_unit_classification` varchar(100) NOT NULL,
  `lower_level_unit` varchar(100) NOT NULL,
  `responsibility_center` varchar(100) NOT NULL,
  `signatory` varchar(100) NOT NULL,
  `position` varchar(50) NOT NULL,
  `program_project` varchar(100) NOT NULL,
  `project_category` varchar(100) NOT NULL,
  `project_sub_category` varchar(100) NOT NULL,
  `activity_level` varchar(100) NOT NULL,
  `expense_class` varchar(100) NOT NULL,
  `expense_type` varchar(100) NOT NULL,
  `account_code` varchar(100) NOT NULL,
  `obligations_incurred` decimal(17,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_obligations`
--

INSERT INTO `tbl_obligations` (`id`, `month`, `day`, `year`, `quarter`, `orsNo`, `payee`, `creditorType`, `particulars`, `fund_cluster`, `financing_source`, `authorization_code`, `fund_category`, `full_funding_code`, `department_code`, `agency_code`, `operating_unit_classification`, `lower_level_unit`, `responsibility_center`, `signatory`, `position`, `program_project`, `project_category`, `project_sub_category`, `activity_level`, `expense_class`, `expense_type`, `account_code`, `obligations_incurred`) VALUES
(1, 'January', '12', '2026', '1st Quarter', '26-01-0001', 'EDV Trading', 'External Creditor', 'Lot 1 procurement of tires for the repair and maintenance of BFAR RO 8 vehicle', '01000000 - Regular Agency Fund', '01100000 - General Fund', '01101000 - New General Approriations', '01101101 - Specific Budget of the Agency (Current)', '01101101', '05-000-00-00000 - Department of Agriculture', '05-003-00-00000 - BUREAU OF FISHERIES AND AQUATIC RESOURCES', '05-003-03-00000 - Regional Offices', '05-003-03-00008 - Region VIII', 'RO', 'JENNIFER G. CHAN', 'OIC, GSU', '310300000000 - Fisheries Extension Program', '310300100000 - Extension, Support, Education and Training Services (ESETS)', '310300100001 - Extension, Support, Education and Training Services (ESETS)', '- Select Activity -', '2 - Maintenance and Other Operating Expenses', '17 - Repairs and Maintenance', '50213060-01 - Transportation Equipment - Motor Vehicle', 423750.00),
(2, 'January', '23', '2026', '1st Quarter', '26-01-0070', 'Dan A. De San Miguel', 'Internal Creditor', 'To payment of communication allowance for the month of January 2026', '01000000 - Regular Agency Fund', '01100000 - General Fund', '01101000 - New General Approriations', '01101101 - Specific Budget of the Agency (Current)', '01101101', '05-000-00-00000 - Department of Agriculture', '05-003-00-00000 - BUREAU OF FISHERIES AND AQUATIC RESOURCES', '05-003-03-00000 - Regional Offices', '05-003-03-00008 - Region VIII', 'PFO-E.Samar', 'CYLET SALVACION C. LLUZ', 'Chief, Aquaculturist', '1000000000 - General Administration and Support (GAS)', 'No Project Category', '100000100001 - General Management and Supervision', '1-0-00-00-1-00001-002 - Operation of BFAR Provincial/City Fishery Offices', '2 - Maintenance and Other Operating Expenses', '9 - Communication Expenses', '50205020-01 - Telephone Expenses - Mobile', 599.97);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_payee`
--

CREATE TABLE `tbl_payee` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_payee`
--

INSERT INTO `tbl_payee` (`id`, `name`) VALUES
(1, 'EDV Trading'),
(2, 'Dan A. De San Miguel');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_program_projects`
--

CREATE TABLE `tbl_program_projects` (
  `id` int(11) NOT NULL,
  `code` varchar(50) NOT NULL,
  `programs_projects` varchar(150) NOT NULL,
  `hasProjectCategory` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_program_projects`
--

INSERT INTO `tbl_program_projects` (`id`, `code`, `programs_projects`, `hasProjectCategory`) VALUES
(1, '1000000000', 'General Administration and Support (GAS)', 0),
(2, '2000000000', 'Support to Operations (STO)', 0),
(3, '310100000000', 'Fisheries Development Program', 1),
(4, '310200000000', 'Fisheries Regulatory and Law Enforcement Program', 1),
(5, '310300000000', 'Fisheries Extension Program', 1),
(6, '310400000000', 'Fisheries Policy Program', 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_project_categ`
--

CREATE TABLE `tbl_project_categ` (
  `id` int(11) NOT NULL,
  `categoryCode` varchar(50) NOT NULL,
  `projectCategory` varchar(150) NOT NULL,
  `project_code` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_project_categ`
--

INSERT INTO `tbl_project_categ` (`id`, `categoryCode`, `projectCategory`, `project_code`) VALUES
(1, '310101000000', 'Capture Fisheries Sub-Program', '310100000000'),
(2, '310102000000', 'Aquaculture Sub-Program', '310100000000'),
(3, '310103000000', 'Post-harvest Sub-Program', '310100000000'),
(4, '310104000000', 'Market Development Sub-Program', '310100000000'),
(5, '310105200000', 'Locally-Funded Sub-Program', '310100000000'),
(6, '310200100000', 'Coastal and Inland Fisheries Resource Management', '310200000000'),
(7, '310200100000', 'Monitoring, Control and Surveillance', '310200000000'),
(8, '310200100000', 'Quality Control and Inspection', '310200000000'),
(9, '310200100000', 'Quarantine, Registration & Licensing', '310200000000'),
(10, '310200300000', 'Foreign Assisted Sub-Program', '310200000000'),
(11, '310300100000', 'Extension, Support, Education and Training Services (ESETS)', '310300000000'),
(12, '310400100001', 'Formulation, Monitoring and Evaluation of Policies, Plans and Programs', '310400000000');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_project_sub_categ`
--

CREATE TABLE `tbl_project_sub_categ` (
  `id` int(11) NOT NULL,
  `subCategoryCode` varchar(50) NOT NULL,
  `subCategory` varchar(150) NOT NULL,
  `categoryCode` varchar(50) NOT NULL,
  `project_code` varchar(50) NOT NULL,
  `hasActivity` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_project_sub_categ`
--

INSERT INTO `tbl_project_sub_categ` (`id`, `subCategoryCode`, `subCategory`, `categoryCode`, `project_code`, `hasActivity`) VALUES
(1, '100000100001', 'General Management and Supervision', '0', '1000000000', 1),
(2, '100000100002', 'Administration of Personnel Benefits', '0', '1000000000', 0),
(3, '200000100001', 'Development of Organizational Policies, Plans & Procedures', '0', '2000000000', 1),
(4, '200000100003', 'Legal and Advisory Services', '0', '2000000000', 1),
(5, '310101100001', 'Fishing Gear/Paraphernalia Distribution', '310101000000', '310100000000', 1),
(6, '310102100001', 'Fisheries Production and Distribution', '310102000000', '310100000000', 1),
(7, '310102100002', 'Operation and management of production facilities', '310102000000', '310100000000', 1),
(8, '310103100001', 'Provision of Fishery On-Farm Equipements & Post-Harvest Facilities', '310103000000', '310100000000', 1),
(9, '310104100001', 'Market Development Services', '310104000000', '310100000000', 1),
(10, '310105200001', 'Special Areas for Agricultural Development (SAAD) Program', '310105200000', '310100000000', 1),
(11, '310105200013', 'Aquaculture and Mariculture Expansion and Invigoration Project', '310105200000', '310100000000', 1),
(12, '310105200013', 'Fuel Assistance to the Fisherfolk', '310105200000', '310100000000', 1),
(13, '310200100001', 'Monitoring, Control and Surveillance', '310200100000', '310200000000', 1),
(14, '310200100002 ', 'Quality Control and Inspection', '310200100000', '310200000000', 1),
(15, '310200100003', 'Quarantine, Registration & Licensing', '310200100000', '310200000000', 1),
(16, '310200100004', 'Coastal and Inland Fisheries Resource Management', '310200100000', '310200000000', 1),
(17, '310200300001', 'Philippine Fisheries and Coastal Resiliency Project', '310200300000', '310200000000', 1),
(18, '310300100001', 'Extension, Support, Education and Training Services (ESETS)', '310300100000', '310300000000', 1),
(19, '310400100001', 'Formulation, Monitoring and Evaluation of Policies, Plans and Programs', '310400100001', '310400000000', 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_prs`
--

CREATE TABLE `tbl_prs` (
  `id` int(11) NOT NULL,
  `index_no` varchar(10) NOT NULL,
  `pr_no` varchar(20) NOT NULL,
  `particulars` text NOT NULL,
  `purpose` text NOT NULL,
  `lot_no` int(10) NOT NULL,
  `responsibility_center` varchar(50) NOT NULL,
  `end_user` varchar(150) NOT NULL,
  `position` varchar(50) NOT NULL,
  `amount` double(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_prs`
--

INSERT INTO `tbl_prs` (`id`, `index_no`, `pr_no`, `particulars`, `purpose`, `lot_no`, `responsibility_center`, `end_user`, `position`, `amount`) VALUES
(1, '2601001600', '26-01-0149', 'Printer (3-in-1 Functions: Print/Scan/Copy), Multifunction Color Inkjet Printer with ADF up to Legal Size Capability and with individual Tanks; Printing resolution: 600 DPI x 1,200 DPI (Horizontal x Vertical), wifi duplex.', 'use in Grouper Broodstock Maintenance at GMFDC Station', 1, 'Legal', 'Atty. Duke Lester B. Chua', 'Legal Officer', 16000.00),
(2, '2601001600', '26-01-0149', 'Mobile Phone with Processor - 2.2GHz, 2GHz, CPU Type - Octa-Core Size (Main Display)-169.1mm (6.7\" full rectangle) / 164.5mm (6.5\" rounded corners - Resolution (Main Display) - 1080 x 2340 (FHD+), Technology (Main Display) - Super AMOLED, Color Depth (Main Display) 16M', 'use in Grouper Broodstock Maintenance at GMFDC Station', 2, 'Legal', 'Atty. Duke Lester B. Chua', 'Legal Officer', 10000.00),
(3, '2512004700', '25-12-1043', 'Labor and Materials for Pond Improvements', 'use in Grouper Broodstock Maintenance at GMFDC Station', 1, 'SAAD-Leyte', 'LOREGINIA P. BRIONES', 'PFO, Leyte', 229215.00),
(4, '2509009700', '25-09-0822', '6mm Mirror Glass Installation, Frosted Tint for Fixed Divider Glass and other supplies and materials for Repair of BFAR RO 8 Comfort Room; Installation of Lightings at BFAR 8, CRMC, Diit and additional Network Storage for\r\nENGAS.', 'use in Grouper Broodstock Maintenance at GMFDC Station', 1, 'Finance Administrative Division', 'Karleen R. Destura', 'Chief, FAS', 63700.00),
(5, '2509009700', '25-09-0822', 'Circuit breaker box, plug and other supplies for Repair of BFAR RO 8 Comfort Room; Installation of Lightings at BFAR 8, CRMC, Diit and additional Network Storage for ENGAS.\r\n', 'use in Grouper Broodstock Maintenance at GMFDC Station', 2, 'Finance Administrative Division', 'Karleen R. Destura', 'Chief, FAS', 66425.00),
(6, '2509009700', '25-09-0822', 'Network attached storage for Repair of BFAR RO 8 Comfort Room; Installation of Lightings at BFAR 8, CRMC, Diit and additional Network Storage for ENGAS.', 'use in Grouper Broodstock Maintenance at GMFDC Station', 3, 'Finance Administrative Division', 'Karleen R. Destura', 'Chief, FAS', 49000.00),
(7, '2511004700', '25-12-1036 ', 'Diesel and Gasoline for maintenance and operations at the Legislated Hatchery in San Jose, Northern Samar.', 'use in Grouper Broodstock Maintenance at GMFDC Station', 1, 'LH - N. Samar', 'Maida G. Dela Cruz', 'PFO N. Samar', 15750.00),
(8, '2511011500', '25-11-1023 ', 'Tilapia Finisher (Floater), atleast 30% CP, 25kg/bag, Tilapia Fry mash and other supplies for Tilapia Grow out production in Brackishwater Fishpen', 'use in Grouper Broodstock Maintenance at GMFDC Station', 1, 'TOS-SRAPC(Operation)', 'JACKIE L. LIM', 'OIC, SRAPC', 161548.00);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_responsibility_center`
--

CREATE TABLE `tbl_responsibility_center` (
  `id` int(11) NOT NULL,
  `name` varchar(150) NOT NULL,
  `allotment_received` decimal(17,2) NOT NULL,
  `current_year_obligation` decimal(17,2) NOT NULL,
  `current_year_disbursement` decimal(17,2) NOT NULL,
  `unpaid_obligations` decimal(17,2) NOT NULL,
  `unobligated_balance` decimal(17,2) NOT NULL,
  `earmark` decimal(17,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_responsibility_center`
--

INSERT INTO `tbl_responsibility_center` (`id`, `name`, `allotment_received`, `current_year_obligation`, `current_year_disbursement`, `unpaid_obligations`, `unobligated_balance`, `earmark`) VALUES
(1, 'Adjudication', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(2, 'Bangus Development Program', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(3, 'BASIL', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(4, 'Biliran Tilapia Hatchery-Operation', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(5, 'Biliran Tilapia Hatchery-PD', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(6, 'Borongan Tilapia Hatchery-Operation', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(7, 'Borongan Tilapia Hatchery-PD', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(8, 'Capture', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(9, 'Casual', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(10, 'CFVGL', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(11, 'CRM Center-Operation', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(12, 'EMU', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(13, 'EPSDP', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(14, 'ESSETS', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(15, 'FARMC', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(16, 'Finance and Administrative Division', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(17, 'Fingerlings', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(18, 'Fish Health Laboratories', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(19, 'FishCORE GOP', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(20, 'FishCORE Loan Proceeds', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(21, 'Fisheries Inspection Unit', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(22, 'Fisheries Quarantine Inspection Unit', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(23, 'Fisheries Scholarship Program', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(24, 'Fishing Gear', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(25, 'Fishing Vessel', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(26, 'FLA', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(27, 'FLELDT', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(28, 'FMA', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(29, 'FMA/SAG', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(30, 'FRMS', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(31, 'Fuel Assistance to the Fisherfolk', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(32, 'GASS', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(33, 'HAB', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(34, 'IEC', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(35, 'IMEMS', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(36, 'Legal Unit', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(37, 'LH-Biliran', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(38, 'LH-N.Samar', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(39, 'LH-RO', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(40, 'LH-Samar', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(41, 'LH-Basey', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(42, 'LH-Calbayog', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(43, 'LH-San Jose', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(44, 'Livelihood Cages', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(45, 'MANA', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(46, 'Marketing Division', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(47, 'MCS', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(48, 'MFO 3', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(49, 'MP', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(50, 'MP(2M)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(51, 'MP(10M)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(52, 'National Bangus Development Program', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(53, 'PBB', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(54, 'PFO-Biliran', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(55, 'PFO-Biliran(CF)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(56, 'PFO-E.Samar', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(57, 'PFO-E.Samar(CF)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(58, 'PFO-Leyte', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(59, 'PFO-Leyte(CF)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(60, 'PFO-N.Samar', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(61, 'PFO-N.Samar(CF)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(62, 'PFO-S.Leyte', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(63, 'PFO-S.Leyte(CF)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(64, 'PFO-W.Samar', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(65, 'PFO-W.Samar(CF)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(66, 'PMES', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(67, 'Policy', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(68, 'Post Harvest', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(69, 'Production Distribution', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(70, 'Production Facilities', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(71, 'QCI', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(72, 'RFT & FCC', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(73, 'RFIMC', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(74, 'RO', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(75, 'SAAD', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(76, 'SAAD-RO', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(77, 'SAAD-Biliran', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(78, 'SAAD-E.Samar', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(79, 'SAAD-Leyte', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(80, 'SAAD-N.Samar', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(81, 'SAAD-SAMAR', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(82, 'SAAD-S.Leyte', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(83, 'Seaweed Development Program', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(84, 'Seaweed Nurseries', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(85, 'Seaweed Sanctuary', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(86, 'STO', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(87, 'Sustainable Shrimp Industry Program', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(88, 'TA', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(89, 'Techno Demo', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(90, 'TOS-GMFDC(Operation)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(91, 'TOS-GMFDC(PD)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(92, 'TOS-JAPTC(Operation)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(93, 'TOS-JAPTC(PD)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(94, 'TOS-LMSH(Operation)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(95, 'TOS-LMSH(PD)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(96, 'TOS-RBAPC(Operation)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(97, 'TOS-RBAPC(PD)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(98, 'TOS-RFAPC(Operation)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(99, 'TOS-RFAPC(PD)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(100, 'TOS-SRAPC(Operation)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(101, 'TOS-SRAPC(PD)', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(102, 'Tilapia', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(103, 'Training', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(104, 'Tuna Development', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(105, 'UEP Tilapia Hatchery-Operation', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
(106, 'UEP Tilapia Hatchery-PD', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_sub_account_codes`
--

CREATE TABLE `tbl_sub_account_codes` (
  `id` int(11) NOT NULL,
  `subAccountCode` varchar(50) NOT NULL,
  `subAccountName` varchar(150) NOT NULL,
  `accountCodeID` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_sub_account_codes`
--

INSERT INTO `tbl_sub_account_codes` (`id`, `subAccountCode`, `subAccountName`, `accountCodeID`) VALUES
(1, '50102050-02', 'Magna Carta for Science and Technology RA 8439', 7),
(2, '50102050-03', 'Magna Carta for Public Health Worker RA 7305', 7),
(3, '50102060-01', 'Laundry Allowance - Civilian', 8),
(4, '50102060-03', 'Magna Carta for Science and Technology RA 8439', 8),
(5, '50102060-04', 'Magna Carta for Public Health Worker RA 7305', 8),
(6, '50102070-01', 'Quarters Allowance - Civilian', 9),
(7, '50102070-03', 'Magna Carta for Science and Technology RA 8439', 9),
(8, '50102070-04', 'Magna Carta for Public Health Worker RA 7305', 9),
(9, '50102100-01', 'Honoraria - Civilian', 12),
(10, '50102100-03', 'Magna Carta for Science and Technology RA 8439', 12),
(11, '50102100-04', ' Magna Carta for Public Health Worker            RA 7305', 12),
(12, '50102110-02', 'Hazard Pay - Civilian', 13),
(13, '50102110-04', 'Magna Carta for Science and Technology RA 8439', 13),
(14, '50102110-05', 'Magna Carta for Public Health Worker RA 7305', 13),
(15, '50102120-01', 'Longevity Pay', 14),
(16, '50102120-03', 'Magna Carta for Science and Technology RA 8439', 14),
(17, '50102120-04', 'Magna Carta for Public Health Worker RA 7305', 14),
(18, '50102130-01', 'Overtime Pay\r\n', 15),
(19, '50102130-02', 'Night Shift Differential Pay', 15),
(20, '50102990-01', 'Per Diems - Civilian', 19),
(21, '50102990-03', 'Allowance of Attoney\'s de Officio - Civilian', 19),
(22, '50102990-06', 'Inquest Allowance - Civilian', 19),
(23, '50102990-07', 'Special Duty Allowance - Civilian', 19),
(24, '50102990-11', 'Collective Negotiation Agreement Incentive - Civilian', 19),
(25, '50102990-12', 'Productivity Enhancement Incentive - Civilian', 19),
(26, '50102990-14', 'Performance Based Bonus - Civilian', 19),
(27, '50102990-38', 'Anniversary - Civilian', 19),
(28, '50202010-01', 'ICT Training Expenses', 33),
(29, '50203090-02', 'Training Expenses', 33),
(30, '50203010-01', 'ICT Office Supplies Expenses', 35),
(31, '50203010-02', 'Office Supplies Expenses', 35),
(32, '50203010-01', 'Textbook and Instructional Material Expenses', 44),
(33, '50203010-02', 'Chalk Allowance', 44),
(34, '50203210-01', 'Machinery', 46),
(35, '50203210-02', 'Office Equipment', 46),
(36, '50203210-03', 'Information and Communication Technology Equipment', 46),
(37, '50203210-04', 'Agriculture and Forestry Equipment', 46),
(38, '50203210-05', 'Marine and Fishery Equipment', 46),
(39, '50203210-07', 'Communication Equipment\r\n', 46),
(40, '50203210-08', 'Disaster Response and Rescue Equipment', 46),
(41, '50203210-09', 'Military, Police and Security Equipment', 46),
(42, '50203210-10', 'Medical Equipment', 46),
(43, '50203210-11', 'Printing Equipment\r\n', 46),
(44, '50203210-12', 'Sports Equipment', 46),
(45, '50203210-13', 'Technical and Scientific Equipment', 46),
(46, '50203210-99', 'Other Machinery and Equipment', 46),
(47, '50203220-01', 'Furniture and Fixtures', 47),
(48, '50203220-02', 'Books', 47),
(49, '50205020-01', 'Mobile', 56),
(50, '50205020-02', 'Landline', 56),
(51, '50206010-01', 'Awards and Rewards Expenses', 59),
(52, '50206010-01', 'Rewards and Incentives\r\n', 59),
(53, '50207010-01', 'ICT Survey Expenses', 62),
(54, '50207010-02', 'Survey Expenses', 62),
(55, '50207020-01', 'ICT Research, Exploration and Development Expenses', 63),
(56, '50207020-02', 'Research, Exploration and Development Expenses', 63),
(57, '50211030-01', 'ICT Consultancy Services', 73),
(58, '50211030-02', 'Consultancy Services', 73),
(59, '50213020-01', 'Aquaculture Structures', 80),
(60, '50213020-02', 'Reforestation Projects', 80),
(61, '50213020-99', 'Other Land Improvements', 80),
(62, '50213030-01', 'Road Networks', 81),
(63, '50213030-04', 'Water Supply Systems', 81),
(64, '50213030-05', 'Power Supply Systems', 81),
(65, '50213030-06', 'Communications Network', 81),
(66, '50213030-07', 'Seaport System', 81),
(67, '50213030-99', 'Other Infrastructure Assets', 81),
(68, '50213040-01', 'Buildings', 82),
(69, '50213040-04', 'Markets', 82),
(70, '50213040-05', 'Slaughterhouses', 82),
(71, '50213040-06', 'Hostels and Dormitories', 82),
(72, '50213040-99', 'Other Structures', 82),
(73, '50213050-01', 'Machinery', 83),
(74, '50213050-02', 'Office Equipment', 83),
(75, '50213050-03', 'Information and Communication Technology  Equipment', 83),
(76, '50213050-04', 'Agricultural and Forestry Equipment', 83),
(77, '50213050-05', 'Marine and Fishery Equipment', 83),
(78, '50213050-07', 'Communication Equipment', 83),
(79, '50213050-08', 'Construction and Heavy Equipment', 83),
(80, '50213050-09', 'Disaster Response and Rescue Equipment', 83),
(81, '50213050-10', 'Military, Police and Security Equipment', 83),
(82, '50213050-11', 'Medical Equipment', 83),
(83, '50213050-12', 'Printing Equipment', 83),
(84, '50213050-13', 'Sports Equipment', 83),
(85, '50213050-14', 'Technical and Scientific Equipment', 83),
(86, '50213050-99', 'Other Machineries and Equipment', 83),
(87, '50213060-01', 'Motor Vehicle', 84),
(88, '50213060-04', 'Watercrafts', 84),
(89, '50213060-99', 'Other Transportation Equipment', 84),
(90, '50213080-01', 'Buildings and Other Structures', 86),
(91, '50213080-02', 'Machinery and Equipment', 86),
(92, '50213080-03', 'Transportation Equipment', 86),
(93, '50213080-04', 'ICT Machinery and Equipment', 86),
(94, '50213080-99', 'Other Leased Assets', 86),
(95, '50213090-01', 'Lands', 87),
(96, '50213090-02', 'Buildings', 87),
(97, '50213090-99', 'Other Leased Assets Improvements', 87),
(98, '50213210-01', 'Machinery', 88),
(99, '50213210-02', 'Office Equipment', 88),
(100, '50213210-03', 'Information and Communication Technology Equipment', 88),
(101, '50213210-04', 'Agriculture and Forestry Equipment', 88),
(102, '50213210-05', 'Marine and Fishery Equipment', 88),
(103, '50213210-07', 'Communication Equipment', 88),
(104, '50213210-08', 'Disaster Response and Rescue Equipment', 88),
(105, '50213210-09', 'Military, Police and Security Equipment', 88),
(106, '50213210-10', 'Medical Equipment', 88),
(107, '50213210-11', 'Printing Equipment', 88),
(108, '50213210-12', 'Sports Equipment', 88),
(109, '50213210-13', 'Technical and Scientific Equipment', 88),
(110, '50213210-99', 'Other Machinery and Equipment', 88),
(111, '50213220-01', 'Furniture and Fixtures', 89),
(112, '50213220-02', 'Books', 89),
(113, '50213990-01', 'Work / Zoo Animals', 91),
(114, '50213990-99', 'Other Property, Plant and Equipment', 91),
(115, '50214030-01', 'Tobacco Excise Tax (Virginia) per RA 7171', 94),
(116, '50214030-02', 'Tobacco Excise Tax (Burley and Native) per RA 8240', 94),
(117, '50214030-05', 'Forestry Charges per RA 7160', 94),
(118, '50214030-00', 'Financial Assistance to LGUs', 94),
(119, '50214040-01', 'Budgetary Support to Operations of GOCCs', 95),
(120, '50214040-02', 'Road Networks', 95),
(121, '50214040-05', 'Water Supply System', 95),
(122, '50214040-06', 'Power Supply System', 95),
(123, '50214040-07', 'Communication Networks', 95),
(124, '50214040-08', 'Seaport Systems', 95),
(125, '50214040-99', 'Other Infrastructure Assets', 95),
(126, '50215010-01', 'Taxes, Duties and Licenses', 101),
(127, '50215010-02', 'Tax Refund', 101),
(128, '50299050-01', 'Building and Structures', 109),
(129, '50299050-02', 'Land', 109),
(130, '50299050-03', 'Motor Vehicle', 109),
(131, '50299050-04', 'Equipment', 109),
(132, '50299050-05', 'Living Quarters', 109),
(133, '50299050-06', 'Operating Lease', 109),
(134, '50299050-07', 'Finance Lease', 109),
(135, '50299050-08', 'ICT Machinery and Equipment', 109),
(136, '50299070-01', 'ICT Software Subscription', 111),
(137, '50299070-02', 'Data Center Service', 111),
(138, '50299070-03', 'Cloud Computing Service', 111),
(139, '50299070-04', 'Library and Other Reading Materials Subscription', 111),
(140, '50299070-99', 'Other Subscription Expenses', 111),
(141, '50299990-01', 'Website Maintenance', 117),
(142, '50299990-99', 'Other Maintenance and Operating Expenses', 117),
(143, '50604020-01', 'Aquaculture Structures', 125),
(144, '50604020-02', 'Reforestation Projects', 125),
(145, '50604020-03', 'Other Land Improvements', 125),
(146, '50604030-01', 'Road Networks', 126),
(147, '50604030-04', 'Water Supply Systems', 126),
(148, '50604030-05', 'Power Supply System', 126),
(149, '50604030-06', 'Communication Networks', 126),
(150, '50604030-07', 'Seaport System', 126),
(151, '50604030-99', 'Other Infrastructure Assets', 126),
(152, '50604040-01', 'Buildings', 127),
(153, '50604040-04', 'Markets', 127),
(154, '50604040-05', 'Slaughterhouses', 127),
(155, '50604040-06', 'Hostels and Dormitories', 127),
(156, '50604040-99', 'Other Structures', 127),
(157, '50604050-01', 'Machinery', 128),
(158, '50604050-02', 'Office Equipment', 128),
(159, '50604050-03', 'Information and Communication Technology', 128),
(160, '50604050-04', 'Agriculture and Forestry Equipment', 128),
(161, '50604050-05', 'Marine and fishery Equipment', 128),
(162, '50604050-07', 'Communication Equipment', 128),
(163, '50604050-08', 'Construction and Heavy Equipment', 128),
(164, '50604050-09', 'Disaster Response and Rescue Equipment', 128),
(165, '50604050-10', 'Military, Police and Security Equipment', 128),
(166, '50604050-11', 'Medical Equipment', 128),
(167, '50604050-12', 'Printing Equipment', 128),
(168, '50604050-13', 'Sports Equipment', 128),
(169, '50604050-14', 'Technical and Scientific Equipment', 128),
(170, '50604050-15', 'ICT Software', 128),
(171, '50604050-99', 'Other Machinery and Equipment', 128),
(172, '50604060-01', 'Motor Vehicle', 129),
(173, '50604060-04', 'Watercrafts', 129),
(174, '50604060-99', 'Other Transportation Equipment', 129),
(175, '50604070-01', 'Furniture and Fixtures', 130),
(176, '50604070-02', 'Books', 130),
(177, '50605010-01', 'Breeding Stocks', 132),
(178, '50605010-02', 'Livestock', 132),
(179, '50605010-03', 'Trees, Plants and Crops', 132),
(180, '50605010-04', 'Aquaculture', 132),
(181, '50605010-99', 'Other Bearer Biological Assets', 132),
(182, '50605020-01', 'Livestock Held for Consumption, Sale and Distribution', 133),
(183, '50605020-02', 'Trees, Plants and Crops Held for Consumption, Sale and Distribution', 133),
(184, '50605020-03', 'Agricultural Produce Held for Consumption, Sale and Distribution', 133),
(185, '50605020-04', 'Aquaculture', 133),
(186, '50605020-99', 'Other Consumable Assets', 133);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user_admin`
--

CREATE TABLE `tbl_user_admin` (
  `id` int(11) NOT NULL,
  `user_id` varchar(150) NOT NULL,
  `hashed_password` varchar(255) NOT NULL,
  `salt_password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_user_admin`
--

INSERT INTO `tbl_user_admin` (`id`, `user_id`, `hashed_password`, `salt_password`) VALUES
(1, 'bfar8budget@admin', 'VgApNhs3k+qSyIYbFsR0uzShOd+bgrqwhHG1ZqMBnQs=', 'gSlBwnQTfFoCkBjaCLozJw==');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_account_codes`
--
ALTER TABLE `tbl_account_codes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_activity`
--
ALTER TABLE `tbl_activity`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_department_code`
--
ALTER TABLE `tbl_department_code`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_document_type`
--
ALTER TABLE `tbl_document_type`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_earmarks`
--
ALTER TABLE `tbl_earmarks`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_end_user`
--
ALTER TABLE `tbl_end_user`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_expenses_category`
--
ALTER TABLE `tbl_expenses_category`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_fund_cluster`
--
ALTER TABLE `tbl_fund_cluster`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_obligations`
--
ALTER TABLE `tbl_obligations`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_payee`
--
ALTER TABLE `tbl_payee`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_program_projects`
--
ALTER TABLE `tbl_program_projects`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_project_categ`
--
ALTER TABLE `tbl_project_categ`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_project_sub_categ`
--
ALTER TABLE `tbl_project_sub_categ`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_prs`
--
ALTER TABLE `tbl_prs`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_responsibility_center`
--
ALTER TABLE `tbl_responsibility_center`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_sub_account_codes`
--
ALTER TABLE `tbl_sub_account_codes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_user_admin`
--
ALTER TABLE `tbl_user_admin`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_account_codes`
--
ALTER TABLE `tbl_account_codes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=137;

--
-- AUTO_INCREMENT for table `tbl_activity`
--
ALTER TABLE `tbl_activity`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=99;

--
-- AUTO_INCREMENT for table `tbl_department_code`
--
ALTER TABLE `tbl_department_code`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `tbl_document_type`
--
ALTER TABLE `tbl_document_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tbl_earmarks`
--
ALTER TABLE `tbl_earmarks`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tbl_end_user`
--
ALTER TABLE `tbl_end_user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT for table `tbl_expenses_category`
--
ALTER TABLE `tbl_expenses_category`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `tbl_fund_cluster`
--
ALTER TABLE `tbl_fund_cluster`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `tbl_obligations`
--
ALTER TABLE `tbl_obligations`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tbl_payee`
--
ALTER TABLE `tbl_payee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tbl_program_projects`
--
ALTER TABLE `tbl_program_projects`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `tbl_project_categ`
--
ALTER TABLE `tbl_project_categ`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `tbl_project_sub_categ`
--
ALTER TABLE `tbl_project_sub_categ`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `tbl_prs`
--
ALTER TABLE `tbl_prs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `tbl_responsibility_center`
--
ALTER TABLE `tbl_responsibility_center`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=107;

--
-- AUTO_INCREMENT for table `tbl_sub_account_codes`
--
ALTER TABLE `tbl_sub_account_codes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=187;

--
-- AUTO_INCREMENT for table `tbl_user_admin`
--
ALTER TABLE `tbl_user_admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
