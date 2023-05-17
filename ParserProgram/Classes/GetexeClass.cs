
namespace ParserProgram.Classes
{
    public class GetexeClass
    {
        public void getExe(ref string exePath) 
        {
            string dllPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            exePath = dllPath.Remove(dllPath.Length - 3) + "exe";
        }
    }
}
