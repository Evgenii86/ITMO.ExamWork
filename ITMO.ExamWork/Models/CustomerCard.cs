using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ITMO.ExamWork.Models
{
    class CustomerCard : INotifyPropertyChanged
    {
        private int clientId;
        private int subscriptionId;

        [Key]
        public int Id { get; set; }
        public int ClientId
        {
            get { return clientId; }
            set
            {
                clientId = value;
                OnPropertyChanged("ClientId");
            }
        }
        public Client Client { get; set; }
        public Subscription Subscription { get; set; }
        public int SubscriptionId
        {
            get { return subscriptionId; }
            set
            {
                subscriptionId = value;
                OnPropertyChanged("SubscriptionId");
            }
        }
        public List<Workout> Workouts { get; set; } = new List<Workout>();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
