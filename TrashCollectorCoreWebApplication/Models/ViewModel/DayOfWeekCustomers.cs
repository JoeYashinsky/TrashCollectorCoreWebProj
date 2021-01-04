using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorCoreWebApplication.Models.ViewModel
{
    public class DayOfWeekCustomers
    {

        public List<Customer> Customers { get; set; }

        public SelectList Weekdays { get; set; }


        public string SelectedPickupDay { get; set; }

    }
}
