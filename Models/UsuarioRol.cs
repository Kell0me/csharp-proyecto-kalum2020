namespace Kalum2020v1.Models
{
    public class UsuarioRol
    {
        //para enlazar las tablas de Usuario y Roles
        public int UsuarioId {get;set;}
        public int RoleId {get;set;}

        //relacion de usuarios
        public Usuario Usuario{get;set;}
        public Rol Rol{get;set;}
    }
}