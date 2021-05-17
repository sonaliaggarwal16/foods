create database food
use food
create table customer_login_table(cid int primary key identity(1,1),c_name varchar(50),c_password varchar(50))
select * from customer_login_table
drop table customer_login_table
create table admin_login_table(admin_id int primary key identity(1,1),admin_name varchar(50),admin_password varchar(50))
insert into admin_login_table values('sona','123')
select * from admin_login_table
create table customer_detail_table(c_name varchar(50),c_email varchar (50),c_password varchar (50),c_contact varchar (10),c_adress varchar (50))
select * from customer_detail_table
drop table customer_detail_table


select * from product_details_table;


drop table product_details_table
select * from product_details_table
create table product_details_table(product_id int primary key identity(1,1),product_img_url varchar(50),p_name varchar (50),p_categor varchar(50),p_price varchar (50))
create table Cart_Details_table(Cart_id int primary key identity(1,1),product_id varchar (50),quantity int,p_price varchar (50),total varchar (50),cid varchar (50))
drop table Cart_Details_table
select * from Cart_Details_table
create table Payment_Details_table(Payment_Id varchar (50),Cart_id varchar (50), product_id varchar (50),p_price varchar (50),shiping varchar (50),total varchar (50),cid varchar (50),dateandtime varchar (50))
select * from Payment_Details_table
drop table Payment_Details_table
CREATE proc [getcartproductdetailsbycid] 
@cid int
as 
begin
SELECT       product_details_table.*,Cart_Details_table.*
FROM           Cart_Details_table INNER JOIN
                        product_details_table ON Cart_Details_table.product_id= product_details_table.product_id 
						 where Cart_Details_table.cid=@cid
end

drop procedure getcartproductdetailsbycid
create proc [getpaymentproductdetailsbyidanddate]
@payment varchar(50),
@cid int,
@date varchar(50)
as
begin
SELECT         Payment_Details_table.*,  Payment_Details_table.*
FROM           Payment_Details_table INNER JOIN
                         product_details_table ON  Payment_Details_table.product_id =product_details_table.product_id
						 where Payment_Id=@payment and Payment_Details_table.cid=@cid and dateandtime=@date
end

create proc [getallproductnames]
 @productname varchar(50)
 as
 begin
 select * from product_details_table
 where p_name  LIKE @productname + '%' 
 end

 create proc [getpaymentproductdetailsbyidanddate]
@payment varchar(50),
@cid int,
@date varchar(50)
as
begin
SELECT        Payment_Details.*, product_details_table.*
FROM            Payment_Details INNER JOIN
                        product_details_table ON Payment_Details_table.product_id= product_details_table.product_id
						 where Payment_Id=@payment and Payment_Details_table.cid=@cid and dateandtime=@date
end
allter 