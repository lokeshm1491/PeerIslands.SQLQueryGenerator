using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PeerIslands.SQLQueryGenerator
{
    public static class FileReader
    {
        /// <summary>
        /// Read from default executing Directory
        /// </summary>
        /// <param name="fileName">File Name to be read</param>
        /// <returns>File content in string format</returns>
        public static string ReadFile(string fileName)
        {
            var fileDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileText = File.ReadAllText(Path.Combine(fileDirectory, fileName));
            return fileText;
        }
    }
}
