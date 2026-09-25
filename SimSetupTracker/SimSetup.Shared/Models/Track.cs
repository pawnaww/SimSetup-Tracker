using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimSetup.Shared.Models;

/// <summary>
/// Reprezentuje tor wyścigowy w systemie SimSetup Tracker.
/// </summary>
public class Track
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nazwa toru jest wymagana.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Nazwa toru musi mieć od 1 do 100 znaków.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Kraj toru jest wymagany.")]
    [StringLength(60, MinimumLength = 1, ErrorMessage = "Kraj musi mieć od 1 do 60 znaków.")]
    public string Country { get; set; } = string.Empty;

    [Range(0.1, 100.0, ErrorMessage = "Długość toru musi wynosić od 0.1 do 100.0 km.")]
    public double LengthKm { get; set; }

    /// <summary>
    /// Relacja 1-do-wielu: Tor może posiadać wiele powiązanych setupów / przejazdów.
    /// </summary>
    [JsonIgnore]
    public ICollection<Setup> Setups { get; set; } = new List<Setup>();

    // Konstruktor bezparametrowy wymagany przez EF Core
    public Track()
    {
    }

    public Track(string name, string country, double lengthKm)
    {
        SetName(name);
        SetCountry(country);
        SetLengthKm(lengthKm);
    }

    public void UpdateDetails(string name, string country, double lengthKm)
    {
        SetName(name);
        SetCountry(country);
        SetLengthKm(lengthKm);
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nazwa toru nie może być pusta.", nameof(name));
        Name = name.Trim();
    }

    private void SetCountry(string country)
    {
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Kraj toru nie może być pusty.", nameof(country));
        Country = country.Trim();
    }

    private void SetLengthKm(double lengthKm)
    {
        if (lengthKm <= 0 || lengthKm > 100)
            throw new ArgumentOutOfRangeException(nameof(lengthKm), "Długość toru musi mieścić się w przedziale 0.1 - 100 km.");
        LengthKm = lengthKm;
    }
}
