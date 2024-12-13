Procedures in MySql

delimiter //
create procedure GetProducts()
begin
   select * from Products;
end;
//
call GetProducts()
delimiter //
create procedure AddProduct(in Pname varchar(255),in price decimal(10,2))
begin
	insert into Products(ProName,Price) values (Pname,price);
end//
 
 delimiter //
 create procedure UpdateProduct(in Proid int,in proname varchar(100),in price decimal(10,2))
 begin
	update Products set ProName=proname,Price=price where ProdId=Proid;
end//
 

delimiter //
create procedure GetProductbyId(in id int)
begin
    select * from Products where ProdId = id;
end;
//

