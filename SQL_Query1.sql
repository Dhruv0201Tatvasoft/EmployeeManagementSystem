use dhruvkhoradiya_db;

CREATE TABLE EmsTblTechnology (
    Id INT PRIMARY KEY,
    Name VARCHAR(20) NOT NULL
);

CREATE TABLE EmsTblSkill (
    Id INT PRIMARY KEY,
    Name VARCHAR(20) NOT NULL
);



CREATE TABLE EmsTblProject (
    Code VARCHAR(10) PRIMARY KEY,
    Name VARCHAR(40) NOT NULL,
    StartingDate DATE NOT NULL,
    EndingDate DATE
);

CREATE TABLE EmsTblTechnologyForProject (
    ProjectCode VARCHAR(10) NOT NULL,
    TechnologyId INT NOT NULL,
    FOREIGN KEY (ProjectCode) REFERENCES EmsTblProject(Code),
    FOREIGN KEY (TechnologyId) REFERENCES EmsTblTechnology(Id)
);


CREATE TABLE EmsTblEmployee (
    Code VARCHAR(10) PRIMARY KEY,
    FirstName VARCHAR(10) NOT NULL,
    LastName VARCHAR(10) NOT NULL,
    Email VARCHAR(40) NOT NULL,
    Password VARCHAR(20) NOT NULL,
    [Designation] nvarchar(30) NOT NULL CHECK ([Designation] IN ('Developer', 'Senior Developer', 'Team lead', 'Manager')),
    [Department] nvarchar(20) NOT NULL CHECK ([Department] IN ('Dotnet', 'Java', 'Php', 'Mobile', 'QA')),
    JoiningDate DATE NOT NULL,
    ReleaseDate DATE,
    DOB DATE NOT NULL,
    ContactNumber VARCHAR(15) NOT NULL,
    Gender VARCHAR(10) NOT NULL,
    MaritalStatus VARCHAR(10) NOT NULL,
    PresentAddress VARCHAR(35) NOT NULL,
    PermenentAddress VARCHAR(35),
);
exec sp_rename 'dbo.EmsTblEmployee.PermenentAddress' ,'PermanentAdress','COLUMN'
CREATE TABLE EmsTblEmployeeEducation (

    EmployeeCode VARCHAR(10) NOT NULL,
    Degree VARCHAR(10) NOT NULL,
    Board VARCHAR(30) NOT NULL,
    Institute VARCHAR(30) NOT NULL,
    State VARCHAR(15) NOT NULL,
    PassingYear VARCHAR(5) NOT NULL,
    Percentage VARCHAR(5) NOT NULL,
    FOREIGN KEY (EmployeeCode) REFERENCES EmsTblEmployee(Code)
);

CREATE TABLE EmsTblEmployeeExperience (
    EmployeeCode VARCHAR(10) NOT NULL,
    Organization VARCHAR(15) NOT NULL,
    FromDate DATE NOT NULL,
    ToDate DATE NOT NULL,
    Designation VARCHAR(15) NOT NULL,
    FOREIGN KEY (EmployeeCode) REFERENCES EmsTblEmployee(Code)
);
ALTER TABLE EmsTblEmployeeExperience alter column Designation Varchar(30) not null
create table EmsTblEmployeeAssociatedToProject (
	EmployeeCode VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES EmsTblEmployee(Code),
	ProjectCode VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES EmsTblProject(Code))

create table EmsTblSkillForEmployee (
EmployeeCode VARCHAR(10) Foreign key references EmsTblEmployee(Code) ON DELETE CASCADE ON UPDATE CASCADE,
SkillId int Foreign key references EmsTblSkill(Id) ON DELETE CASCADE ON UPDATE CASCADE)





insert into EmsTblTechnology values 
(1,'Dotnet'),
(2,'Java'),
(3,'Php'),
(4,'Iphone'),
(5,'Android'),
(6,'NodeJs'),
(7,'React'),
(8,'Python'),
(9,'Angular'),
(10,'Vue')
insert into EmsTblProject values 
('P0001','Employee Management System','2020-12-10','2021-12-20'),
('P0002','Inventory System','2018-07-09',null),
('P0003','HR Management System','2019-08-17','2021-07-22'),
('P0004','Hotel Reservation System','2021-06-24',null),
('P0005','Hello Doc','2022-04-15',null)



insert into EmsTblTechnologyForProject values
('P0001',1),('P0001',9) ,('P0002',7),('P0002',6),('P0002',3),('P0003',2),('P0003',5),('P0004',9),('P0004',6),('P0005',1)

exec sp_rename 'dbo.EmsTblEmployeeEducation.Degree' ,'Qualification','COLUMN'
exec sp_rename 'dbo.EmsTblEmployee.PermanentAdress','PermanentAddress','COLUMN'

select * from EmsTblEmployee
alter table EmsTblEmployeeEducation Drop FOREIGN key EmployeeCode
ALTER TABLE EmsTblEmployeeEducation
ADD CONSTRAINT FK_EmployeeCode
FOREIGN KEY (EmployeeCode)
REFERENCES EmsTblEmployee(Code)
ON UPDATE CASCADE
ON DELETE CASCADE;

ALTER TABLE EmsTblEmployeeAssociatedToProject
ADD CONSTRAINT FK_ProjectCodeForEmployeeAssociatedToProject
FOREIGN KEY (ProjectCode)
REFERENCES EmsTblProject(Code)
ON UPDATE CASCADE
ON DELETE CASCADE;

alter table EmsTblEmployeeExperience Drop FOREIGN key EmployeeCode
ALTER TABLE EmsTblEmployeeExperience
ADD CONSTRAINT FK_EmployeeCodeExperience
FOREIGN KEY (EmployeeCode)
REFERENCES EmsTblEmployee(Code)
ON UPDATE CASCADE
ON DELETE CASCADE;

alter table EmsTblTechnologyForProject Drop FOREIGN key ProjectCode
ALTER TABLE EmsTblTechnologyForProject
ADD CONSTRAINT FK_ProjectCode
FOREIGN KEY (ProjectCode)
REFERENCES EmsTblProject(Code)
ON UPDATE CASCADE
ON DELETE CASCADE;

alter table EmsTblTechnologyForProject Drop FOREIGN key TechnologyId
ALTER TABLE EmsTblTechnologyForProject
ADD CONSTRAINT FK_TechnologyId
FOREIGN KEY (TechnologyId)
REFERENCES EmsTblTechnology(Id)
ON UPDATE CASCADE
ON DELETE CASCADE;



SELECT 
    COUNT(*) AS count,
    MONTH(JoiningDate) AS MonthNumber,
    DATENAME(month, JoiningDate) AS Month
FROM 
    EmsTblEmployee 
WHERE 
 JoiningDate between DATEADD(month,-6, DATEADD(day,-DAY(GETDATE())+1,GETDATE())) AND EOMONTH(GETDATE(),-1)
	  
GROUP BY 
    MONTH(JoiningDate), DATENAME(month, JoiningDate)
ORDER BY 
    (MONTH(GETDATE()) - MONTH(JoiningDate) + 12) % 12;

	select * from EmsTblEmployee order by MaritalStatus