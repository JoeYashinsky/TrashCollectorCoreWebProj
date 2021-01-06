using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorCoreWebApplication.Models
{
    public class Day
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Regular Pickup Day")]
        public string Name { get; set; }
    }
}
