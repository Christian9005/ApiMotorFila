namespace ApiMotorFila.Domain;

public class MotorDto
{
    public string Name { get; set; }
    public int Speed { get; set; }
    public int Meter { get; set; }
    public bool State { get; set; }
}
public class MotorDtoUpdate
{
    public string Name { get; set; }
    public int? Speed { get; set; }
    public int? Meter { get; set; }
    public bool? State { get; set; }
}