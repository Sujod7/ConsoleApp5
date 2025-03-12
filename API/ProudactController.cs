using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

namespace API
{
    
    [ApiController]
    [Route("api/[controller]")]

    public class ProudactController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetProudacts()
        {
            /*  var responce = new List<Proudact>() {
                 new Proudact { Id = 1, Name = "Kreem" },
                 new Proudact { Id =2, Name = "Sun cover" }


              */
            var responce = ProductsDatastore.Current.Products;
        
            return new JsonResult(responce);
        }

        [HttpGet("{id}")]
        public ActionResult GetProudact(int id)// عملناها من نوع aCTIONrESULT  لانو برنا نرجع Not fooounf=d بقى مابتتحول ل Json
        {
            /*  var responce = new List<Proudact>() {
                 new Proudact { Id = 1, Name = "Kreem" },
                 new Proudact { Id =2, Name = "Sun cover" }


              */
            var responce = ProductsDatastore.Current.Products.FirstOrDefault(p => p.Id == id);
            if (responce == null)
          
                return NotFound();

            return Ok(responce);
        }
    }
}