﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseMVC.Models.Interfaces
{
   public  interface IChangeable
    {
        int Unit { get; }
        void Up();
        void Down();
    }
}
