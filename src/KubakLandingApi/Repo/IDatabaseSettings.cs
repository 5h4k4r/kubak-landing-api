using System.ComponentModel.DataAnnotations;

namespace KubakLandingApi.Models
{
  public interface IDatabaseSettings
  {
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
  }

  public class DatabaseSettings : IDatabaseSettings
  {
    [Required]
    public string ConnectionString { get; set; } = string.Empty;

    [StringLength(100, MinimumLength = 1)]
    public string DatabaseName { get; set; } = string.Empty;
  }
}