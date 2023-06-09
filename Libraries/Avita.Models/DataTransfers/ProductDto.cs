namespace Avita.Models.DataTransfers;

public record ProductDto
{
    public int Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public long Price { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public int Quantity { get; set; }
}