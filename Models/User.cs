using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Razor.Models
{

[Table(name: "ApiRest")]
public class User
    {
        [Key]
        public int? id { get; set; }

        public string Nombre { get; set; }

        public string DNI { get; set; }

        public short Edad { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public decimal Basico { get; set; }

        public DateTime Ingreso { get; set; }

        public bool Activo { get; set; }
    }

    //public class UserContext : DbContext
    //{
    //    public UserContext(DbContextOptions options) : base(options) { }
    //    public DbSet<User> Users { get; set; }
    //}


}
