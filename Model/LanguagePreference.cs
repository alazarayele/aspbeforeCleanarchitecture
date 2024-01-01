namespace asp.Model;

public class LanguagePreference : BaseModel
{

    public int person {get;set;}
  public int LanguageId { get; set; }
    public int proficiency {get;set;}
     public string remark {get;set;}
      public int PersonId { get; set; }
    public Person Person { get; set; }
   
    public Language Language { get; set; }

    public int ProficiencyId { get; set; }
    
    // Navigation property for Proficiency
    public Proficiency Proficiency { get; set; }
}