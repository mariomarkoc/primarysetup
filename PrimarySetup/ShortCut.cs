using IWshRuntimeLibrary;

namespace PrimarySetup
{
    public static class ShortCut
    {

        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "Internet Explorer 11 Så Lett Data";   // The description of the shortcut
            shortcut.IconLocation = @"C:\Program Files\Internet Explorer\iexplore.exe";           // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation;                 // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                    // Save the shortcut
        }
    }
}
