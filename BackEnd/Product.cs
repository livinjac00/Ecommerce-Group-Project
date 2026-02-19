namespace BackEnd;

public class Product
{
    public Guid Id {get; set;}
    public string Name {get; set;}
    public decimal Price {get; set;}
    public string Description {get; set;}
    
    public Product()
    {
        Id = Guid.NewGuid();
        Name = "";
        Description = "";
        Price = 0;
    }
    
    public Product(string name, decimal price, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Description = description;
    }
}