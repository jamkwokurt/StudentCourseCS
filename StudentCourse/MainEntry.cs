namespace StudentCourse;


public class MainEntry
{
    private List<Course> _courses = new List<Course>();
    public MainEntry()
    {
        AddData();
    }

    public void AddData()
    {
        Department deptEngineering = new Department("Engineering", 70.13, 294.90);
        
        Course swen501 = new Course("SWEN501",deptEngineering,15,50);
        Course swen502 = new Course("SWEN502",deptEngineering,45,50);
        Course swen504 = new Course("SWEN504",deptEngineering,60,50);
        Lecturer michael = new Lecturer("Michael", 35, 2, 4);
        Lecturer karsten = new Lecturer("Karsten", 40, 1, 4);
        Lecturer ali = new Lecturer("Ali", 30, 3, 4);
        michael.TeachCourse(swen501);
        karsten.TeachCourse(swen502);
        ali.TeachCourse(swen504);
        
        Student yuri = new Student("Yuri", false,10);
        Student rhea = new Student("Rhea", true,10);
        Student penny = new Student("Penny", true,10);
        swen501.Enroll(yuri);
        swen501.Enroll(rhea);
        swen501.Enroll(penny);
        swen502.Enroll(yuri);
        swen502.Enroll(rhea);
        swen502.Enroll(penny);
        swen504.Enroll(yuri);
        swen504.Enroll(rhea);
        swen504.Enroll(penny);
        
        Console.WriteLine("SWEN 501 points: "+swen501.Points);
        Console.WriteLine(swen501.CalculateProfit());
        Console.WriteLine("SWEN 502 points: "+swen502.Points);
        Console.WriteLine(swen502.CalculateProfit());
        Console.WriteLine("SWEN 504 points: "+swen504.Points);
        Console.WriteLine(swen504.CalculateProfit());
        
        michael.DoMarking();
        karsten.DoMarking();
        ali.DoMarking();
        
        swen504.GetAllStudentMarks();
        yuri.GetAllCourseMarks();
        deptEngineering.CompareGPA();

    }

    
    
    private static void Main(string[] args)
    {
        Console.WriteLine("========== Student and Course Management System ==========");
        new MainEntry();
    }
}



