using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace conference.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }
        public int SpeakerId { get; set; }
        public virtual Speaker Speaker { get; set; }
    }
}