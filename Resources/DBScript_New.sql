USE [SJSUParking]
GO
/****** Object:  User [admin]    Script Date: 11/30/2013 5:48:31 PM ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[ParkingSlot]    Script Date: 11/30/2013 5:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ParkingSlot](
	[garage_name] [varchar](50) NOT NULL,
	[slot_number] [varchar](50) NOT NULL,
	[floor] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ParkingSpace] PRIMARY KEY CLUSTERED 
(
	[slot_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Permit]    Script Date: 11/30/2013 5:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permit](
	[SJSUId] [varchar](50) NOT NULL,
	[permit_type] [varchar](50) NOT NULL,
	[start_date] [varchar](50) NOT NULL,
	[end_date] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 11/30/2013 5:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reservation](
	[SJSUId] [varchar](50) NOT NULL,
	[garage_name] [varchar](50) NOT NULL,
	[slot_number] [varchar](50) NOT NULL,
	[date] [varchar](50) NOT NULL,
	[start_time] [varchar](50) NOT NULL,
	[end_time] [varchar](50) NOT NULL,
	[reservation_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[reservation_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/30/2013 5:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[SJSUID] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[DrivingLicNo] [varchar](50) NOT NULL,
	[Type] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
