namespace asp.Model;

public class Person : BaseModel
{

    public string code { get; set; }
    public int type { get; set; }
    public string firstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Nationality { get; set; }
    public DateTime DOB { get; set; }

    public int title { get; set; }
    public string gender { get; set; }
    public int preference { get; set; }
    public Boolean isActive { get; set; }
    public string remark { get; set; }

    public List<Attachment> Attachments { get; set; }
    public List<Career> Careers { get; set; }
    public List<CommunicationSource> CommunicationSources { get; set; }
    public List<Hobby> Hobbies { get; set; }
    public List<LanguagePreference> LanguagePreferences { get; set; }


}