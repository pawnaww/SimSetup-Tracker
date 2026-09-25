using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimSetup.Shared.Models;

/// <summary>
/// Reprezentuje samochód wyścigowy w systemie SimSetup Tracker.
/// </summary>
public class Car
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Marka samochodu jest wymagana.")]
    [StringLength(60, MinimumLength = 1, ErrorMessage = "Marka musi mieć od 1 do 60 znaków.")]
    public string Brand { get; set; } = string.Empty;

    [Required(ErrorMessage = "Model samochodu jest wymagany.")]
    [StringLength(80, MinimumLength = 1, ErrorMessage = "Model musi mieć od 1 do 80 znaków.")]
    public string Model { get; set; } = string.Empty;

    [Range(1900, 2100, ErrorMessage = "Rok produkcji musi zawierać się w przedziale 1900-2100.")]
    public int Year { get; set; }

    /// <summary>
    /// Pełna nazwa pojazdu (np. "Ferrari 488 GT3 (2020)").
    /// </summary>
    public string DisplayName => $"{Brand} {Model} ({Year})";

    /// <summary>
    /// Relacja 1-do-wielu: Samochód może posiadać wiele konfiguracji (setupów).
    /// </summary>
    [JsonIgnore]
    public ICollection<Setup> Setups { get; set; } = new List<Setup>();

    // Konstruktor bezparametrowy wymagany przez EF Core
    public Car()
    {
    }

    // Konstruktor z parametrami zapewniający poprawną inicjalizację obiektu
    public Car(string brand, string model, int year)
    {
        SetBrand(brand);
        SetModel(model);
        SetYear(year);
    }

    public void UpdateDetails(string brand, string model, int year)
    {
        SetBrand(brand);
        SetModel(model);
        SetYear(year);
    }

    private void SetBrand(string brand)
    {
        if (string.IsNullOrWhiteSpace(brand))
            throw new ArgumentException("Marka nie może być pusta.", nameof(brand));
        Brand = brand.Trim();
    }

    private void SetModel(string model)
    {
        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentException("Model nie może być pusty.", nameof(model));
        Model = model.Trim();
    }

    private void SetYear(int year)
    {
        if (year < 1900 || year > 2100)
            throw new ArgumentOutOfRangeException(nameof(year), "Rok produkcji musi być w przedziale 1900-2100.");
        Year = year;
    }
}
