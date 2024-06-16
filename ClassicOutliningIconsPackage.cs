using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;
using System.Windows;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Shell.Interop;
using ClassicOutliningIcons;

namespace ClassicOutliningIcons
{
	/// <summary>
	/// This is the class that implements the package exposed by this assembly.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The minimum requirement for a class to be considered a valid package for Visual Studio
	/// is to implement the IVsPackage interface and register itself with the shell.
	/// This package uses the helper classes defined inside the Managed Package Framework (MPF)
	/// to do it: it derives from the Package class that provides the implementation of the
	/// IVsPackage interface and uses the registration attributes defined in the framework to
	/// register itself and its components with the shell. These attributes tell the pkgdef creation
	/// utility what data to put into .pkgdef file.
	/// </para>
	/// <para>
	/// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
	/// </para>
	/// </remarks>
	[PackageRegistration (UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
	[Guid (ClassicOutliningIconsPackage.PackageGuidString)]
	[ProvideAutoLoad (UIContextGuids.NoSolution, PackageAutoLoadFlags.BackgroundLoad)]
	[ProvideAutoLoad (UIContextGuids.SolutionExists, PackageAutoLoadFlags.BackgroundLoad)]
	[ProvideAutoLoad (UIContextGuids.CodeWindow, PackageAutoLoadFlags.BackgroundLoad)]
	[ProvideAutoLoad (UIContextGuids.EmptySolution, PackageAutoLoadFlags.BackgroundLoad)]
	[ProvideOptionPage (typeof (ColorOptionsPage), "Classic Outlining", "Appearance", 0, 0, true)]
	public sealed class ClassicOutliningIconsPackage : AsyncPackage
	{
		public static ClassicOutliningIconsPackage Instance { get; private set; }

		/// <summary>
		/// ClassicOutliningIconsPackage GUID string.
		/// </summary>
		public const string PackageGuidString = "b59134e4-53f8-4c01-a27e-5d3bfa59b01a";

		ColorOptionsPage optionsPage => (ColorOptionsPage)GetDialogPage (typeof (ColorOptionsPage));

		public string SymbolColor { get => optionsPage?.SymbolColor ?? "Black"; }
		public string RectangleColor { get => optionsPage?.RectangleColor ?? "Gray"; }
		public string RectangleCollapsedBackgroundColor { get => optionsPage?.RectangleCollapsedBackgroundColor ?? "LightGray"; }
		public string RectangleHoveredBackgroundColor { get => optionsPage?.RectangleHoveredBackgroundColor ?? "Gray"; }



		#region Package Members

		/// <summary>
		/// Initialization of the package; this method is called right after the package is sited, so this is the place
		/// where you can put all the initialization code that rely on services provided by VisualStudio.
		/// </summary>
		/// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
		/// <param name="progress">A provider for progress updates.</param>
		/// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
		protected override async Task InitializeAsync (CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
		{
			Instance = this;

			// When initialized asynchronously, the current thread may be a background thread at this point.
			// Do any initialization that requires the UI thread after switching to the UI thread.
			await this.JoinableTaskFactory.SwitchToMainThreadAsync (cancellationToken);

			var rDict = new ResourceDictionary ()
			{
				Source = new Uri ("/ClassicOutliningIcons;component/ClassicOutliningIcons.xaml", UriKind.Relative)
			};

			var modifiedType = typeof (OutliningMarginHeaderControl);
			Application.Current.Resources[modifiedType] = rDict["ClassicOutliningMarginHeaderControlStyle"];
		}

		#endregion
	}
}
