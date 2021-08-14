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


