CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[TimeSubmited] DATETIME NULL,
	[IsDelivered] BIT NOT NULL,
	[PizzaId] INT NOT NULL,
	[State] INT NOT NULL,
	[IsDeleted] BIT NOT NULL
	CONSTRAINT FK_pizza FOREIGN KEY ([PizzaId]) REFERENCES Pizzas(Id),
	CONSTRAINT FK_order_state FOREIGN KEY ([State]) REFERENCES [State](Id)
)
