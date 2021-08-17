CREATE TABLE Games(
	GameId int PRIMARY KEY IDENTITY(1,1),
	Descriptions nvarchar(800),
	ReleaseDate DateTime
	);


CREATE TABLE Users(
	UserId int PRIMARY KEY IDENTITY(1,1),
	FirstName nvarchar(255),
	LastName nvarchar(255),
	Email nvarchar(100),
	Password nvarchar(100)
	);

CREATE TABLE Customers(
	CustomerId int PRIMARY KEY IDENTITY(1,1),
	UserId int,
	CompanyName nvarchar(255),
	FOREIGN KEY (UserId) REFERENCES Users(UserId)
	);

CREATE TABLE Sales(
	SalesId int PRIMARY KEY IDENTITY(1,1),
	GameId int, 
	CustomerId int,
	FOREIGN KEY (GameId) REFERENCES Games(GameId),
	FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
	);

	DROP TABLE Sales;

	INSERT INTO Games(Descriptions, ReleaseDate, GameName) 
	VALUES('this is a game', 2021-02-03, 'Outlast');
	
	INSERT INTO Customers(UserId, CompanyName, CustomerName)
	VALUES (1, 'Özkaynak', 'Işıl');

	INSERT INTO Users (FirstName, LastName, Email, Password)
	VALUES('Işıl', 'Özkaynak', 'isil@gmail.com', '123456');

	INSERT INTO Sales(GameId, CustomerId) VALUES(1,1);