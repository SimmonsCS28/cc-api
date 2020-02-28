CREATE USER CupcheckCancerApiReadWrite FOR LOGIN CupcheckCancerAdmin WITH DEFAULT_SCHEMA=[dbo]

-- SELECT *
-- FROM dbo.[User];

-- UPDATE dbo.[User]
-- SET LastModifiedUserId = 1
-- WHERE UserId = 1;
-- go

-- INSERT INTO dbo.[User]
-- (
--     Password,
--     FirstName,
--     LastName,
--     Email,
--     PhoneNumber,
--     TshirtSize,
--     CreatedDate,
--     LastModifiedDate
-- )
-- VALUES(
--     'RedFL0Gpe%%er$t!ck',
--     'Cole',
--     'Simmons',
--     'simmonscs28@gmail.com',
--     '608-843-4795',
--     'L',
--     CURRENT_TIMESTAMP,
--     CURRENT_TIMESTAMP
-- );

GRANT SELECT,UPDATE,INSERT,DELETE ON [User] TO CupcheckCancerApiReadWrite;

SELECT *
FROM [User];

DELETE
FROM [User]
WHERE TeamId = 14;

create table [User]
(
	UserId int identity
		constraint User_pk
			primary key nonclustered,
	TeamId int,
	Password VARCHAR(256),
	FirstName VARCHAR(256) not null,
	LastName VARCHAR(256) not null,
	Email VARCHAR(256) not null,
	VolunteerType TINYINT,
	PhoneNumber VARCHAR(25),
	TshirtSize VARCHAR (4),
	CreatedDate DATETIME not null,
	LastModifiedDate DATETIME not null,
	LastModifiedUserId int
)
go

create unique index User_Email_uindex
	on [User] (Email)
go

drop table [User]

GRANT SELECT,UPDATE,INSERT,DELETE ON Team TO CupcheckCancerApiReadWrite;

SELECT *
FROM Team;

DELETE 
FROM Team 
WHERE TeamId = 14;

create table Team
(
	TeamId INT identity
		constraint Team_pk
			primary key nonclustered,
	TournamentId INT not null,
	CaptainUserId int not null,
	TeamName VARCHAR (255) not null,
    PaymentTerm tinyint not null,
    PaymentDate DATETIME,
    PaymentMethod tinyint, 
	RegistrationDate DATETIME not null,
    LastModifiedDate DATETIME not null,
    LastModifiedUserId INT not null
)
go

create unique index Team_TeamName_uindex
	on Team (TeamName)
go

drop table Team

GRANT SELECT,UPDATE,INSERT,DELETE ON Tournament TO CupcheckCancerApiReadWrite;

create table Tournament
(
	TournamentId INT identity
		constraint Tournament_pk
			primary key nonclustered,
	TournamentScheduleId INT,
	TournamentStartDate DATETIME not null,
	TournamentEndDate DATETIME not null,
    TournamentMaxTeams INT not null,
    TournamentFeeAmount DECIMAL,
	CreationDate DATETIME not null,
    LastModifiedDate DATETIME not null,
    LastModifiedUserId INT not null
)
go

SELECT *
FROM dbo.Tournament;

UPDATE Tournament
SET TournamentScheduleId = 1
WHERE TournamentId = 1;

INSERT INTO Tournament
(
TournamentStartDate,
TournamentEndDate,
TournamentMaxTeams,
TournamentFeeAmount,
CreationDate,
LastModifiedDate,
LastModifiedUserId)
Values (
    '20200516 8:00:00 AM',
    '20200516 8:00:00 PM',
    8,
    300,
    CURRENT_TIMESTAMP,
    CURRENT_TIMESTAMP,
    1
    );
    go

GRANT SELECT,UPDATE,INSERT,DELETE ON TournamentSchedule TO CupcheckCancerApiReadWrite;

create table TournamentSchedule
(
	TournamentScheduleId INT identity
		constraint TournamentSchedule_pk
			primary key nonclustered,
	RinkScheduleId INT,
	CreationDate DATETIME not null,
    LastModifiedDate DATETIME not null,
    LastModifiedUserId INT not null
)
go

