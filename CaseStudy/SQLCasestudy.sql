create database CasestudyDB

use CasestudyDB

Create table Students
(
id int primary key,
name nvarchar(200),
dateOfBirth Date
);

select * from Students



Create table Courses
(
id int primary key,	
name nvarchar(200),
fees decimal(10, 2));

delete from Courses where id = 202

select * from courses

Create table Enrollments
(
Enrollmentid int IDENTITY(301, 1) primary key,
studentId int,
studentname varchar(200),
courseId int,
coursename varchar(200),
coursefees decimal(10,2),
enrollmentDate DATETIME
foreign key(studentId) references Students(id),
foreign key(courseId) references Courses(id),
unique(studentId,courseId)
);


select id as StudentID, name as StudentName from Students
select id as CourseId, name as CourseName from courses
select * from Enrollments










