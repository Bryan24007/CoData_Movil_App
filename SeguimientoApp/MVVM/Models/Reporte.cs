using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoApp.MVVM.Models
{
    public class Reporte
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Autor { get; set; }
        public EstadoReporte Estado { get; set; }
        public string Categoria { get; set; }
        public PrioridadReporte Prioridad { get; set; }
        public string Contacto { get; set; }
        public string Ubicacion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string ImagenUrl { get; set; }

        // Propiedades computadas para la UI
        public string FechaFormateada => Fecha.ToString("dd/MM/yy");

        public string EstadoTexto => Estado switch
        {
            EstadoReporte.Pendiente => "PENDIENTE",
            EstadoReporte.EnProceso => "EN PROCESO",
            EstadoReporte.Resuelto => "RESUELTO",
            _ => "DESCONOCIDO"
        };

        public Color EstadoColor => Estado switch
        {
            EstadoReporte.Pendiente => Colors.Red,
            EstadoReporte.EnProceso => Colors.Orange,
            EstadoReporte.Resuelto => Colors.Green,
            _ => Colors.Gray
        };

        public Color PrioridadColor => Prioridad switch
        {
            PrioridadReporte.Critica => Colors.Red,
            PrioridadReporte.Alta => Colors.Orange,
            PrioridadReporte.Media => Colors.Yellow,
            PrioridadReporte.Baja => Colors.Green,
            _ => Colors.Gray
        };

        public string PrioridadTexto => Prioridad switch
        {
            PrioridadReporte.Critica => "Crítica",
            PrioridadReporte.Alta => "Alta",
            PrioridadReporte.Media => "Media",
            PrioridadReporte.Baja => "Baja",
            _ => "Sin definir"
        };

        public Color BorderColor => Estado switch
        {
            EstadoReporte.Pendiente => Colors.Red,
            EstadoReporte.EnProceso => Colors.Orange,
            EstadoReporte.Resuelto => Colors.Green,
            _ => Colors.Gray
        };
    }

    public enum EstadoReporte
    {
        Pendiente,
        EnProceso,
        Resuelto
    }

    public enum PrioridadReporte
    {
        Baja,
        Media,
        Alta,
        Critica
    }
}
