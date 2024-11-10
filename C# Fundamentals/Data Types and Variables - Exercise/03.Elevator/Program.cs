int people = int.Parse(Console.ReadLine());
int capacity = int.Parse(Console.ReadLine());

int courses = (int)Math.Ceiling((double)people / capacity);


/*int fullCourses = people/capacity;
int leftPeople = people%capacity;
if (leftPeople > 0)
{ 

int partiallyCourses = capacity/leftPeople;
int courses = fullCourses + partiallyCourses;
Console.WriteLine(courses);
}
else
{
Console.WriteLine(fullCourses);
}*/




