/*TASK 2: Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. Use a nested SELECT statement.
*/
select FirstName, LastName, Salary
from employees
where Salary=(
select Min(Salary) from employees);

/*TASK 2: Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
*/
select  FirstName, LastName, Salary
from employees
where salary<=(
select Min(salary)+Min(salary)*0.1 from employees);

/*TASK 3: Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. Use a nested SELECT statement.
*/

select CONCAT(e.FirstName,' ',e.LastName) as FullName,e.DepartmentID, Salary,d.Name
from employees e join Departments d
	on e.DepartmentID=d.DepartmentID
where Salary=
(select Min(salary) from employees
where DepartmentId=e.DepartmentId);

/*TASK 4: Write a SQL query to find the average salary in the department #1.
*/
select DepartmentID, Avg(Salary)
from employees
where departmentId=1;

/*TASK 5: Write a SQL query to find the average salary  in the "Sales" department.
*/
select d.Name, avg(Salary)
from employees e join departments d
	on e.departmentid=d.departmentid
where name='Sales';

/*TASK 6: Write a SQL query to find the number of employees in the "Sales" department.
*/
select d.Name, Count(employeeid)
from employees e join departments d
	on e.departmentid=d.departmentid
where name='Sales';

/*TASK 7: Write a SQL query to find the number of all employees that have manager.
*/
select count(EmployeeID)
from employees
where managerid is not null;
/*TASK 8: Write a SQL query to find the number of all employees that have no manager.
*/
select count(EmployeeID)
from employees
where managerid is null;

/*TASK 9: Write a SQL query to find all departments and the average salary for each of them.
*/
select Name, AVG(Salary)
from employees e join departments d
	on e.DepartmentID=d.DepartmentID
group by e.DepartmentID;

/*TASK 10: Write a SQL query to find the count of all employees in each department and for each town.
*/
select d.Name as DepartmentName ,t.Name as TownName, count(EmployeeID)
from employees e join departments d
	on e.DepartmentID=d.DepartmentID
join addresses a
	on a.AddressID=e.AddressID
join towns t
	on t.TownID=a.TownID
group by e.DepartmentID, a.TownID;

/*TASK 11: Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
*/
select m.ManagerID, e.FirstName, e.LastName, count(e.employeeID)
from employees e join employees m
	on e.EmployeeID=m.ManagerID
group by m.ManagerID
having count(e.employeeID)=5;


/*TASK 12: Write a SQL query to find all employees along with their managers. 
For employees that do not have manager display the value "(no manager)".
*/
select m.FirstName, m.LastName, IFNULL(CONCAT(e.FirstName,' ',e.LastName),'(no manager)')
from employees e right outer join employees m
	on e.EmployeeID=m.ManagerID
order by m.ManagerID;
/*TASK 13: Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.
 Use the built-in LEN(str) function.
*/
select FirstName,LastName
from employees
where LENgth(LastName)=5;

/*TASK 14: Write a SQL query to display the current date and time in the following format 
"day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.
*/
select DATE_FORMAT(NOW(),'%d.%c.%Y %T:%f');

/*TASK 15: Write a SQL statement to create a table Users. Users should have username,
 password, full name and last login time. Choose appropriate data types for the table fields.
 Define a primary key column with a primary key constraint. Define the primary key column 
as identity to facilitate inserting records. Define unique constraint to avoid repeating 
usernames. Define a check constraint to ensure the password is at least 5 characters long.
*/
create table Users(
UserID int auto_increment not null,
Username nvarchar(50) not null,
Pass varchar(100) not null,
FullName nvarchar(100),
LastLoginTime datetime,
constraint PK_Users primary key(UserID),
constraint UK_Users_Username UNIQUE(Username),
constraint CH_Users_Password CHECK(length(users.Pass)>=5)
);

DELIMITER $$
CREATE TRIGGER `TR_BeforeInsert_Users`
BEFORE INSERT ON `users`
FOR EACH ROW
BEGIN
    IF CHAR_LENGTH(NEW.Pass ) < 5 THEN
    SIGNAL SQLSTATE '12345'
        SET MESSAGE_TEXT = 'check constraint on Pass failed';
    END IF;
