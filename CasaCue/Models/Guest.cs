namespace CasaCue.Models;

public class Guest
{
    public Guid Id { get; set; } // UUID wird übergeben
    public string Name { get; set; } // Name des Gastes
    public int GroupSize { get; set; } // Gruppengröße
    public int QueuePosition { get; set; } // Position in der Warteliste
}