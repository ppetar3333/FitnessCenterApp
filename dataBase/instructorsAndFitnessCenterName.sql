select instructor.firstName, instructor.lastName, instructor.gender, instructor.email, instructor.typeOfUser,
fitnessCenter.nameOfCenter
from Instructor as instructor
join FitnessCenter as fitnessCenter
on instructor.fitnessCenter = fitnessCenter.id;