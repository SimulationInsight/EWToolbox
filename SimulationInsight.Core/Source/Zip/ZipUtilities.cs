using System.IO.Compression;

namespace SimulationInsight.Core;

public static class ZipUtilities
{
    public static void ZipDirectory(string inputPath, string zipPath)
    {
        var tempFileName = Path.GetTempFileName();

        File.Delete(tempFileName);

        if (File.Exists(zipPath))
        {
            File.Delete(zipPath);
        }

        ZipFile.CreateFromDirectory(inputPath, tempFileName);

        File.Copy(tempFileName, zipPath);

        File.Delete(tempFileName);
    }

    public static void UnzipDirectory(string zipPath, string extractPath)
    {
        ZipFile.ExtractToDirectory(zipPath, extractPath);
    }
}