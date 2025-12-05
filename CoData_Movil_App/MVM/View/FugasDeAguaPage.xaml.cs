namespace CoData_Movil_App.MVM.View;
using Microsoft.Maui.Controls;
using CoData_Movil_App;

public partial class FugasDeAguaPage : ContentPage
{
    private readonly ReporteRepository _db = new ReporteRepository();
    public FugasDeAguaPage()
	{
		InitializeComponent();
	}
    private async void OnEnviarReporteClicked(object sender, EventArgs e)
    {
        string descripcion = DescripcionEditor.Text;
        string ubicacion = DireccionEntry.Text;

        if (string.IsNullOrWhiteSpace(descripcion))
        {
            await DisplayAlert("Error", "El reporte no puede estar vacío.", "OK");
            return;
        }

        var reporte = new Reporte
        {
            Texto = descripcion,
            Fecha = DateTime.Now,
            Ubi = ubicacion,


        };

        await _db.AddReporteAsync(reporte);

        await DisplayAlert("Éxito", "Reporte guardado correctamente.", "OK");

        descripcion = string.Empty;

    }
    private async void PageMenu(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Menu());

    }
    private async void PageSeguimiento(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SeguimientoPage());

    }
}