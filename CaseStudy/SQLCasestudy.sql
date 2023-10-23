create database CasestudyDB

use CasestudyDB

Create table Students
(
id int primary key,
name nvarchar(200),
dateOfBirth Date
);

select id as 'Student ID', name as 'Student name' from Students


Create table Courses
(
id int primary key,
name nvarchar(200));

select id as Cource_Id, name as CourseName from Courses

Create table Enrollments
(
Enrollmentid int primary key,
studentId int,
studentname varchar(200),
courseId int,
coursename varchar(200),
enrollmentDate DATETIME
);
--foreign key(studentId) references Students(id),
--foreign key(courseId) references Courses(id)




select * from Enrollments
delete from Students where id=1
delete from Courses where id =1

delete from Enroll