SELECT *
FROM dbo.TournamentSchedule;

INSERT INTO TournamentSchedule
(
RinkScheduleId,
CreationDate,
LastModifiedDate,
LastModifiedUserId)
Values (
    1,
    CURRENT_TIMESTAMP,
    CURRENT_TIMESTAMP,
    1
    );
    go

GRANT SELECT,UPDATE,INSERT,DELETE ON RinkSchedule TO CupcheckCancerApiReadWrite;

create table RinkSchedule
(
	RinkScheduleId INT identity
		constraint RinkSchedule_pk
			primary key nonclustered,
	RinkId  INT not null,
    GameId INT, 
	CreationDate DATETIME not null,
    LastModifiedDate DATETIME not null,
    LastModifiedUserId INT not null
)
go

INSERT INTO RinkSchedule
(
RinkId,
GameId,
CreationDate,
LastModifiedDate,
LastModifiedUserId)
Values (
    1,
    CURRENT_TIMESTAMP,
    CURRENT_TIMESTAMP,
    1
    );
    go

GRANT SELECT,UPDATE,INSERT,DELETE ON Rink TO CupcheckCancerApiReadWrite;

create table Rink
(
	RinkId INT identity
		constraint Rink_pk
			primary key nonclustered,
	RinkName  VARCHAR (256) not null,
	CreationDate DATETIME not null,
    LastModifiedDate DATETIME not null,
    LastModifiedUserId INT not null
)
go

 

INSERT INTO Rink
(
RinkName,
CreationDate,
LastModifiedDate,
LastModifiedUserId)
Values (
    'Tubbs',
    CURRENT_TIMESTAMP,
    CURRENT_TIMESTAMP,
    1
    );
    go


drop table Game

GRANT SELECT,UPDATE,INSERT,DELETE ON Game TO CupcheckCancerApiReadWrite;

create table Game
(
	GameId INT identity
		constraint Game_pk
			primary key nonclustered,
	TournamentId  INT not null,
    Team1TeamId INT not null,
    Team2TeamId INT not null,
    GameManagerUserId INT,
    GameStartTime DATETIME,
    GameEndTime DATETIME,
	WinningTeamId INT,
	LosingTeamId INT,
	Tie tinyint,
	CreationDate DATETIME not null,
    LastModifiedDate DATETIME not null,
    LastModifiedUserId INT not null
)
go

GRANT SELECT,UPDATE,INSERT,DELETE ON AccessRole TO CupcheckCancerApiReadWrite;

create table AccessRole
(
	AccessRoleId INT identity
		constraint AccessRole_pk
			primary key nonclustered,
	[Name]  VARCHAR (256) not null,
	CreationDate DATETIME not null,
    LastModifiedDate DATETIME not null,
    LastModifiedUserId INT not null
)
go

GRANT SELECT,UPDATE,INSERT,DELETE ON UserAccessRoleXref TO CupcheckCancerApiReadWrite;

create table UserAccessRoleXref
(
	UserId INT identity
		constraint UserAccessRoleXref_pk
			primary key nonclustered,
	AccessRoleId  INT not null,
	CreationDate DATETIME not null,
    CreatedByUserId INT not null,
    LastModifiedDate DATETIME not null,
    LastModifiedUserId INT not null
)
go

drop table UserAccessRoleXref

GRANT SELECT,UPDATE,INSERT,DELETE ON UserType TO CupcheckCancerApiReadWrite;

SELECT *
FROM UserType;

create table UserType
(
	UserTypeId INT identity
		constraint UserType_pk
			primary key nonclustered,
	[Description]  VARCHAR (256) not null,
	CreationDate DATETIME not null,
    LastModifiedDate DATETIME not null,
    LastModifiedUserId INT not null
)
go

INSERT INTO UserType ([Description], CreationDate, LastModifiedDate, LastModifiedUserId)
VALUES ('RegistrationCheckInTable', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1)


