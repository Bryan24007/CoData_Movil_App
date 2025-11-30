using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoData_Movil_App.MVM.View;

public partial class Pantalla_Registro : ContentPage
{
    private readonly UserRepository _db = new UserRepository();
    public Pantalla_Registro()
	{
		InitializeComponent();
	}
    private async void Registro(object sender, EventArgs e) 
    {
        string email = txtEmail.Text;
        string pass = txtPassword.Text;

        // Validaciones básicas
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
        {
            lblMessage.TextColor = Colors.Red;
            lblMessage.Text = "Debe ingresar correo y contraseña.";
            return;
        }

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            lblMessage.TextColor = Colors.Red;
            lblMessage.Text = "Formato de correo inválido.";
            return;
        }

        if (pass.Length < 6)
        {
            lblMessage.TextColor = Colors.Red;
            lblMessage.Text = "La contraseña debe tener al menos 6 caracteres.";
            return;
        }

        // Verificar si ya existe el correo
        var existingUser = (await _db.GetUsersAsync()).FirstOrDefault(u => u.Email == email);
        if (existingUser != null)
        {
            lblMessage.TextColor = Colors.Red;
            lblMessage.Text = "El correo ya está registrado.";
            return;
        }

        // Guardar usuario
        var newUser = new User { Email = email, Password = pass };
        await _db.AddUserAsync(newUser);

        lblMessage.TextColor = Colors.Green;
        lblMessage.Text = "Usuario registrado correctamente.";

        // Opcional: navegar directo al login
        await Navigation.PushAsync(new MainPage());
    }
}