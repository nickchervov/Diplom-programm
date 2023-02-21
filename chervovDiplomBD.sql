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

INSERT INTO Position VALUES ('���������')
INSERT INTO Position VALUES ('��������')
INSERT INTO Position VALUES ('�������������')
INSERT INTO Position VALUES ('��������')
INSERT INTO Position VALUES ('������� �������')
INSERT INTO Position VALUES ('�������')

INSERT INTO Departments VALUES ('��������� �����')
INSERT INTO Departments VALUES ('����� ���������')
INSERT INTO Departments VALUES ('����� ��������')
INSERT INTO Departments VALUES ('�������������� �����')
INSERT INTO Departments VALUES ('����� ����������')

INSERT INTO TransportTypes VALUES ('�������������')
INSERT INTO TransportTypes VALUES ('����������� ��������')
INSERT INTO TransportTypes VALUES ('���������')

INSERT INTO TransportStatus VALUES ('��������')
INSERT INTO TransportStatus VALUES ('�����')
INSERT INTO TransportStatus VALUES ('� �������')

INSERT INTO Employees VALUES ('������','������','����������',3,4,'adm','adm','/Images/adm.png')
INSERT INTO Employees VALUES ('���������','������','����������',1,1,'kir1','kir1','-')
INSERT INTO Employees VALUES ('��������','�����','��������',4,2,'dam1','dam1','-')
INSERT INTO Employees VALUES ('����������','�������','����������',4,3,'evg1','evg1','-')
INSERT INTO Employees VALUES ('�������','�����','����������',4,4,'rom','rom','-')
INSERT INTO Employees VALUES ('������','�������','����������',5,1,'ale1','ale1','-')
INSERT INTO Employees VALUES ('���������','����','���������',6,1,'ole1','ole1','-')

INSERT INTO Transport VALUES ('Toyota','Camry',2,5,2,'�000O�','���21124070445066','/Images/camry.png')
INSERT INTO Transport VALUES ('Lexus','Lx500',2,5,2,'�000��', '���34564070441222','/Images/lexus.png')
INSERT INTO Transport VALUES ('������','Next',2,2,3,'�561��', '���12124040405021','/Images/gaznext.png')
INSERT INTO Transport VALUES ('������','Next',2,3,2,'�719��', '���56114040405221','/Images/gaznext.png')
INSERT INTO Transport VALUES ('������','Next',2,3,1,'�101��', '���12124040405021','/Images/gaznext.png')
INSERT INTO Transport VALUES ('���','3302',2,1,1,'�631��',    '���01124070445012','/Images/gaz.png')
INSERT INTO Transport VALUES ('���','3302',2,2,2,'�610��',    '���34124015415098','/Images/gaz.png')
INSERT INTO Transport VALUES ('���','3302',2,3,2,'�210��',    '���11526077091017','/Images/gaz.png')
INSERT INTO Transport VALUES ('�����','65207',2,2,2,'�671��', '���91524364141041','/Images/kamaz.png')
INSERT INTO Transport VALUES ('�����','65207',2,2,2,'�601��', '���11624174742041','/Images/kamaz.png')
INSERT INTO Transport VALUES ('�����','65207',2,2,1,'�671��', '���41324314144041','/Images/kamaz.png')
