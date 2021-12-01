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
    class Workout : INotifyPropertyChanged
    {
        private int customerCardId;
        private DateTime? dateOfWorkout;
        private int? typeOfTrainingId;
        private int coachId;
        private int roomId;

        [Key]
        public int Id { get; set; }
        public int CustomerCardId
        {
            get { return customerCardId; }
            set
            {
                customerCardId = value;
                OnPropertyChanged("CustomerCardId");
            }
        }
        public CustomerCard CustomerCard { get; set; }
        public DateTime? DateOfWorkout
        {
            get { return dateOfWorkout; }
            set
            {
                dateOfWorkout = value;
                OnPropertyChanged("DateOfWorkout");
            }
        }

        public TypeOfTraining TypeOfTraining { get; set; }
        public int? TypeOfTrainingId
        {
            get { return typeOfTrainingId; }
            set
            {
                typeOfTrainingId = value;
                OnPropertyChanged("TypeOfTrainingId");
            }
        }
        public int CoachId
        {
            get { return coachId; }
            set
            {
                coachId = value;
                OnPropertyChanged("CoachId");
            }
        }
        public Coach Coach { get; set; }
        public int RoomId
        {
            get { return roomId; }
            set
            {
                roomId = value;
                OnPropertyChanged("RoomId");
            }
        }
        public Room Room { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
