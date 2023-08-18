﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace testTechniqueWeCount.Models
{
    public class Administrateur
    {
        [Key]
        public int Id { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
    }
}
