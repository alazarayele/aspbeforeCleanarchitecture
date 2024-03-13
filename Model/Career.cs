namespace asp.Model;

public class Career : BaseModel
{

    public int type {get;set;}
    public int Careerperson {get;set;}
    public int index {get;set;}
    public string organization {get;set;}
    public int field {get;set;}
    public int level {get;set;}
    public DateTime startdate {get;set;}
    public DateTime endDate {get;set;}
    public string award {get;set;}

    public string note {get;set;}

    public string remark {get;set;}

  public List<Attachment> Attachments { get; set; }  // Navigation property for the attachments

    public int personId {get;set;}

    public Person Person {get; set;}
    

}