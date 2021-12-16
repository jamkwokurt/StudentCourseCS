using System.Collections;

namespace StudentCourse;

public class Lecturer
{
    private string _name;
    private int _id;
    private List<Course> _courses;

    public Lecturer(string name, double hourlyRate, int id, int limits)
    {
        _name = name;
        HourlyRate = hourlyRate;
        _id = id;
        Limits = limits;
        _courses = new List<Course>();
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double HourlyRate { get; set; }

    public List<Course> Courses
    {
        get => _courses;
        set => _courses = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Limits { get; set; }

    public void TeachCourse(Course course)
    {
        if (this._courses.Count < this.Limits)
        {
            this._courses.Add(course); 
            course.Lecturers.Add(this);
        }
        else
        {
            Console.WriteLine("Failed to teach course; number reached limit!");
        }
        
    }

    public void DoMarking(Course course)
    {
        if (!course.IsMarked)
        {
           foreach (Student student in course.Students)
           {
               Console.WriteLine("Student name: " + student.Name + " id: " + student.Id + " please input mark:");
               int mark = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
               if (mark > 100 || mark < 0)
               {
                   Console.WriteLine("Invalid marking; mark must be less than or equal to 100 and greater than or equal to 0.");
               }
               student.Marks.Add(course.Name,mark);
           }

           course.IsMarked = true;
        }
        else
        {
            Console.WriteLine("Course is already marked");
        }
        
    }
}
