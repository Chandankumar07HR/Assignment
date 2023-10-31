
--create table EMPLOYEE
--(
--EMPNO int primary key,
--EMPNAME varchar(15),
--JOB varchar(20),
--MGRID int,
--HIREDATE date,
--SAL int,
--COMM int,
--DEPTNO int foreign key references DEPT(DEPTNO)
--)

--insert into EMPLOYEE values(7369, 'SMITH', 'CLERK', 7902, '17-DEC-80', 800, NULL, 20),
--                           (7499, 'ALLEN', 'SALESMAN', 7698,'20-FEB-81', 1600, 300, 30),
--                           (7521, 'WARD', 'SALESMAN', 7698,'22-FEB-81', 1250, 500, 30),
--                           (7566, 'JONES', 'MANAGER', 7839, '02-APR-81', 2975, NULL, 20),
--						   (7654, 'MARTIN', 'SALESMAN', 7698,'28-SEP-81', 1250, 1400, 30),
--						   (7698, 'BLAKE', 'MANAGER', 7839, '01-MAY-81', 2850, NULL, 30),
--						   (7782, 'CLARK', 'MANAGER', 7839, '09-JUN-81', 2450, NULL, 10),
--						   (7788, 'SCOTT', 'ANALYST', 7566, '19-APR-87', 3000, NULL, 20),
--						   (7839, 'KING', 'PRESIDENT', NULL, '17-NOV-81', 5000, NULL, 10),
--						   (7844, 'TURNER', 'SALESMAN', 7698,'08-SEP-81', 1500, 0, 30),
--						   (7876, 'ADAMS', 'CLERK', 7788, '23-MAY-87', 1100, NULL, 20),
--						   (7900, 'JAMES', 'CLERK', 7698, '03-DEC-81', 950, NULL, 30),
--						   (7902, 'FORD', 'ANALYST', 7566, '03-DEC-81', 3000, NULL, 20),
--						   (7934, 'MILLER', 'CLERK', 7782, '23-JAN-82', 1300, NULL, 10)

--create table DEPT (
--DEPTNO int primary key,
--DNAME varchar(20),
--LOC varchar(30)
--)

--insert into DEPT values (10, 'ACCOUNTING', 'NEW YORK'),
--(20, 'RESEARCH', 'DALLAS'),
--(30, 'SALES', 'CHICAGO'),
--(40,'OPERATIONS','BOSTON')

use Assignment2DB

select * from Employee

--1. Retrieve a list of MANAGERS. 
select EMPNAME,JOB FROM EMPLOYEE where JOB = 'MANAGER' 

--2. Find out the names and salaries of all employees earning more than 1000 per month. 
SELECT EMPNAME, SAL FROM EMPLOYEE WHERE SAL > 1000;

--3. Display the names and salaries of all employees except JAMES.
SELECT EMPNAME, SAL FROM EMPLOYEE WHERE SAL NOT BETWEEN 900 and 1000;

--4. Find out the details of employees whose names begin with ‘S’.
SELECT * FROM EMPLOYEE WHERE EMPNAME LIKE 'S%';

--5. Find out the names of all employees that have ‘A’ anywhere in their name.
SELECT EMPNAME FROM EMPLOYEE WHERE EMPNAME LIKE '%A%';

--6. Find out the names of all employees that have ‘L’ as their third character in their name.
SELECT EMPNAME FROM EMPLOYEE WHERE EMPNAME LIKE '__L%';

--7. Compute daily salary of JONES. 
SELECT SAL/30 as 'Monthly Salary' FROM EMPLOYEE WHERE EMPNAME = 'JONES';

--8. Calculate the total monthly salary of all employees. 
SELECT SUM(SAL) as 'sum of salary'FROM EMPLOYEE;

--9. Print the average annual salary . 
SELECT SUM(SAL)/12 FROM EMPLOYEE;
SELECT EMPNAME, AVG(SAL) AS 
AVERAGE_SALARY FROM EMPLOYEE GROUP BY EMPNAME;

--10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 
SELECT EMPNAME, JOB, SAL, DEPTNO FROM EMPLOYEE WHERE DEPTNO = 30 AND JOB not in ('SALESMAN');

--11 List unique departments of the EMP table.
SELECT DISTINCT DEPTNO FROM EMPLOYEE;

--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
SELECT EMPNAME AS Employee, SAL AS 'Monthly Salary' FROM EMPLOYEE WHERE DEPTNO IN (10, 30) AND SAL > 1500;

--13 Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000.
SELECT EMPNAME, JOB, SAL FROM EMPLOYEE WHERE JOB IN ('MANAGER', 'ANALYST') AND SAL NOT IN (1000, 3000, 5000);

--14. Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%. 
SELECT EMPNAME, SAL, COMM FROM EMPLOYEE WHERE COMM > 1.1 * SAL;

--15. Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782.
SELECT EMPNAME FROM EMPLOYEE WHERE EMPNAME LIKE '%LL%' AND (DEPTNO = 30 OR MGRID = 7782);

--16. Display the names of employees with experience of over 30 years and under 40 yrs. Count the total number of employees. 
select EMPNAME, DATEdiff(year,hiredate,getdate()) as Experience from EMPLOYEE where (DATEdiff(year,hiredate,getdate())>30) and (DATEdiff(year,hiredate,getdate())<40)

--17. Retrieve the names of departments in ascending order and their employees in descending order.
SELECT DNAME, EMPNAME FROM DEPT, EMPLOYEE WHERE DEPT.DEPTNO = EMPLOYEE.DEPTNO ORDER BY DNAME ASC, EMPNAME DESC;

--18. Find out experience of MILLER
SELECT EMPNAME, DATEdiff(year,hiredate,getdate()) AS Experience FROM EMPLOYEE WHERE EMPNAME = 'MILLER';