END$$
delimiter ;

Insert into Users(Username, Pass, FullName,lastlogintime) values('blake','alabala','Pesho', now());
Insert into Users(Username, Pass, FullName,lastlogintime) values('matrix','ala','Petranka', now());
select length(Pass) from users;

/*TASK 16: Write a SQL statement to create a view that displays the users from the Users table
 that have been in the system today. Test if the view works correctly.
*/
create view TodaysUsers  as
select UserName from users
where now()- LastLoginTime <=86400;

Insert into Users(Username, Pass, FullName,lastlogintime) values('harper','alabalak','Pesho', now());
Insert into Users(Username, Pass, FullName,lastlogintime) values('Petra','alabash','Petranka', DATE(02/02/2014));

select username from todaysusers;

/*TASK 17: Write a SQL statement to create a table Groups. Groups should have 
unique name (use unique constraint). Define primary key and identity column.
*/

CREATE TABLE Groups(
GroupId int AUTO_INCREMENT,
`Name` varchar(50) not null,
constraint PK_GroupId primary key(GroupId),
constraint UK_Groups_Name UNIQUE(`Name`));

/*TASK 18: Write a SQL statement to add a column GroupID to the table Users.
 Fill some data in this new column and as well in the Groups table. 
Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
*/

ALTER TABLE users
ADD GroupId int;

ALTER TABLE users
ADD constraint FK_Users_Groups foreign key(GroupId)
references Groups(GroupId);

insert into Groups(Name) values ('QA');
insert into Groups(Name) values ('C#');
insert into Groups(Name) values ('Web Developers');
insert into Groups(Name) values ('Sales');

update users
set GroupId=1
where userID=4;

update users
set GroupId=4
where userID=2;

update users
set GroupId=5
where userID=3;

update users
set GroupId=6
where userID=1;

/*TASK 19: Write SQL statements to insert several records in the Users 
and Groups tables.
*/
insert into Users(Username,pass, fullname, lastlogintime, groupID)
values('mirko','12345','Miroslav',null,6);

insert into Users(Username,pass, fullname, lastlogintime, groupID)
values('tanya','54361','Tatyana',null,4);

/*TASK 20: Write SQL statements to update some of the records in the 
Users and Groups tables.
*/
update groups set Name='Quality Assurance'
where name='QA';

update groups set Name='Programmer'
where name='C#';

update users set pass='987654321'
where UserName='tanya';

update users set GroupId=4
where UserName='mirko';

/*TASK 21: Write SQL statements to delete some of the records from the Users and Groups tables.
*/

delete from users
where GroupId=1;

delete from groups
where Name='Quality Assurance';

/*TASK 22: Write SQL statements to insert in the Users table the names of all
 employees from the Employees table. Combine the first and last names as a full name.
 For username use the first letter of the first name + the last name (in lowercase). 
Use the same for the password, and NULL for last login time.
*/

insert ignore into users (username, pass, fullname, lastlogintime, GroupId)
select  concat(substring(firstName,1,1),lastName),
	concat(substring(firstName,1,1), lastName),
	concat(firstname,' ',lastname),
	null,
	null
from employees
where char_length(concat(substring(firstName,1,1), lastName))>=5 ;

/*TASK 23: Write a SQL statement that changes the password to NULL for all users
 that have not been in the system since 10.03.2010.
*/
ALTER TABLE `telerikacademy`.`users` 
CHANGE COLUMN `Pass` `Pass` VARCHAR(100) NULL ;

SET SQL_SAFE_UPDATES=0;
update users set Pass=null
where date_format(lastlogintime,'%d.%m.%Y')<'10.03.2010';
SET SQL_SAFE_UPDATES=1;

/*TASK 24: Write a SQL statement that deletes all users without passwords (NULL password).
*/
set sql_safe_updates=0;
delete from users
where pass is null;
set sql_safe_updates=1;

