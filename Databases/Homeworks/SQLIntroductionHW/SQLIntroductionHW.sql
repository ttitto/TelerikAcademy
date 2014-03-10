--Task 4
--Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

select *
from departments

--Task 5
--Write a SQL query to find all department names.

select Name
from departments

--Task6
--Write a SQL query to find the salary of each employee.

select FirstName, LastName, Salary
from employees

--Task 7
--Write a SQL to find the full name of each employee.

select FirstName+' '+LastName as FullName
from employees

--Task 8
--Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".

select FirstName+'.'+LastName +'@telerik.com' as [Full Email Addresses]
from Employees

--Task 9
--Write a SQL query to find all different employee salaries.

select distinct Salary
from employees

--Task10
--Write a SQL query to find all information about the employees whose job title is “Sales Representative“.

select *
from employees
where JobTitle ='Sales Representative'

--Task 11
--Write a SQL query to find the names of all employees whose first name starts with "SA".

select FirstName, LastName
from Employees
where FirstName like'SA%'

--Task 12
--Write a SQL query to find the names of all employees whose last name contains "ei".
select FirstName, LastName
from employees
where LastName like '%ei%'

--Task 13
--Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].

select Salary
from employees
where Salary between 20000 and 30000

--Task 14
--Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

select FirstName, LastName
from employees
where Salary  in(25000, 14000, 12500 , 23600)


--Task 15
--Write a SQL query to find all employees that do not have manager.

select *
from employees
where ManagerID is null

--Task 16
--Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.

select *
from employees
where Salary>50000
order by Salary asc

--Task 17
--Write a SQL query to find the top 5 best paid employees.

select top 5 *
from employees
order by Salary desc

--Task 18
--Write a SQL query to find all employees along with their address. Use inner join with ON clause.

select FirstName, LastName, AddressText
from Employees e join Addresses a on e.AddressID=a.AddressID

--Task 19
--Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).

select FirstName, LastName, AddressText
from Employees e,Addresses a
where e.AddressID=a.AddressID

--Task 20
--Write a SQL query to find all employees along with their manager.

select e.FirstName, e.LastName,m.FirstName+' ' +m.LastName as Manager
from employees e left outer  join employees m
on e.EmployeeID=m.ManagerID

--Task 21
--Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.

select e.FirstName, e.LastName,a.AddressText as Address,m.FirstName+' ' +m.LastName as Manager
from employees e left outer  join employees m
on e.EmployeeID=m.ManagerID
join Addresses a on e.AddressID=a.AddressID

--Task 22
--Write a SQL query to find all departments and all town names as a single list. Use UNION.

select Name
from Departments
 Union 
select Name
 from towns

 --Task 23
 --Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.

 select e.FirstName, e.LastName,m.FirstName+' ' +m.LastName as Manager
from employees e left outer  join employees m
on e.EmployeeID=m.ManagerID

 select e.FirstName, e.LastName,m.FirstName+' ' +m.LastName as Manager
from employees e right outer  join employees m
on e.EmployeeID=m.ManagerID

--Task 24
--Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.

select FirstName, LastName, d.Name as Department, year(e.HireDate) as [Hire Year]
from Employees e join Departments d on e.DepartmentID=d.DepartmentID
where d.Name in('Sales','Finance')
and YEAR(e.HireDate) between 1995 and 2005