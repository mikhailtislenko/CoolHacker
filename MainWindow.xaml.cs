using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CoolHacker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Part motherboard;
        Part cpu;
        Part vc;
        Part discdrive;
        Part ram;
        string TotalResult = "";
        public MainWindow()
        {
            InitializeComponent();

            PurposeWindow purposeWindow = new();
            // purposeWindow.Owner = this;
            purposeWindow.ShowDialog();
            TascLbl.Content = Manager.purpose_of_the_machine;
            Manager.Separator();
        }

        private void Filling_LstBX(List<Part> list)                                                              // Очищаем и заполняем листбокс доступными деталями
        {
            AvailablePartsLstBx.Items.Clear();
            foreach (var item in list)
            {
                AvailablePartsLstBx.Items.Add(item.Name);
                Manager.TmpLst = list;                                                                          // Промежуточный список. Обновляется вместе с левым окном.
            }
        }

        private void MotherboardsBtn_Click(object sender, RoutedEventArgs e)
        {
            Filling_LstBX(Manager.MotherBoards);
        }

        private void CPUsBtn_Click(object sender, RoutedEventArgs e)
        {
            Filling_LstBX(Manager.CPUs);
        }

        private void RamsBtn_Click(object sender, RoutedEventArgs e)
        {
            Filling_LstBX(Manager.RAMs);
        }

        private void VideoCardsBtn_Click(object sender, RoutedEventArgs e)
        {
            Filling_LstBX(Manager.VideoCards);
        }

        private void DiscDrivesBtn_Click(object sender, RoutedEventArgs e)
        {
            Filling_LstBX(Manager.DiscDrives);
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AvailablePartsLstBx_MouseDoubleClick(object sender, MouseButtonEventArgs e)              // По двойному клику на элемент левого списка он появится в правом
        {
            if (AvailablePartsLstBx.SelectedItem != null)
            {
                bool error = false;    //если элемент есть, тогда тру.
                //Это код проверки на наличие аналогичного элемента в списке, если подобный элемент уже есть показывается предупреждение. 
                foreach (var item in Manager.Parts)
                {
                    if (Manager.TmpLst[AvailablePartsLstBx.SelectedIndex].GetType().Name == item.GetType().Name)
                    {
                        error = true;
                        MessageBox.Show("Элемент этого типа уже есть в конфигурации!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;

                    }

                }

                //Это код добавления элемента в список и обновление списка
                if (!error)
                {
                    Manager.Parts.Add(Manager.TmpLst[AvailablePartsLstBx.SelectedIndex]);
                    SelectedPartsLstBx.Items.Clear();
                    foreach (var item in Manager.Parts)
                    {

                        SelectedPartsLstBx.Items.Add(item.Name);

                    }
                }
            }
        }

        private void SelectedPartsLstBx_MouseDoubleClick(object sender, MouseButtonEventArgs e)               // По двойному клику удаляет выбранный элемен из правого списка.
        {
            if (AvailablePartsLstBx.SelectedItem != null)
            {
                Manager.Parts.RemoveAt(SelectedPartsLstBx.SelectedIndex);
                SelectedPartsLstBx.Items.Remove(SelectedPartsLstBx.SelectedItem);
            }
        }

        private void AvailablePartsLstBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Part> lst = new();
            lst = Manager.TmpLst;
            int indx = AvailablePartsLstBx.SelectedIndex;
            if (indx < 0) indx = 0;
            Part tmpPart = lst[indx];
            ObjectiveTxtBlck.Text = " Тип ПК: " + tmpPart.PCType.ToString() + "; сокет: " + tmpPart.Socket.ToString() + "; тип памяти: " + tmpPart.RamType.ToString() + "; объём памяти: " + tmpPart.RamCapasity.ToString() + "; версия PCI-E: " + tmpPart.VCInterface.ToString() + "; Интерфейс накопителя: " + tmpPart.DiscInterface.ToString();


        }      //  Показывает описание элемента выделенного в левом окне.

        private void SelectedPartsLstBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            List<Part> lst = new();
            lst = Manager.Parts;
            int indx = SelectedPartsLstBx.SelectedIndex;
            if (indx < 0) indx = 0;
            Part tmpPart = lst[indx];
            ObjectiveTxtBlck.Text = " Тип ПК: " + tmpPart.PCType.ToString() + "; сокет: " + tmpPart.Socket.ToString() + "; тип памяти: " + tmpPart.RamType.ToString() + "; объём памяти: " + tmpPart.RamCapasity.ToString() + "; версия PCI-E: " + tmpPart.VCInterface.ToString() + "; Интерфейс накопителя: " + tmpPart.DiscInterface.ToString();


        }       //  Показывает описание элемента выделенного в левом окне.

        private void ControlBtn_Click(object sender, RoutedEventArgs e)
        {
            ControlNumberOfParts(Manager.Parts);
            
           

        }
        private void ControlMasineWeight()
        {
            int mashineWeight = 0;                                                                            // Производительность машины.
            int purposeWeight = 0;                                                                            // Желаемая производительность.

            foreach (Part item in Manager.Parts)     // Распределение деталей из списка по объектам.
            {
                switch (item.GetType().Name)
                {
                    case "MotherBoard":
                        motherboard = item;
                        PartNullExep(motherboard);                                                            // проверка на налл
                        break;

                    case "CPU":
                        cpu = item;
                        PartNullExep(cpu);                                                                    // проверка на налл
                        break;

                    case "VideoCard":
                        vc = item;
                        PartNullExep(vc);                                                                     // проверка на налл
                        break;

                    case "DiscDrive":
                        discdrive = item;
                        PartNullExep(discdrive);                                                              // проверка на налл
                        break;

                    case "RAM":
                        ram = item;
                        PartNullExep(ram);
                        break;

                }
            }


            switch (motherboard.PCType)                //     Вес собранной машины
            {
                case "Low":
                    mashineWeight = 0;
                    break;

                case "Middle":
                    mashineWeight = 1;
                    break;

                case "Gaming":
                    mashineWeight = 2;
                    break;
                case "All":
                    mashineWeight = 3;
                    break;

            }

            switch (Manager.purpose_of_the_machine)     //    Вес желаемой машины
            {
                case "Low":
                    purposeWeight = 0;
                    break;

                case "Middle":
                    purposeWeight = 1;
                    break;

                case "Gaming":
                    purposeWeight = 2;
                    break;
                case "All":
                    purposeWeight = 3;
                    break;

            }

            if (purposeWeight > mashineWeight)
            {
                Manager.erorr_purpose = true;                                                        //  Выявлена ошибка выбора материнской платы в контексте производительности
                TotalResult = TotalResult + " Выявлена ошибка выбора материнской платы в контексте производительности; ";
            }
            if (cpu.PCType != Manager.purpose_of_the_machine)
            {
                Manager.erorr_cpu_purpose = true;                                                    //  Выявлена ошибка выбора процессора в контексте производительности
                TotalResult = TotalResult + " Выявлена ошибка выбора процессора в контексте производительности; ";

            }

            if (cpu.Socket != motherboard.Socket)
            {
                Manager.erorr_cpu_moterboard = true;                                                 //  Выявлена ошибка выбора процессора в контексте совместимости
                TotalResult = TotalResult + " Выявлена ошибка выбора процессора в контексте совместимости; ";

            }

            if (vc.PCType != motherboard.PCType)
            {
                Manager.erorr_videocard_purpose = true;                                              //  Выявлена ошибка выбора видеокарты в контексте производительности
                TotalResult = TotalResult + "  Выявлена ошибка выбора видеокарты в контексте производительности; ";

            }

            if (discdrive.PCType != motherboard.PCType)
            {
                Manager.erorr_discdrive_purpose = true;     //  Выявлена ошибка выбора накопителя в контексте производительности
                TotalResult = TotalResult + "   Выявлена ошибка выбора накопителя в контексте производительности; ";

            }

            if (ram.RamType != motherboard.RamType)
            {
                Manager.erorr_ram_moterboard = true;                                                        //  Выявлена ошибка памяти в контексте совместимости
                TotalResult = TotalResult + "  Выявлена ошибка памяти в контексте совместимости; ";

            }

            TotalResult = TotalResult + " Если честно резутат так себе... ";
            TotalWindow totalWindow = new(TotalResult);
            totalWindow.Owner = this;
            totalWindow.ShowDialog();
            this.Close();
        }

        private void ControlNumberOfParts(List<Part> parts)
        {


            if (parts.Count > 5 | parts.Count < 4)      // Допустим в одну машину можно установить только один элемент каждого типа. Если элементов больше пяти  тогда ошибка
            {
                MessageBox.Show("Кажется что-то не так! Может деталей не хватает? Оперативы... или проца.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                ControlMasineWeight(); 
            }

        }
        private void PartNullExep(Part part)                                                               // проверка на налл
        {
            if (part is null) MessageBox.Show("Кажется что-то не так! Может деталей не хватает? Оперативы... или проца.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);

        }
    }
}