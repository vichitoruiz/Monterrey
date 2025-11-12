using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSEL.MONTERREY.WPF.ViewModels
{
    public class AcercaDeVM : ViewModelBase
    {
        private string _titulo = "Acerca de SSEL Monterrey";
        private string _version = "1.0.0";
        private string _autor = "Desarrollado por Vichito Ruiz";
        private string _descripcion = "Sistema de gestión y monitoreo SSEL Monterrey - Proyecto WPF .NET 9";

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

        public string Version
        {
            get => _version;
            set
            {
                if (_version != value)
                {
                    _version = value;
                    SetProperty();
                }
            }
        }

        public string Autor
        {
            get => _autor;
            set
            {
                if (_autor != value)
                {
                    _autor = value;
                    SetProperty();
                }
            }
        }

        public string Descripcion
        {
            get => _descripcion;
            set
            {
                if (_descripcion != value)
                {
                    _descripcion = value;
                    SetProperty();
                }
            }
        }

    }
}
