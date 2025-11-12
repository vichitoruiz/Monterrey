using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSEL.MONTERREY.WPF.ViewModels;

    public class ReclamosVM : ViewModelBase
    {
        private string _titulo = "Reclamos View";
        private string _descripcion = string.Empty;
        private string _estado = string.Empty;

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

        public string Estado
        {
            get => _estado;
            set
            {
                if (_estado != value)
                {
                    _estado = value;
                    SetProperty();
                }
            }
        }


    }

