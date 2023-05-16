using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RiotSharp.Persistence
{
    public class FileSystemStore : IResponseStore
    {
        private string directoryPath;
        private TimeSpan RetentionTime = new TimeSpan(7, 0, 0, 0);
        private TimeSpan ExpirationTime = new TimeSpan(1, 0, 0, 0);

        public FileSystemStore(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                throw new ArgumentException("Destination directory does not exist.");
            this.directoryPath = directoryPath;
        }

        public Response Get(string key)
        {
            try
            { 
                var fileEntries = Directory.GetFiles(directoryPath);
                foreach(var fileName in fileEntries.Where(x => x.Contains(key)))
                {
                    var fileNameParts = fileName.Split('_');
                    if (fileNameParts.First() != key)
                        continue;
                    var creationTime = new DateTime(Convert.ToInt64(fileNameParts.Last()));
                    var timeDifference = DateTime.Now.Subtract(creationTime);
                    if (timeDifference > ExpirationTime)
                    {
                        if (timeDifference > RetentionTime)
                            File.Delete(Path.Combine(directoryPath, fileName));

                        return null;
                    }  
                    else
                    {
                        using (var fileStream = new FileStream(Path.Combine(directoryPath, fileName), FileMode.Open))
                        {
                            //return fileStream.Re
                            return null; 
                        }
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public void Save(string key, string response)
        {
            var fileName = key + "_" + DateTime.Now.ToBinary();
            using (var fileStream = new FileStream(Path.Combine(directoryPath + fileName), FileMode.Create))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(response);
                fileStream.Write(info, 0, info.Length);
            }
        }

        /// <summary>
        /// Delete all entries past the retention time
        /// </summary>
        private void CleanUp()
        {

        }
    }
}
