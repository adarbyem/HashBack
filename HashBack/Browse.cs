using System.Windows.Forms;

namespace HashBack
{
    class Browse
    {
        //Create a File Dialoge if Needed
        public OpenFileDialog browse()
        {
            OpenFileDialog fileDialogue = new OpenFileDialog();
            if (fileDialogue.ShowDialog() == DialogResult.OK)
            {
                return fileDialogue; //Return this Object
            }
           return null;
        }
        //Create a Folder Dialoge if Needed
        public FolderBrowserDialog browseFolder()
        {
            FolderBrowserDialog folderDialoge = new FolderBrowserDialog();
            if (folderDialoge.ShowDialog() == DialogResult.OK)
            {
                return folderDialoge; //Return this Object
            }
            return null;
        }
    }
}
