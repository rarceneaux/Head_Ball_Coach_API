--create table Players(
--Id int not null Identity(1,1) Primary Key,
--[Name] varchar(50) not null,
--Position varchar(50) not null,
--FormationId int not null,
--JerseyNumber int not null
--)

--How to make a foreign key in table
create table Formations(
Id int not null Identity(1,1) Primary Key,
PlayId int,
FOREIGN KEY (PlayId) REFERENCES Plays(Id),
[Name] varchar(50) not null
)

create table Players(
Id int not null Identity(1,1) Primary Key,
[Name] varchar(50) not null,
Position varchar(50) not null,
FormationId int,
FOREIGN KEY (FormationId) REFERENCES Formations(Id),
JerseyNumber int
)

--insert into Plays(Name,TypeOfPlay)
--values('28 Buck Sweep Throw-Back Pass','Pass')

insert into Players(Name,Position,FormationId,JerseyNumber)
values('Henry','TB',1,22)


select*
from Players

update Players
set FormationId = 1
where Position = 'FB'


select Formations.Name as Package, Plays.Name as Play,  Players.Name, Players.Position
from Plays 
	join Formations on Plays.Id = Formations.PlayId
	join Players on Formations.Id = Players.FormationId


select*
from Plays
where TypeOfPlay = '@TypeOfPlay'

--add new play to table
insert into Plays(TypeOfPlay,Name)
                        output inserted.*
                        values('Pass','Hail Mary')

--get play by id
select*
from Plays
where Id = id