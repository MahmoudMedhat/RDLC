create database Blogger
Create table Category(id int identity primary key , CategoryName nvarchar(100)null ,IMG image)
create table Articles(id int identity primary key,Descriptions nvarchar(max),Img nvarchar(70)null,category int FOREIGN KEY REFERENCES Category(id))
create table Logo(id int identity primary key ,Name nvarchar(20) , img nvarchar(150))