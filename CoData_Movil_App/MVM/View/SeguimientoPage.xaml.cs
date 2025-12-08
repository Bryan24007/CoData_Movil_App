namespace CoData_Movil_App.MVM.View;
using Microsoft.Maui.Controls;

public partial class SeguimientoPage : ContentPage
{
    private readonly ReporteRepository _db = new ReporteRepository();
    public SeguimientoPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var reportes = await _db.GetReportesAsync();

        // Asignar comandos a cada reporte
        foreach (var r in reportes)
        {
            r.SaveCommand = new Command(async () =>
            {
                await _db.UpdateReporteAsync(r);
                await DisplayAlert("Éxito", "Reporte actualizado", "OK");
            });

            r.DeleteCommand = new Command(async () =>
            {
                await _db.DeleteReporteAsync(r);
                await DisplayAlert("Éxito", "Reporte eliminado", "OK");
                reportesList.ItemsSource = await _db.GetReportesAsync(); // refrescar lista
            });
        }

        reportesList.ItemsSource = reportes;
    }
    private async void PageMenu(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Menu());

    }
    private async void PagePerfil(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PagePerfil());
    }

}