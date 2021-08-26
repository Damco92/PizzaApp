CREATE TABLE [dbo].[Transitions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[State] INT NOT NULL,
	[NextState] INT NOT NULL,
	CONSTRAINT FK_current_state FOREIGN KEY ([State]) REFERENCES [State](Id),
	CONSTRAINT FK_next_state FOREIGN KEY ([NextState]) REFERENCES [State](Id)
)