/*TASK 25: Write a SQL query to display the average employee salary by department 
and job title.*/

select d.name, e.JobTitle,avg(salary)
from employees e  join departments d
	on e.DepartmentID=d.DepartmentID
group by d.name, e.JobTitle
order by avg(salary) desc;

/*TASK 26: Write a SQL query to display the minimal employee salary by department 
and job title along with the name of some of the employees that take it.
*/
select d.Name as `Department Name`,e.JobTitle,e.LastName,min(salary)
from employees e Join departments d
	on e.DepartmentID=d.DepartmentID
group by d.Name,e.JobTitle
order by d.Name;

/*TASK 27: Write a SQL query to display the town where maximal number of employees work.*/
select TownName from (
	select t.Name as TownName,Count(e.EmployeeID) as EmployeeCount
	from employees e join addresses a
		on e.AddressID=a.AddressID
	join towns t
		on a.TownID=t.TownID
	group by t.Name 
having EmployeeCount=(
	select Max(EmpCount.cnt) 
	from(
	select count(EmployeeID) as cnt 
	from employees e join addresses a
		on e.AddressID=a.AddressID
	group by TownID) EmpCount)
) as NewTable;

/*TASK 28: Write a SQL query to display the number of managers from each town.
*/
select ManagerTown.Name, count(ManagerTown.ManagerID) as `Managers Count`
from(
select t.Name,e.ManagerID
from employees e join employees m
	on m.EmployeeID=e.ManagerID
join addresses a
	on a.AddressID=e.AddressID
join towns t 
	on t.townid=a.townid
group by e.ManagerID) ManagerTown
group by ManagerTown.Name

/*TASK 29: Write a SQL to create table WorkHours to store work reports for each employee
 (employee id, date, task, hours, comments). Don't forget to define  identity, primary key
 and appropriate foreign key. 
	Issue few SQL statements to insert, update and delete of some data in the table.
	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
 For each change keep the old record data, the new record data and the command 
(insert / update / delete).
*/

CREATE TABLE WorkHours(
WHId int auto_increment not null,
EmployeeId int ,
WHDate date,
Task varchar(200),
Hours float,
Comments text,
constraint PK_WorkHours primary key (WHId),
constraint FK_WorkHours_Employees foreign key (EmployeeId)
	references employees(EmployeeID)
);

INSERT INTO WorkHours(EmployeeId, WHDate,Task,Hours,Comments)
	VALUES(1,'2013-12-20','BGCoder Project: accept zip file',6.5,'Initial class structure created');
INSERT INTO WorkHours(EmployeeId, WHDate,Task,Hours,Comments)
	VALUES(33,'2013-12-20','BGCoder Project: accept zip file',6.5,'Initial class structure created');
INSERT INTO WorkHours(EmployeeId, WHDate,Task,Hours,Comments)
	VALUES(220,'2013-12-20','BGCoder Project: accept zip file',3.33,'Initial class structure created');
INSERT INTO WorkHours(EmployeeId, WHDate,Task,Hours,Comments)
	VALUES(133,'2013-12-21','BGCoder Project: accept zip file',2.67,'Bug fixed');
INSERT INTO WorkHours(EmployeeId, WHDate,Task,Hours,Comments)
	VALUES(55,'2013-12-21','BGCoder Project: accept zip file',1.08,'some class implementation');
INSERT INTO WorkHours(EmployeeId, WHDate,Task,Hours,Comments)
	VALUES(46,'2013-12-22','BGCoder Project: accept zip file',2.33,'Initial class structure created');

UPDATE WorkHours SET WHDate='2013-12-20' WHERE WorkHours.EmployeeId=1;

DELETE FROM WorkHours WHERE EmployeeId=1;

