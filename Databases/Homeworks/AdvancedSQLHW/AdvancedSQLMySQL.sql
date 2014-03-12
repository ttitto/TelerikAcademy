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
set GroupId=2
where userID=4;
