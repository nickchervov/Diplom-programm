USE [diplomDb]
                                         
                       
                       
CREATE TABLE DriverLicense ("id" int Identity (1,1) NOT NULL,
                            seriesNumber varchar(12),
                            receiptDate date,
                            endDate date,
                            Primary Key("id"));
CREATE TABLE LicenseClasses ( "id" int Identity (1,1) NOT NULL,
                              "name" varchar(2) NOT NULL,
                              Primary Key("id"));                                                     
CREATE TABLE DriverLicenseClass(id int Identity (1,1) NOT NULL,
								licenseId int NOT NULL,
                                classId int NOT NULL,
								Primary Key(id),
                                Foreign Key(classId) REFERENCES LicenseClasses("id"),
                                Foreign Key (licenseId) REFERENCES DriverLicense("id"));
--CREATE TABLE Drivers (iddri int NOT NULL,
--                      personId int NOT NULL UNIQUE,
--                      licenseId int NOT NULL UNIQUE,
--                      Primary Key(iddri),
--                      Foreign Key (personId) REFERENCES Personal("id"),
--                      Foreign Key (licenseId) REFERENCES DriverLicense("id"));                           

CREATE TABLE org("id" int Identity (1,1) NOT NULL,
                 "name" varchar(70) NOT NULL,
                 country varchar(60) NOT NULL,
                 postcode varchar(6) NOT NULL,
                 city varchar(60) NOT NULL,
                 street varchar(100) NOT NULL,
                 Primary Key("id"));
                     
CREATE TABLE Departments ("id" int Identity (1,1) NOT NULL,
                          "name" varchar(60) NOT NULL,
                          orgId int NOT NULL,
                          Primary Key("id"),
                          Foreign Key(orgId) REFERENCES org("id"));

CREATE TABLE Personal ("id" int Identity (1,1) NOT NULL,
                       tabNumber int NOT NULL,
                       FIO varchar(60) NOT NULL,
                       position varchar(100) NOT NULL,
					   departmentId int NOT NULL,
                       age int NOT NULL,
                       pol varchar(2) NOT NULL,
					   idVU int NOT NULL,
                       isDri bit NOT NULL,
                       isDis bit NOT NULL,
					   isAdm bit NOT NULL,
					   isPer bit NOT NULL,
					   isSer bit NOT NULL,
                       Primary Key("id"),
					   Foreign Key(departmentId) REFERENCES Departments("id"),
					   Foreign Key(idVU) REFERENCES DriverLicense("id"));
                       
CREATE TABLE Auth("id" int Identity (1,1) NOT NULL,
                  personId int NOT NULL UNIQUE,
             	  "login" varchar(20) NOT NULL UNIQUE,
                  "password" varchar(20) NOT NULL,
                  Primary Key("id"),
                  Foreign Key(personId) REFERENCES Personal("id"));
                                
--CREATE TABLE PersonalsDepartments(id int Identity (1,1),
--								  personId int NOT NULL,
--             	                  departmentId int NOT NULL,
--								  Primary Key(id),
--                                  Foreign Key(personId) REFERENCES Personal("id"),
--                                  Foreign Key(departmentId) REFERENCES Departments("id"));

--CREATE TABLE Dispatchers (idDis int Identity (1,1) NOT NULL,
--                          personId int NOT NULL UNIQUE,
--                          Primary Key(idDis),
--                          Foreign Key (personId) REFERENCES Personal("id"));    
                       
CREATE TABLE TsTypes("id" int Identity (1,1) NOT NULL,
                     "name" varchar(60) NOT NULL,
                     Primary Key("id"));
					 
CREATE TABLE TsStatus(id int Identity (1,1) NOT NULL,
					  statusName varchar(100) NOT NULL,
					  Primary Key(id));

CREATE TABLE Photos (URLPhoto varchar(100) NOT NULL,
					codeName varchar(max) NOT NULL,
					Primary Key (URLPhoto));

CREATE TABLE Transport("id" int Identity (1,1) NOT NULL,
                       GovNumber varchar(13) NOT NULL,
             	       tsModel varchar(100) NOT NULL,
                       tsTypeId int NOT NULL,
					   tsStatusId int NOT NULL,
					   Photo varchar(100) NOT NULL,
                       Primary Key("id"),
					   Foreign Key(tsStatusId) REFERENCES TsStatus(id),
					   Foreign Key(Photo) REFERENCES Photos(URLPhoto),
                       Foreign Key(tsTypeId) REFERENCES TsTypes("id"));
                            
                            
CREATE TABLE MesTypes("id" int Identity (1,1) NOT NULL,
                      "name" varchar(60) NOT NULL,
                      Primary Key("id"));
CREATE TABLE TransTypes("id" int Identity (1,1) NOT NULL,
                        "name" varchar(60) NOT NULL,
                        Primary Key("id"));
                                
CREATE TABLE Waybillses( nom int NOT NULL,
                         startDate date NOT NULL,
                         endDate date NOT NULL,
                         mesTypeId int NOT NULL,
                         transTypeId int NOT NULL,
                         idDis int NOT NULL,
                         idCus int NOT NULL,
                         transportId int NOT NULL,
                         orgId int NOT NULL,
                         routee varchar(300) NOT NULL,
                         idDri int NOT NULL,
                         Primary Key(nom),
                         Foreign Key(mesTypeId) REFERENCES MesTypes("id"),
                         Foreign Key(transTypeId) REFERENCES TransTypes("id"),
                         Foreign Key(idDis) REFERENCES Personal("id"),
                         Foreign Key(transportId) REFERENCES Transport("id"),
                         Foreign Key(orgId) REFERENCES org("id"),
                         Foreign Key(idDri) REFERENCES Personal("id"),
                         Foreign Key(idCus) REFERENCES Personal("id"));                                                         
                       
