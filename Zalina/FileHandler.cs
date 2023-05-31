using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zalina
{
    internal class FileHandler
    {
        private readonly string filePath;

        public FileHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public void WriteToFile(string content)
        {
            // Записываем данные в файл
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(content);
            }
        }

        public string ReadFromFile()
        {
            // Считываем данные из файла
            using (StreamReader reader = new StreamReader(filePath))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
