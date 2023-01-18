namespace Day_1.Models
{
    public static class SampleData
    {
        private static List<Product> products = new List<Product>()
        {
            new Product() {Id=1,Name="car",price=100,Description="this is a car"},
            new Product() {Id=2,Name="bick",price=200,Description= "thia is a bick"}
        };
        public static List<Product> Products { get => products; }


        public static void AddProduct(Product product) {
            products.Add(product);
        }
    }
}
