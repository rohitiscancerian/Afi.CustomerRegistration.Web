﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Afi.CustomerRegistration.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PolicyReferenceNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
