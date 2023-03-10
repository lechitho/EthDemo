USE [EthDemo]
GO
/****** Object:  Table [dbo].[Blocks]    Script Date: 12/27/2022 8:45:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blocks](
	[blockID] [int] IDENTITY(1,1) NOT NULL,
	[blockNumber] [int] NULL,
	[hash] [varchar](66) NULL,
	[parentHash] [varchar](66) NULL,
	[miner] [varchar](42) NULL,
	[blockReward] [decimal](38, 0) NULL,
	[gasLimit] [decimal](38, 0) NULL,
	[gasUsed] [decimal](38, 0) NULL,
 CONSTRAINT [PK_Blocks] PRIMARY KEY CLUSTERED 
(
	[blockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 12/27/2022 8:45:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[transactionID] [int] IDENTITY(1,1) NOT NULL,
	[blockID] [int] NULL,
	[hash] [varchar](66) NULL,
	[from] [varchar](42) NULL,
	[to] [varchar](42) NULL,
	[value] [decimal](38, 0) NULL,
	[gas] [decimal](38, 0) NULL,
	[gasPrice] [decimal](38, 0) NULL,
	[transactionIndex] [int] NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[transactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_TransactionsBlocks] FOREIGN KEY([blockID])
REFERENCES [dbo].[Blocks] ([blockID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_TransactionsBlocks]
GO