create table WorksHoursLog(
LogId int auto_increment,
Command varchar(15),

WHId_Old int,
EmployeeId_Old int,
WHDate_Old date,
Task_Old varchar(200),
Hours_Old float,
Comments_Old text,

WHId_New int,
EmployeeId_New int,
WHDate_New date,
Task_New varchar(200),
Hours_New float,
Comments_New text,
constraint PK_WorkHoursLog primary key (LogId)
);
/*VALUES('insert',OLD.`WHId`,OLD.EmployeeId,OLD.WHDate, OLD.Task,OLD.Hours,OLD.Comments,
NEW.WHId,NEW.EmployeeId,NEW.WHDate, NEW.Task,NEW.Hours,NEW.Comments);*/

DROP TRIGGER if exists `TR_BeforeInsert_WorkHours`;
DELIMITER $$
CREATE TRIGGER `TR_BeforeInsert_WorkHours`
BEFORE INSERT ON `WorkHours` 
FOR EACH ROW

	INSERT into WorksHoursLog(Command, WHId_Old,EmployeeId_Old, WHDate_Old, Task_Old,Hours_Old,Comments_Old,
		WHId_New,EmployeeId_New, WHDate_New, Task_New,Hours_New,Comments_New )
	VALUES('insert',
	null,
	null,
	null,
	null,
	null,
	null,
	NEW.WHId,	NEW.EmployeeId,	NEW.WHDate,	NEW.Task,	NEW.Hours,	NEW.Comments);
$$

)END$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER `TR_BeforeDelete_WorkHours`
BEFORE DELETE ON `WorkHours` 
FOR EACH ROW

	INSERT into WorksHoursLog(Command, WHId_Old,EmployeeId_Old, WHDate_Old, Task_Old,Hours_Old,Comments_Old,
		WHId_New,EmployeeId_New, WHDate_New, Task_New,Hours_New,Comments_New )
	VALUES('delete',
	OLD.WHId,OLD.EmployeeId,OLD.WHDate, OLD.Task,OLD.Hours,OLD.Comments,
	null,
	null,
	null,
	null,
	null,
	null
);
$$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER `TR_BeforeUpdate_WorkHours`
BEFORE UPDATE ON `WorkHours` 
FOR EACH ROW

	INSERT into WorksHoursLog(Command, WHId_Old,EmployeeId_Old, WHDate_Old, Task_Old,Hours_Old,Comments_Old,
		WHId_New,EmployeeId_New, WHDate_New, Task_New,Hours_New,Comments_New )
	VALUES('update',
	OLD.WHId,OLD.EmployeeId,OLD.WHDate, OLD.Task,OLD.Hours,OLD.Comments,
	NEW.WHId,NEW.EmployeeId,NEW.WHDate,NEW.Task,NEW.Hours,NEW.Comments);
$$
DELIMITER ;

/*TASK 30: Start a database transaction, delete all employees from the 'Sales' department 
along with all dependent records from the other tables. At the end rollback the transaction.
*/

alter table employees
drop foreign key `FK_Employees_Employees`;

start transaction;

delete from employees 
where departmentID=(
select departmentId from departments
Where Name='Purchasing');
rollback ;

alter table employees
add constraint `FK_Employees_Employees` foreign key (`ManagerID`)
	references employees(`EmployeeId`);

/*TASK 31: Start a database transaction and drop the table EmployeesProjects. 
Now how you could restore back the lost table data?
*/

start transaction;
DROP TABLE employeesprojects;
rollback;


/*TASK 32: Find how to use temporary tables in SQL Server. Using temporary tables 
backup all records from EmployeesProjects and restore them back after dropping and 
re-creating the table.
*/
CREATE TEMPORARY TABLE EmployeesProjectSummary(
EmployeeID int,
ProjectID int
);

INSERT INTO EmployeesProjectSummary (
	SELECT EmployeeID, ProjectID FROM employeesprojects);

DROP TABLE employeesprojects;

CREATE TABLE EmployeesProjects(
EmployeeID int ,
ProjectID int,
CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
CONSTRAINT FK_Employees_EmployeesProjects FOREIGN KEY (EmployeeID) REFERENCES employees(EmployeeID)
);

INSERT INTO EmployeesProjects (
	SELECT * FROM EmployeesProjectSummary);




