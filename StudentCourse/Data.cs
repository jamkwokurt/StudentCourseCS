namespace StudentCourse;

public class DB
{
   private List<Department> _departments = new List<Department>();
   private List<Course> _courses = new List<Course>();
   private IDictionary<string, Lecturer> _lecturerMap = new Dictionary<string, Lecturer>();
   private List<Student> _students = new List<Student>();
   private IDictionary<string, Student> _studentIDMap = new Dictionary<string, Student>();
   
   
}