using System.ComponentModel.DataAnnotations;

namespace CoData_Movil_App.MVM.Model
{
    public class reportes
    {
        [Key]
        public int id_reporte { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string estado { get; set; }
        public int id_usuario { get; set; }
         

    }

    public class reporte_usuario
    {
        public int id_reporte { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string estado { get; set; }
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string email_usuario { get; set; }
    }

    public class login
    {
        [Key]
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string email_usuario { get; set; }
        public string contrasena { get; set; }

    }

    public class registro
    {
        [Key]
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string email_usuario { get; set; }
        public string contrasena { get; set; }
    }

    public class actualizar_reporte
    {
        [Key]
        public int id_reporte { get; set; }
        public string estado { get; set; }
    }

    public class eliminar_reporte
    {
        [Key]
        public int id_reporte { get; set; }
    }

    public class eliminar_usuario
    {
        [Key]
        public int id_usuario { get; set; }
    }

    public class actualizar_usuario
    {
        [Key]
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string email_usuario { get; set; }
        public string contrasena { get; set; }
    }

    

}
