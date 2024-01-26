using CourseOOP_Gachkovsky.Models;
using CourseOOP_Gachkovsky.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOOP_Gachkovsky
{
    class RezerveTourDPOViewModel
    {
        public ObservableCollection<RezerveTourDPO> ListRezerveToursDPO { get; set; } = new ObservableCollection<RezerveTourDPO>();

        public RezerveTourDPOViewModel(TourViewModel tours, RezerveTourViewModel RezerveTours) 
        {
            foreach (RezerveTour rezerveTour in RezerveTours.ListRezerveTours)
            {
                ListRezerveToursDPO.Add(new RezerveTourDPO(rezerveTour.Id, rezerveTour.TourID, rezerveTour.CountPeople, tours));
            }
        }
    }
}
