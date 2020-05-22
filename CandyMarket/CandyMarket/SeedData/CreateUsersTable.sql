CREATE TABLE Users
(
	UserId int identity,
	FirstName varchar(60) not null,
	LastName varchar(60) not null
);

INSERT INTO Users (FirstName, LastName)
VALUES 
	('Janet', 'Jackson'),
	('Cyndi', 'Lauper'),
	('Madonna', 'Ciccone'),
	('Cherilyn', 'Sarkisian'),
	('Tina', 'Turner');

SELECT *
FROM Users;