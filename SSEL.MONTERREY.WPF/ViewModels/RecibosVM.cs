using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSEL.MONTERREY.WPF.ViewModels;

    public class RecibosVM : ViewModelBase
    {
        private string _titulo = "Recibos View";
        private string _periodo = string.Empty;
        private string _numeroRecibo = string.Empty;
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

        public string Periodo
        {
            get => _periodo;
            set
            {
                if (_periodo != value)
                {
                    _periodo = value;
                    SetProperty();
                }
            }
        }

        public string NumeroRecibo
        {
            get => _numeroRecibo;
            set
            {
                if (_numeroRecibo != value)
                {
                    _numeroRecibo = value;
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

