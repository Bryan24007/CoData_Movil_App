namespace CoData_Movil_App.MVM.View;
using CoData_Movil_App.MVM;
using CoData_Movil_App.MVM.View;
using System;
using Microsoft.Maui.Storage;



public partial class PagePerfil : ContentPage
{
	public PagePerfil()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        CargarDatosUsuario();
    }

    private void CargarDatosUsuario()
    {
        if (txtNombre != null) txtNombre.Text ="Juan ramon";
        if (txtCorreo != null) txtCorreo.Text = "correo_ejemplo@uts.edu.mx";
    }

    private async void OnCambiarFotoClicked(object sender, System.EventArgs e)
    {
        try
        {
            // Abrir selector de archivos
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Selecciona tu foto de perfil",
                FileTypes = FilePickerFileType.Images // Solo imágenes
            });

            if (result != null)
            {
                // Cargar imagen seleccionada
                var stream = await result.OpenReadAsync();
                userImage.Source = ImageSource.FromStream(() => stream);
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"No se pudo cargar la imagen: {ex.Message}", "OK");
        }
    }

    private async void OnGuardarCambiosClicked(object sender, System.EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre?.Text))
        {
            await DisplayAlert("Error", "Nombre requerido", "OK");
            return;
        }

        if (!string.IsNullOrEmpty(txtNuevaPassword?.Text) && txtNuevaPassword.Text != txtConfirmarPassword?.Text)
        {
            await DisplayAlert("Error", "Contraseñas no coinciden", "OK");
            return;
        }

        await DisplayAlert("Éxito", "Cambios guardados", "OK");
        await Navigation.PopAsync();
    }
    private async void PageSeguimiento(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SeguimientoPage());

    }
    private async void PageMenu(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Menu());

    }
    private async void loginPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());

    }
}