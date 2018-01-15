using System;
using System.Collections.Generic;
using System.Linq;

//Write a class Student with the following properties: first name, last name
//and age.Write a method that for a given array of students finds those,
//whose first name is before their last one in alphabetical order.Use LINQ.

public class Student
{
    public string FirstName { get; private set; }
    
    public string LastName { get; private set; }

    public int Age { get; private set; }
    
    public Student(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;

        this.LastName = lastName;

        this.Age = age;
    }

    static IEnumerable<Student> AlphabeticalNames(List<Student> listStudents)
    {
        var selection =

            from students in listStudents

            where students.FirstName.CompareTo(students.LastName) < 0

            orderby students.LastName

            select students;

        return selection;
    }

    public static void PrintStudentABC()
    {
        Console.WriteLine("Please type the number of student/s to be checked:");
       
        int numOfStudent = int.Parse(Console.ReadLine());

        List<Student> listOfStudents = new List<Student>();

        for (int i = 0; i < numOfStudent; i++)
        {
            string inpStudent = Console.ReadLine();

            string[] studentPropert = inpStudent.Split(' ');

            listOfStudents.Add(new Student(studentPropert[0], studentPropert[1], int.Parse(studentPropert[2])));
        }

        IEnumerable<Student> studentsSortedAlphabetical = AlphabeticalNames(listOfStudents);

        foreach (Student student in studentsSortedAlphabetical)

        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Age);
        }
    }

    public static void Main(string[] args)
    {
        PrintStudentABC();
    }

}

