namespace CoData_Movil_App;

public partial class Menu : ContentPage
{
    private readonly ReporteRepository _db = new ReporteRepository();
    public Menu()
	{
		InitializeComponent();
	}

    private async void enviarRep(object sender, EventArgs e)
    {
        string texto = txtReporte.Text;

        if (string.IsNullOrWhiteSpace(texto))
        {
            await DisplayAlert("Error", "El reporte no puede estar vacío.", "OK");
            return;
        }

        var reporte = new Reporte
        {
            Texto = texto,
            Fecha = DateTime.Now
        };

        await _db.AddReporteAsync(reporte);

        await DisplayAlert("Éxito", "Reporte guardado correctamente.", "OK");

        txtReporte.Text = string.Empty; // limpiar editor
    }
}
