using System.Threading.Tasks;
using CoData_Movil_App.MVM;
using CoData_Movil_App.MVM.View;

namespace CoData_Movil_App
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
           

        }

        

        private async void p_registro(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pantalla_Registro());

        }

        private async void Buton_inicar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu());

        }
    }
}
