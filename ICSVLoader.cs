namespace CoolHacker
{
    interface ICSVLoader
    {

        /// <summary>
        ///  Метод осуществляет чтение из файла CSV с данными в массив.
        /// </summary>
        /// <param name="CSVFilePath">Путь к файлу</param>
        /// <returns>возвращает массив массивов строк из базы данных</returns>
        public string[][] ReadFromFile(string CSVFilePath = "CSVCoolHacker.csv");

    }
}
