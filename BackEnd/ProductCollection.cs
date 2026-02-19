using System.Text.Json;

namespace BackEnd;

public class ProductCollection
{
    public List<Product> Products { get; set;} = new();
    private string fileName = "products.json";
    
    public void Save()
    {
        string json = JsonSerializer.Serialize(Products);
        File.WriteAllText(fileName, json);
    }
    
    public void Load()
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            Products = JsonSerializer.Deserialize<List<Product>>(json) ?? new();
        }
    }
    
    public void Add(Product newProduct)
    {
        Products.Add(newProduct);
    }
    
    public Product? GetById(Guid id)
    {
        foreach (Product p in Products)
        {
            if (p.Id == id)
            {
                return p;
            }
        }
        return null;
    }
    
    public void Remove(Guid id)
    {
        for (int i = 0; i < Products.Count; i++)
        {
            if (Products[i].Id == id)
            {
                Products.RemoveAt(i);
                return;
            }
        }
    }
}