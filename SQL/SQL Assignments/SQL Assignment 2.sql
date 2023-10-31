create database Assignment2DB

use Assignment2DB

create table EMPLOYEE
(
EMPNO int primary key,
EMPNAME varchar(15),
JOB varchar(20),
MGRID int,
HIREDATE date,
SAL int,
COMM int,
DEPTNO int foreign key references DEPT(DEPTNO)
)

insert into EMPLOYEE values(7369, 'SMITH', 'CLERK', 7902, '17-DEC-80', 800, NULL, 20),
                           (7499, 'ALLEN', 'SALESMAN', 7698,'20-FEB-81', 1600, 300, 30),
                           (7521, 'WARD', 'SALESMAN', 7698,'22-FEB-81', 1250, 500, 30),
                           (7566, 'JONES', 'MANAGER', 7839, '02-APR-81', 2975, NULL, 20),
						   (7654, 'MARTIN', 'SALESMAN', 7698,'28-SEP-81', 1250, 1400, 30),
						   (7698, 'BLAKE', 'MANAGER', 7839, '01-MAY-81', 2850, NULL, 30),
						   (7782, 'CLARK', 'MANAGER', 7839, '09-JUN-81', 2450, NULL, 10),
						   (7788, 'SCOTT', 'ANALYST', 7566, '19-APR-87', 3000, NULL, 20),
						   (7839, 'KING', 'PRESIDENT', NULL, '17-NOV-81', 5000, NULL, 10),
						   (7844, 'TURNER', 'SALESMAN', 7698,'08-SEP-81', 1500, 0, 30),
						   (7876, 'ADAMS', 'CLERK', 7788, '23-MAY-87', 1100, NULL, 20),
						   (7900, 'JAMES', 'CLERK', 7698, '03-DEC-81', 950, NULL, 30),
						   (7902, 'FORD', 'ANALYST', 7566, '03-DEC-81', 3000, NULL, 20),
						   (7934, 'MILLER', 'CLERK', 7782, '23-JAN-82', 1300, NULL, 10)

create table DEPT (
DEPTNO int primary key,
DNAME varchar(20),
LOC varchar(30)
)

insert into DEPT values (10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40,'OPERATIONS','BOSTON')


select * from EMPLOYEE
select * from DEPT
---1. List all employees whose name begins with 'A'.
select * from EMPLOYEE where EMPNAME LIKE 'A%'

---2. Select all those employees who don't have a manager. 
select * from EMPLOYEE where MGRID IS NULL

--3. List employee name, number and salary for those employees who earn in the range 1200 to 1400. 
SELECT EMPNAME, EMPNO, SAL
FROM EMPLOYEE
WHERE SAL BETWEEN 1200 AND 1400

--4. Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise. 
SELECT * FROM EMPLOYEE WHERE DEPTNO = 20;
UPDATE EMPLOYEE SET SAL = SAL * 1.1 WHERE DEPTNO = 20;
SELECT * FROM EMPLOYEE WHERE DEPTNO = 20;

--5. Find the number of CLERKS employed. Give it a descriptive heading. 
Select COUNT(*) AS NUMBEROFCLERK from EMPLOYEE Where JOB='CLERK'

--6 Find the average salary for each job type and the number of people employed in each job.
SELECT JOB, AVG(SAL) AS 'AVERAGE SALARY', COUNT(*) AS NUMBER_OF_EMPLOYEES
FROM EMPLOYEE
GROUP BY JOB;

--7. List the employees with the lowest and highest salary. 
SELECT *  FROM EMPLOYEE ORDER BY SAL ASC
SELECT * FROM EMPLOYEE ORDER BY SAL DESC

SELECT * FROM EMPLOYEE WHERE SAL = (SELECT MIN(SAL) FROM EMPLOYEE)
UNION
SELECT * FROM EMPLOYEE WHERE SAL = (SELECT MAX(SAL) FROM EMPLOYEE)

--8. List full details of departments that don't have any employees. 
SELECT *
FROM DEPT
LEFT JOIN EMPLOYEE ON DEPT.deptno = EMPLOYEE.deptno
WHERE EMPLOYEE.empno IS NULL;

--9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name. 
SELECT * FROM EMPLOYEE
WHERE JOB = 'ANALYST' AND sal > 1200 AND DEPTNO= 20
ORDER BY EMPNAME ASC;

--10. For each department, list its name and number together with the total salary paid to employees in that department. 
SELECT DEPT.DNAME, DEPT.DEPTNO, SUM(EMPLOYEE.SAL) AS "Total Salary"
FROM DEPT 
LEFT JOIN EMPLOYEE ON DEPT.DEPTNO = EMPLOYEE.DEPTNO
GROUP BY DEPT.DEPTNO, DEPT.DNAME;

--11. Find out salary of both MILLER and SMITH.

SELECT EMPNAME, SAL FROM EMPLOYEE 
Where EMPNAME IN ('MILLER', 'SMITH')

--12. Find out the names of the employees whose name begin with ‘A’ or ‘M’. 
SELECT EMPNAME FROM EMPLOYEE
WHERE EMPNAME LIKE 'A%' OR EMPNAME LIKE 'M%';

--13. Compute yearly salary of SMITH. 
SELECT EMPNAME, SAL * 12 AS 'yearly Salary'
FROM EMPLOYEE
WHERE EMPNAME = 'SMITH';

--14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850. 
SELECT EMPNAME, SAL FROM EMPLOYEE
WHERE SAL NOT BETWEEN 1500 AND 2850;

--15. Find all managers who have more than 2 employees reporting to them

SELECT MGRID, COUNT(*) AS 'No Of Employees'
FROM EMPLOYEE
GROUP BY MGRID
HAVING COUNT(*) > 2;
SELECT EMPNAME
FROM EMPLOYEE
WHERE MGRID IN (SELECT MGRID FROM EMPLOYEE GROUP BY MGRID HAVING COUNT(*) > 2);

create table tblAudit(
details nvarchar(max))

create or alter trigger trgAuditDelete
on EMPLOYEE
for delete
as
begin
   declare @id int
   select @id = EMPNO from deleted
   --insert the deleted employee information into the audit table
   insert into tblAudit values('Employee with EmpNO:' + cast(@id as varchar(5)) +
   ' is deleted on :' + cast(getdate() as varchar(20)))
end

DELETE FROM EMPLOYEE WHERE EMPNO =(7934)

select * from tblAudit

select * from EMPLOYEE

 

create or alter trigger trgAuditInsert
on EMPLOYEE
for insert
as
begin
declare @id int
select @id=EMPNO from inserted
--insert the newly added employee into audit table
insert into tblAudit values('New Employee with EmpId :' + cast(@id as nvarchar(5)) +
'  is added on :' + cast(getdate() as varchar(20)))
end

insert into EMPLOYEE values (7934, 'MILLER', 'CLERK', 7782, '23-JAN-82', 1300, NULL, 10)
select * from tblAudit
select * from Employee

