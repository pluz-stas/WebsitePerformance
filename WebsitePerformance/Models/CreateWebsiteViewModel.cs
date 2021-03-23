using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebsitePerformance.Mvc.Annotations;

namespace WebsitePerformance.Mvc.Models
{
    public class CreateWebsiteViewModel
    {
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Domain")]
        [HostName(ErrorMessage = "Incorrect input")]
        public string Domain { get; set; }
    }
}
