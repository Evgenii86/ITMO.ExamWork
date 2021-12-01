using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ITMO.ExamWork.Models;
using Microsoft.EntityFrameworkCore;

namespace ITMO.ExamWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new MyContext();
            db.Coachs.Load();
            coachsListView.ItemsSource = db.Coachs.Local.ToBindingList();
            db.Clients.Load();
            clientsListView.ItemsSource = db.Clients.Local.ToBindingList();
            db.Workouts.Load();
            workoutsListView.ItemsSource = db.Workouts.Local.ToBindingList();
            db.Subscriptions.Load();
            subscriptionsListView.ItemsSource = db.Subscriptions.Local.ToBindingList();
            db.CustomerCards.Load();
            customerCardsListView.ItemsSource = db.CustomerCards.Local.ToBindingList();
            db.Rooms.Load();
            roomsListView.ItemsSource = db.Rooms.Local.ToBindingList();
            db.TypeOfTrainings.Load();
            typeOfTrainingsListView.ItemsSource = db.TypeOfTrainings.Local.ToBindingList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void CoachCreateButton_Click(object sender, RoutedEventArgs e)
        {
            Coach c = new Coach();
            try
            {
                c.FirstName = FirstNameBox.Text;
                c.LastName = LastNameBox.Text;
                c.Patronymic = PatronymicBox.Text;
                c.Salary = Convert.ToDecimal(SalaryBox.Text);
                c.DateofBirth = CoachDatePicker.SelectedDate;
                c.TypeOfTrainingID = Convert.ToInt32(TypeOfTrainingBox.Text);
                db.Coachs.Add(c);
                db.SaveChanges();
            }
            catch(DbUpdateException)
            {
                db.Coachs.Remove(c);
                MessageBox.Show("Введен несуществующий ID типа тренировки");
            }
            catch(FormatException)
            {
                MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
            }
            
        }
        private void ClientCreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client cl = new Client
                {
                    FirstName = ClientFirstNameBox.Text,
                    LastName = ClientLastNameBox.Text,
                    Patronymic = ClientPatronymicBox.Text,
                    Telefon = ClientTelefonBox.Text,
                    Address = ClientAddressBox.Text,
                    Age = Convert.ToInt32(ClientAgeBox.Text)
                };
                db.Clients.Add(cl);
                db.SaveChanges();
            }
            catch (FormatException)
            {
                MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
            }

        }
        private void WorkoutCreateButton_Click(object sender, RoutedEventArgs e)
        {
            Workout w = new Workout();
            try
            {
                int WorkoutHour = Convert.ToInt32(WorkoutHourBox.Text);
                int WorkoutMinute = Convert.ToInt32(WorkoutMinuteBox.Text);
                w.CustomerCardId = Convert.ToInt32(WorkoutClientCardBox.Text);
                w.TypeOfTrainingId = Convert.ToInt32(WorkoutTypeBox.Text);
                w.CoachId = Convert.ToInt32(WorkoutCoachIDBox.Text);
                w.RoomId = Convert.ToInt32(WorkoutRoomIDBox.Text);
                w.DateOfWorkout = new DateTime(WorkoutDatePicker.SelectedDate.Value.Year, WorkoutDatePicker.SelectedDate.Value.Month, WorkoutDatePicker.SelectedDate.Value.Day, WorkoutHour, WorkoutMinute, 0);
                db.Workouts.Add(w);
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                db.Workouts.Remove(w);
                MessageBox.Show("Введены несуществующие в базе данных атрибуты в одном или нескольких полях: " +
                    "номер карты клиента, ID типа тренировки, ID тренера, номер зала");
            }
            catch (FormatException)
            {
                MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Формат введенной даты не корректен. Проверьте данные и исправьте");
            }

        }
        private void SubscriptionCreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Subscription subscr = new Subscription
                {
                    Name = SubscriptionNameBox.Text,
                    Price = Convert.ToDecimal(SubscriptionPriceBox.Text),
                    DaysOfAction = Convert.ToInt32(SubscriptionDaysBox.Text)
                };
                db.Subscriptions.Add(subscr);
                db.SaveChanges();
            }
            catch (FormatException)
            {
                MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
            }

        }
        private void CustomerCardCreateButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerCard cCard = new CustomerCard();
            try
            {
                cCard.ClientId = Convert.ToInt32(CustomerCardClientIDBox.Text);
                cCard.SubscriptionId = Convert.ToInt32(CustomerCardSubscriptionIDBox.Text);
                db.CustomerCards.Add(cCard);
                db.SaveChanges();
            }
            catch(DbUpdateException)
            {
                db.CustomerCards.Remove(cCard);
                MessageBox.Show("Введены несуществующие в базе данных атрибуты в одном или нескольких полях: " +
                    "ID клиента, ID абонемента");
            }
            catch (FormatException)
            {
                MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
            }
            
        }
        private void RoomCreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Room r = new Room
                {
                    Name = RoomNameBox.Text
                };
                db.Rooms.Add(r);
                db.SaveChanges();
            }
            
            catch (FormatException)
            {
                MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
            }

        }
        private void TypeOfTrainingCreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TypeOfTraining t = new TypeOfTraining
                {
                    Denomination = TypeOfTrainingDenominationBox.Text
                };
                db.TypeOfTrainings.Add(t);
                db.SaveChanges();
            }
            
            catch (FormatException)
            {
                MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
            }

        }



        private void CoachUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if(coachsListView.SelectedItem != null)
            {
                Coach coach = coachsListView.SelectedItem as Coach;
                try
                {
                    
                    coach.FirstName = FirstNameBox.Text;
                    coach.LastName = LastNameBox.Text;
                    coach.Patronymic = PatronymicBox.Text;
                    coach.Salary = Convert.ToDecimal(SalaryBox.Text);
                    coach.DateofBirth = CoachDatePicker.SelectedDate;
                    coach.TypeOfTrainingID = Convert.ToInt32(TypeOfTrainingBox.Text);
                    db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show("Введен несуществующий ID типа тренировки");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
                }
            }
            
        }
        private void ClientUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (clientsListView.SelectedItem != null)
            {
                try
                {
                    Client client = clientsListView.SelectedItem as Client;
                    client.FirstName = ClientFirstNameBox.Text;
                    client.LastName = ClientLastNameBox.Text;
                    client.Patronymic = ClientPatronymicBox.Text;
                    client.Telefon = ClientTelefonBox.Text;
                    client.Address = ClientAddressBox.Text;
                    client.Age = Convert.ToInt32(ClientAgeBox.Text);
                    db.SaveChanges();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
                }
            }
            
        }
        private void WorkoutUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (workoutsListView.SelectedItem != null)
            {
                try
                {
                    int WorkoutHour = Convert.ToInt32(WorkoutHourBox.Text);
                    int WorkoutMinute = Convert.ToInt32(WorkoutMinuteBox.Text);
                    Workout workout = workoutsListView.SelectedItem as Workout;
                    workout.CustomerCardId = Convert.ToInt32(WorkoutClientCardBox.Text);
                    workout.TypeOfTrainingId = Convert.ToInt32(WorkoutTypeBox.Text);
                    workout.CoachId = Convert.ToInt32(WorkoutCoachIDBox.Text);
                    workout.RoomId = Convert.ToInt32(WorkoutRoomIDBox.Text);
                    workout.DateOfWorkout = new DateTime(WorkoutDatePicker.SelectedDate.Value.Year, WorkoutDatePicker.SelectedDate.Value.Month, WorkoutDatePicker.SelectedDate.Value.Day, WorkoutHour, WorkoutMinute, 0);
                    db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show("Введены несуществующие в базе данных атрибуты в одном или нескольких полях: " +
                        "номер карты клиента, ID типа тренировки, ID тренера, номер зала");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Формат введенной даты не корректен. Проверьте данные и исправьте");
                }
            }
            
        }
        private void SubscriptionUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (subscriptionsListView.SelectedItem != null)
            {
                try
                {
                    Subscription subscription = subscriptionsListView.SelectedItem as Subscription;
                    subscription.Name = SubscriptionNameBox.Text;
                    subscription.Price = Convert.ToDecimal(SubscriptionPriceBox.Text);
                    subscription.DaysOfAction = Convert.ToInt32(SubscriptionDaysBox.Text);
                    db.SaveChanges();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
                }
            }

        }
        private void CustomerCardUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (customerCardsListView.SelectedItem != null)
            {
                try
                {
                    CustomerCard customerCard = customerCardsListView.SelectedItem as CustomerCard;
                    customerCard.ClientId = Convert.ToInt32(CustomerCardClientIDBox.Text);
                    customerCard.SubscriptionId = Convert.ToInt32(CustomerCardSubscriptionIDBox.Text);
                    db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show("Введены несуществующие в базе данных атрибуты в одном или нескольких полях: " +
                        "ID клиента, ID абонемента");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
                }
            }

        }
        private void RoomUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (roomsListView.SelectedItem != null)
            {
                try
                {
                    Room room = roomsListView.SelectedItem as Room;
                    room.Name = RoomNameBox.Text;
                    db.SaveChanges();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
                }
            }

        }
        private void TypeOfTrainingUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (typeOfTrainingsListView.SelectedItem != null)
            {
                try
                {
                    TypeOfTraining typeOfTraining = typeOfTrainingsListView.SelectedItem as TypeOfTraining;
                    typeOfTraining.Denomination = TypeOfTrainingDenominationBox.Text;
                    db.SaveChanges();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Формат вводимых данных не корректен. Проверьте данные и исправьте");
                }
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Coach coach = coachsListView.SelectedItem as Coach;
            if (coach != null)
            {
                db.Coachs.Remove(coach);
                FirstNameBox.Text = "";
                LastNameBox.Text = "";
                PatronymicBox.Text = "";
                SalaryBox.Text = "";
                TypeOfTrainingBox.Text = "";
                CoachDatePicker.SelectedDate = DateTime.Now;
                db.SaveChanges();
            }
            
        }
        private void ClientDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Client client = clientsListView.SelectedItem as Client;
            if (client != null)
            {
                db.Clients.Remove(client);
                ClientFirstNameBox.Text = "";
                ClientLastNameBox.Text = "";
                ClientPatronymicBox.Text = "";
                ClientTelefonBox.Text = "";
                ClientAddressBox.Text = "";
                ClientAgeBox.Text = "";
                db.SaveChanges();
            }
            
        }
        private void WorkoutDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Workout workout = workoutsListView.SelectedItem as Workout;
            if (workout != null)
            {
                db.Workouts.Remove(workout);
                WorkoutClientCardBox.Text = "";
                WorkoutTypeBox.Text = "";
                WorkoutCoachIDBox.Text = "";
                WorkoutRoomIDBox.Text = "";
                WorkoutDatePicker.SelectedDate = DateTime.Now;
                WorkoutHourBox.Text = "";
                WorkoutMinuteBox.Text = "";
                db.SaveChanges();
            }
            
        }
        private void SubscriptionDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Subscription subscription = subscriptionsListView.SelectedItem as Subscription;
            if (subscription != null)
            {
                db.Subscriptions.Remove(subscription);
                SubscriptionNameBox.Text = "";
                SubscriptionPriceBox.Text = "";
                SubscriptionDaysBox.Text = "";
                db.SaveChanges();
            }

        }
        private void CustomerCardDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerCard customerCard = customerCardsListView.SelectedItem as CustomerCard;
            if (customerCard != null)
            {
                db.CustomerCards.Remove(customerCard);
                CustomerCardClientIDBox.Text = "";
                CustomerCardSubscriptionIDBox.Text = "";
                db.SaveChanges();
            }

        }
        private void RoomDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Room room = roomsListView.SelectedItem as Room;
            if (room != null)
            {
                db.Rooms.Remove(room);
                RoomNameBox.Text = "";
                db.SaveChanges();
            }

        }
        private void TypeOfTrainingDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TypeOfTraining typeOfTraining = typeOfTrainingsListView.SelectedItem as TypeOfTraining;
            if (typeOfTraining != null)
            {
                db.TypeOfTrainings.Remove(typeOfTraining);
                TypeOfTrainingDenominationBox.Text = "";
                db.SaveChanges();
            }

        }

        private void coachListView_selected(object sender, SelectionChangedEventArgs e)
        {
            Coach coach2 = coachsListView.SelectedItem as Coach;
            if (coach2 != null)
            {
                FirstNameBox.Text = coach2.FirstName;
                LastNameBox.Text = coach2.LastName;
                PatronymicBox.Text = coach2.Patronymic;
                SalaryBox.Text = coach2.Salary.ToString();
                CoachDatePicker.SelectedDate = coach2.DateofBirth;
                TypeOfTrainingBox.Text = coach2.TypeOfTrainingID.ToString();
            }
        }
        private void clientListView_selected(object sender, SelectionChangedEventArgs e)
        {
            Client client2 = clientsListView.SelectedItem as Client;
            if (client2 != null)
            {
                ClientFirstNameBox.Text = client2.FirstName;
                ClientLastNameBox.Text = client2.LastName;
                ClientPatronymicBox.Text = client2.Patronymic;
                ClientTelefonBox.Text = client2.Telefon;
                ClientAddressBox.Text = client2.Address;
                ClientAgeBox.Text = client2.Age.ToString();
            }
        }
        private void workoutListView_selected(object sender, SelectionChangedEventArgs e)
        {
            Workout workout2 = workoutsListView.SelectedItem as Workout;
            if (workout2 != null)
            {
                WorkoutClientCardBox.Text = workout2.CustomerCardId.ToString();
                WorkoutTypeBox.Text = workout2.TypeOfTrainingId.ToString();
                WorkoutCoachIDBox.Text = workout2.CoachId.ToString();
                WorkoutRoomIDBox.Text = workout2.RoomId.ToString();
                WorkoutDatePicker.SelectedDate = workout2.DateOfWorkout;
                WorkoutHourBox.Text = workout2.DateOfWorkout.Value.Hour.ToString();
                WorkoutMinuteBox.Text = workout2.DateOfWorkout.Value.Minute.ToString();

            }
        }
        private void subscriptionListView_selected(object sender, SelectionChangedEventArgs e)
        {
            Subscription subscription2 = subscriptionsListView.SelectedItem as Subscription;
            if (subscription2 != null)
            {
                SubscriptionNameBox.Text = subscription2.Name;
                SubscriptionPriceBox.Text = subscription2.Price.ToString();
                SubscriptionDaysBox.Text = subscription2.DaysOfAction.ToString();
            }
        }
        private void customerCardListView_selected(object sender, SelectionChangedEventArgs e)
        {
            CustomerCard customerCard2 = customerCardsListView.SelectedItem as CustomerCard;
            if (customerCard2 != null)
            {
                CustomerCardClientIDBox.Text = customerCard2.ClientId.ToString();
                CustomerCardSubscriptionIDBox.Text = customerCard2.SubscriptionId.ToString();
            }
        }
        private void roomListView_selected(object sender, SelectionChangedEventArgs e)
        {
            Room room2 = roomsListView.SelectedItem as Room;
            if (room2 != null)
            {
                RoomNameBox.Text = room2.Name;
            }
        }
        private void typeOfTrainingListView_selected(object sender, SelectionChangedEventArgs e)
        {
            TypeOfTraining typeOfTraining2 = typeOfTrainingsListView.SelectedItem as TypeOfTraining;
            if (typeOfTraining2 != null)
            {
                TypeOfTrainingDenominationBox.Text = typeOfTraining2.Denomination;
            }
        }


    }
}
