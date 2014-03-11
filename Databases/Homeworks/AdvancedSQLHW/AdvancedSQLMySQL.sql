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
select e.FirstName, d.name, Min(Salary) as 'Minimal Salary'
from departments d join employees e
	on d.DepartmentID=e.departmentID
group by d.departmentID;

select e.FirstName as FullName, Salary,d.Name
from employees e join departments d
	on e.DepartmentID=d.DepartmentID
having e.Salary=(
select Min(Salary) from employees)