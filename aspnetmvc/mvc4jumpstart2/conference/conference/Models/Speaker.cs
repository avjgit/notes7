using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace conference.Models
{
    public class Speaker
    {
        public int SpeakerId { get; set; }
        
        // display name can be used in error message
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Speaker name")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddres { get; set; }

        public virtual List<Session> Sessions { get; set; } 
    }
}