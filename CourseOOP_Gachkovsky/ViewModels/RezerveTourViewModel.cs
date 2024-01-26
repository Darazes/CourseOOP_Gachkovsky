using CourseOOP_Gachkovsky.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOOP_Gachkovsky.ViewModels
{
    public class RezerveTourViewModel
    {
        public ObservableCollection<RezerveTour> ListRezerveTours { get; set; } = new ObservableCollection<RezerveTour>();

        public RezerveTourViewModel() { }

        public int MaxId()
        {
            int max_id = 0;
            foreach (RezerveTour RezerveTours in ListRezerveTours)
            {
                if (RezerveTours.Id > max_id) max_id = RezerveTours.Id;
            }
            return max_id;
        }
    }
}
