using System.Threading.Tasks;

namespace CoData_Movil_App.MVM.View;

public partial class Pantalla_Registro : ContentPage
{
	public Pantalla_Registro()
	{
		InitializeComponent();
	}
    private async void volver(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}