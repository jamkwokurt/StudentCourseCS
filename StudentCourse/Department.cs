using System.Collections;
using Microsoft.VisualBasic;

namespace StudentCourse;

public class Department
{
    private string _name;
    private List<Course> _courses;
    private IDictionary<string, List<string>> _result;

    public Department(string name, double feePerPointDom, double feePerPointInt)
    {
        _name = name;
        this.FeePerPointDom = feePerPointDom;
        this.FeePerPointInt = feePerPointInt;
        this._courses = new List<Course>();
        this._result = new Dictionary<string, List<string>>();
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double FeePerPointDom { get; set; }

    public double FeePerPointInt { get; set; }

    public List<Course> Courses
    {
        get => _courses;
        set => _courses = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void AddCourse(Course course)
    {
        this._courses.Add(course);
        course.Department = this;
    }

    public void CompareGPA()
    {
        IDictionary<string, double> gpaMap = new Dictionary<string, double>();
        foreach (Course course in _courses)
        {
            double courseMarkSum = 0;
            foreach (Student student in course.Students)
            {
                double mark = student.Marks[course.Name];
                courseMarkSum += mark;
            }
            double gpa = courseMarkSum / course.Students.Count;
            gpaMap.Add(course.Name,gpa);
        }

        double gpaSum = 0;
        foreach (double gpa in gpaMap.Values)
        {
            gpaSum += gpa;
        }

        double gpaAve = gpaSum / _courses.Count;
        
        var higher = new List<string>();
        var equal = new List<string>();
        var lower = new List<string>();
        _result.Add("higher",higher);
        _result.Add("equal",equal);
        _result.Add("lower",lower);
        
        foreach (KeyValuePair<string,double> pair in gpaMap)
        {
            
            if (pair.Value > gpaAve)
            {
                _result["higher"].Add(pair.Key);
            }
            else if (pair.Value == gpaAve)
            {
                _result["equal"].Add(pair.Key);
            }
            else
            {
                _result["lower"].Add(pair.Key);
            }
            
        }

        Console.WriteLine("Courses that have GPAs higher than the department average:");
        foreach (string course in _result["higher"])
        {
            Console.WriteLine(course);
        }
        Console.WriteLine("Courses that have GPAs equal to the department average:");
        foreach (string course in _result["equal"])
        {
            Console.WriteLine(course);
        }
        Console.WriteLine("Courses that have GPAs lower than the department average:");
        foreach (string course in _result["lower"])
        {
            Console.WriteLine(course);
        }
        
    }
}