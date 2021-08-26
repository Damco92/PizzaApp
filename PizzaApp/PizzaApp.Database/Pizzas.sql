CREATE TABLE [dbo].[Pizzas]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[PizzaTypeId] INT NOT NULL,
	[PizzaSizeId] INT NOT NULL,
	CONSTRAINT FK_pizza_type FOREIGN KEY (PizzaTypeId) REFERENCES PizzaType(Id),
	CONSTRAINT FK_pizza_size FOREIGN KEY (PizzaSizeId) REFERENCES PizzaSize(Id)
)
