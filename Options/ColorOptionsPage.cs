using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Internal.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;


namespace ClassicOutliningIcons
{
	[Guid ("1c260f71-2ab6-44d0-a70b-3049de9217d6")]
	public class ColorOptionsPage : DialogPage
	{
		private string _lineColor = "Black";
		private string _rectangleColor = "Gray";
		private string _rectangleCollapsedBackgroundColor = "LightGray";
		private string _rectangleHoveredBackgroundColor = "Gray";

		[Category ("Classic Outlining")]
		[DisplayName ("Symbol Color")]
		[Description ("The color of the symbols +- (e.g., red or #ffffff).")]
		public string SymbolColor
		{
			get { return _lineColor; }
			set { _lineColor = value; }
		}


		[Category ("Classic Outlining")]
		[DisplayName ("Rectangle Border Color")]
		[Description ("The color of the rectangle border (e.g., red or #ffffff).")]
		public string RectangleColor
		{
			get { return _rectangleColor; }
			set { _rectangleColor = value; }
		}

		[Category ("Classic Outlining")]
		[DisplayName ("Rectangle Collapsed Background Color")]
		[Description ("The color of the rectangle when collapsed (e.g., red or #ffffff).")]
		public string RectangleCollapsedBackgroundColor
		{
			get { return _rectangleCollapsedBackgroundColor; }
			set { _rectangleCollapsedBackgroundColor = value; }
		}

		[Category ("Classic Outlining")]
		[DisplayName ("Rectangle Hovered Background Color")]
		[Description ("The color of the rectangle when hovered (e.g., red or #ffffff).")]
		public string RectangleHoveredBackgroundColor
		{
			get { return _rectangleHoveredBackgroundColor; }
			set { _rectangleHoveredBackgroundColor = value; }
		}


	}
}
