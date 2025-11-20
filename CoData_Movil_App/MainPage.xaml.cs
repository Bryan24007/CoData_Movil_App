using System.Threading.Tasks;

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
            await Navigation.PushAsync(new MVM.View.Pantalla_Registro());
        }

    }

}
