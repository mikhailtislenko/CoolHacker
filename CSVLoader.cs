using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace CoolHacker
{
    class CSVLoader : ICSVLoader
    {
       
        /// <summary>
        ///  Метод осуществляет чтение из файла CSV с данными в массив.
        /// </summary>
        /// <param name="CSVFilePath">Путь к файлу</param>
        /// <returns>возвращает массив массивов строк из базы данных</returns>
        public string[][] ReadFromFile(string CSVFilePath = "CSVCoolHacker.csv")
        {
            List<Array> fieldsArrow = new List<Array>();                               //  список для прочитаных полей

            using (TextFieldParser tfp = new TextFieldParser(CSVFilePath))             // Юзинг, чтобы потом освободить занятые ресурсы.
            {
                int i = 0;

                tfp.TextFieldType = FieldType.Delimited;
                tfp.SetDelimiters(",");
                while (!tfp.EndOfData)
                {
                    string[] fields = tfp.ReadFields();
                    i++;
                    fieldsArrow.Add(fields);
                }

            }
            
            string[][] mass = new string[fieldsArrow.Count][];                        // Массив массивов для копирования полей из списка
            fieldsArrow.CopyTo(mass);
            return mass;

           // throw new NotImplementedException();
        }
    }
}
