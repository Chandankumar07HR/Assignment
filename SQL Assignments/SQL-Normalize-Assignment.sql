create database NormalizeDB

use NormalizeDB


create table NF1tbl
(
Clientno varchar(15),
Cname varchar(30),
PropertyNo varchar(15),
Paddress varchar(40),
RentStart date,
RentFinish date,
Rent int,
OwnerNo varchar(20),
Oname varchar(30)
)

insert into NF1tbl values('CR76','John kay','pg4','6 lawerence st.Glasgow','1-jul-00','31-aug-01',350,'CO40','Tina Murphy'),
('CR76','John kay','pg16','5 novar dr glasgow','1-sep-02','1-sep-03',450,'CO93','Tony Shaw'),
('CR56','Aline Stewart','pg4','6 lawerence st.glasgow','1-sep-99','10-jun-00',350,'CO40','Tina Murphy'),
('CR56','Aline Stewart','pg36','2 manor rd.glasgow','10-oct-00','1-dec-01',370,'CO93','Tony Shaw'),
('CR56','Aline Stewart','pg16','5 novar dr glasgow','1-nov-02','1-aug-03',450,'CO93','Tony Shaw')

select * from NF1tbl

create table Client
(
Clientno varchar(10) primary key,
Cname varchar(20)
)

insert into Client values('CR76','John kay'),
                         ('CR56','Aline Stewart')

select * from Client

create table Owner
(
OwnerNo varchar(15)primary key,
Oname varchar(30)
)

insert into Owner values ('CO40','Tina Murphy'),
                         ('CO93','Tony Shaw')
select * from Owner

create table PropertyOwner
(
PropertyNo varchar(20) primary key,
paddress varchar(30),
Rent int,
Ownerno varchar(15) foreign key references Owner(OwnerNo)
)

insert into PropertyOwner values('pg4','6 lawerence st.glasgow',350,'CO40'),
('pg16','5 novar dr glasgow ',450,'CO93'),
('pg36','2 manor rd.glasgow ',370,'CO93')
select * from PropertyOwner

create table Rental
(
ClientNo varchar(10) foreign key references Client(Clientno),
PropertyNo varchar(20) foreign key references PropertyOwner(PropertyNo),
RentStart date,
RentFinish date)

insert into Rental values('CR76','pg4','2000-07-01','2001-08-31'),
('CR76','pg16','2002-09-01','2003-09-01'),
('CR56','pg4','1999-09-01','2000-06-10'),
('CR56','pg36','2000-10-10','2001-12-01'),
('CR56','pg16','2002-11-01','2003-08-01')

select * from Rental

select * from NF1tbl
select c.Clientno,c.Cname,po.propertyno,po.paddress,po.rent,r.rentstart,r.rentfinish, o.oname, o.OwnerNo  from Client c inner join Rental r on c.Clientno=r.ClientNo inner join PropertyOwner po on r.PropertyNo=po.PropertyNo inner join Owner o on po.Ownerno=o.OwnerNo
