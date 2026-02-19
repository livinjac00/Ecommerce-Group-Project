namespace Tests;

public class UnitTest1
{
    [Fact]
    public void ProductCollectiontest()
    {
        ProductCollectiontest collection= new ProductCollectiontest();
        Product product = new Product("Phone", 500m, "Smartphone");

        collection.Add(product);

        Assert.NotNull(collection.GetById(product.Id));

        collection.Remove(product.Id);
        
        Assert.Null(collection.GetById(product.Id));
    }
}
