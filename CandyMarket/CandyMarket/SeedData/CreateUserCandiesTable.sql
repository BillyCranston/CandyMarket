CREATE TABLE UserCandies
(
	UserCandyId int identity(1,1),
	CandyId int not null,
	UserId int not null,
	DateReceived datetime not null,
	isConsumed bit not null,
);

INSERT INTO UserCandies (CandyId, UserId, DateReceived, isConsumed)
VALUES
	(3, 3,'2020-03-30', 0),
	(3, 4, '2020-04-04', 0),
	(2, 4, '2020-04-04', 0),
	(4, 4, '2020-04-04', 0),
	(5, 4, '2020-04-04', 0),
	(3, 5, '2020-05-05', 0),
	(3, 5, '2020-05-05', 0),
	(3, 5, '2020-05-05', 0)
	(2, 5, '2020-05-05', 0);

SELECT *
FROM UserCandies;
