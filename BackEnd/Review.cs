namespace BackEnd;

public class Review
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public int Rating { get; set; } // 1-5
    public string Comment { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    public Review() { }

    public Review(Guid productId, string userName, int rating, string comment)
    {
        ProductId = productId;
        UserName = userName;
        Rating = rating;
        Comment = comment;
    }
}
