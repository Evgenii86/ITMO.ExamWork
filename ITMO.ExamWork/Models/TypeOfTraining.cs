using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ITMO.ExamWork.Models
{
    class TypeOfTraining : INotifyPropertyChanged
    {
        private string denomination;

        public int Id { get; set; }
        public string Denomination
        {
            get { return denomination; }
            set
            {
                denomination = value;
                OnPropertyChanged("Denomination");
            }
        }
        public List<Coach> Coachs { get; set; } = new List<Coach>();
        public List<Workout> Workouts { get; set; } = new List<Workout>();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
