using CourseOOP_Gachkovsky.Helpers;
using CourseOOP_Gachkovsky.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOOP_Gachkovsky.Models
{
    [Serializable]
    public class Tour
    {
        public int Id { get; set; }
        public string NameTour { get; set; }
        public string Destination { get; set; }
        public float PriceTour { get; set; }
        public int CountDays { get; set; }
        public int CountTickets { get; set; }
        public string ImgUrl { get; set; }
        public bool IsActual { get; set; }

        public Tour() { }

        public string ActualText
        {
            get 
            {
                return (IsActual) ? "Актуален" : "Завершен";
            }
        }

        public void RezervePeople(int CountPeople, TourViewModel tours)
        {
            Serialize serialize = new Serialize();

            foreach (Tour tour in tours.ListTours)
            {
                if (tour.Id == Id && tour.CountTickets >= CountPeople) tour.CountTickets -= CountPeople;
                if (tour.Id == Id && tour.CountTickets <= 0) tour.IsActual = false;
            }
            serialize.SerializeTourXML(tours);
        }

        //public void AddTickets(int CountTickets, TourViewModel tours)
        //{
        //    this.CountTickets += CountTickets;
        //}

    }
}
