using System.Windows.Input;
using SQLite;

public class Reporte
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Tipo { get; set; } 
    public string Descripcion { get; set; }
    public string Ubi { get; set; }
    public string Texto { get; set; }
    public DateTime Fecha { get; set; }

    [Ignore] // No se guarda en BD
    public ICommand SaveCommand { get; set; }

    [Ignore]
    public ICommand DeleteCommand { get; set; }
}
