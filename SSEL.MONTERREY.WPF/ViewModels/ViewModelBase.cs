using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSEL.MONTERREY.WPF.ViewModels;

    /// <summary>
    /// Clase base para todos los ViewModels.
    /// Implementa INotifyPropertyChanged y utilidades comunes.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // Evento de notificación de cambios de propiedad (seguro para nullables)
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Notifica a la vista que una propiedad cambió.
        /// </summary>
        /// <param name="name">Nombre de la propiedad que cambió.</param>
        protected virtual void SetProperty([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        /// <summary>
        /// Asigna un nuevo valor a un campo y notifica el cambio solo si el valor es distinto.
        /// </summary>
        /// <typeparam name="T">Tipo del valor.</typeparam>
        /// <param name="field">Campo a modificar.</param>
        /// <param name="value">Nuevo valor.</param>
        /// <param name="propertyName">Nombre de la propiedad (se infiere automáticamente).</param>
        /// <returns>True si el valor cambió, False si era el mismo.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value))
                return false;

            field = value;
            SetProperty(propertyName);
            return true;
        }
    }
