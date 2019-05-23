CREATE TABLE [dbo].[UserDemo](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](200) NULL,
	[Password] [varchar](200) NULL,
	[Discribe] [varchar](800) NULL,
	[SubmitTime] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [dbo].[UserDemo]
           ([UserName]
           ,[Password]
           ,[Discribe]
           ,[SubmitTime])
     VALUES
           ('小新'
           ,'123456'
           ,'作者博客地址：https://www.jianshu.com/u/3caeff0e589d'
           ,GETDATE())
GO


