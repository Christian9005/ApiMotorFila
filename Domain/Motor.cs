using System.ComponentModel.DataAnnotations;

namespace ApiMotorFila.Domain;

public class Motor
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Speed { get; set; }
    public float Meter { get; set; }
    public bool State { get; set; }
}