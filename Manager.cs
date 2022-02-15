using System.Collections.Generic;
using System.Windows;

namespace CoolHacker
{
    static internal class Manager
    {

        public static List<Part> MotherBoards = new();      // Доступные материнки
        public static List<Part> CPUs = new();              // Доступные процы
        public static List<Part> VideoCards = new();        // Доступные видюхи
        public static List<Part> DiscDrives = new();        // Доступные накопители
        public static List<Part> RAMs = new();              // Доступная память

        public static List<Part> Parts = new();             // Детали выбранные для машины
        public static List<Part> TmpLst = new();            // Список для временного хранения 


        public static string purpose_of_the_machine = "";   // Это желаемая конфигурация машины
        
        //Чтобы как-то контролировать наличие и количество деталей.
        public static bool motherBoard = false;
        public static bool cpu = false;
        public static bool videoCard = false;
        public static bool discDrive = false;
        public static bool ram = false;

        // учитываемые ошибки сборки ПК
        public static bool erorr_purpose = false;                 // Ошибка выбора материнской платы в контексте производительности
        public static bool erorr_cpu_purpose = false;             // Ошибка выбора процессора в контексте производительности
        public static bool erorr_cpu_moterboard = false;          // Ошибка выбора процессора в контексте совместимости
        public static bool erorr_videocard_purpose = false;       // Ошибка выбора видеокарты в контексте производительности
        public static bool erorr_discdrive_purpose = false;       // Ошибка выбора накопителя в контексте производительности
        public static bool erorr_discdrive_moterboard = false;    // Ошибка выбора накопителя в контексте совместимости
        public static bool erorr_ram_moterboard = false;          // Ошибка выбора памяти в контексте совместимости

        public static void ControlNumberOfParts(List<Part> parts)
        {
            if (Parts.Count > 5 | Parts.Count < 4)      // Допустим в одну машину можно установить только один элемент каждого типа. Если элементов больше пяти  тогда ошибка
            {
                MessageBox.Show("Кажется что-то не так! Может деталей не хватает? Оперативы... или проца.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                foreach (var item in Parts)
                {
                    switch (item.GetType().Name)
                    {
                        case "MotherBoard":
                            if (!motherBoard) motherBoard = true;
                            break;
                        case "CPU":
                            if (!cpu) cpu = true;
                            break;
                        case "VideoCard":
                            if (!videoCard) videoCard = true;
                            break;
                        case "DiscDrive":
                            if (!discDrive) discDrive = true;
                            break;
                        case "RAM":
                            if (!ram) ram = true;
                            break;

                    }
                }
            }

        }


       
        /// <summary>
        /// Метод инициализирует объекты производных от абстрактного класса Part классов, и распределяет их по соответствующим спискам.
        /// </summary>
        public static void Separator()
        {
            ICSVLoader loader = new CSVLoader();
            string[][] CSVstr = loader.ReadFromFile();

            for (int i = 1; i < CSVstr.Length; i++)
            {
                switch (CSVstr[i][1])
                {
                    case "MotherBoard":
                        Part motherBoard = new MotherBoard(CSVstr[i][0], CSVstr[i][2], CSVstr[i][3], CSVstr[i][4], CSVstr[i][5], CSVstr[i][6], CSVstr[i][7]);
                        MotherBoards.Add(motherBoard);
                        break;

                    case "CPU":
                        Part cpu = new CPU(CSVstr[i][0], CSVstr[i][2], CSVstr[i][3], CSVstr[i][4], CSVstr[i][5], CSVstr[i][6], CSVstr[i][7]);
                        CPUs.Add(cpu);
                        break;

                    case "VC":
                        Part videoCard = new VideoCard(CSVstr[i][0], CSVstr[i][2], CSVstr[i][3], CSVstr[i][4], CSVstr[i][5], CSVstr[i][6], CSVstr[i][7]);
                        VideoCards.Add(videoCard);
                        break;

                    case "SSD":
                        Part discDriveSSD = new DiscDrive(CSVstr[i][0], CSVstr[i][2], CSVstr[i][3], CSVstr[i][4], CSVstr[i][5], CSVstr[i][6], CSVstr[i][7]);
                        DiscDrives.Add(discDriveSSD);
                        break;

                    case "HDD":
                        Part discDriveHDD = new DiscDrive(CSVstr[i][0], CSVstr[i][2], CSVstr[i][3], CSVstr[i][4], CSVstr[i][5], CSVstr[i][6], CSVstr[i][7]);
                        DiscDrives.Add(discDriveHDD);
                        break;

                    case "RAM":
                        Part ram = new RAM(CSVstr[i][0], CSVstr[i][2], CSVstr[i][3], CSVstr[i][4], CSVstr[i][5], CSVstr[i][6], CSVstr[i][7]);
                        RAMs.Add(ram);
                        break;
                }

            }

        }


    }
}
