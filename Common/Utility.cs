using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Common
{
    public class Utility
    {
        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();

        }
        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {


            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;

        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

        
            // Get Personal Images Path
            string DestinationFolder = GetPersonalImagesPath();


            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string newFileName = ReplaceFileNameWithGUID(sourceFile);
            string destinationFile = Path.Combine(DestinationFolder, newFileName);

            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = Path.Combine(@"Resources\Personal Images", newFileName);
            return true;
        }

        public static string GetPersonalImagesPath()
        {
            // Use Path.Combine to merge paths safely and professionally.
            return Path.Combine(GetRootPath(), "Resources", "Personal Images");
        }

        public static string GetRootPath()
        {
            // 1. Specify the base path of the application (usually bin\Debug or bin\Release).
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // 2. Go up three levels (../../../) to reach the root folder 
            // This is necessary to exit the 'bin\Debug' or 'bin\Release' directories 
            // and the intermediate project folder (e.g., 'UI').
            string relativePath = Path.Combine(basePath, @"..\..\..");

            // 3. Convert the relative path to an absolute and final (normalized) path.
            return Path.GetFullPath(relativePath);
        }

        public static string PasswordEncryption(string Password, int Key)
        {
            StringBuilder encryptedPassword = new StringBuilder(Password.Length);

            foreach (char c in Password)
            {
                int shiftedCharValue = c + Key;

                encryptedPassword.Append((char)shiftedCharValue);
            }
            return encryptedPassword.ToString();
        }

        public static string PasswordDecryption(string EncryptedPassword, int Key)
        {
            StringBuilder decryptedPassword = new StringBuilder(EncryptedPassword.Length);

            foreach (char c in EncryptedPassword)
            {
                int originalCharValue = c - Key;

                decryptedPassword.Append((char)originalCharValue);
            }

            return decryptedPassword.ToString();
        }

    }
}
