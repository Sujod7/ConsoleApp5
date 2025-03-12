using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/products/{productid}/brands")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ILogger<BrandsController> logger;

        public BrandsController(ILogger<BrandsController> logger)
        {
            this.logger = logger;
        }
        [HttpGet]
        public ActionResult GetBrands(int productid)
        {
            var product = ProductsDatastore.Current.Products.FirstOrDefault(p => p.Id == productid);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.Brands);
        }

        [HttpGet("{brandid}", Name = "Getbrand")]
        public ActionResult GetBrand(int productid, int brandid)
        {
            var product = ProductsDatastore.Current.Products.FirstOrDefault(p => p.Id == productid);
            if (product == null)
            {
                return NotFound();
            }

            var brand = product.Brands.FirstOrDefault(b => b.Id == brandid);
            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        [HttpPost]
        public ActionResult CreateBrand(int productid, BrandForCreation brand)
        {
            var product = ProductsDatastore.Current.Products.FirstOrDefault(p => p.Id == productid);
            if (product == null)
            {
                return NotFound();
            }

            var maxBrandId = ProductsDatastore.Current.Products.SelectMany(p => p.Brands).Max(b => b.Id);
            var newBrand = new Brand
            {
                Name = brand.Name,
                Notes = brand.Notes,
                Id = ++maxBrandId
            };
            product.Brands.Add(newBrand);

            return CreatedAtRoute("Getbrand", new { productid = productid, brandid = newBrand.Id }, newBrand);
        }

        [HttpPut("{brandid}")]
        public ActionResult UpdateBrand(int productid,int brandid, BrandForUpdate brand)
        {
            var product = ProductsDatastore.Current.Products.FirstOrDefault(p => p.Id == productid);
            if (product == null)
            {
                return NotFound();
            }

            var exsingbrand = product.Brands.FirstOrDefault(b=>b.Id == brandid);
            if (exsingbrand == null)
            {
                return NotFound();
            }
            exsingbrand.Name = brand.Name; // عملنا mapping
            exsingbrand.Notes = brand.Notes;
            //204
            return NoContent();
        }
        [HttpPatch("{brandid}")]
        public ActionResult PartiayllUpdateBrand(int productid, int brandid, JsonPatchDocument<BrandForUpdate> patchDocument)
        {
            var product = ProductsDatastore.Current.Products.FirstOrDefault(p => p.Id == productid);
            if (product == null)
            {
                return NotFound();
            }

            var exsingbrand = product.Brands.FirstOrDefault(b => b.Id == brandid);
            if (exsingbrand == null)
            {
                return NotFound();
            }

            var brandtopaych = new BrandForUpdate()
            {
                Name = exsingbrand.Name,
                Notes = exsingbrand.Notes,
            };

            patchDocument.ApplyTo(brandtopaych, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();// تحققنا انو القيود الي حاطينا عالبيانات دخلها المستخدم بالشكل الصحيح
            }
            exsingbrand.Name = brandtopaych.Name; //  عالمتغير الاصلي عملنا mapping
            exsingbrand.Notes = brandtopaych.Notes;

            return NoContent();
        }

            [HttpDelete("{brandid}")]

            public ActionResult DeletBrand(int productid, int brandid)
            {
                var product = ProductsDatastore.Current.Products.FirstOrDefault(p => p.Id == productid);
                if (product == null)
                {
                    return NotFound();
                }

                var exsingbrand = product.Brands.FirstOrDefault(b => b.Id == brandid);
                if (exsingbrand == null)
                {
                    return NotFound();
                }
            product.Brands.Remove(exsingbrand);
                //204
                return NoContent();
            }

        }

    }

