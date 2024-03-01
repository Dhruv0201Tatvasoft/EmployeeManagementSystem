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
    Email VARCHAR(15) NOT NULL,
    Password VARCHAR(20) NOT NULL,
    [Designation] nvarchar(20) NOT NULL CHECK ([Designation] IN ('Developer', 'Senior Developer', 'Team lead', 'Manager')),
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

create table EmsTblEmployeeAssociatedToProject (
	EmployeeCode VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES EmsTblEmployee(Code),
	ProjectCode VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES EmsTblProject(Code))

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

	Select FirstName, LastName from EmsTblEmployee
INSERT INTO EmsTblEmployee (Code, FirstName, LastName, Email, Password, [Designation], [Department], JoiningDate, ReleaseDate, DOB, ContactNumber, Gender, MaritalStatus, PresentAddress, PermanentAdress)
VALUES
    ('EMP001', 'Dhruv', 'Khoradiya', 'abc@email.com', 'password1', 'Manager', 'Dotnet', '2022-01-01', NULL, '1990-05-15', '1234567890', 'Male', 'Married', 'Mumbai, Maharashtra', 'Mumbai, Maharashtra'),
    ('EMP002', 'Falgun', 'Panchal', 'abc@email.com', 'password2', 'Senior Developer', 'Java', '2023-02-01', NULL, '1988-08-20', '1234567890', 'Male', 'Single', 'Delhi, Delhi', 'Delhi, Delhi'),
    ('EMP003', 'Riya', 'Sharma', 'abc@email.com', 'password3', 'Developer', 'PHP', '2023-05-10', NULL, '1992-11-25', '1234567890', 'Female', 'Married', 'Bangalore, Karnataka', 'Bangalore, Karnataka'),
    ('EMP004', 'Rahul', 'Patel', 'abc@email.com', 'password4', 'Team lead', 'Mobile', '2022-11-18', NULL, '1985-04-12', '1234567890', 'Male', 'Single', 'Ahmedabad, Gujarat', 'Ahmedabad, Gujarat'),
    ('EMP005', 'Neha', 'Singh', 'abc@email.com', 'password5', 'Manager', 'QA', '2022-03-22', NULL, '1987-08-30', '1234567890', 'Female', 'Married', 'Lucknow, Uttar Pradesh', 'Lucknow, Uttar Pradesh'),
    ('EMP006', 'Vikas', 'Yadav', 'abc@email.com', 'password6', 'Senior Developer', 'Dotnet', '2023-07-05', NULL, '1989-06-02', '1234567890', 'Male', 'Single', 'Jaipur, Rajasthan', 'Jaipur, Rajasthan'),
    ('EMP007', 'Kavita', 'Gupta', 'abc@email.com', 'password7', 'Developer', 'Java', '2022-09-15', NULL, '1993-03-14', '1234567890', 'Female', 'Married', 'Chandigarh, Punjab', 'Chandigarh, Punjab'),
    ('EMP008', 'Rajat', 'Verma', 'abc@email.com', 'password8', 'Team lead', 'Mobile', '2023-01-28', NULL, '1986-12-08', '1234567890', 'Male', 'Single', 'Bhopal, Madhya Pradesh', 'Bhopal, Madhya Pradesh'),
    ('EMP009', 'Ayesha', 'Khan', 'abc@email.com', 'password9', 'Manager', 'QA', '2022-12-03', NULL, '1991-02-18', '1234567890', 'Female', 'Married', 'Hyderabad, Telangana', 'Hyderabad, Telangana'),
    ('EMP010', 'Sandeep', 'Yadav', 'abc@email.com', 'password10', 'Senior Developer', 'PHP', '2023-04-09', NULL, '1984-07-20', '1234567890', 'Male', 'Single', 'Pune, Maharashtra', 'Pune, Maharashtra'),
    ('EMP011', 'Priya', 'Das', 'abc@email.com', 'password11', 'Manager', 'Dotnet', '2022-06-14', NULL, '1988-10-05', '1234567890', 'Female', 'Married', 'Kolkata, West Bengal', 'Kolkata, West Bengal'),
    ('EMP012', 'Gaurav', 'Shah', 'abc@email.com', 'password12', 'Developer', 'Mobile', '2023-09-23', NULL, '1994-09-28', '1234567890', 'Male', 'Single', 'Nagpur, Maharashtra', 'Nagpur, Maharashtra'),
    ('EMP013', 'Aarti', 'Pandey', 'abc@email.com', 'password13', 'Team lead', 'Java', '2022-08-08', NULL, '1987-01-03', '1234567890', 'Female', 'Married', 'Ahmedabad, Gujarat', 'Ahmedabad, Gujarat'),
    ('EMP014', 'Ankit', 'Jain', 'abc@email.com', 'password14', 'Team lead', 'QA', '2023-02-16', NULL, '1990-04-22', '1234567890', 'Male', 'Single', 'Bengaluru, Karnataka', 'Bengaluru, Karnataka'),
    ('EMP015', 'Pooja', 'Singh', 'abc@email.com', 'password15', 'Senior Developer', 'PHP', '2022-10-30', NULL, '1989-11-12', '1234567890', 'Female', 'Married', 'Chennai, Tamil Nadu', 'Chennai, Tamil Nadu'),
    ('EMP016', 'Rahul', 'Yadav', 'abc@email.com', 'password16', 'Manager', 'Mobile', '2022-11-25', NULL, '1985-05-18', '1234567890', 'Male', 'Single', 'Lucknow, Uttar Pradesh', 'Lucknow, Uttar Pradesh'),
    ('EMP017', 'Asha', 'Verma', 'abc@email.com', 'password17', 'Developer', 'Java', '2023-03-05', NULL, '1991-08-15', '1234567890', 'Female', 'Married','Ahmedabad, Gujarat',NULL)


