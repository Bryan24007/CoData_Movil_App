using System.Windows.Input;
using SQLite;

public class Reporte
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Texto { get; set; }
    public DateTime Fecha { get; set; }

    [Ignore] // No se guarda en BD
    public ICommand SaveCommand { get; set; }

    [Ignore]
    public ICommand DeleteCommand { get; set; }
}
