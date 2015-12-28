using System;
using System.Diagnostics;
using System.Windows;

namespace PrimarySetup
{
    class SoftwareInstaller
    {
        public SoftwareInstaller()
        {

        }

        internal void InstallAdobeReader(Boolean SuppressReboot)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            string file = @"\Adobe\AdbeRdr11000_en_US.exe";
            string filename = getWorkingDirectory() + file;
            psi.FileName = filename;
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;

            psi.Arguments = "/sPB /rs";
            Process p;
            try
            {
                p = Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Feilmelding ; " + ex.Message);
                throw;
            }
            string strOutput = p.StandardError.ReadToEnd();
            MessageBox.Show("Adobe ble installert","Adobe Installer",MessageBoxButton.OK,MessageBoxImage.Information);
            p.WaitForExit();
        }

        private string getWorkingDirectory()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(path);
            return directory;
        }

        internal void InstallJavaRuntimeEnviroment()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            string file = @"\Java\jre-8u66-windows-i586.exe";
            string filename = getWorkingDirectory() + file;
            psi.FileName = filename;
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;

            psi.Arguments = "/s";
            Process p;
            try
            {
                p = Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Feilmelding ; " + ex.Message);
                throw;
            }
            string strOutput = p.StandardError.ReadToEnd();
            MessageBox.Show("Java ble installert", "Adobe Installer", MessageBoxButton.OK, MessageBoxImage.Information);
            p.WaitForExit();
        }
    }
}
