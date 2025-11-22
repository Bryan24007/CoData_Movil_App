using CoData_Movil_App.MVM.View;

namespace CoData_Movil_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NewPage1();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
