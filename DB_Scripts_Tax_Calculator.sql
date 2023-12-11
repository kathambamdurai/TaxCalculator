IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'TaxCalculator')
  BEGIN
    CREATE DATABASE [TaxCalculator]
    END
GO

USE [TaxCalculator]
GO

CREATE TABLE [dbo].[PostalCodeDetails](
	[PostalCodeId] [int] NOT NULL,
	[PostalCodeName] [nvarchar](10) NULL,
	[TaxCalculationTypeId] [int] NULL,
 CONSTRAINT [PK_PostalCodeDetails] PRIMARY KEY CLUSTERED 
(
	[PostalCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgressiveTax]    Script Date: 12/5/2023 1:34:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgressiveTax](
	[ProgressiveTaxId] [int] IDENTITY(1,1) NOT NULL,
	[TaxPercentage] [decimal](5, 2) NULL,
	[FromAmount] [decimal](10, 2) NULL,
	[ToAmount] [decimal](10, 2) NULL,
 CONSTRAINT [PK_ProgressiveTax] PRIMARY KEY CLUSTERED 
(
	[ProgressiveTaxId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxCalculationDetails]    Script Date: 12/5/2023 1:34:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxCalculationDetails](
	[TaxCalculationId] [int] IDENTITY(1,1) NOT NULL,
	[AnnualIncome] [decimal](10, 2) NULL,
	[PostalCodeId] [int] NULL,
	[TaxAmount] [decimal](10, 2) NULL,
	[CalculatedOn] [datetime] NULL,
 CONSTRAINT [PK_TaxCalculationDetails] PRIMARY KEY CLUSTERED 
(
	[TaxCalculationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxCalculationType]    Script Date: 12/5/2023 1:34:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxCalculationType](
	[TaxCalculationTypeId] [int] NOT NULL,
	[TaxCalculationTypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaxCalculationType] PRIMARY KEY CLUSTERED 
(
	[TaxCalculationTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[PostalCodeDetails] ([PostalCodeId], [PostalCodeName], [TaxCalculationTypeId]) VALUES (1, N'7441', 1)
GO
INSERT [dbo].[PostalCodeDetails] ([PostalCodeId], [PostalCodeName], [TaxCalculationTypeId]) VALUES (2, N'A100', 2)
GO
INSERT [dbo].[PostalCodeDetails] ([PostalCodeId], [PostalCodeName], [TaxCalculationTypeId]) VALUES (3, N'7000', 3)
GO
INSERT [dbo].[PostalCodeDetails] ([PostalCodeId], [PostalCodeName], [TaxCalculationTypeId]) VALUES (4, N'1000', 1)
GO
SET IDENTITY_INSERT [dbo].[ProgressiveTax] ON 
GO
INSERT [dbo].[ProgressiveTax] ([ProgressiveTaxId], [TaxPercentage], [FromAmount], [ToAmount]) VALUES (1, CAST(10.00 AS Decimal(5, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(8350.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[ProgressiveTax] ([ProgressiveTaxId], [TaxPercentage], [FromAmount], [ToAmount]) VALUES (2, CAST(15.00 AS Decimal(5, 2)), CAST(8351.00 AS Decimal(10, 2)), CAST(33950.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[ProgressiveTax] ([ProgressiveTaxId], [TaxPercentage], [FromAmount], [ToAmount]) VALUES (3, CAST(25.00 AS Decimal(5, 2)), CAST(33951.00 AS Decimal(10, 2)), CAST(82250.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[ProgressiveTax] ([ProgressiveTaxId], [TaxPercentage], [FromAmount], [ToAmount]) VALUES (4, CAST(28.00 AS Decimal(5, 2)), CAST(82251.00 AS Decimal(10, 2)), CAST(171550.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[ProgressiveTax] ([ProgressiveTaxId], [TaxPercentage], [FromAmount], [ToAmount]) VALUES (5, CAST(33.00 AS Decimal(5, 2)), CAST(171551.00 AS Decimal(10, 2)), CAST(372950.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[ProgressiveTax] ([ProgressiveTaxId], [TaxPercentage], [FromAmount], [ToAmount]) VALUES (6, CAST(35.00 AS Decimal(5, 2)), CAST(372951.00 AS Decimal(10, 2)), NULL)
GO
SET IDENTITY_INSERT [dbo].[ProgressiveTax] OFF
GO
INSERT [dbo].[TaxCalculationType] ([TaxCalculationTypeId], [TaxCalculationTypeName]) VALUES (1, N'Progressive')
GO
INSERT [dbo].[TaxCalculationType] ([TaxCalculationTypeId], [TaxCalculationTypeName]) VALUES (2, N'Flat Value')
GO
INSERT [dbo].[TaxCalculationType] ([TaxCalculationTypeId], [TaxCalculationTypeName]) VALUES (3, N'Flat rate')
GO
ALTER TABLE [dbo].[PostalCodeDetails]  WITH CHECK ADD  CONSTRAINT [FK_PostalCodeDetails_TaxCalculationType] FOREIGN KEY([TaxCalculationTypeId])
REFERENCES [dbo].[TaxCalculationType] ([TaxCalculationTypeId])
GO
ALTER TABLE [dbo].[PostalCodeDetails] CHECK CONSTRAINT [FK_PostalCodeDetails_TaxCalculationType]
GO
