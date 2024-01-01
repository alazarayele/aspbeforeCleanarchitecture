namespace asp.Model;

public class Hobby : BaseModel
{

    public int code { get; set; }

    public int InterestId { get; set; }

    // Navigation property for Interest
    public Interest Interest { get; set; }
    public string remark { get; set; }

    public int PersonId { get; set; }
    public Person Person { get; set; }


}