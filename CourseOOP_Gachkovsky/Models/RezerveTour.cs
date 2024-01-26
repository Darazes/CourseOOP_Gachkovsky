using CourseOOP_Gachkovsky.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOOP_Gachkovsky.Models
{
    [Serializable]
    public class RezerveTour
    {
        public int Id { get; set; }
        public int TourID { get; set; }
        public int CountPeople { get; set; }

        public RezerveTour() { }
        public RezerveTour(int Id, int TourID, int CountPeople, TourViewModel tours)
        {
            this.Id = Id;
            this.TourID = TourID;
            this.CountPeople = CountPeople;
            getTour(TourID, tours).RezervePeople(CountPeople, tours);
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
