USE [Movie]
GO


 

IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Movies]')  AND type IN ( N'U' ) )  DROP TABLE [Movies] 
 


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[ID] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[ID] ASC) ON [PRIMARY],
	[Title] [nvarchar](50) NULL,  
	[Genre] [nvarchar](50) NULL, 
	[Price] [money] NULL, 
	[Rating] [nvarchar](5) NULL,  
	[CreatedAt] [datetime] not null default(getdate()) ,
	[UpdatedAt] [datetime]  not null default(getdate()) 
	) ON [PRIMARY]
GO
INSERT INTO  [Movies] ([Title], [Genre], [Price], [Rating]) VALUES  ('The Lost Boys', 'Action', 3.99, 'G'  ) 
INSERT INTO  [Movies] ([Title], [Genre], [Price], [Rating]) VALUES  ('When Harry Met Sally', 'Romantic Comedy', 3.99, 'G'  ) 
INSERT INTO  [Movies] ([Title], [Genre], [Price], [Rating]) VALUES  ('Raiders of the lost arc', 'Action', 3.99, 'G'  ) 
INSERT INTO  [Movies] ([Title], [Genre], [Price], [Rating]) VALUES  ('Ghostbusters', 'Comedy', 4.99, 'G'  )  
INSERT INTO  [Movies] ([Title], [Genre], [Price], [Rating]) VALUES  ('Ghostbusters 2', 'Comedy', 2.99, 'G'  )  
INSERT INTO  [Movies] ([Title], [Genre], [Price], [Rating]) VALUES  ('Spaceballs', 'Comedy', 7.99, 'G'  )  
  