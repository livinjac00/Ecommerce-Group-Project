namespace BackEnd;

public class Product
{
    public Guid Id {get; set;}
    public string Name {get; set;}
    public decimal Price {get; set;}
    public string Description {get; set;}
    public Guid CategoryId {get; set;}
    public string CategoryName {get; set;}
    public List<Review> Reviews { get; set; } = new();
    
    public Product()
    {
        Id = Guid.NewGuid();
        Name = "";
        Description = "";
        Price = 0;
        CategoryId = Guid.Empty;
        CategoryName = "";
    }
    
    public Product(string name, decimal price, string description, Guid categoryId, string categoryName)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Description = description;
        CategoryId = categoryId;
        CategoryName = categoryName;
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