namespace BackEnd;

public class Product
{
    public Guid Id {get; set;}
    public string Name {get; set;}
    public decimal Price {get; set;}
    public string Description {get; set;}
    public Guid CategoryId {get; set;}
    public string CategoryName {get; set;}
    public int Stock {get; set;}
    public string  ImageUrl {get; set;}
    
    public Product()
    {
        Id = Guid.NewGuid();
        Name = "";
        Description = "";
        Price = 0;
        CategoryId = Guid.Empty;
        CategoryName = "";
        Stock = 0;
        ImageUrl = "";
    }
    
    public Product(string name, decimal price, string description, Guid categoryId, string categoryName, int stock, string imageUrl)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Description = description;
        CategoryId = categoryId;
        CategoryName = categoryName;
        Stock = stock;
        ImageUrl = imageUrl;
    }

    public Product(Guid id, string name, decimal price, string description)
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
        CategoryId = Guid.Empty;
        CategoryName = "";
    }
}