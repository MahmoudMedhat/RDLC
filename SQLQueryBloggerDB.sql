create database Blogger
Create table Category(id int identity primary key , CategoryName nvarchar(100)null ,IMG image)
create table Articles(id int identity primary key,Descriptions nvarchar(max),Img nvarchar(70)null,category int FOREIGN KEY REFERENCES Category(id))
create table Logo(id int identity primary key ,Name nvarchar(20) , img nvarchar(150))

insert into  dbo.Logo(Name,img) values ('img','file:///c:/users/mahmoud/documents/visual%20studio%202015/Projects/RDLCProj/RDLCProj/images/images.jpg')
insert into  dbo.Logo(Name,img) values ('Apple','file:///c:/users/mahmoud/documents/visual%20studio%202015/Projects/RDLCProj/RDLCProj/images/Apple.jpg')

create proc ProcSelectArticles @Name nvarchar(100)
as
begin
SELECT Articles.Descriptions, Category.CategoryName, Articles.Img FROM Articles INNER JOIN Category ON Articles.category = Category.id
where CategoryName like '%'+@Name+'%'
end


create view SelectArticles
as
SELECT Articles.Descriptions, Category.CategoryName, Articles.Img FROM Articles INNER JOIN Category ON Articles.category = Category.id

create view ViewLogo
as
select Name , img from dbo.logo