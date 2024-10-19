using System;
using System.Collections.Generic;

public delegate bool IsEligibleforScholarship(Student student);
public class Student
{
    public int RollNo { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
    public char SportsGrade { get; set; }

    public static string GetEligibleStudents(List<Student> studentsList, IsEligibleforScholarship isEligible)
    {
        List<string> eligibleStudents = new List<string>();

        foreach (Student student in studentsList)
        {
            if (isEligible(student))
            {
                eligibleStudents.Add(student.Name);
            }
        }

        return string.Join(", ", eligibleStudents);
    }
}

public class Program5
{
    public static bool ScholarshipEligibility(Student student)
    {
        return student.Marks > 80 && student.SportsGrade == 'A';
    }

    static void Main()
    {
        List<Student> lstStudents = new List<Student>
        {
            new Student { RollNo = 1, Name = "Raj", Marks = 75, SportsGrade = 'A' },
            new Student { RollNo = 2, Name = "Rahul", Marks = 82, SportsGrade = 'A' },
            new Student { RollNo = 3, Name = "Kiran", Marks = 89, SportsGrade = 'B' },
            new Student { RollNo = 4, Name = "Sunil", Marks = 86, SportsGrade = 'A' }
        };


        IsEligibleforScholarship eligibilityCheck = new IsEligibleforScholarship(ScholarshipEligibility);

        string eligibleStudents = Student.GetEligibleStudents(lstStudents, eligibilityCheck);

        Console.WriteLine(eligibleStudents);
    }
}