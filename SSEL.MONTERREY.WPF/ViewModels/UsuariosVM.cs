using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSEL.MONTERREY.WPF.ViewModels;

    public class UsuariosVM : ViewModelBase
    {
        private string _titulo = "Usuarios View";
        private string _nombreUsuario = string.Empty;
        private string _correo = string.Empty;
        private string _rol = string.Empty;
        private bool _activo = true;

        public string Titulo
        {
            get => _titulo;
            set
            {
                if (_titulo != value)
                {
                    _titulo = value;
                    SetProperty();
                }
            }
        }

        public string NombreUsuario
        {
            get => _nombreUsuario;
            set
            {
                if (_nombreUsuario != value)
                {
                    _nombreUsuario = value;
                    SetProperty();
                }
            }
        }

        public string Correo
        {
            get => _correo;
            set
            {
                if (_correo != value)
                {
                    _correo = value;
                    SetProperty();
                }
            }
        }

        public string Rol
        {
            get => _rol;
            set
            {
                if (_rol != value)
                {
                    _rol = value;
                    SetProperty();
                }
            }
        }

        public bool Activo
        {
            get => _activo;
            set
            {
                if (_activo != value)
                {
                    _activo = value;
                    SetProperty();
                }
            }
        }

       
    }

