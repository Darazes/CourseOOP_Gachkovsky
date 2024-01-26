using CourseOOP_Gachkovsky.Helpers;
using CourseOOP_Gachkovsky.Models;
using CourseOOP_Gachkovsky.ViewModels;
using CourseOOP_Gachkovsky.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseOOP_Gachkovsky
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Serialize serialize = new Serialize();
        TourViewModel vmTour = new TourViewModel();
        RezerveTourViewModel vmRezerveTour = new RezerveTourViewModel();
        

        public MainWindow()
        {
            InitializeComponent();
            ClearTourInput();
            if (File.Exists(Directory.GetCurrentDirectory() + "\\Tours.xml")) GetDeserializeObjects();
            RefreshListTours();

            RezerveTourDPOViewModel vmRezerveTourDPO = new RezerveTourDPOViewModel(vmTour, vmRezerveTour);

            ListRezeveTours.ItemsSource = vmRezerveTourDPO.ListRezerveToursDPO;
        }

        public void ClearTourInput()
        {
            tb_IdTour.Text = string.Empty;
            tb_NameTour.Text = string.Empty;
            tb_Destination.Text = string.Empty;
            tb_PriceTour.Text = string.Empty;
            tb_CountDays.Text = string.Empty;
            tb_CountTickets.Text = string.Empty;
        }

        private void ListToursAdd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListToursAdd.SelectedItems.Count == 1)
            {
                Tour tour = (Tour)ListToursAdd.SelectedItems[0];

                if (tour != null)
                {
                    tb_IdTour.Text = tour.Id.ToString();
                    tb_NameTour.Text = tour.NameTour;
                    tb_Destination.Text = tour.Destination;
                    tb_PriceTour.Text = tour.PriceTour.ToString();
                    tb_CountDays.Text = tour.CountDays.ToString();
                    tb_CountTickets.Text = tour.CountTickets.ToString();
                }
            }
            else if (ListToursAdd.SelectedItems.Count == 0)
            {
                ClearTourInput();
            }
        }

        private void Tours_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RefreshListTours();
        }

        private void RefreshListTours()
        {
            ListTours.ItemsSource = null;
            ListTours.ItemsSource = vmTour.ListTours;
            ListToursAdd.ItemsSource = null;
            ListToursAdd.ItemsSource = vmTour.ListTours;
            ListRezeveTours.ItemsSource = null;
            RezerveTourDPOViewModel vmRezerveTourDPO = new RezerveTourDPOViewModel(vmTour, vmRezerveTour);
            ListRezeveTours.ItemsSource = vmRezerveTourDPO.ListRezerveToursDPO;
        }

        private Tour TourParametrs()
        {
            Tour tour = new Tour
            {
                Id = vmTour.MaxId() + 1,
                NameTour = tb_NameTour.Text,
                Destination = tb_Destination.Text,
                PriceTour = float.Parse(tb_PriceTour.Text),
                CountDays = int.Parse(tb_CountDays.Text),
                CountTickets = int.Parse(tb_CountTickets.Text),
                IsActual = true
                // Путь к изображению
            };
            return tour;
        }

        private void GetDeserializeObjects()
        {
            TourViewModel NewVMTours = serialize.DeserializeTourXML();
            vmTour.ListTours.Clear();
            foreach (Tour tour in NewVMTours.ListTours)
            {
                vmTour.ListTours.Add(tour);
            }

            if (vmTour.ListTours.Count > 0 && new FileInfo(Directory.GetCurrentDirectory() + "\\RezerveTours.xml").Length != 0)
            {
                RezerveTourViewModel NewVMRezerveTours = serialize.DeserializeRezerveTourXML();
                vmRezerveTour.ListRezerveTours.Clear();
                foreach (RezerveTour rezerveTour in NewVMRezerveTours.ListRezerveTours)
                {
                    vmRezerveTour.ListRezerveTours.Add(rezerveTour);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tb_NameTour.Text == "" || tb_Destination.Text == "" || tb_PriceTour.Text == "" || tb_CountDays.Text == "" || tb_CountTickets.Text == "")
            {
                MessageBox.Show("Заполните все поля ", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!IsNum(tb_PriceTour.Text.ToString()) || !IsNum(tb_CountDays.Text.ToString()) || !IsNum(tb_CountTickets.Text.ToString())
                || (tb_PriceTour.Text.Length > 7) || (tb_CountDays.Text.Length > 7) || (tb_CountTickets.Text.Length > 7))
            {
                MessageBox.Show("Числовые поля заполнены неверно(Цена, количество дней, Количество билетов)", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Добавить проверку полей
            Tour tour = TourParametrs();
            vmTour.ListTours.Add(tour);
            RefreshListTours();
            ClearTourInput();
            serialize.SerializeTourXML(vmTour);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Tour tour;
            var result = MessageBox.Show("Изменить выбранный элемент?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (ListToursAdd.SelectedItems.Count == 1 && result == MessageBoxResult.Yes)
            {

                if (tb_NameTour.Text == "" || tb_Destination.Text == "" || tb_PriceTour.Text == "" || tb_CountDays.Text == "" || tb_CountTickets.Text == "")
                {
                    MessageBox.Show("Заполните все поля ", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (!IsNum(tb_PriceTour.Text.ToString()) || !IsNum(tb_CountDays.Text.ToString()) || !IsNum(tb_CountTickets.Text.ToString())
                    || (tb_PriceTour.Text.Length > 7) || (tb_CountDays.Text.Length > 7) || (tb_CountTickets.Text.Length > 7))
                {
                    MessageBox.Show("Числовые поля заполнены неверно(Цена, количество дней, Количество билетов)", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                tour = TourParametrs();
                int currentId = int.Parse(tb_IdTour.Text);
                foreach (Tour t in vmTour.ListTours)
                {
                    if (t.Id == currentId)
                    {
                        t.NameTour = tour.NameTour;
                        t.Destination = tour.Destination;
                        t.PriceTour = tour.PriceTour;
                        t.CountDays = tour.CountDays;
                        t.CountTickets = tour.CountTickets;
                        if (tour.CountTickets >= 0) t.IsActual = true;
                        else t.IsActual = false;
                    }
                }

                RefreshListTours();
                serialize.SerializeTourXML(vmTour);
            }
            else MessageBox.Show("Выберите изменяемый элемент", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Удалить выбранный элемент?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (ListToursAdd.SelectedItems.Count == 1 && result == MessageBoxResult.Yes)
            {
                int currentId = int.Parse(tb_IdTour.Text);
                foreach (Tour t in vmTour.ListTours.ToArray())
                {
                    if (t.Id == currentId)
                    {
                        vmTour.ListTours.Remove(t);
                    }
                }
                RefreshListTours();
                serialize.SerializeTourXML(vmTour);
            }
            else MessageBox.Show("Выберите удаляемый элемент", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ListTours_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Tour currentTour = new Tour();
            if (ListTours.SelectedItems.Count == 1) 
            {
                currentTour = (Tour)ListTours.SelectedItem;
            }
            NewRezerveTourWindow newRezerveTourWindow = new NewRezerveTourWindow(currentTour,vmTour,vmRezerveTour);
            newRezerveTourWindow.Closed += (s, args) => RefreshListTours();
            newRezerveTourWindow.Show();
        }

        private void ListRezeveTours_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RezerveTourDPO currentRezerveTour = new RezerveTourDPO();
            if (ListRezeveTours.SelectedItems.Count == 1)
            {
                currentRezerveTour = (RezerveTourDPO)ListRezeveTours.SelectedItem;
            }
            RezerveTourInfo rezerveTourInfo = new RezerveTourInfo(currentRezerveTour);
            rezerveTourInfo.Show();

        }

         static bool IsNum(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c)) return false;
            }
            return true;
        }
    }
}
