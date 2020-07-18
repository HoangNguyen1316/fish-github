

CREATE DATABASE MANAGEMENTsdf


--------CREATE TABLE----------------

USE MANAGEMENTsdf
CREATE TABLE dbo.LoginUser(
		ID char(10) PRIMARY KEY,
		Pass char(20),
		NameLog char(50)
		)


CREATE TABLE dbo.Type_product(
		ID char(10)  PRIMARY KEY,
		Type_Product nchar(50),
		Num_Of_Product int)

CREATE TABLE dbo.Detail_Product
(
		ID_Product char(10) PRIMARY KEY,
		ID_TypeProduct char(10),
		ID_Supplier char(10),
		Original_Price bigint,
		NameProduct nvarchar(50),
		Description_Pro nvarchar(Max),
		Image_Path nvarchar(Max),
		Amount_Current int,
		
)

CREATE TABLE dbo.Supplier(
		ID_sup char (10) PRIMARY KEY,
		Name_Sup nvarchar(50),
		Address_sup nvarchar(50),
		Phone char(10),
		Email char(50),
		MoreInfo nvarchar(Max)
		)
use MANAGEMENTsdf
CREATE TABLE dbo.Input_Form(
		ID_Input char(10) PRIMARY KEY,
		ID_Product char(10),
		ID_Sup char(10),
		Input_Date Datetime,
		Amount int
		)

CREATE TABLE dbo.Output_Form(
		ID_Output char(10) PRIMARY KEY,
		ID_Product char(10),
		ID_Customer char(10),
		Amount int,
		Output_Date Datetime,
		Event_ nvarchar (Max),
		Price_Sale bigint,
		Note nvarchar(Max),
		Status nvarchar(Max),
		BuyOnline nchar(10),
		Ship bigint
		)

CREATE TABLE dbo.Customer(
		ID_Customer char (10) PRIMARY KEY,
		Name_Cus nvarchar(50),
		Address_Cus nvarchar(50),
		Phone char(10),
		Birthday datetime ,
		Email char(50))
GO

------INSERT DATA-------------
USE MANAGEMENTsdf
------ Type-Product
Insert Into Type_Product values ('PAN001', 'Pant','3')
Insert Into Type_Product values ('SHI001', 'shirt','5')
Insert Into Type_Product values ('HAT001', 'Hat','4')
-------- Detail

------- 3- PANT 
Insert Into Detail_Product values ('Item001', 'PAN001', 'SUPP001',85000,'Jeans-Black',
				'Curve high rise StretcIh straight leg jeans in washed black','jeans-black.jpg',135000)
Insert Into Detail_Product values ('Item002', 'PAN001', 'SUPP001',140000,'Jeans-White',
				'Object straight leg jeans in white','jeans-white.jpg',195000)
Insert Into Detail_Product values ('Item003', 'PAN001', 'SUPP002',150000,'Jeans-Baggy',
				'Recycled Farleigh high waisted slim mom jeans in dark wash','jeans-Baggy.jpg',200000)
------------ 5- Shirt

Insert Into Detail_Product values ('Item004', 'SHI001', 'SUPP001',85000,'T-Shirt-Meo',
				'Curve high rise Stretch straight leg jeans in washed black','T-Shirt-Meo.jpg',135000)
Insert Into Detail_Product values ('Item005', 'SHI001', 'SUPP002',65000,'T-Shirt-Shiba',
				'Curve high rise Stretch straight leg jeans in washed black','T-Shirt-Shiba.jpg',145000)
Insert Into Detail_Product values ('Item006', 'SHI001', 'SUPP002',85000,'Crop-Top-Meo',
				'Curve high rise Stretch straight leg jeans in washed black','Crop-Top-Meo.jpg',108000)
Insert Into Detail_Product values ('Item007', 'SHI001', 'SUPP003',110000,'Crop-Top-Girl',
				'Curve high rise Stretch straight leg jeans in washed black','Crop-Top-Girl.jpg',165000)
