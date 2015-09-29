USE [AdoExecutorTestDb]
GO
/****** Object:  Table [dbo].[TestDbType]    Script Date: 3/3/2015 7:51:43 PM ******/
DROP TABLE [dbo].[TestDbType]
GO
/****** Object:  Table [dbo].[TestDbType]    Script Date: 3/3/2015 7:51:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestDbType](
	[Id] [uniqueidentifier] NOT NULL,
	[BigInt] [bigint] NULL,
	[Binary50] [binary](50) NULL,
	[Bit] [bit] NULL,
	[Char10] [char](10) COLLATE Polish_CI_AS NULL,
	[Date] [date] NULL,
	[DateTime] [datetime] NULL,
	[DateTime2] [datetime2](7) NULL,
	[DateTimeOffset] [datetimeoffset](7) NULL,
	[Decimal] [decimal](18, 5) NULL,
	[Float] [float] NULL,
	[Image] [image] NULL,
	[Int] [int] NULL,
	[Money] [money] NULL,
	[NChar10] [nchar](10) COLLATE Polish_CI_AS NULL,
	[NText] [ntext] COLLATE Polish_CI_AS NULL,
	[Numeric] [numeric](18, 5) NULL,
	[NVarchar50] [nvarchar](50) COLLATE Polish_CI_AS NULL,
	[Real] [real] NULL,
	[SmallDateTime] [smalldatetime] NULL,
	[SmallInt] [smallint] NULL,
	[SmallMoney] [smallmoney] NULL,
	[Text] [text] COLLATE Polish_CI_AS NULL,
	[Time] [time](7) NULL,
	[TinyInt] [tinyint] NULL,
	[Uniqueidentifier] [uniqueidentifier] NULL,
	[Varbinary50] [varbinary](50) NULL,
	[Varchar50] [varchar](50) COLLATE Polish_CI_AS NULL,
	[Xml] [xml] NULL,
 CONSTRAINT [PK_TestDbType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[TestDbType] ([Id], [BigInt], [Binary50], [Bit], [Char10], [Date], [DateTime], [DateTime2], [DateTimeOffset], [Decimal], [Float], [Image], [Int], [Money], [NChar10], [NText], [Numeric], [NVarchar50], [Real], [SmallDateTime], [SmallInt], [SmallMoney], [Text], [Time], [TinyInt], [Uniqueidentifier], [Varbinary50], [Varchar50], [Xml]) VALUES (N'cdfc5a0b-74b4-4322-ae68-12a76a30aa09', 5643765856, 0xABCDFE0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, 0, N'testChar2 ', CAST(0x68340B00 AS Date), CAST(0x00009ED100C96378 AS DateTime), CAST(0x07148DCA6E662C340B AS DateTime2), CAST(0x0714BD41AB552C340B7800 AS DateTimeOffset), CAST(543249.36548 AS Decimal(18, 5)), 4564.4858, 0x57897435454565, 897698, 156.2574, N'testNChar2', N'testNText2', CAST(876.54354 AS Numeric(18, 5)), N'testNVarchar2', 65877.57, CAST(0xA35502A3 AS SmallDateTime), 765, 342.6547, N'testText2', CAST(0x0780DD1157B10000 AS Time), 232, N'ce9c740e-0ef6-48b5-8608-5fc93e3e92e7', 0x2F4B5A, N'testVarchar2', N'<test>564</test>')
GO
INSERT [dbo].[TestDbType] ([Id], [BigInt], [Binary50], [Bit], [Char10], [Date], [DateTime], [DateTime2], [DateTimeOffset], [Decimal], [Float], [Image], [Int], [Money], [NChar10], [NText], [Numeric], [NVarchar50], [Real], [SmallDateTime], [SmallInt], [SmallMoney], [Text], [Time], [TinyInt], [Uniqueidentifier], [Varbinary50], [Varchar50], [Xml]) VALUES (N'9aa3b743-0a67-4274-8470-f7e978ddc930', 54354354, 0xABCDEF0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, 1, N'testChar1 ', CAST(0x8F390B00 AS Date), CAST(0x0000A43400F8AC67 AS DateTime), CAST(0x07A6EB5A7B7E8F390B AS DateTime2), CAST(0x07706E9619768F390B3C00 AS DateTimeOffset), CAST(54.43243 AS Decimal(18, 5)), 214535.43, 0x57B3ACC5454565, 4321, 126.1400, N'testNChar1', N'testNText1', CAST(43254.65400 AS Numeric(18, 5)), N'testNVarchar1', 654654.563, CAST(0xA43D0569 AS SmallDateTime), 169, 3123.4320, N'testText1', CAST(0x0780E1C886C10000 AS Time), 168, N'270e8267-aa79-4e43-8910-ea45abe62487', 0xAEFDCB, N'testVarchar1', N'<test>5</test>')
GO

CREATE PROCEDURE [dbo].[spTestDbType]
	@BigInt [bigint],
	@Binary50 [binary](50),
	@Bit [bit],
	@Char10 [char](10),
	@Date [date],
	@DateTime [datetime],
	@DateTime2 [datetime2](7),
	@DateTimeOffset [datetimeoffset](7),
	@Decimal [decimal](18, 5),
	@Float [float],
	@Image [image],
	@Int [int],
	@Money [money],
	@NChar10 [nchar](10),
	@NText [ntext],
	@Numeric [numeric](18, 5),
	@NVarchar50 [nvarchar](50),
	@Real [real],
	@SmallDateTime [smalldatetime],
	@SmallInt [smallint],
	@SmallMoney [smallmoney],
	@Text [text],
	@Time [time](7),
	@TinyInt [tinyint],
	@Uniqueidentifier [uniqueidentifier],
	@Varbinary50 [varbinary](50),
	@Varchar50 [varchar](50),
	@Xml [xml]
AS
BEGIN


CREATE TABLE #temp (
	[BigInt] [bigint] NULL,
	[Binary50] [binary](50) NULL,
	[Bit] [bit] NULL,
	[Char10] [char](10) NULL,
	[Date] [date] NULL,
	[DateTime] [datetime] NULL,
	[DateTime2] [datetime2](7) NULL,
	[DateTimeOffset] [datetimeoffset](7) NULL,
	[Decimal] [decimal](18, 5) NULL,
	[Float] [float] NULL,
	[Image] [image] NULL,
	[Int] [int] NULL,
	[Money] [money] NULL,
	[NChar10] [nchar](10) NULL,
	[NText] [ntext] NULL,
	[Numeric] [numeric](18, 5) NULL,
	[NVarchar50] [nvarchar](50) NULL,
	[Real] [real] NULL,
	[SmallDateTime] [smalldatetime] NULL,
	[SmallInt] [smallint] NULL,
	[SmallMoney] [smallmoney] NULL,
	[Text] [text] NULL,
	[Time] [time](7) NULL,
	[TinyInt] [tinyint] NULL,
	[Uniqueidentifier] [uniqueidentifier] NULL,
	[Varbinary50] [varbinary](50) NULL,
	[Varchar50] [varchar](50) NULL,
	[Xml] [xml] NULL)


INSERT INTO #temp(
            [BigInt]
           ,[Binary50]
           ,[Bit]
           ,[Char10]
           ,[Date]
           ,[DateTime]
           ,[DateTime2]
           ,[DateTimeOffset]
           ,[Decimal]
           ,[Float]
           ,[Image]
           ,[Int]
           ,[Money]
           ,[NChar10]
           ,[NText]
           ,[Numeric]
           ,[NVarchar50]
           ,[Real]
           ,[SmallDateTime]
           ,[SmallInt]
           ,[SmallMoney]
           ,[Text]
           ,[Time]
           ,[TinyInt]
           ,[Uniqueidentifier]
           ,[Varbinary50]
           ,[Varchar50]
           ,[Xml])
     VALUES
           (@BigInt
           ,@Binary50
           ,@Bit
           ,@Char10
           ,@Date
           ,@DateTime
           ,@DateTime2
           ,@DateTimeOffset
           ,@Decimal
           ,@Float
           ,@Image
           ,@Int
           ,@Money
           ,@NChar10
           ,@NText
           ,@Numeric
           ,@NVarchar50
           ,@Real
           ,@SmallDateTime
           ,@SmallInt
           ,@SmallMoney
           ,@Text
           ,@Time
           ,@TinyInt
           ,@Uniqueidentifier
           ,@Varbinary50
           ,@Varchar50
           ,@Xml)

select * 
from #temp

END

GO


