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

    public int Id
    {
        get => _id;
        set => _id = value;
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

    public void DoMarking()
    {
        if (_courses.Count != 0)
        {
            Console.WriteLine("You're marking as " + _name + " and course you teach listed below: ");
            for (int i = 0; i < _courses.Count; i++)
            {
                Console.Write(i + 1 + ". " + _courses[i].Name + " ");
                Console.WriteLine("\nPlease select a course to mark:");
                int selection = Int32.Parse(Console.ReadLine());
                if (selection > 0 && selection < _courses.Count + 1)
                {
                    Course course = _courses[selection - 1];
                    if (!course.IsMarked)
                    {
                        foreach (Student student in course.Students)
                        {
                            Console.WriteLine("Student name: " + student.Name + " id: " + student.Id + " please input mark:");
                            int mark = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                            if (mark <= 100 && mark >= 0)
                            {
                                student.Marks.Add(course.Name,mark);
                            }
                            else
                            {
                                Console.WriteLine("Invalid marking; mark must be less than or equal to 100 and greater than or equal to 0.");
                            }
                       
                        }
               
                        course.IsMarked = true;
                    }
                    else
                    {
                        Console.WriteLine("Course is already marked");
                    }  
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
        else
        {
            Console.WriteLine("No course on record");
        }
        
    }
}
