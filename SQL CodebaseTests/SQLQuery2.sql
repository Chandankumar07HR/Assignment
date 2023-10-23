use Assignment2DB

select * from dbo.EMPLOYEE

select * from dbo.DEPT

DECLARE
 @EMPNO INT,
 @SALARY INT;

DECLARE cursor_employee CURSOR FOR
 SELECT EMPNO, SAL
 FROM EMPLOYEE
 WHERE DEPTNO = 10; 

OPEN cursor_employee;

FETCH NEXT FROM cursor_employee INTO @EMPNO, @SALARY;

WHILE @@FETCH_STATUS = 0
BEGIN

 SET @SALARY = @SALARY * 1.15;

 UPDATE EMPLOYEE
 SET SAL = @SALARY
 WHERE EMPNO = @EMPNO;

 FETCH NEXT FROM cursor_employee INTO @EMPNO, @SALARY;
END;

CLOSE cursor_employee;
DEALLOCATE cursor_employee;
