CREATE TABLE Candies
(
	CandyId int identity,
	CandyName varchar(60) NOT NULL,
	Manufacturer varchar(60) NOT NULL,
	FlavorCategory varchar(60) NOT NULL
);

select *
from Candies;

INSERT INTO Candies (CandyName, Manufacturer, FlavorCategory)
VALUES
	('Skittles Original', 'Mars, Inc.', 'Fruity'),
	('Skittles Sour', 'Mars, Inc.', 'Sour Fruit'),
	('M&M Original', 'Mars, Inc.', 'Chocolate'),
	('M&M Caramel', 'Mars, Inc.', 'Chocolate'),
	('Snickers', 'Mars, Inc.', 'Chocolate'),
	('Jelly Belly Original Jelly Beans', 'Jelly Belly', 'Jelly Beans'),
	('Bean Boozled', 'Jelly Belly', 'Weird and Unusual'),
	('Laffy Taffy', 'Nestle', 'Fruity'),
	('Life Saver Gummy Rings Original', 'Wrigley', 'Gummies'),
	('Sour Patch Kids', 'Mondelez', 'Sour'),
	('Jolly Rancher Original', 'Hershey', 'Hard Candy'),
	('Haribo Goldbears', 'Haribo', 'Gummies'),
	('Haribo Starmix', 'Haribo', 'Gummies')
;

select *
from Candies;