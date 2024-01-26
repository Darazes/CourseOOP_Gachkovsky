using CourseOOP_Gachkovsky.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOOP_Gachkovsky.ViewModels
{
    [Serializable]
    public class TourViewModel
    {
        public ObservableCollection<Tour> ListTours { get; set; } = new ObservableCollection<Tour>();
        public TourViewModel(){}
        public int MaxId()
        {
            int max_id = 0;
            foreach (Tour tours in ListTours)
            {
                if (tours.Id > max_id) max_id = tours.Id;
            }
            return max_id;
        }

        public Tour FindTourId(int id)
        {
            foreach (Tour tour in ListTours)
            {
                if (id == tour.Id) return tour;
            }
            return null;
        }

        public Tour FindTourName(string Name)
        {
            foreach (Tour tour in ListTours)
            {
                if (Name == tour.NameTour) return tour;
            }
            return null;
        }
    }
}
