using System.Text.RegularExpressions;

namespace LucideIcons.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Wandelt einen Enum-Wert (CamelCase) in einen Dateinamen im Format "lower-case-with-dashes.svg" um.
        /// Beispiel: WrapText -> wrap-text.svg
        /// </summary>
        public static string ToSvgFilename(System.Enum value)
        {
            // Enum in String umwandeln (z.B. "WrapText")
            string name = value.ToString();
        
            // Mit Regex: Vor jedem Großbuchstaben (außer dem ersten) wird ein Bindestrich eingefügt.
            string kebabCase = Regex.Replace(name, "(?<!^)([A-Z])", "-$1").ToLowerInvariant();
        
            return kebabCase;
        }
    }
}