select * from EmsTblTechnologyForProject
select * from EmsTblTechnology
select * from EmsTblEmployee
select CONCAT(FirstName,' ' ,LastName) from EmsTblEmployee 
Select * from  EmsTblProject where Code = 'P0005' 
delete from EmsTblTechnologyForProject where ProjectCode ='P0001'
UPDATE  EmsTblProject SET Code = 'P0074' , Name = 'Dhruv' , StartingDate = '2020-12-10',  EndingDate = NULL WHERE Code ='P0001' 
SELECT * from EmsTblProject where Code = 'P0001'
UPDATE EmsTblProject SET Code = 'P0078' , Name = 'Mechanical System' , StartingDate = '2019-08-17',  EndingDate = '2021-07-22' WHERE Code ='P0003' 
delete from EmsTblProject where Code=''
Insert into EmsTblProject (Code,Name,StartingDate,EndingDate) values ('P0013','Everest','2024-02-19','NULL')
Insert into EmsTblEmployeeAssociatedToProject (EmployeeCode,ProjectCode) Values ('EMP001','P0005')

 SELECT 

        CONCAT(
            COALESCE(FirstName + ' ', '')
            , COALESCE(Lastname, '')
        )
    AS Name
 from EmsTblEmployeeAssociatedToProject inner join EmsTblEmployee on EmsTblEmployeeAssociatedToProject.EmployeeCode = EmsTblEmployee.Code where EmsTblEmployeeAssociatedToProject.ProjectCode = 'P0005'

 Select CONCAT(Firstname,' ',Lastname)As Name,EmsTblEmployee.Code  
               from EmsTblEmployeeAssociatedToProject inner join EmsTblEmployee on  
                EmsTblEmployeeAssociatedToProject.EmployeeCode = EmsTblEmployee.Code  
               where EmsTblEmployeeAssociatedToProject.ProjectCode = 'P0005'


delete  from EmsTblEmployeeAssociatedToProject where ProjectCode ='P0005' and  EmployeeCode ='EMP001'
delete  from EmsTblTechnology where Id =6
select * from EmsTblTechnology where name like 'dotnet'
update EmsTblTechnology set name ='KHP' where name like 'PHP'
Update EmsTblTechnology SET Name = 'Iphone' where name like ''	
select * from EmsTblProject where code like 'P0001'
delete from EmsTblTechnology where Name like 'Dotnet'
Delete From EmsTblTechnology where Name like 'Dotnet'
select * from EmsTblSkill (Name) values  ('Management') ,('Coding'),('Communication'),('Testing')

SELECT Code, CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, '')) AS Name, Email, Designation, Department, JoiningDate, ReleaseDate
FROM EmsTblEmployee

SELECT *
FROM EmsTblEmployee
Select *,CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, '')) AS Name from EmsTblEmployee where 1=1 AND Department like 'Java%'
WHERE UPPER(CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, ''))) LIKE '%Khoradiya%';
Select *,CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, '')) AS Name from EmsTblEmployee where 1=1 AND  UPPER(CONCAT(COALESCE(FirstName + ' ', ''), COALESCE(Lastname, ''))) LIKE '%Dhruv%'