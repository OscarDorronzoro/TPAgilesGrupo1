using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TPAgilesGrupo1.Model
{
    public class Usuario : Invitado
    {
        #region Base de datos
        private static List<Usuario> usuariosRegistrados = new List<Usuario>();
        public static void InicializarUsuario()
        {
            usuariosRegistrados.Add(new Usuario("pepe@gmail.com", "1234567abc!!"));
            usuariosRegistrados.Add(new Usuario("juan@gmail.com", "qwerty123@"));
        }
        #endregion

        readonly private int MIN_PASSWORD_LENGTH = 8;
        readonly private int MAX_PASSWORD_LENGTH = 60; 
        public string mail;
        public string contrasena;



        public Usuario() : base()
        {
        }

        public Usuario(string nombre) : base(nombre)
        {
        }

        public Usuario(string mail, string contrasena) : base()
        {
            this.mail = mail;
            this.contrasena = contrasena;
        }

        public bool ValidarMail(string mail)
        {
            return Regex.IsMatch(mail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
        
        public bool ValidarContrasena(string contrasena)
        {
            bool contrasenaValida = true;

            if (contrasena.Length < MIN_PASSWORD_LENGTH) contrasenaValida = false;
            if (contrasena.Length > MAX_PASSWORD_LENGTH) contrasenaValida = false;
            if (!(
                contrasena.Contains("!") ||
                contrasena.Contains("@") ||
                contrasena.Contains("#") ||
                contrasena.Contains("$") ||
                contrasena.Contains("%") ||
                contrasena.Contains("&") ||
                contrasena.Contains(".") ||
                contrasena.Contains("=")
                )) contrasenaValida = false;

            return contrasenaValida;
        }

        public bool LogIn()
        {
            return Usuario.usuariosRegistrados.Contains(this);
        }

        public override bool Equals(object obj)
        {
            Usuario usuario = (Usuario)obj;
            return usuario.mail == this.mail && usuario.contrasena == this.contrasena;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
