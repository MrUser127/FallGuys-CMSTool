using System;
using System.Reflection;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace FGCMSTool.Views
{
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();

            Loaded += (sender, e) =>
            {
                string[]? versionAndRev = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.Split("+");
                AppVer.Text = string.Format(AppVer.Text, versionAndRev != null && versionAndRev.Length > 0 ? versionAndRev[0] : "MISSING");
                AppRev.Text = string.Format(AppRev.Text, versionAndRev != null && versionAndRev.Length > 1 ? versionAndRev[1].Substring(0, 7) : "MISSING");
            };
        }

        private void OpenDiscord(object? sender, RoutedEventArgs e) => OpenURL("https://discord.gg/PEysxvSE3x");
        private void OpenGithubRepo(object? sender, RoutedEventArgs e) => OpenURL("https://github.com/floyzi/FallGuys-CMSTool");

        void OpenURL(string url) => Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
}
