using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorCoreWebApplication.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [ForeignKey("Day")]
        [Display(Name = "Regular Pickup Day")]
        public int DayId { get; set; }
        public Day Day { get; set; }

        [DisplayFormat(DataFormatString = "0:dd MM yyyy")]
        [Display(Name = "Extra Pickup Date (optional)")]
        [DataType(DataType.Date)]
        public DateTime? ExtraPickupDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MM yyyy")]
        [Display(Name = "Suspend Service Date (optional)")]
        [DataType(DataType.Date)]
        public DateTime? SuspendServiceDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MM yyyy")]
        [Display(Name = "Suspension End Date (optional)")]
        [DataType(DataType.Date)]
        public DateTime? SuspensionEndDate { get; set; }

        [Display(Name = "Pickup Confirmed")]
        public bool PickupConfirmed { get; set; }

        [Display(Name = "Balance Due")]
        public double BalanceDue { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
