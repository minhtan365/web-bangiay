set dateformat dmy
create database RedStore1
use RedStore1

create table Products
(
	idSP varchar(10) not null primary key,
	nameSP nvarchar(50) not null,
	imgSP varchar(max) not null,
	priceSP money not null,
	typeSP int not null,
	foreign key (typeSP) references typProducts(typeSP)
)


create table tkNguoiDung
(
	taiKhoan varchar(20) not null primary key,
	Email nvarchar(100) not null,
	passWords varchar(100) not null,
)

create table Users
(
	idUser int identity (1,1) primary key,
	userName nvarchar(100) not null,
	Email nvarchar(100) not null,
	numberPhone nvarchar(20) not null,
	Adress nvarchar(250),
)

create table Orders
(
	soDH varchar(10) not null primary key,
	idUser int not null,
	taiKhoan varchar(20),
	ngayDat datetime,
	ngayGiao datetime,
	diaChiGH nvarchar(250) not null,
)


create table detailOrders
(
	soDH varchar(10) not null,
	idSP varchar(10) not null,
	quanTity int not null,
	priceSP money not null,
	primary key (soDH,idSP),
	FOREIGN key (soDH) references Orders(soDH),
	foreign key (idSP) references Products(idSP)
)

create table typProducts
(
	typeSP int not null primary key,
	secTors nvarchar(90) not null,
	noTe ntext,
)

create table AdminAccounts
(
	idAdmin int identity(1,1) not null primary key,
	taiKhoanAdmin varchar(20) not null,
	matKhauAdmin varchar(100) not null,
)


ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Users FOREIGN KEY (idUser) REFERENCES Users(idUser);

ALTER TABLE detailOrders
ADD CONSTRAINT FK_detailOrders_Orders FOREIGN KEY (soDH) REFERENCES Orders(soDH);

ALTER TABLE detailOrders
ADD CONSTRAINT FK_detailOrders_Products FOREIGN KEY (idSP) REFERENCES Products(idSP);

-- Create foreign key relationship with tkNguoiDung (assuming taiKhoan is the linking column)
ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_tkNguoiDung FOREIGN KEY (taiKhoan) REFERENCES tkNguoiDung(taiKhoan);


insert into typProducts values(1,N'Sản phẩm quảng cáo','')
insert into typProducts values(2,N'Sản phẩm nổi bật','')
insert into typProducts values(3,N'Sản phẩm mới nhất','')
insert into typProducts values(4,N'Tất cả sản phẩm','')
select * from typProducts


insert into Products values('A01','SPQC','~/Chung/image/category-1.jpg','0',1)
insert into Products values('A02','SPQC','~/Chung/image/category-2.jpg','0',1)
insert into Products values('A03','SPQC','~/Chung/image/category-3 (2).jpg','0',1)
select * from Products

insert into Products values('B01','HRX by Hrithik Roshan','~/Chung/image/PRO.png','47.99',2)
insert into Products values('B02','MEN GREY OUT BACK OUTDOOR SHOES','~/Chung/image/OUTDOOR.png','50.00',2)
insert into Products values('B03','Men Black Trainer-1 Training or Gym Shoes','~/Chung/image/TRAINING.png','38.99',2)
insert into Products values('B04','Unisex Grey & Black Football Shoes','~/Chung/image/FOOTBALL.png','28.99',2)

insert into Products values('C05','Women Grey Flex Lite-1 Shoes','~/Chung/image/FLEX.png','42.99',3)
insert into Products values('C06','Men Black Urban Outdoor Shoes','~/Chung/image/Urban.png','29.99',3)
insert into Products values('C07','Men Grey Metaflash Running Shoes','~/Chung/image/GREY.png','54.99',3)
insert into Products values('C08','Men Black Mesh Running Shoes','~/Chung/image/RUNNING.png','49.99',3)

insert into Products values('S01','HRX by Hrithik Roshan','~/Chung/image/PRO.png','47.99','4')
insert into Products values('S02','MEN GREY OUT BACK OUTDOOR SHOES','~/Chung/image/OUTDOOR.png','50.00','4')
insert into Products values('S03','Men Black Trainer-1 Training or Gym Shoes','~/Chung/image/TRAINING.png','38.99','4')
insert into Products values('S04','Unisex Grey & Black Football Shoes','~/Chung/image/FOOTBALL.png','28.99','4')
insert into Products values('S05','Women Grey Flex Lite-1 Shoes','~/Chung/image/FLEX.png','42.99','4')
insert into Products values('S06','Men Black Urban Outdoor Shoes','~/Chung/image/Urban.png','29.99','4')
insert into Products values('S07','Men Grey Metaflash Running Shoes','~/Chung/image/GREY.png','54.99','4')
insert into Products values('S08','Men Black Mesh Running Shoes','~/Chung/image/RUNNING.png','49.99','4')
insert into Products values('S09','Men Black Running Shoes','~/Chung/image/BLACK.png','45.99','4')
insert into Products values('S10','Women White PROPULSION Running Shoes','~/Chung/image/WHITE.png','69.99','4')
insert into Products values('S11','HRX Mens cotton socks','~/Chung/image/product-7.jpg','09.00','4')
insert into Products values('S12','Flat Lace-Fastening Shoes','~/Chung/image/product-10.jpg','48.00','4')
insert into Products values('S13','Downshifter Sports Shoes','~/Chung/image/product-11.jpg','50.00','4')
insert into Products values('S14','Lace-Up Running Shoes','~/Chung/image/product-2.jpg','35.00','4')
insert into Products values('S15','Lace Fastening Shoes','~/Chung/image/product-3.jpg','15.00','4')
insert into Products values('S16','Flat Heel gray hoes','~/Chung/image/product-10.jpg','50.00','4')
insert into Products values('S17','Lace-Fastening white Shoes','~/Chung/image/product-12.jpg','21.00','4')

