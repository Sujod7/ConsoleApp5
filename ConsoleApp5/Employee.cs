using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Employee
    {
        public Employee()
        {
            Daily_task daily_Task = new Daily_task();
            Email = "default@example.com"; // قيمة افتراضية
        }

        public int Id { get; set; }
        public string Fname { get; set; }

        public string Lname { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        public List<Daily_task> tasks { get; set; }

        public Address Aaddress { get; set; }

    }
}

