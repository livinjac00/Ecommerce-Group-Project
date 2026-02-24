using BackEnd;
namespace Tests;

public class UnitTest1
{
    [Fact]
    public void ProductCollectionTest()
    {
        ProductCollection collection= new ProductCollection();
        Product product = new Product("Phone", 500m, "Smartphone", Guid.NewGuid(), "Electronics");

        collection.Add(product);

        Assert.NotNull(collection.GetById(product.Id));

        collection.Remove(product.Id);
        
        Assert.Null(collection.GetById(product.Id));
    }
}
