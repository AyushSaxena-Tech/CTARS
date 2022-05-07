using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCApplication.Models
{
    public class Client
    {
        public int ID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<ClientGoal> ClientGoals { get; set; }

        public string FullName
        {
            get
            {
                return FirstName.ToString() + " " + LastName.ToString();
            }
        }
    }
}