using System;
using System.IO;

namespace HashBack
{
    class FolderSize
    {
        double folderSize = 0.0;
        public double getSize(string path)
        {
            doGetSize(path);
            folderSize = folderSize / 1024;
            folderSize = Math.Round(folderSize, 2);
            return folderSize;
        }
        public void doGetSize(string path)
        {
            foreach (string a in Directory.GetDirectories(path))
            {
                doGetSize(a);
            }
            foreach (string b in Directory.GetFiles(path))
            {
                FileInfo info = new FileInfo(b);
                folderSize += info.Length;
            }
        }
    }
}
