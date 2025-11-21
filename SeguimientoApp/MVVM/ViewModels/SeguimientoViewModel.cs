using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeguimientoApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoApp.MVVM.ViewModels
{
    public partial class SeguimientoViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Reporte> reportes;

        [ObservableProperty]
        private ObservableCollection<Reporte> reportesFiltrados;

        [ObservableProperty]
        private string textoBusqueda;

        [ObservableProperty]
        private bool isRefreshing;

        [ObservableProperty]
        private Reporte reporteSeleccionado;

        [ObservableProperty]
        private bool isExpandido;

        [ObservableProperty]
        private int contadorReportes;

        public SeguimientoViewModel()
        {
            Reportes = new ObservableCollection<Reporte>();
            ReportesFiltrados = new ObservableCollection<Reporte>();
            CargarDatosDePrueba();
        }

        partial void OnTextoBusquedaChanged(string value)
        {
            FiltrarReportes();
        }

        [RelayCommand]
        private void FiltrarReportes()
        {
            if (string.IsNullOrWhiteSpace(TextoBusqueda))
            {
                ReportesFiltrados = new ObservableCollection<Reporte>(Reportes);
            }
            else
            {
                var filtrados = Reportes.Where(r =>
                    r.Titulo.Contains(TextoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                    r.Descripcion.Contains(TextoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                    r.Id.Contains(TextoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                    r.Categoria.Contains(TextoBusqueda, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                ReportesFiltrados = new ObservableCollection<Reporte>(filtrados);
            }
            ContadorReportes = ReportesFiltrados.Count;
        }

        [RelayCommand]
        private async Task RefrescarAsync()
        {
            IsRefreshing = true;
            await Task.Delay(1000);
            CargarDatosDePrueba();
            FiltrarReportes();
            IsRefreshing = false;
        }

        [RelayCommand]
        private void SeleccionarReporte(Reporte reporte)
        {
            if (ReporteSeleccionado == reporte)
            {
                ReporteSeleccionado = null;
                IsExpandido = false;
            }
            else
            {
                ReporteSeleccionado = reporte;
                IsExpandido = true;
            }
        }

        [RelayCommand]
        private async Task ActualizarReporteAsync(Reporte reporte)
        {
            await Shell.Current.GoToAsync($"actualizarReporte?id={reporte.Id}");
        }

        [RelayCommand]
        private async Task VerMapaAsync(Reporte reporte)
        {
            try
            {
                var location = new Location(reporte.Latitud, reporte.Longitud);
                var options = new MapLaunchOptions { Name = reporte.Titulo };
                await Map.Default.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "No se pudo abrir el mapa", "OK");
            }
        }

        [RelayCommand]
        private async Task EliminarReporteAsync(Reporte reporte)
        {
            bool confirm = await Shell.Current.DisplayAlert(
                "Confirmar eliminación",
                $"¿Estás seguro de eliminar el reporte {reporte.Id}?",
                "Eliminar", "Cancelar");

            if (confirm)
            {
                Reportes.Remove(reporte);
                ReportesFiltrados.Remove(reporte);
                ContadorReportes = ReportesFiltrados.Count;
                await Shell.Current.DisplayAlert("Éxito", "Reporte eliminado", "OK");
            }
        }

        [RelayCommand]
        private void LlamarContacto(Reporte reporte)
        {
            try
            {
                if (PhoneDialer.Default.IsSupported)
                    PhoneDialer.Default.Open(reporte.Contacto);
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error", "No se pudo realizar la llamada", "OK");
            }
        }

        private void CargarDatosDePrueba()
        {
            Reportes.Clear();

            Reportes.Add(new Reporte
            {
                Id = "RPT-001",
                Titulo = "Fuga de agua en Av. Principal",
                Descripcion = "Fuga considerable en la tubería principal que afecta el suministro de agua potable en toda la zona",
                Fecha = new DateTime(2024, 6, 25),
                Autor = "María González",
                Estado = EstadoReporte.EnProceso,
                Categoria = "Agua y Drenaje",
                Prioridad = PrioridadReporte.Critica,
                Contacto = "644-123-4567",
                Ubicacion = "Av. Principal #123, Col. Centro",
                Latitud = 27.4863,
                Longitud = -109.9408
            });

            Reportes.Add(new Reporte
            {
                Id = "RPT-002",
                Titulo = "Luminarias descompuestas",
                Descripcion = "Varias luminarias sin funcionar en la calle",
                Fecha = new DateTime(2024, 6, 24),
                Autor = "Juan Pérez",
                Estado = EstadoReporte.Pendiente,
                Categoria = "Alumbrado Público",
                Prioridad = PrioridadReporte.Media,
                Contacto = "644-987-6543",
                Ubicacion = "Calle 5 de Febrero #456",
                Latitud = 27.4900,
                Longitud = -109.9350
            });

            Reportes.Add(new Reporte
            {
                Id = "RPT-003",
                Titulo = "Baches reparados exitosamente",
                Descripcion = "Los baches reportados fueron reparados",
                Fecha = new DateTime(2024, 6, 20),
                Autor = "Carlos López",
                Estado = EstadoReporte.Resuelto,
                Categoria = "Vialidades",
                Prioridad = PrioridadReporte.Alta,
                Contacto = "644-555-1234",
                Ubicacion = "Blvd. García Morales #789",
                Latitud = 27.4750,
                Longitud = -109.9500
            });

            ContadorReportes = Reportes.Count;
            ReportesFiltrados = new ObservableCollection<Reporte>(Reportes);
        }
    }
}
