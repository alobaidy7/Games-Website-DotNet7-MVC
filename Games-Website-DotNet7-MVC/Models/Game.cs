﻿using System.ComponentModel.DataAnnotations;

namespace Games_Website_DotNet7_MVC.Models
{
    public class Game : BaseEntity
    {
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Cover { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        public ICollection<GameDevice> Devices { get; } = new List<GameDevice>();
    }
}