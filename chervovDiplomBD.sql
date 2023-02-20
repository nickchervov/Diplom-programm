use [deuser5]

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
					   Primary Key(Id),
					   Foreign Key(TransportTypeId) REFERENCES TransportTypes(Id),
					   Foreign Key(DepartmentsId) REFERENCES Departments(Id))

INSERT INTO Position VALUES ('Инженер')
INSERT INTO Position VALUES ('Директор')
INSERT INTO Position VALUES ('Начальник')
INSERT INTO Position VALUES ('Менеджер')
INSERT INTO Position VALUES ('Главный инженер')

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

INSERT INTO Employees VALUES ('Червов','Никита','Евгеньевич',2,5,'adm','adm','/Images/adm.png')

INSERT INTO Transport VALUES ('Toyota','Camry',2,5,2,'G000OV','ХТА21124070445066')