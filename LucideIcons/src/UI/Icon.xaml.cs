using System.Drawing;
using System.Windows;
using LucideIcons.Enum;
using LucideIcons.Extensions;
using LucideIcons.Helpers;

namespace LucideIcons
{
    /// <summary>
    /// Interaktionslogik für Icon
    /// </summary>
    public partial class Icon
    {
        public Icon()
        {
            InitializeComponent();
        }
        
        public IconName LucideIcon
        {
            get { return (IconName)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }


        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(LucideIcon), typeof(IconName), typeof(Icon), new UIPropertyMetadata(PropertyChanged));
        
        public Color Stroke
        {
            get { return (Color)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register(nameof(Stroke), typeof(Color), typeof(Icon), new UIPropertyMetadata(Color.Black, PropertyChanged));
                
        public float StrokeWidth
        {
            get { return (float)GetValue(StrokeWidthProperty); }
            set { SetValue(StrokeWidthProperty, value); }
        }

        public static readonly DependencyProperty StrokeWidthProperty =
            DependencyProperty.Register(nameof(StrokeWidth), typeof(float), typeof(Icon), new UIPropertyMetadata(1f, PropertyChanged));

        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Icon icon)
            {
                if (e.Property == IconProperty || e.Property == HeightProperty || e.Property == WidthProperty || e.Property == StrokeProperty || e.Property == StrokeWidthProperty)
                {
                    // Icon laden und konvertieren
                    var drawingImage = IconHelper.GetIcon(EnumHelper.ToSvgFilename(icon.LucideIcon), icon.Stroke, icon.StrokeWidth, (int)icon.Width, (int)icon.Height);
                    icon.Image.Source = drawingImage.ToImageSource();   
                }
                
            }
        }
    }
}
