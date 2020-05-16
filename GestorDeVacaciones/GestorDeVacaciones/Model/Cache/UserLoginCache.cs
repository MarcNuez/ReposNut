using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.Model.Cache
{
    public static class UserLoginCache
    {

        public static int Id { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string Nombre { get; set; }
        public static string Apellidos { get; set; }
        public static string Email { get; set; }
        public static string Rol { get; set; }

        public static string UrlImage { get; set; }


    }
}
