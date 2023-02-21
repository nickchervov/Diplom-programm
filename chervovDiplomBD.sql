use [kursDb]

CREATE TABLE Position(Id int IDENTITY(1,1) NOT NULL ,
						PositionName nvarchar(max) NOT NULL,
						Primary Key(Id))

CREATE TABLE Departments(Id int IDENTITY(1,1) NOT NULL,
						 DepartmentName nvarchar(max) NOT NULL,
						 Primary Key(Id))

CREATE TABLE TransportTypes(Id int IDENTITY(1,1) NOT NULL,
							TypesName nvarchar(max) NOT NULL,
							Primary Key(Id))

CREATE TABLE TransportStatus(Id int IDENTITY(1,1) NOT NULL,
							 StatusName nvarchar(max) NOT NULL,
							 Primary Key(Id))

CREATE TABLE Employees(Id int IDENTITY(1,1) NOT NULL,
					   Surname nvarchar(max) NOT NULL,					   
					   SecondName nvarchar(max) NOT NULL,
					   ThirdName nvarchar(max) NOT NULL,
					   PositionId int NOT NULL,
					   DepartmentId int NOT NULL,
					   "Login" nvarchar(15) NOT NULL,
					   "Password" nvarchar(15) NOT NULL,
					   Photo nvarchar(max) NOT NULL,
					   Primary Key(Id),
					   Foreign Key(PositionId) REFERENCES Position(Id),
					   Foreign Key(DepartmentId) REFERENCES Departments(Id))

CREATE TABLE Transport(Id int IDENTITY(1,1) NOT NULL,
					   Brand nvarchar(max) NOT NULL,
					   Model nvarchar(max) NOT NULL,
					   TransportTypeId int NOT NULL,
					   DepartmentsId int NOT NULL,
					   StatusId int NOT NULL,
					   GovNumber nvarchar(7) NOT NULL,
					   VinNumber nvarchar(17) NOT NULL,
					   Photo nvarchar(max) NOT NULL,	
					   Primary Key(Id),
					   Foreign Key(TransportTypeId) REFERENCES TransportTypes(Id),
					   Foreign Key(DepartmentsId) REFERENCES Departments(Id),
					   Foreign Key(StatusId) REFERENCES TransportStatus(id))

INSERT INTO Position VALUES ('Начальник')
INSERT INTO Position VALUES ('Директор')
INSERT INTO Position VALUES ('Администратор')
INSERT INTO Position VALUES ('Менеджер')
INSERT INTO Position VALUES ('Главный инженер')
INSERT INTO Position VALUES ('Инженер')

INSERT INTO Departments VALUES ('Ремонтный отдел')
INSERT INTO Departments VALUES ('Отдел логистики')
INSERT INTO Departments VALUES ('Отдел доставки')
INSERT INTO Departments VALUES ('Информационный отдел')
INSERT INTO Departments VALUES ('Совет директоров')

INSERT INTO TransportTypes VALUES ('Электрический')
INSERT INTO TransportTypes VALUES ('Внутреннего сгорания')
INSERT INTO TransportTypes VALUES ('Гибридный')

INSERT INTO TransportStatus VALUES ('Свободен')
INSERT INTO TransportStatus VALUES ('Занят')
INSERT INTO TransportStatus VALUES ('В ремонте')

INSERT INTO Employees VALUES ('Червов','Никита','Евгеньевич',3,4,'adm','adm','/Images/adm.png')
INSERT INTO Employees VALUES ('Прокопьев','Кирилл','Михайлович',1,1,'kir1','kir1','-')
INSERT INTO Employees VALUES ('Черненко','Дамир','Олегович',4,2,'dam1','dam1','-')
INSERT INTO Employees VALUES ('Череповцов','Евгений','Кириллович',4,3,'evg1','evg1','-')
INSERT INTO Employees VALUES ('Тополев','Роман','Алексеевич',4,4,'rom','rom','-')
INSERT INTO Employees VALUES ('Угорев','Алексей','Максимович',5,1,'ale1','ale1','-')
INSERT INTO Employees VALUES ('Романенко','Олег','Дамирович',6,1,'ole1','ole1','-')

INSERT INTO Transport VALUES ('Toyota','Camry',2,5,2,'Н000OН','ХТА21124070445066','/Images/camry.png')
INSERT INTO Transport VALUES ('Lexus','Lx500',2,5,2,'Л000НВ', 'ХТА34564070441222','/Images/lexus.png')
INSERT INTO Transport VALUES ('Газель','Next',2,2,3,'П561РВ', 'ХТА12124040405021','/Images/gaznext.png')
INSERT INTO Transport VALUES ('Газель','Next',2,3,2,'В719ОР', 'ХТА56114040405221','/Images/gaznext.png')
INSERT INTO Transport VALUES ('Газель','Next',2,3,1,'М101ПП', 'ХТА12124040405021','/Images/gaznext.png')
INSERT INTO Transport VALUES ('ГАЗ','3302',2,1,1,'У631ОР',    'ХТА01124070445012','/Images/gaz.png')
INSERT INTO Transport VALUES ('ГАЗ','3302',2,2,2,'П610НО',    'ХТА34124015415098','/Images/gaz.png')
INSERT INTO Transport VALUES ('ГАЗ','3302',2,3,2,'Л210ВВ',    'ХТА11526077091017','/Images/gaz.png')
INSERT INTO Transport VALUES ('КАМАЗ','65207',2,2,2,'Р671ПЕ', 'ХТА91524364141041','/Images/kamaz.png')
INSERT INTO Transport VALUES ('КАМАЗ','65207',2,2,2,'К601АА', 'ХТА11624174742041','/Images/kamaz.png')
INSERT INTO Transport VALUES ('КАМАЗ','65207',2,2,1,'И671КК', 'ХТА41324314144041','/Images/kamaz.png')
