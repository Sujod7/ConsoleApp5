
using API;

namespace API

{
    public class Proudact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Brand> Brands { get; set; } = new List<Brand>();
    }
}
