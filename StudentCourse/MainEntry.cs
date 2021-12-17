using System.Collections;

namespace StudentCourse;


public class MainEntry
{
    private List<Department> _departments = new List<Department>();
    private List<Course> _courses = new List<Course>();
    private IDictionary<string, Lecturer> _lecturerMap = new Dictionary<string, Lecturer>();
    private List<Student> _students = new List<Student>();
    private IDictionary<string, Student> _studentIDMap = new Dictionary<string, Student>();
    
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
        _departments.Add(deptEngineering);
        
        Course swen501 = new Course("SWEN501",deptEngineering,15,50);
        _courses.Add(swen501);
        Course swen502 = new Course("SWEN502",deptEngineering,45,50);
        _courses.Add(swen502);
        Course swen504 = new Course("SWEN504",deptEngineering,60,50);
        _courses.Add(swen504);
        
        Lecturer michael = new Lecturer("Michael", 35, 1, 4);
        _lecturerMap.Add("Michael",michael);
        Lecturer karsten = new Lecturer("Karsten", 40, 2, 4);
        _lecturerMap.Add("Karsten",karsten);
        Lecturer ali = new Lecturer("Ali", 30, 3, 4);
        _lecturerMap.Add("Ali",ali);
        
        Student yuri = new Student("Yuri", false,10);
        _students.Add(yuri);
        _studentIDMap.Add(yuri.Id.ToString(),yuri);
        Student rhea = new Student("Rhea", true,10);
        _students.Add(rhea);
        _studentIDMap.Add(rhea.Id.ToString(),rhea);
        Student penny = new Student("Penny", true,10);
        _students.Add(penny);
        _studentIDMap.Add(penny.Id.ToString(),penny);

    }

    public void AssignLecturer()
    {
        foreach(Lecturer lecturer in _lecturerMap.Values)
        {
            Console.WriteLine("Please select course to assign to " + lecturer.Name + " (separate by space for multiple course)");
            for (int i = 0; i < _courses.Count; i++)
            {
                Console.WriteLine((i+1) + ". " + _courses[i].Name );
            }
            string[] selections = Console.ReadLine().Split(" ");
            foreach (string selection in selections)
            {
                int index = Int32.Parse(selection) - 1;
                if (index >= 0 && index < _courses.Count)
                {
                    lecturer.TeachCourse(_courses[index]);
                }
                else
                {
                    Console.WriteLine("Invalid selection");
                }
            }
        }

    }

    public void EnrolStudent()
    {
        for (int i = 0; i < _departments.Count; i++)
        {
            Console.WriteLine((i+1) + ". " + _departments[i].Name );
        }
        Console.WriteLine("Please select department first: ");
        int selectionDpt = Int32.Parse(Console.ReadLine());
        if (selectionDpt > 0 && selectionDpt < _departments.Count + 1)
        {
            for (int i = 0; i < _courses.Count; i++)
            {
                Console.WriteLine((i+1) + ". " + _courses[i].Name );
            }
            Console.WriteLine("Please select course to continue: ");
            int selectionCrs = Int32.Parse(Console.ReadLine());
            if (selectionCrs > 0 && selectionCrs < _courses.Count + 1)
            {
                Course course = _courses[selectionCrs - 1];
                for (int i = 0; i < _students.Count; i++)
                {
                    Console.Write(_students[i].Id + ". " + _students[i].Name + " ");
                }
                Console.WriteLine("Please enter student id using space to separate:");
                string[] ids = Console.ReadLine().Split(" ");
                
                if (ids.Length != 0)
                {
                  foreach (string id in ids)
                  {
                      Student student = _studentIDMap[id];
                      course.Enroll(student);
                  }  
                }
                else
                {
                    Console.WriteLine("Invalid ID input");
                }
            }
            else
            {
                Console.WriteLine("Invalid course input");
            }
        }
        else
        {
            Console.WriteLine("Invalid department input");
        }
        
    }
    
    public void RecordGrades()
    {
        Console.WriteLine("Please enter lecturer name and id seperated by space to start marking: ");
        string[] input = Console.ReadLine().Split(" ");

        if (_lecturerMap.ContainsKey(input[0]))
        {
            foreach (Lecturer lecturer in _lecturerMap.Values)
            {
                if (input[0].Equals(lecturer.Name) && input[1].Equals(lecturer.Id.ToString()))
                {
                    lecturer.DoMarking();
                }
            } 
        }
        else
        {
            Console.WriteLine("No lecturer found with given information");
        }
        
        
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
        for (int i = 0; i < _departments.Count; i++)
        {
            Console.WriteLine((i+1) + ". " + _departments[i].Name );
        }
        int selection = Int32.Parse(Console.ReadLine());
        if (selection > 0 && selection < _departments.Count + 1)
        {
            _departments[selection - 1].CompareGPA();
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

