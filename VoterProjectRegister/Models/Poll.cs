using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VoterProjectRegister.Data;

namespace VoterProjectRegister.Models
{
    public class Poll
    {

        public int PollID { get; set; }

        public string PollTitle { get; set; }

        [StringLength(280)]
        public string PollDescription { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }
        public virtual ICollection<OneTimeCode> Codes { get; set; }


    }
}
