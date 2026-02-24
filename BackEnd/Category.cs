namespace BackEnd;

public class Category
{
    public Guid Id {get; set;} = Guid.NewGuid();
    public string Name {get; set;} = string.Empty;

    public Category() {}

    public Category(string name)
    {
        Name = name;
    }
}