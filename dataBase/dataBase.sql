create table Addresses(
	id int primary key (id asc) not null,
	street varchar(30) null,
	number varchar(30) null,
	city varchar(30) null,
	country varchar(30) null,
	active bit not null
);
insert into Addresses values (1001,'Sime matavulja','15','Novi Sad','Srbija',1);
insert into Addresses values (1002,'Jevrejska','18','Beograd','Srbija',1);
insert into Addresses values (1003,'Lajkovacka pruga','68','Lajkovac','Srbija',1);
insert into Addresses values (1004,'Knez Mihailova','13','Lajkovac','Srbija',1);

create table FitnessCenter(
	id int primary key (id asc) not null,
	nameOfCenter varchar(30) null,
	addressID int null,
	foreign key (addressID) references Addresses (id),
	active bit not null
);
insert into FitnessCenter values(1,'City Fitness',1001,1);

create table Instructor(
	id int primary key (id asc) not null,
	firstName varchar(30) null,
	lastName varchar(30) null,
	jmbg bigint unique,
	gender varchar(10) check (gender in('male','female')),
	addressID int null,
	foreign key (addressID) references Addresses (id),
	email varchar(50) null,
	passwordOfUser varchar(20) not null,
	fitnessCenter int references FitnessCenter (id),
	typeOfUser varchar(30) check (typeOfUser in('instruktor')),
	active bit not null
);
insert into Instructor values(2001,'Petar','Petrovic',1111111111111,'male',1002,'ppetar33@gmail.com','test',1,'instruktor',1);
insert into Instructor values(2002,'Marko','Markovic',2222222222222,'male',1003,'mmarko33@gmail.com','test',1,'instruktor',1);
insert into Instructor values(2003,'Jovana','Jovanovic',3333333333333,'female',1004,'jjovana33@gmail.com','test',1,'instruktor',1);

create table Beginner(
	id int primary key (id asc) not null,
	firstName varchar(30) null,
	lastName varchar(30) null,
	jmbg bigint unique,
	gender varchar(10) check (gender in('male','female')),
	addressID int null,
	foreign key (addressID) references Addresses (id),
	email varchar(50) null,
	passwordOfUser varchar(20) not null,
	typeOfUser varchar(30) check (typeOfUser in('polaznik')),
	active bit not null
);
insert into Beginner values(3001,'Stefan','Stefanovic',4444444444444,'male',1002,'sstefan33@gmail.com','test','polaznik',1);
insert into Beginner values(3002,'Marina','Marinovic',6666666666666,'female',1001,'mmarina33@gmail.com','test','polaznik',1);
insert into Beginner values(3003,'Darko','Darkovic',5555555555555,'male',1003,'ddarko33@gmail.com','test','polaznik',1);

create table Administrator(
	id int primary key (id asc) not null,
	firstName varchar(30) null,
	lastName varchar(30) null,
	jmbg bigint unique,
	gender varchar(10) check (gender in('male','female')),
	addressID int null,
	foreign key (addressID) references Addresses (id),
	email varchar(50) null,
	passwordOfUser varchar(20) not null,
	typeOfUser varchar(30) check (typeOfUser in('administrator')),
	active bit not null
);
insert into Administrator values(5001,'Lea','Jovanovic',1231231231233,'female',1001,'llea33@gmail.com','test','administrator',1);
insert into Administrator values(5002,'Vladimir','Vladimirovic',2323232323232,'male',1004,'vvladimir33@gmail.com','test','administrator',1);
insert into Administrator values(5003,'Stefana','Stefanovic',4533232323232,'female',1003,'jjovana33@gmail.com','test','administrator',1);

create table TrainingSchedule(
	id int primary key (id asc) not null,
	dateOfTraining datetime null,
	stratTime varchar(10) null,
	durationOfTraining int null, 
	statusOfTraining varchar(15) check (statusOfTraining in('slobodan','rezervisan')),
	instructor int null,
	foreign key (instructor) references Instructor (id),
	beginner int null,
	foreign key (beginner) references Beginner (id),
	active bit not null
);
insert into TrainingSchedule values(4001,'2020-10-12','15:30',60,'rezervisan',2001,3001,1);
insert into TrainingSchedule values(4002,'2020-11-13','09:30',45,'rezervisan',2001,3001,1);
insert into TrainingSchedule values(4003,'2020-12-14','20:30',30,'slobodan',null,null,1);