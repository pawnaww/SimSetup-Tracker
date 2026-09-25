using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimSetup.Shared.Models;

/// <summary>
/// Reprezentuje konfigurację (setup) samochodu oraz osiągnięty czas na torze.
/// </summary>
public class Setup
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CarId { get; set; }

    [ForeignKey(nameof(CarId))]
    public Car? Car { get; set; }

    [Required]
    public int TrackId { get; set; }

    [ForeignKey(nameof(TrackId))]
    public Track? Track { get; set; }

    [Required(ErrorMessage = "Czas okrążenia jest wymagany.")]
    public TimeSpan LapTime { get; set; }

    [Range(10.0, 60.0, ErrorMessage = "Ciśnienie w oponach przednich musi zawierać się w przedziale 10-60 PSI.")]
    public double TirePressureFront { get; set; }

    [Range(10.0, 60.0, ErrorMessage = "Ciśnienie w oponach tylnych musi zawierać się w przedziale 10-60 PSI.")]
    public double TirePressureRear { get; set; }

    [Range(0, 50, ErrorMessage = "Docisk aerodynamiczny przedni (AeroFront) musi być w przedziale 0-50.")]
    public int AeroFront { get; set; }

    [Range(0, 50, ErrorMessage = "Docisk aerodynamiczny tylny (AeroRear) musi być w przedziale 0-50.")]
    public int AeroRear { get; set; }

    [StringLength(1000, ErrorMessage = "Notatki nie mogą przekraczać 1000 znaków.")]
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Sformatowany czas okrążenia w czytelnym formacie wyścigowym (np. "01:23.456").
    /// </summary>
    public string FormattedLapTime => LapTime.ToString(@"mm\:ss\.fff");

    // Konstruktor bezparametrowy wymagany przez EF Core
    public Setup()
    {
    }

    public Setup(
        int carId,
        int trackId,
        TimeSpan lapTime,
        double tirePressureFront,
        double tirePressureRear,
        int aeroFront,
        int aeroRear,
        string? notes = null)
    {
        CarId = carId;
        TrackId = trackId;
        SetLapTime(lapTime);
        SetTirePressures(tirePressureFront, tirePressureRear);
        SetAero(aeroFront, aeroRear);
        Notes = notes?.Trim();
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateSetup(
        TimeSpan lapTime,
        double tirePressureFront,
        double tirePressureRear,
        int aeroFront,
        int aeroRear,
        string? notes)
    {
        SetLapTime(lapTime);
        SetTirePressures(tirePressureFront, tirePressureRear);
        SetAero(aeroFront, aeroRear);
        Notes = notes?.Trim();
    }

    private void SetLapTime(TimeSpan lapTime)
    {
        if (lapTime <= TimeSpan.Zero || lapTime > TimeSpan.FromMinutes(60))
            throw new ArgumentOutOfRangeException(nameof(lapTime), "Czas okrążenia musi być większy od 0 i mniejszy niż 60 minut.");
        LapTime = lapTime;
    }

    private void SetTirePressures(double front, double rear)
    {
        if (front < 10.0 || front > 60.0)
            throw new ArgumentOutOfRangeException(nameof(front), "Ciśnienie z przodu musi być w zakresie 10-60 PSI.");
        if (rear < 10.0 || rear > 60.0)
            throw new ArgumentOutOfRangeException(nameof(rear), "Ciśnienie z tyłu musi być w zakresie 10-60 PSI.");
        TirePressureFront = front;
        TirePressureRear = rear;
    }

    private void SetAero(int front, int rear)
    {
        if (front < 0 || front > 50)
            throw new ArgumentOutOfRangeException(nameof(front), "Aero z przodu musi być w zakresie 0-50.");
        if (rear < 0 || rear > 50)
            throw new ArgumentOutOfRangeException(nameof(rear), "Aero z tyłu musi być w zakresie 0-50.");
        AeroFront = front;
        AeroRear = rear;
    }
}
