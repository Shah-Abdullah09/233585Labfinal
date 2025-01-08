// File: Models/Product.cs
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public Product()
    {
        Name = "";
        Price = 0;
        Category = "";
    }
}
