using System.ComponentModel.DataAnnotations.Schema;

namespace asp.Model;

public class Attachment : BaseModel
{

    public int refernce { get; set; }
    public string description { get; set; }
    public string url { get; set; }
    [NotMapped]
    public IFormFile file { get; set; }

    public int index { get; set; }
    public int type { get; set; }
    public string remark { get; set; }

    public int PersonId { get; set; }
    public Person Person { get; set; }

    public int CareerId { get; set; }
    public Career Career { get; set; }  // Navigation property for the career


}

