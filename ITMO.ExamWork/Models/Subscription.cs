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
    class Subscription : INotifyPropertyChanged
    {
        private string name;
        private decimal price;
        private int daysOfAction;

        public int Id { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public int DaysOfAction
        {
            get { return daysOfAction; }
            set
            {
                daysOfAction = value;
                OnPropertyChanged("DaysOfAction");
            }
        }
        public List<CustomerCard> CustomerCards { get; set; } = new List<CustomerCard>();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
