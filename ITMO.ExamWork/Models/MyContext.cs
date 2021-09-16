using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ITMO.ExamWork.Models
{
    class MyContext : DbContext
    {
        public MyContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<TypeOfTraining> TypeOfTrainings { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<CustomerCard> CustomerCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FitnessDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeOfTraining>().HasData(
                new TypeOfTraining[]
                {
                new TypeOfTraining { Id = 1, Denomination="Плавание"},
                new TypeOfTraining { Id = 2, Denomination="Силовой тренинг"},
                new TypeOfTraining { Id = 3, Denomination="Пилатес"},
                new TypeOfTraining { Id = 4, Denomination="Аэробика"},
                new TypeOfTraining { Id = 5, Denomination="Оздоровление"}
                });
            modelBuilder.Entity<Room>().HasData(
                new Room[]
                {
                new Room { Id = 1, Name = "Бассейн"}, 
                new Room { Id = 2, Name = "Зал 1" }, 
                new Room { Id = 3, Name = "Зал 2" }, 
                new Room { Id = 4, Name = "Зал 3" },
                new Room { Id = 5, Name = "Зал аэробики" }
                });
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription[]
                {
                new Subscription { Id = 1, Name = "Годовой", Price = 20000, DaysOfAction = 365},
                new Subscription { Id = 2, Name = "6 месяцев", Price = 12950, DaysOfAction = 183},
                new Subscription { Id = 3, Name = "Квартал", Price = 4800, DaysOfAction = 92},
                new Subscription { Id = 4, Name = "Месячный", Price = 2230, DaysOfAction = 30}
                });
            modelBuilder.Entity<Coach>().HasData(
                new Coach[]
                {
                new Coach { Id = 1, FirstName = "Василий", LastName = "Федотов", Patronymic = "Викторович", Salary = 55000, DateofBirth = new DateTime(1977, 4, 4), TypeOfTrainingID = 4},
                new Coach { Id = 2, FirstName = "Игорь", LastName = "Власов", Patronymic = "Алексеевич", Salary = 59500, DateofBirth = new DateTime(1982, 10, 23), TypeOfTrainingID = 3},
                new Coach { Id = 3, FirstName = "Леонид", LastName = "Дроздов", Patronymic = "Вадимович", Salary = 63690, DateofBirth = new DateTime(1985, 1, 5), TypeOfTrainingID = 1},
                new Coach { Id = 4, FirstName = "Олег", LastName = "Крылов", Patronymic = "Назарович", Salary = 60000, DateofBirth = new DateTime(1974, 11, 14), TypeOfTrainingID = 2}
                });
            modelBuilder.Entity<Client>().HasData(
                new Client[]
                {
                new Client { Id = 1, FirstName = "Никита", LastName = "Вышинский", Patronymic = "Борисович", Telefon = "444-55-77", Address = "ул. Кораблестроителей, 34, 112", Age = 30},
                new Client { Id = 2, FirstName = "Владислав", LastName = "Орлов", Patronymic = "Александрович", Telefon = "999-555-77-88", Address = "ул. Доблести, 3, 84", Age = 25},
                new Client { Id = 3, FirstName = "Олег", LastName = "Ольгин", Patronymic = "Олегович", Telefon = "111-22-77", Address = "пр-кт Испытателей, 17, 94", Age = 38},
                new Client { Id = 4, FirstName = "Иннокентий", LastName = "Синицин", Patronymic = "Николаевич", Telefon = "996-111-44-99", Address = "ул. Софийская, 105, 136", Age = 23}
                });
        }
    }
}
