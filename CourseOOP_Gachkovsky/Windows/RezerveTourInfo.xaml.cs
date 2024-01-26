using CourseOOP_Gachkovsky.Models;
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
    /// Логика взаимодействия для RezerveTourInfo.xaml
    /// </summary>
    public partial class RezerveTourInfo : Window
    {
        public RezerveTourInfo(RezerveTourDPO rezerveTour)
        {
            InitializeComponent();

            tb_NameTour.Text = rezerveTour.NameTour;
            tb_Destination.Text = rezerveTour.Destination;
            tb_CountDays.Text = rezerveTour.CountDays.ToString();
            tb_CountPeople.Text = rezerveTour.CountPeople.ToString();
            tb_FinalPrice.Text = rezerveTour.FinalPrice.ToString();
        }
    }
}
