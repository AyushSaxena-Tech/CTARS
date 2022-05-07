using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCApplication.Models
{
    public class ClientGoal
    {
        public int ID { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Details { get; set; }
        public DateTime DateCreated { get; set; }

        public Client Client { get; set; }

        public string FullName
        {
            get
            {
                if (!object.ReferenceEquals(null, Client))
                    return Client.FirstName.ToString() + " " + Client.LastName.ToString();
                else
                    return "";
            }
        }
    }
}