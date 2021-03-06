﻿using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventApplication.Models
{
    public class User
    {
        public User()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual List<TicketOrder> TicketOrders { get; set; }
    }
}