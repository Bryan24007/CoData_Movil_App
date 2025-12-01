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
            string email = txtEmail.Text;
            string pass = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
            {
                lblMessage.Text = "Debe ingresar correo y contraseña.";
                
                return;
            }

            var db = new UserRepository();
            var isValid = await db.ValidateUserAsync(email, pass);

            if (isValid)
            {
                await Navigation.PushAsync(new Menu()); 
            }
            else
            {
                lblMessage.Text = "Datos incorrectos!";
            }

        }
        private bool _isPasswordVisible = false;
        private async void oculto(object sender, EventArgs e)
        {
            _isPasswordVisible = !_isPasswordVisible;

            // Cambiar visibilidad
            txtPassword.IsPassword = !_isPasswordVisible;

            // Cambiar ícono según estado
            ocultar.Source = _isPasswordVisible
                ? "icons_oculto.png"   // Ícono de "ocultar"
                : "icons_visible.png"; // Ícono de "mostrar"
        }
    }
}
