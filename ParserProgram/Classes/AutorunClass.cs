using Microsoft.Win32;
using System.Reflection;

namespace ParserProgram.Classes
{
    internal class AutorunClass
    {
        internal bool AutoRun(bool autorun)
        {
            const string name = "MMC Parser";
            string dllPath = Assembly.GetExecutingAssembly().Location;
            string exePath = dllPath.Remove(dllPath.Length - 3) + "exe";
            RegistryKey reg;

            try
            {
                reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");

                if (autorun)
                {
                    reg.SetValue(name, exePath);
                }
                else
                {
                    reg.DeleteValue(name);
                }

                reg.Flush();
                reg.Close();
            }
            catch (Exception) { return false; }

            return true;
        }
    }
}
