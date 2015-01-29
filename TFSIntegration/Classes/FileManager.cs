// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileManager.cs" company="">
//   
// </copyright>
// <summary>
//   The file manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TFSIntegration.Classes
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>The file manager.</summary>
    public class FileManager
    {
        #region Public Methods and Operators

        /// <summary>The read file.</summary>
        /// <param name="path">The path.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string ReadFile(string path)
        {
            try
            {
                // create a writer and open the file
                TextReader textReader = new StreamReader(path);

                // write a line of text to the file
                var result = textReader.ReadToEnd();

                // close the stream
                textReader.Close();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>The create folder.</summary>
        /// <param name="path">The path.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool CreateFolder(string path)
        {
            try
            {
                var dirInfo = Directory.CreateDirectory(path);
                return dirInfo.Exists;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>The folder exist.</summary>
        /// <param name="path">The path.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool FolderExist(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>The folder exist.</summary>
        /// <param name="folderName">The project type.</param>
        /// <param name="path">The path.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string FolderExist(string folderName, string path)
        {
            try
            {
                var directories = Directory.GetDirectories(path).ToList();
                var result = directories.Find(dir => dir.Contains(folderName));
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>The write file.</summary>
        /// <param name="path">The path.</param>
        /// <param name="contents">The contents.</param>
        public void WriteFile(string path, string contents)
        {
            // create a writer and open the file
            TextWriter streamWriter = new StreamWriter(path);

            // write a line of text to the file
            streamWriter.WriteLine(contents);

            // close the stream
            streamWriter.Close();
        }

        #endregion
    }
}