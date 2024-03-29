USE [Sample]
GO
/****** Object:  Table [dbo].[OrderType]    Script Date: 03-Sep-19 10:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderType](
	[OrderCode] [nvarchar](50) NOT NULL,
	[OrderName] [nvarchar](50) NULL,
	[SpecimenType] [nvarchar](50) NULL,
 CONSTRAINT [PK_OrderType] PRIMARY KEY CLUSTERED 
(
	[OrderCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Patient]    Script Date: 03-Sep-19 10:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[MedicalRecordNumber] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[Address] [nvarchar](150) NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[MedicalRecordNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PatientOrder]    Script Date: 03-Sep-19 10:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientOrder](
	[PatientOrderId] [int] NOT NULL,
	[CreationDate] [datetime] NULL,
	[PatientId] [int] NULL,
	[OrderCode] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_PatientOrder] PRIMARY KEY CLUSTERED 
(
	[PatientOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100116', N'Basic Metabolic Panel', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100120', N'Comprehensive Metabolic', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100121', N'Electrolyte Panel', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100124', N'General Chemistry 13', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100125', N'General Chemistry 6', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100129', N'Hematology', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100130', N'Kidney Check', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100131', N'Lipid Panel', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100132-IH', N'Lipid Panel Plus', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100133', N'Liver Panel Plus', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100134', N'MetLyte 8 Panel', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100135', N'Renal Function Panel', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100137', N'Vitamin D', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100138', N'Total PSA', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'-100139', N'TSH', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100140', N'Urinalysis', N'Urine')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100141', N'Microalbumin', N'Urine')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100152', N'Testosterone', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100153', N'Basic Metabolic Panel Plus', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100154', N'Albumin Creatinine Ratio', N'Urine')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100155', N'Hemoglobin A1c', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100156', N'hCG, Urine', N'Urine')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100157', N'hCG, Serum', N'Serum')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100158', N'Hemoglobin', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100159', N'Influenza A + B', N'Swab')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100160', N'Strep A+', N'Swab')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100161', N'Respiratory Syncytial Virus (RSV)', N'Swab')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100162', N'HSV 1 + 2 and VZV', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100165', N'RSV + hMPV', N'Swab')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100166', N'C. difficile', N'Stool')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'100210B', N'D-Dimer', N'Blood')
INSERT [dbo].[OrderType] ([OrderCode], [OrderName], [SpecimenType]) VALUES (N'1002-9', N'Cardiac Panel', N'Blood')
INSERT [dbo].[Patient] ([MedicalRecordNumber], [FirstName], [LastName], [DateOfBirth], [Address]) VALUES (123087, N'Rajesh', N'Kumar', CAST(N'2009-06-16 00:00:00.000' AS DateTime), N'Main Street')
INSERT [dbo].[Patient] ([MedicalRecordNumber], [FirstName], [LastName], [DateOfBirth], [Address]) VALUES (123986, N'ABCDEF', N'XYZ', CAST(N'2011-09-11 00:00:00.000' AS DateTime), N'Juhu')
INSERT [dbo].[PatientOrder] ([PatientOrderId], [CreationDate], [PatientId], [OrderCode], [Status]) VALUES (1, CAST(N'2019-08-21 00:00:00.000' AS DateTime), 123986, N'100116', N'Performed')
INSERT [dbo].[PatientOrder] ([PatientOrderId], [CreationDate], [PatientId], [OrderCode], [Status]) VALUES (2, CAST(N'2019-08-29 00:00:00.000' AS DateTime), 123986, N'100116', N'Requested')
