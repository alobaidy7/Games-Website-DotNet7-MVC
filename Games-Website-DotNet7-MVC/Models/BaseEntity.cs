﻿using System.ComponentModel.DataAnnotations;

namespace Games_Website_DotNet7_MVC.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
    }
}
