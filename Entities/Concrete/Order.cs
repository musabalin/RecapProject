﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeID { get; set; }
        public decimal Freight { get; set; }
    }
}