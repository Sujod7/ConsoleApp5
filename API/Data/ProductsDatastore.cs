using API;

namespace API
{
    public class ProductsDatastore
    {
        public ProductsDatastore()
        {
            Products = new List<Proudact>
            {
                new Proudact
                {
                    Id = 1,
                    Name = "Kreem",
                    Brands = new List<Brand>
                    {
                        new Brand { Id = 1, Name = "Amazon", Notes = "original" },
                        new Brand { Id = 2, Name = "Adidas", Notes = "original" }
                    }
                },
                new Proudact
                {
                    Id = 2,
                    Name = "Sun cover",
                    Brands = new List<Brand>
                    {
                     new Brand { Id = 3, Name = "Shoes", Notes = "original" },
                    }
                }
            };
        }

        public List<Proudact> Products { get; set; }
        public static ProductsDatastore Current { get; } = new ProductsDatastore(); // بجيب نسخة معدة ومنشأة لمرة واحدة من الداتا وبعرضها بدون قابلية للتعديل 
    }
}
