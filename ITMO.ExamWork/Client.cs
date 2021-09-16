using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalWork.Models
{
    class Client
    {
        [Key]
        [Required]
        private int Id { get; set; }
        [Required]
        [MaxLength(50)]
        private string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        private string LastName { get; set; }
        [MaxLength(50)]
        private string Patronymic { get; set; }
        [Required]
        [MaxLength(25)]
        private string Telefon { get; set; }
        [MaxLength(80)]
        private string Address { get; set; }
        private int Age { get; set; }
        private List<Coach> Coachs { get; set; }
        private CustomerCard CustomerCard { get; set; }
    }
}
