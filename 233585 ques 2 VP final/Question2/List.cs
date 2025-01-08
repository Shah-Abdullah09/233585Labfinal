using Question2.Components.Pages;

public static class ProductDataService
{
    public static List<Product> products = new List<Product>();

    public static void AddProduct(Product p)
    {
        products.Add(p);
    }

    public static List<Product> GetProducts()
    {
        return products;
    }
}
