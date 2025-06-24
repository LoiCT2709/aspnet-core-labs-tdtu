Create database Thu_nghiem;

go

use Thu_nghiem;


go
--tẠO BẢNG
CREATE TABLE Customer(
	CustomerID int primary key,
	CustomerName nvarchar(100),
	Address nvarchar(200),
	Amount int
)
go

--Thêm dữ liệu:
insert into Customer(CustomerID, CustomerName, Address, Amount)
values 
(1,N'David',N'Texas',1500),
(2, N'Tony',N'NewYork',3000),
(3, N'Alice',N'LA', 5000),
(4, N'Tom',N'California',2500);


