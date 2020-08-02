using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Rename_Image_Files
{
    public partial class FormRename : Form
    {
        ArrayList fileList = new ArrayList();
        string[] fileType = new string[] { "JPG", "PNG", "MOV", "3GP","MP4" };
        string directory;
        int numFiles;
        string logFile = "C:\\Test\\" + DateTime.Now.ToString("yyyMMdd") + ".log";



        public enum xFileType
        {
            JPG, PNG, MOV
        };

        public FormRename()
        {
            InitializeComponent();
            FileTypeToCheckBox();
        }


        public void FileTypeToCheckBox()
        {
            try
            {
                foreach (string value in fileType)
                {
                    CLBFileType.Items.Add(value, true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
                UpdateLog(e.Message);
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            directory = string.Empty;
            LVFilenames.Clear();
            Console.Clear();

            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                directory = Path.GetDirectoryName(dialog.FileName);
                LblPath.Text = "Folder: " + directory;
                UpdateLog(LblPath.Text.ToUpper());
                LoadFilestoArray(directory);
            }
        }

        private void LoadFilestoArray(string directory)
        {
            fileList.Clear();

            if (!string.IsNullOrEmpty(directory))
            {
                UpdateLog("LOADING FILES TO LIST");

                foreach (int checkedIndex in CLBFileType.CheckedIndices)
                {
                    string ext = "*." + CLBFileType.Items[checkedIndex].ToString();
                    //Console.WriteLine(checkedIndex + "\t" + CLBFileType.Items[checkedIndex].ToString());

                    fileList.AddRange(System.IO.Directory.GetFiles(directory, ext));
                }
                numFiles = fileList.Count;

                UpdateListView();
            }
        }


        private void UpdateListView()
        {
            if (numFiles != 0)
            {
                int count = 0;

                UpdateLog("UPLOADING FOLDER LIST");

                while (count < numFiles)
                {
                    string name = Path.GetFileName(fileList[count].ToString());
                    LVFilenames.Items.Add(name);
                    UpdateLog(name);
                    count += 1;
                }
            }
        }

        private void UpdateFileName()
        {
            int count = 0;
            DateTime dtCreated = DateTime.MinValue;
            int updated = 0;
            string strNewFileName;

            string logText = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\t" + LblPath.Text.ToUpper();

            UpdateLog(logText);
            UpdateLog("RENAMING FILES");

            while (count < numFiles)
            {

                string strCurFile = fileList[count].ToString();
                string ext = Path.GetExtension(strCurFile);

                if (strCurFile == "C:\\test\\20200111_123542.JPG")
                {
                    MessageBox.Show(strCurFile);
                }

                FileStream fsCurFile = new FileStream(strCurFile, FileMode.Open);

                if (IsImageFile(ext))
                {
                    BitmapSource bmsource = BitmapFrame.Create(fsCurFile);
                    BitmapMetadata filemeta = (BitmapMetadata)bmsource.Metadata;

                    if (!string.IsNullOrEmpty(filemeta.DateTaken))
                    {
                        dtCreated = DateTime.Parse(filemeta.DateTaken);
                    }
                }
                else
                {
                    FileInfo x = new FileInfo(strCurFile);
                    dtCreated = x.LastWriteTime;
                }

                //if (!string.IsNullOrEmpty(dtCreated.ToString()))
                if (dtCreated != DateTime.MinValue)
                {
                    strNewFileName = directory + "\\" + dtCreated.ToString("yyyyMMdd_HHmmss") + ext;


                    //IF THE FILE HAS A NEW NAME
                    if (!String.Equals(strCurFile, strNewFileName, StringComparison.OrdinalIgnoreCase))
                    {
                        bool fileExists = File.Exists(strNewFileName);

                        //IF NEW FILE NAME DOESNT EXIST, RENAME CURRENT FILE
                        if (!fileExists)
                        {
                            {
                                try
                                {
                                    fsCurFile.Close(); //Close or else File.Move will not work
                                    File.Move(strCurFile, strNewFileName);

                                    logText = Path.GetFileName(strCurFile) + "\t" + ">>" + "\t" + Path.GetFileName(strNewFileName);
                                    UpdateLog(logText);
                                }
                                catch (Exception e)
                                {
                                    logText = Path.GetFileName(strCurFile) + "\t" + "File not moved. Error: " + e.Message;
                                    UpdateLog(logText.ToUpper());
                                }
                            }
                        }

                        //NEW FILE EXISTS
                        else
                        {
                            try
                            {
                                string fileNameOnly = Path.GetFileNameWithoutExtension(strNewFileName);
                                int fileNumber = 0;

                                do
                                {
                                    fileNumber += 1;
                                    strNewFileName = directory + fileNameOnly + "(" + fileNumber + ")" + ext;
                                } while (File.Exists(strNewFileName));

                                fsCurFile.Close();//Close or else File.Move will not work
                                                  //File.Create(strNewFileName);
                                File.Move(strCurFile, strNewFileName);

                                logText = Path.GetFileName(strCurFile) + "\t" + ">>" + "\t" + Path.GetFileName(strNewFileName);
                                UpdateLog(logText.ToUpper());
                            }
                            catch (Exception e)
                            {
                                logText = Path.GetFileName(strCurFile) + "\t" + e.Message;
                                UpdateLog(logText);
                            }
                        }
                        updated += 1;
                    }
                }
                count += 1;
                fsCurFile.Close();
            }

            string msg = "FILES UPDATED:" + "\t" + updated.ToString();
            MessageBox.Show(msg, "Update Stats");
            UpdateLog(msg);
        }

        private void BtnRename_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(directory))
            {
                MessageBox.Show("Select a folder", "Error");
            }
            else
            {
                fileList.Clear();
                LVFilenames.Clear();

                LoadFilestoArray(directory);
                UpdateFileName();
            }
        }

        /// <summary>
        /// Check if file is an Image
        /// </summary>
        /// <param name="fileExtension"> Filename extension</param>
        private bool IsImageFile(string fileExtension)
        {
            //foreach (var fileType in Enum.GetValues(typeof(FileType)))
            foreach (string value in fileType)
            {
                if (fileExtension.ToUpper() == ".JPG" && value == "JPG")
                {
                    return true;
                }
                else if (fileExtension.ToUpper() == ".PNG" && value == "PNG")
                {
                    return true;
                }
            }
            return false;
        }

        private void UpdateLog(string message)
        {
            string log = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\t" + message;
            File.AppendAllText(logFile, log + Environment.NewLine);
            Console.WriteLine(log);
        }
    }
}
