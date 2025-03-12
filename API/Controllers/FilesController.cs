using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var path = "MyFile.txt"; // استخدم اسم متغير غير Path
            if (!System.IO.File.Exists(path)) // تحقق من وجود الملف
            {
                return NotFound();
            }

            var fileContent = System.IO.File.ReadAllText(path);
            var fileBytes = Encoding.UTF8.GetBytes(fileContent); // تحويل النص إلى byte[]

            return File(fileBytes, "text/plain", System.IO.Path.GetFileName(path)); // استخدم System.IO.Path
        }
    }
}
