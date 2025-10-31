namespace SkodaApi.Models;

public class Banner : BaseEntity
{
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public List<string> ListItems { get; set; } = new();
  public string ButtonText { get; set; } = string.Empty;
  public string ButtonUrl { get; set; } = string.Empty;
  public string ImageUrl { get; set; } = string.Empty;
}