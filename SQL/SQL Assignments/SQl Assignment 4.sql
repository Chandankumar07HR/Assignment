--1Write a T-SQL Program to find the factorial of a given number.
-- here given number is =4
declare @num int
declare @Fact int
set @num = 4 
set @Fact = 1
while @num > 1
begin
    set @Fact  = @Fact  * @num
    set @num = @num - 1
end
select @fact as factorial



--2 Create a stored procedure to generate multiplication tables up to a given number.
create or alter procedure multiplication(@number int)
as
begin
declare @num int
declare @Table int
set @num =1
while(@num<=10)
begin
set @Table = @number*@num
print cast(@number as varchar(15)) +'*'+ cast (@num as varchar(20)) + '='+ cast(@table as varchar(30))
set @num=@num+1
end
end

multiplication 7

--Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like �Due to Independence day you cannot manipulate data� or "Due To Diwali", you cannot manupulate" etc

--Note: Create holiday table as (holiday_date,Holiday_name) store at least 4 holiday details. try to match and stop manipulation 

CREATE TABLE Holiday
(
Holiday_date DATE PRIMARY KEY,
Holiday_Name VARCHAR(20)
)

INSERT INTO Holiday VALUES
('2023-02-08', 'Dipavali'),
('2022-03-22', 'Ganesha Chathurthi'),
('2021-02-28', 'Yugadi'),
('2020-06-23', 'Bhakrid');

CREATE OR ALTER TRIGGER RestrictData
ON EMPLOYEE
FOR INSERT, UPDATE, DELETE
AS
BEGIN
   DECLARE @Holiday_Name VARCHAR(40), @Holiday_date DATE
   SET @Holiday_date = CONVERT(DATE, GETDATE())

   SELECT @Holiday_Name = Holiday_Name
   FROM Holiday
   WHERE Holiday_date = @Holiday_date

   IF @Holiday_Name IS NOT NULL
   BEGIN
       ROLLBACK TRANSACTION
        raiserror('Due to yugadi day you cannot manipulate data�',18,2)
   END
END

Insert into EMPLOYEE Values(8733,'chethan','clerk',3948,'1999-9-18',8888, 700,10)
select * from Holiday








