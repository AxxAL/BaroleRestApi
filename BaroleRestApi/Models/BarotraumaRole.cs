using System;
using System.ComponentModel.DataAnnotations;

namespace BaroleRestApi.Models
{
    public class BarotraumaRole
    {
        public Guid? Id { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string? Title { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string? BarotraumaJob { get; set; }
        
        [Required]
        [MaxLength(512)]
        public string? Goal { get; set; }
        
        [Required]
        [MaxLength(512)]
        public string? WinCondition { get; set; }
        
        [MaxLength(512)]
        public string? AdditionalInfo { get; set; }
        
        [MaxLength(512)]
        public string? Tips { get; set; }
    }
}