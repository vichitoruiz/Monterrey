using System;
using System.Linq;
using System.Windows;

namespace SSEL.MONTERREY.WPF.Helpers;

    public static class ThemeManager
    {
        private static readonly string LightThemePath = "Assets/Themes/LightTheme.xaml";
        private static readonly string DarkThemePath = "Assets/Themes/DarkTheme.xaml";

        public static bool IsDarkTheme { get; private set; }

        public static void ApplyLightTheme()
        {
            ApplyTheme(LightThemePath);
            IsDarkTheme = false;
        }

        public static void ApplyDarkTheme()
        {
            ApplyTheme(DarkThemePath);
            IsDarkTheme = true;
        }

        private static void ApplyTheme(string themePath)
        {
            var app = Application.Current;
            var existingDictionaries = app.Resources.MergedDictionaries;

            // Eliminar temas anteriores
            var oldTheme = existingDictionaries.FirstOrDefault(d => 
                d.Source != null && d.Source.OriginalString.Contains("/Themes/"));
            if (oldTheme != null)
                existingDictionaries.Remove(oldTheme);

            // Agregar el nuevo
            var newTheme = new ResourceDictionary { Source = new Uri(themePath, UriKind.Relative) };
            existingDictionaries.Add(newTheme);
        }

        public static void ToggleTheme()
        {
            if (IsDarkTheme) ApplyLightTheme();
            else ApplyDarkTheme();
        }
    }

