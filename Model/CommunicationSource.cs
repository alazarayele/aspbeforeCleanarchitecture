namespace asp.Model;

public class CommunicationSource : BaseModel
{

    public int code {get;set;}
    public int person {get;set;}
    public int type {get;set;}
    public string communicatedBy {get;set;}
    public string remark {get;set;}
      public int PersonId { get; set; }
    public Person Person { get; set; }
   

}