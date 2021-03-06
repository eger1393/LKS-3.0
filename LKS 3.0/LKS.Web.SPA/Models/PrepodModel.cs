﻿using LKS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Models.Enums;

namespace LKS.Web.Models
{
    public class PrepodModel
    {
        public string Id { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Coolness Coolness { get; set; }
        public string PrepodRank { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
