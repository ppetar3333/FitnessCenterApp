alter table Beginner add listOfReservedTrainings varchar(max)

update Beginner set listOfReservedTrainings = CONCAT(listOfReservedTrainings, '4001,4002') where id=3001

alter table Instructor add listOfTrainings varchar(max)

update Instructor set listOfTrainings = CONCAT(listOfTrainings, '4001,4002') where id=2001