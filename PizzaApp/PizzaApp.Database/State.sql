CREATE TABLE [dbo].[State]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[StateTypeId] INT NOT NULL,
	[Name] NVARCHAR(50),
	[Description] NVARCHAR(200),
	CONSTRAINT FK_state_type FOREIGN KEY ([StateTypeId]) REFERENCES StateType(Id)
)
