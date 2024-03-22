using Microsoft.AspNetCore.Mvc;

using asp.Application.Interface;
using asp.Model;

using Microsoft.AspNetCore.Authorization;

namespace asp.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]

public class AttachementController : ControllerBase

{
    private readonly IAttachments _iattachments;
    private readonly string _uploadFolderPath;

    private readonly Icarrier _icarrier;

    public AttachementController(IAttachments attachments,IConfiguration configuration,Icarrier icarrier)
    {
        _iattachments = attachments;
        _uploadFolderPath = configuration["UploadFolderPath"];
        _icarrier = icarrier; 
    }

    [HttpGet]
    public List<Attachment> GetAll()
    {
        return _iattachments.GetAll().ToList();
    }

   

/*
[HttpPost]
    public async Task<string> AddAttachementsAsync([FromForm]Attachment attachment)
    
    {
        if (attachment.file == null || attachment.file.Length == 0)
            {
                return "No file uploaded";
            }

            // Generate a unique filename for the uploaded file
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + attachment.file.FileName;

            // Combine the upload folder path with the unique filename to get the full path
            string filePath = Path.Combine(_uploadFolderPath, uniqueFileName);

            // Save the uploaded file to the server
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await attachment.file.CopyToAsync(fileStream);
            }

            // Set the URL property of the attachment to the path where the file is stored
            attachment.url = filePath;

            // Add the attachment to the database or perform any other necessary operations
            return _iattachments.Add(attachment);

       
    }



*/
    [HttpPost("{personId}")]
        public async Task<IActionResult> CreateAttachmentWithPerson(int personId, Attachment attachment)
        {
            var result = await _iattachments.CreateAttachmentWithPerson(personId, attachment);
            return Ok(result);
        }

       [HttpPost]
public async Task<IActionResult> AddAttachmentWithPersonAndCareer(int personId, int careerId, Attachment model)
{
    try
    {
        // Fetch the person based on the provided ID
        var person = _iattachments.GetById(personId);
        if (person == null)
        {
            return BadRequest("Person not found.");
        }

        // Fetch the career based on the provided ID
        var career = _icarrier.GetById(careerId);
        if (career == null)
        {
            return BadRequest("Career not found.");
        }

        // Check if the form file is provided
        if (model.file == null || model.file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

     

        // Check file extension (if necessary)
        // if (!IsAllowedFileExtension(model.File.FileName))
        // {
        //     return BadRequest("File type not allowed.");
        // }

        // Check file content type (if necessary)
        // if (!IsAllowedContentType(model.File.ContentType))
        // {
        //     return BadRequest("File content type not allowed.");
        // }

        // Associate the fetched person and career with the attachment
        var attachment = new Attachment
        {
            PersonId = personId,
            CareerId = careerId,
            description = model.description,
            // Assign the form file directly to the File property
            file = model.file,
            // Assign other properties from the form model
        };

        // Add the attachment
        var result = _iattachments.Add(attachment);
        
        // Check if the attachment was added successfully
        if (result == "Success")
        {
            // If successful, return a success response
            return Ok("Attachment added successfully.");
        }
        else
        {
            // If adding the attachment failed, return an error response
            return BadRequest("Failed to add attachment.");
        }
    }
    catch (Exception ex)
    {
        // If an exception occurs, return an error response
        return StatusCode(500, $"Internal server error: {ex.Message}");
    }
}


       
       

 

    
      

          
         
      





    [HttpGet("id")]
    public Attachment GetAttachment(int id)
    {
        return _iattachments.GetById(id);
    }

    [HttpDelete("{id}")]
    public string Deleteattachement(int id)
    {
        return _iattachments.Delete(id);
    }
}