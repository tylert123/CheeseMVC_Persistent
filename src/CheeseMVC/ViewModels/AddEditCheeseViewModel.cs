﻿using CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddEditCheeseViewModel : AddCheeseViewModel
    {
        public int CheeseId { get; set; }
        //public string CheeseName { get; set; }
        //public string CheeseDescription { get; set; }
    }
}
