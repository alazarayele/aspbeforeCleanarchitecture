namespace asp.Model;



public class Student : BaseModel
{
    
    public string Name{get;set;}

    public string Gender{get;set;}

    public List<Course> Courses{get;set;}

    internal Student MapToModel(Student o)
    {
      
       
            Student student = new Student();
            student.Name = Name;
            student.Gender = Gender;
          
            return student;
        

    }
}
