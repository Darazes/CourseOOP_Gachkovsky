using CourseOOP_Gachkovsky.Helpers;
using CourseOOP_Gachkovsky.Models;
using CourseOOP_Gachkovsky.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CourseOOP_Gachkovsky.Windows
{
    /// <summary>
    /// Логика взаимодействия для NewRezerveTourWindow.xaml
    /// </summary>
    public partial class NewRezerveTourWindow : Window
    {
        Serialize serialize = new Serialize();
        TourViewModel tours = new TourViewModel();
        RezerveTourViewModel rezerveTours = new RezerveTourViewModel();
        //RezerveTourDPOViewModel rezerveToursDPO = new RezerveTourDPOViewModel();
        public Tour tour = new Tour();
        public NewRezerveTourWindow(Tour tour,TourViewModel tours, RezerveTourViewModel rezerveTours)
        {
            InitializeComponent();
            FillTour(tour);
            this.tour = tour;
            this.tours = tours;
            this.rezerveTours = rezerveTours;
        }

        public void FillTour(Tour tour)
        {
            tb_NameTour.Text = tour.NameTour;
            tb_Destination.Text = tour.Destination;
            tb_PriceTour.Text = tour.PriceTour.ToString();
            tb_CountDays.Text = tour.CountDays.ToString();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            rezerveTours.ListRezerveTours.Add(new RezerveTour(rezerveTours.MaxId(), tour.Id, int.Parse(tb_CountTickets.Text), tours));
            serialize.SerializeRezerveTourXML(rezerveTours);  
            Close();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
