﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroes.Models
{
    public class Hero
    {
        [Key]
        public int id { get; set; }
        [StringLength(30, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        public string AlterEgo { get; set; }
        
        public string PrimaryAbility { get; set; }
       
        public string SecondaryAbility { get; set; }
       
        public string CatchPhrase { get; set; }
    }
}
