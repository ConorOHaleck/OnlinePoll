using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VoterProjectRegister.Models
{
    public class Choice
    {
        public int ChoiceID { get; set; }
        public string Title { get; set; }

        [StringLength(280)]
        public string Description { get; set; }
        public Int64 Tally { get; set; }

    }
}
