using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using Svg;
using System.Drawing;
using LucideIcons.Enum;

namespace LucideIcons.Helpers
{
    public static class IconHelper
    {
        /// <summary>
        /// Lädt ein Icon aus den eingebetteten Ressourcen.
        /// </summary>
        /// <param name="iconName">Name des Icons (z.B. "alert-circle")</param>
        /// <param name="strokeWidth"></param>
        /// <param name="width">Breite des gerenderten Bildes</param>
        /// <param name="height">Höhe des gerenderten Bildes</param>
        /// <param name="iconStroke"></param>
        /// <returns>Ein gerendertes System.Drawing.Image</returns>
        public static Image GetIcon(string iconName, Color iconStroke, float strokeWidth = 1f, int width = 32, int height = 32)
        {
            // Ressourcennamen zusammensetzen (achten Sie auf den korrekten Namespace und Ordnerstruktur)
            string resourceName = $"LucideIcons.icons.{iconName}.svg";

            // Ressourcestream abrufen
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if(stream == null)
                {
                    Debug.WriteLine($"Resource could not be loaded: {iconName}");
                    return GetIcon(IconName.MessageCircleQuestion.ToString(), iconStroke, strokeWidth, width, height);
                }
                
                // SVG-Dokument laden und in ein Bitmap rendern
                var svgDoc = SvgDocument.Open<SvgDocument>(stream);
                svgDoc.Stroke = new SvgColourServer(iconStroke);
                svgDoc.StrokeWidth = new SvgUnit(strokeWidth);
                return svgDoc.Draw(width, height);
            }
        }
    }
}