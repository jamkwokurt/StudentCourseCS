namespace StudentCourse;


public class MainEntry
{
    private List<Department> _department = new List<Department>();
    private List<Course> _courses = new List<Course>();
    private List<Lecturer> _lecturers = new List<Lecturer>();
    private List<Student> _students = new List<Student>();
    public MainEntry()
    {
        AddData();
        ShowMenu();
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("Please select from menu: ");
            Console.WriteLine("1. Assign Lecturer");
            Console.WriteLine("2. Enrol Student");
            Console.WriteLine("3. Record Grades");
            Console.WriteLine("4. Print Course Grades");
            Console.WriteLine("5. Print Student Grades");
            Console.WriteLine("6. Compare GPA");
            Console.WriteLine("7. Calculate Profit");
            Console.WriteLine("8. Go Back to Menu");
            int selection = Int32.Parse(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    AssignLecturer();
                    continue;
                case 2:
                    EnrolStudent();
                    continue;
                case 3:
                    RecordGrades();
                    continue;
                case 4:
                    PrintCourseGrades();
                    continue;
                case 5:
                    PrintStudentGrades();
                    continue;
                case 6:
                    CompareGPA();
                    continue;
                case 7:
                    CalculateProfit();
                    continue;
                case 8:
                    continue;
            }

            break;
        }
    }

    public void AddData()
    {
        Department deptEngineering = new Department("Engineering", 70.13, 294.90);
        _department.Add(deptEngineering);
        
        Course swen501 = new Course("SWEN501",deptEngineering,15,50);
        _courses.Add(swen501);
        Course swen502 = new Course("SWEN502",deptEngineering,45,50);
        _courses.Add(swen502);
        Course swen504 = new Course("SWEN504",deptEngineering,60,50);
        _courses.Add(swen504);
        
        Lecturer michael = new Lecturer("Michael", 35, 2, 4);
        _lecturers.Add(michael);
        Lecturer karsten = new Lecturer("Karsten", 40, 1, 4);
        _lecturers.Add(karsten);
        Lecturer ali = new Lecturer("Ali", 30, 3, 4);
        _lecturers.Add(ali);
        
        Student yuri = new Student("Yuri", false,10);
        _students.Add(yuri);
        Student rhea = new Student("Rhea", true,10);
        _students.Add(rhea);
        Student penny = new Student("Penny", true,10);
        _students.Add(penny);

    }

    public void AssignLecturer()
    {
        foreach(Lecturer lecturer in _lecturers)
        {
            Console.WriteLine("Please select course for " + lecturer.Name);
            for (int i = 0; i < _courses.Count; i++)
            {
                Console.WriteLine((i+1) + ". " + _courses[i].Name );
            }
            int selection = Int32.Parse(Console.ReadLine());
            if (selection > 0 && selection < _courses.Count + 1)
            {
                lecturer.TeachCourse(_courses[selection - 1]);
            }
            else
            {
                Console.WriteLine("Invalid selection");
            }
        }
        
        // michael.TeachCourse(swen501);
        // karsten.TeachCourse(swen502);
        // ali.TeachCourse(swen504);
    }

    public void EnrolStudent()
    {
        foreach (Student student in _students)
        {
            Console.WriteLine("Please add course for " + student.Name);
            for (int i = 0; i < _courses.Count; i++)
            {
                Console.WriteLine((i+1) + ". " + _courses[i].Name );
            }
            int selection = Int32.Parse(Console.ReadLine());
            if (selection > 0 && selection < _courses.Count + 1)
            {
                _courses[selection - 1].Enroll(student);
            }
            else
            {
                Console.WriteLine("Invalid selection");
            }
        }
        // swen501.Enroll(yuri);
        // swen501.Enroll(rhea);
        // swen501.Enroll(penny);
        // swen502.Enroll(yuri);
        // swen502.Enroll(rhea);
        // swen502.Enroll(penny);
        // swen504.Enroll(yuri);
        // swen504.Enroll(rhea);
        // swen504.Enroll(penny);
    }

    public void RecordGrades()
    {
        Console.WriteLine("Please enter lecturer name and id seperated by space to start marking: ");
        string[] input = Console.ReadLine().Split(" ");
        foreach (Lecturer lecturer in _lecturers)
        {
            if (input[0].Equals(lecturer.Name) && input[1].Equals(lecturer.Id.ToString()))
            {
                lecturer.DoMarking();
            }
            else
            {
                Console.WriteLine("Lecturer information not found. Please try again");
            }
        }
        
        // michael.DoMarking();
        // karsten.DoMarking();
        // ali.DoMarking();
    }

    public void PrintCourseGrades()
    {
        Console.WriteLine("Please select course to print marking");
        for (int i = 0; i < _courses.Count; i++)
        {
            Console.WriteLine((i+1) + ". " + _courses[i].Name );
        }
        int selection = Int32.Parse(Console.ReadLine());
        if (selection > 0 && selection < _courses.Count + 1)
        {
            _courses[selection - 1].GetAllStudentMarks();
        }
        else
        {
            Console.WriteLine("Invalid selection");
        }
    }

    public void PrintStudentGrades()
    {
        Console.WriteLine("Please select student to print marking");
        for (int i = 0; i < _students.Count; i++)
        {
            Console.WriteLine((i+1) + ". " + _students[i].Name );
        }
        int selection = Int32.Parse(Console.ReadLine());
        if (selection > 0 && selection < _students.Count + 1)
        {
            _students[selection - 1].GetAllCourseMarks();
        }
        else
        {
            Console.WriteLine("Invalid selection");
        }
    }

    public void CompareGPA()
    {
        Console.WriteLine("Please select department to start:");
        for (int i = 0; i < _department.Count; i++)
        {
            Console.WriteLine((i+1) + ". " + _department[i].Name );
        }
        int selection = Int32.Parse(Console.ReadLine());
        if (selection > 0 && selection < _department.Count + 1)
        {
            _department[selection - 1].CompareGPA();
        }
        else
        {
            Console.WriteLine("Invalid selection");
        }
    }

    public void CalculateProfit()
    {
        Console.WriteLine("Please select course to calculate: ");
        for (int i = 0; i < _courses.Count; i++)
        {
            Console.WriteLine((i+1) + ". " + _courses[i].Name );
        }
        int selection = Int32.Parse(Console.ReadLine());
        if (selection > 0 && selection < _courses.Count + 1)
        {
            _courses[selection - 1].CalculateProfit();
        }
        else
        {
            Console.WriteLine("Invalid selection");
        }
    }
    
    private static void Main(string[] args)
    {
        Console.WriteLine("========== Student and Course Management System ==========");
        new MainEntry();
    }
}



