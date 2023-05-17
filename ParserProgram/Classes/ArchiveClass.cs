using System.IO.Compression;

namespace ParserProgram.Classes
{
    internal class ArchiveClass
    {
        string folderPath;
        string needDirPath;
        string archPath;
        internal ArchiveClass(string folderP)
        {
            folderPath = folderP;
            needDirPath = folderPath + "\\" + DateTime.Now.AddDays(-2).ToShortDateString();
            archPath = needDirPath + ".zip";
        }

        internal void doArchive()
        {
            try
            {
                if (Directory.Exists(needDirPath))
                {
                    if (File.Exists(archPath) == true)
                    {
                        File.Delete(archPath);
                    }

                    ZipFile.CreateFromDirectory(needDirPath, archPath);

                    try
                    {
                        Directory.Delete(needDirPath, true);
                    }
                    catch
                    {
                        return;
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Ошибка архивации: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
