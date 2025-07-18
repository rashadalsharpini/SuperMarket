namespace DataLayer.Entities;

public class BaseEntity<TKey>
{
    public TKey Id { get; set; }
    public string? Description { get; set; } = null!;
}