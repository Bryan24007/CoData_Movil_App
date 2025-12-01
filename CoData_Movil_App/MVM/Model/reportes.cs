using SQLite;

public class Reporte
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Texto { get; set; }
    public DateTime Fecha { get; set; }
}
