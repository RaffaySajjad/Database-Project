CREATE DATABASE PHS

create table Account
(
    cnic varchar(15) primary key,
    email varchar(35),
    password varchar(15),
    fName varchar(10),
    lName varchar(10)
)

create table Pharmacy
(
    cnic varchar(15) primary key,
    taxNo varchar(13),
    pName varchar(20),
    pAddress varchar(35),
    constraint pharmFk foreign key (cnic) references Account(cnic)
)

create table Customer
(
    cnic varchar(15) primary key,
    pAddress varchar(35),
    constraint custFk foreign key (cnic) references Account(cnic)
)

create table Doctor
(
    cnic varchar(15) primary key,
    experience int,
    regNo varchar(13),
    specialization varchar(20),
    charges float
    constraint docFk foreign key (cnic) references Account(cnic)
)

create table Stock
(
    idNum varchar(15),
    medicine varchar(15),
    qty int,
    price float,
    constraint stockFK foreign key (idNum) references Pharmacy(cnic),
    primary key (idNum, medicine)
)

create table Orders
(
    cnic varchar(15),
    [dateTime] datetime DEFAULT(getdate()),
    [service] varchar(30), -- Service = Medicine/ Doctor/ Lab
    cost float,
    serviceName varchar(15),
    [status] varchar(15),
    qty int,
    fullfilledBy varchar(25)
    constraint ordersFk foreign key (cnic) references Customer(cnic),
    primary key (cnic, [dateTime])
)

create table Subscribers
(
    email varchar(35) primary key,
    subscriptionStarted datetime DEFAULT(getdate())
)

create table Inquires
(
    [name] varchar(35),
    email varchar(35),
    registeredAt datetime,
    number varchar(35),
    [message] varchar(250),
    primary key(email, registeredAt)
)

create table Coupons
(
    code varchar(15) primary key,
    discount float,
    [status] varchar(7), -- Active/Expired
    usedBy varchar(35) -- Email of User 
)

----Functionalities----
go
create procedure registerAccount
    @cnic varchar(15),
    @email varchar(35),
    @password varchar(15),
    @fName varchar(10),
    @lName varchar(10)
as
begin
    set nocount on;
    insert into Account values(@cnic, @email, @password, @fName, @lName);
end

go
create procedure registerCustomer
    @cnic varchar(15),
    @pAddress varchar(35)
as
begin
    set nocount on;
    insert into Customer values(@cnic, @pAddress);
end

go
create procedure registerPharmacy
    @cnic varchar(15),
    @taxNo varchar(13),
    @pName varchar(20),
    @pAddress varchar(35)
as
begin
    set nocount on;
    insert into Pharmacy values(@cnic, @taxNo, @pName, @pAddress);
end

go
create procedure registerDoctor
    @cnic varchar(15),
    @experience int,
    @regNo varchar(13),
    @specialization varchar(20),
    @charges float
as
begin
    set nocount on;
    insert into Doctor values(@cnic, @experience, @regNo, @specialization, @charges);
end