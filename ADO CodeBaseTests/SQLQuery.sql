create database CodeBaseTestdb

use CodeBaseTestdb
CREATE TABLE Code_Employee (
   empno int primary key,
   empname varchar(35) not null,
   empsal numeric(10,2) check (empsal >= 25000),
   emptype char(1) check (emptype in ('F', 'P'))
);



CREATE or alter PROCEDURE  AddEmployee
   @empname varchar(45),
   @empsal numeric(10,3),
   @emptype char(1)
AS
BEGIN
   DECLARE @empno int;

   -- Generate a new employee number
   SELECT @empno = ISNULL(MAX(empno), 0) + 1 FROM Code_Employee;

   -- Insert the new employee record
   INSERT INTO Code_Employee (empno, empname, empsal, emptype)
   VALUES (@empno, @empname, @empsal, @emptype);
END;

