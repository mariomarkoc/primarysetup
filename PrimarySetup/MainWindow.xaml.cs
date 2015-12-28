using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrimarySetup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string wallpaperFilename = null;
        private bool fullScreen = true;
        private SoftwareInstaller softwareInstaller;

        public MainWindow()
        {
            InitializeComponent();
            softwareInstaller = new SoftwareInstaller();

        }

        private void StartUpMethod()
        {
            imageLogo.Source = new BitmapImage(new Uri(@"\LydOgTeleStorTransparent.png", UriKind.Relative));
        }

        private void btnHomePage_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey startPageKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            startPageKey.SetValue("Start Page", "http://www.salett.no/");
            startPageKey.Close();
            MessageBox.Show("IE set!");

        }

        private void btnSetSearchEngine_Click(object sender, RoutedEventArgs e)
        {
            Guid g = Guid.NewGuid();
            MessageBox.Show(g.ToString().ToUpper());

            RegistryKey searchScope = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\SearchScopes", true);

            searchScope.CreateSubKey("{" + g.ToString().ToUpper() + "}");
            String guid = ("{" + g.ToString().ToUpper() + "}");
            searchScope = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\SearchScopes\" + guid, true);
            
            
            CustomSearch cs = new CustomSearch("DisplayName", "Google", "FaviconURL",
                "http://www.google.com/favicon.ico", "ShowSearchSuggestions", 1, "SuggestionsURL",
                "http://clients5.google.com/complete/search?q={searchTerms}&client=ie8&mw={ie:maxWidth}&sh={ie:sectionHeight}&rh={ie:rowHeight}&inputencoding={inputEncoding}&outputencoding={outputEncoding}",
                "URL", "http://www.google.com/search?q={searchTerms}");


            searchScope.SetValue(cs.CurrentDisplayName, cs.CurrentDisplaynameValue);
            searchScope.SetValue(cs.CurrentFaviconURL, cs.CurrentFaviconURLvalue);
            searchScope.SetValue(cs.CurrentShowSearchSuggestions, cs.CurrentShowSearchSuggestionsValue, RegistryValueKind.DWord);
            searchScope.SetValue(cs.CurrentSuggestionsURL, cs.CurrentSuggestionsURLValue);
            searchScope.SetValue(cs.CurrentURL, cs.CurrentURLValue);

            searchScope = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\SearchScopes", true);
            searchScope.SetValue("DefaultScope", guid);

            searchScope.Close();
        }

        private void btnCopyFiles_Click(object sender, RoutedEventArgs e)
        {
            string myPicturesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string myDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string myFavorites = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);

            string supportFile = "SupportSaLettData.exe";
            string backgroundFile = "ltlbakgrunn.jpg";

            string supportFileToDesktop = System.IO.Path.Combine(myDocuments, supportFile);
            string supportFileToDocuments = System.IO.Path.Combine(myDesktop, supportFile);
            string backgroundFileToDesktop = System.IO.Path.Combine(myDesktop, backgroundFile);
            string backgroundFileToDocuments = System.IO.Path.Combine(myDocuments, backgroundFile);

            try
            { 
                //Supportfil
                System.IO.File.Copy(supportFile, supportFileToDesktop, true);
                System.IO.File.Copy(supportFile, supportFileToDocuments, true);
            
                //Bakgrunnsfil
                System.IO.File.Copy(backgroundFile, backgroundFileToDesktop, true);
                System.IO.File.Copy(backgroundFile, backgroundFileToDocuments, true);
                MessageBox.Show("Filene ble kopiert \n" + backgroundFileToDesktop + "  \n" + backgroundFileToDocuments);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Feil skjedde" + ex.Message);
            }

            
        }

        private void btnInstallJava_Click(object sender, RoutedEventArgs e)
        {
            softwareInstaller.InstallJavaRuntimeEnviroment();
        }

        private void btnSetBackground_Click(object sender, RoutedEventArgs e)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(path);
            string file = @"\ltlbakgrunn.jpg";
            wallpaperFilename = directory + file;
            if (!String.IsNullOrEmpty(wallpaperFilename))
            {
                Wallpaper.SetDesktopWallpaper(wallpaperFilename, SelectedWallpaperStyle);
                MessageBox.Show("Bakgrunnsbilde satt","Lyd & Tele AS",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        private WallpaperStyle SelectedWallpaperStyle
        {
            get
            {
                if (fullScreen)
                {
                    return WallpaperStyle.Fill;
                    
                }
                else
                {
                    return WallpaperStyle.Fill;
                }
            }
        }

        private void btnCreateShortCut_Click(object sender, RoutedEventArgs e)
        {
            string s = System.IO.Path.Combine(@"C:\Program Files\Internet Explorer", @"iexplore.exe");          
            ShortCut.CreateShortcut("Internet Explorer", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), s);
        }

        private void btnInstallAdobe_Click(object sender, RoutedEventArgs e)
        {
            softwareInstaller.InstallAdobeReader(true);
        }
    }
}
