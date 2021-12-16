using System.Collections;

namespace StudentCourse;

public class Student
{
    private string _name;
    private static int lastId = 0;
    private bool _isDomesticStudent;
    private List<Course> _coursesEnrolled;
    private Dictionary<string, double> _marks;
    

    public Student(string name,bool isDomesticStudent, int limits)
    {
        this._name = name;
        this.Id = GenerateId();
        this._isDomesticStudent = isDomesticStudent;
        this.Limits = limits;
        _coursesEnrolled = new List<Course>();
        _marks = new Dictionary<string, double>();
    }

    public int Id { get; set; }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static int GenerateId()
    {
        return Interlocked.Increment(ref lastId);
    }
    
    public double CourseFeePerPoint { get; set; }

    public List<Course> CoursesEnrolled
    {
        get => _coursesEnrolled;
        set => _coursesEnrolled = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Dictionary<string, double> Marks
    {
        get => _marks;
        set => _marks = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Limits { get; set; }

    public void addCourse(Course course)
    {
        if (this._coursesEnrolled.Count < this.Limits)
        {
            payForCourse(course);
            _coursesEnrolled.Add(course);
        }
        else
        {
            Console.WriteLine("Failed to add course " + course.Name + ". " + "Number reached limit!");
        }
    }

    public void payForCourse(Course course)
    {
        if (_isDomesticStudent)
        {
            CourseFeePerPoint = course.Department.FeePerPointDom;
        }
        else
        {
            CourseFeePerPoint = course.Department.FeePerPointInt;
        }

        double feeTotal = course.Points * CourseFeePerPoint;
        course.Profit += feeTotal;
    }
    
    public void GetAllCourseMarks()
    {
        if (_coursesEnrolled != null)
        {
            Console.WriteLine(_name + "'s Grades listed below: ");
            foreach (Course course in _coursesEnrolled)
            {
                Console.WriteLine("Course name: " + course.Name + " mark: " + _marks[course.Name]);
            }   
        }
       
    }
}