Insert Into Detail_Product values ('Item008', 'SHI001', 'SUPP003',45000,'T-Shirt-Flex',
				'Curve high rise Stretch straight leg jeans in washed black','T-Shirt-Flex.jpg',65000)
-------------  4 Hat

Insert Into Detail_Product values ('Item009', 'HAT001', 'SUPP001',35000,'Rossy-Hat',
				'Curve high rise Stretch straight leg jeans in washed black','Rossy-hat.jpg',65000)
Insert Into Detail_Product values ('Item010', 'HAT001', 'SUPP003',55000,'Saturday-Hat',
				'Curve high rise Stretch straight leg jeans in washed black','Saturday-Hat.jpg',85000)
Insert Into Detail_Product values ('Item011', 'HAT001', 'SUPP003',45000,'Mike-Hat',
				'Curve high rise Stretch straight leg jeans in washed black','Mike-Hat.jpg',65000)
Insert Into Detail_Product values ('Item0012', 'HAT001', 'SUPP002',55000,'Jimmy-Hat',
				'Curve high rise Stretch straight leg jeans in washed black','Jimmy.jpg',85000)


------------Supplier
Insert into Supplier Values ('SUPP001', 'Adidas','Germany','0812345678',
'adidas@gmail.com','Adidas is the original sports brand')
Insert into Supplier Values ('SUPP002', 'Nike','Americas','0012345678',
'nike@gmail.com','Just do it')
Insert into Supplier Values ('SUPP003', 'Bitis','VietName','0333875388',
'bitisbietnams@gmail.com','Life is the trip')

----------- Customer
Insert Into Customer values ('CUS001','Mike','Da Kao Quan 1','0389790458','06-30-2000','mikefence@gmail.com')
Insert Into Customer values ('CUS002','Eirly','Quan 2','045678342','12-28-2000','eirly@gmail.com')
Insert Into Customer values ('CUS003','Hadest','Linh Chieu Thu Duc','0368045333','5-4-2000','Hadest@gmail.com')

-----------Input_Form

Insert Into Input_Form values ('Ip001','Item001','SUPP001',2-31-2020,500)
Insert Into Input_Form values ('Ip002','Item002','SUPP001',6-31-2020,400)
Insert Into Input_Form values ('Ip003','Item003','SUPP002',7-5-2020,700)
Insert Into Input_Form values ('Ip004','Item004','SUPP001',6-1-2020,200)
Insert Into Input_Form values ('Ip005','Item005','SUPP002',07-5-2020,500)
Insert Into Input_Form values ('Ip006','Item006','SUPP002',10-31-2020,800)
Insert Into Input_Form values ('Ip007','Item007','SUPP003',8-24-2020,600)
Insert Into Input_Form values ('Ip008','Item008','SUPP003',8-24-2020,500)
Insert Into Input_Form values ('Ip009','Item009','SUPP001',6-31-2020,100)
Insert Into Input_Form values ('Ip010','Item010','SUPP003',9-31-2020,500)
Insert Into Input_Form values ('Ip011','Item011','SUPP003',06-31-2020,80)
Insert Into Input_Form values ('Ip0012','Item012','SUPP001',06-31-2020,100)

-----Output_Form

Insert Into Output_Form values ('Out001','Item003','CUS001',3,9-12-2020,'no event',190000,NULL)
Insert Into Output_Form values ('Out002','Item008','CUS002',1,9-15-2020,'no event',80000,NULL)
Insert Into Output_Form values ('Out003','Item006','CUS003',5,10-12-2020,'Big sale 10%',130000,NULL)
Insert Into Output_Form values ('Out004','Item011','CUS002',4,11-19-2020,'Sale all 5%',190000,NULL)
------Login-----

Insert into LoginUser values ('ID001A','admin','admin')
Insert into LoginUser values ('ID002B','123456789','Nhanvien01')
Insert into LoginUser values ('ID003B','111111111','Nhanvien02')
Insert into LoginUser values ('ID004C','121245587','Nhanvien03')


----Staff------------------
