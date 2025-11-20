namespace SkodaApi.Models;

public class StockCar : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Condition { get; set; } = string.Empty;
    public int Mileage { get; set; }
    public string Vin { get; set; } = string.Empty;
    public List<string> Gallery { get; set; } = new();
    public string Color { get; set; } = string.Empty;
    public int EnginePower { get; set; }
    public string Transmission { get; set; } = string.Empty;
    public decimal EngineVolume { get; set; }
    public decimal FuelConsumption { get; set; }
    public string Configuration { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string SpecificationFile { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
