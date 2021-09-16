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
    class Coach : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string patronymic;
        private decimal salary;
        private DateTime? dateofBirth;
        private int typeOfTrainingID;

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }

        }
        [Required]
        [MaxLength(50)]
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        [MaxLength(50)]
        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }
        public decimal Salary
        {
            get { return salary; }
            set
            {
                salary = value;
                OnPropertyChanged("Salary");
            }
        }
        public DateTime? DateofBirth
        {
            get { return dateofBirth; }
            set
            {
                dateofBirth = value;
                OnPropertyChanged("DateofBirth");
            }
        }
        public List<Client> Clients { get; set; } = new List<Client>();
        public TypeOfTraining TypeOfTraining { get; set; }
        public int TypeOfTrainingID
        {
            get { return typeOfTrainingID; }
            set
            {
                typeOfTrainingID = value;
                OnPropertyChanged("TypeOfTrainingID");
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
