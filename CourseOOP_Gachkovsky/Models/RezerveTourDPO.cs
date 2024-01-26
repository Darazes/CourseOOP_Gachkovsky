using CourseOOP_Gachkovsky.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOOP_Gachkovsky.Models
{
    public class RezerveTourDPO
    {
        public int Id { get; set; }
        public string NameTour { get; set; }
        public string Destination { get; set; }
        public int CountDays { get; set; }
        public int CountPeople { get; set; }
        public float FinalPrice { get; set; }

        public RezerveTourDPO() { }
        public RezerveTourDPO(int Id, int TourID, int CountPeople, TourViewModel tours)
        {
            this.Id = Id;
            NameTour = getTour(TourID, tours).NameTour;
            Destination = getTour(TourID, tours).Destination;
            CountDays = getTour(TourID, tours).CountDays;
            this.CountPeople = CountPeople;
            FinalPrice = getTour(TourID, tours).PriceTour * CountPeople;
        }

        public Tour getTour(int TourID, TourViewModel vmTour)
        {
            foreach (Tour t in vmTour.ListTours)
            {
                if (t.Id == TourID)
                {
                    return t;
                }
            }
            return null;
        }
    }
}
