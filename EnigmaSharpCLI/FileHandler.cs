using System;
using System.IO;

namespace EnigmaSharpCLI
{
    class FileHandler
    {
        /// <summary>
        /// Create a new file with encrypted text and a unique name in the original directory.
        /// </summary>
        /// <param name="sourceFilePath">File path to original file</param>
        /// <param name="encryptedText">Encrypted text to be saved</param>
        static public void CreateEncryptedFile(string sourceFilePath, string encryptedText)
        {
            try
            {
                string filePathWOExt = Path.Combine(Path.GetDirectoryName(sourceFilePath), Path.GetFileNameWithoutExtension(sourceFilePath));

                int j = 2;
                string counter = " (enigma).txt";

                while (File.Exists(filePathWOExt + counter))
                {                 
                    counter = " (enigma)(" + j.ToString() + ").txt";
                    j++;
                }
                File.WriteAllText(filePathWOExt + counter, encryptedText);

                Console.WriteLine("File saved.");
            }
            catch
            {
                Console.WriteLine("Error occured while saving.");
            }
        }
    }
}
