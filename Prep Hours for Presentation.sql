USE [TimeTracker]
GO

DELETE FROM [dbo].[Hours]
GO

INSERT INTO [dbo].[Hours]
           ([UserID]
           ,[ActivityID]
           ,[Year]
           ,[Week]
           ,[Hours])
     VALUES
           ('JASSOW','1',2016,39,0),
		   ('JASSOW','2',2016,39,0),
		   ('JASSOW','3',2016,39,0),
		   ('JASSOW','4',2016,39,0),
		   ('JASSOW','5',2016,39,0),
		   ('JASSOW','8',2016,39,28),
		   ('JASSOW','9',2016,39,0),
		   ('JASSOW','10',2016,39,0)	   
GO


