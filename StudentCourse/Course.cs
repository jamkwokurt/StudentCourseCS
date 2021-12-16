using System.Collections;

namespace StudentCourse;

public class Course
{
    private string _name;
    private static int lastId = 0;
    private int _limits;
    private static double _roomCostPerPoint = 500;
    private List<Lecturer> _lecturers = new List<Lecturer>();
    private double _studentFeeTotal;
    private double _roomFeeTotal;
    private double _lecturerPayTotal;
    private Department _department;

    public Course(string name, Department department, int points, int limits)
    {
        _name = name;
        Id = GenerateId();
        _department = department;
        department.Courses.Add(this);
        Points = points;
        _limits = limits;
        Students = new List<Student>();
        IsMarked = false;
    }

    private bool IsValidPoint(int point)
    {
        HashSet<int> vPoints = new HashSet<int>();
        vPoints.Add(15);
        vPoints.Add(20);
        vPoints.Add(30);
        vPoints.Add(40);
        vPoints.Add(45);
        vPoints.Add(60);

        if (vPoints.Contains(point))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Id { get; set; }

    public static int GenerateId()
    {
        return Interlocked.Increment(ref lastId);
    }

    public List<Student> Students1
    {
        get => Students;
        set => Students = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Student> Students { get; private set; }

    public int Points { get; set; }

    public bool IsMarked { get; set; }

    public List<Lecturer> Lecturers
    {
        get => _lecturers;
        set => _lecturers = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Department Department
    {
        get => _department;
        set => _department = value ?? throw new ArgumentNullException(nameof(value));
    }
    public int Limits { get; set; }

    public double Profit { get; set; }

    public void Enroll(Student student)
    {
        if (this.Students.Count < this._limits)
        {
            Students.Add(student);
            Console.WriteLine("Course " + this._name + " has enrolled " + student.Name);
            student.addCourse(this);
            Console.WriteLine(student.Name + " is enrolled in " + this._name);
        }
        else
        {
            Console.WriteLine("Failed to enrol student " + student.Name + "; number reached limit!");
        }

    }
    
    public double CalculateProfit()
    {
        double currentProfit = Profit;
        Console.WriteLine("Current profit from student tuition fee: " + currentProfit);
        _roomFeeTotal = _roomCostPerPoint * Points;
        Console.WriteLine("Room cost Total: " + _roomFeeTotal);
        foreach (Lecturer lecturer in _lecturers)
        {
            _lecturerPayTotal += lecturer.HourlyRate * Points * 10;
            Console.WriteLine(lecturer.Name + ":" + lecturer.HourlyRate * Points + " Lecture Cost Total: " + _lecturerPayTotal);
        }

        Profit = currentProfit - _roomFeeTotal - _lecturerPayTotal;
        Console.WriteLine("Course profit: " + Profit);
        return Profit;
    }

    public void GetAllStudentMarks()
    {
        if (Students != null)
        {
            Console.WriteLine("Mark for students enrolled in " + _name + " below: ");
            foreach (Student student in Students)
            {
                Console.WriteLine("Student name: " + student.Name + " id: " + student.Id + " mark: " + student.Marks[this._name]);
            }
        }
        
    }
}