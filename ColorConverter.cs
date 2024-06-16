using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ClassicOutliningIcons
{
	public class ColorConverter : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is string colorString)
			{
				try
				{
					return (SolidColorBrush)new BrushConverter ().ConvertFromString (colorString);
				}
				catch
				{
					// Handle invalid color string
				}
			}
			return Brushes.White; // Default to white
		}

		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
	}
}


