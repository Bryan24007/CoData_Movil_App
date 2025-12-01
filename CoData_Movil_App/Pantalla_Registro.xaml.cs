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
            lblMessage.TextColor = Colors.White;
            lblMessage.Text = "Debe ingresar correo y contraseña.";
            return;
        }

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            lblMessage.TextColor = Colors.White;
            lblMessage.Text = "Formato de correo inválido.";
            return;
        }

        if (pass.Length < 6)
        {
            lblMessage.TextColor = Colors.White;
            lblMessage.Text = "La contraseña debe tener al menos 6 caracteres.";
            return;
        }

        // Verificar si ya existe el correo
        var existingUser = (await _db.GetUsersAsync()).FirstOrDefault(u => u.Email == email);
        if (existingUser != null)
        {
            lblMessage.TextColor = Colors.White;
            lblMessage.Text = "El correo ya está registrado.";
            return;
        }

        // Guardar usuario
        var newUser = new User { Email = email, Password = pass };
        await _db.AddUserAsync(newUser);

        lblMessage.TextColor = Colors.White;
        lblMessage.Text = "Usuario registrado correctamente.";

        // Opcional: navegar directo al login
        await Navigation.PopAsync();
    }
    private bool _isPasswordVisible = false;
    private async void vercontra(object sender, EventArgs e)
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