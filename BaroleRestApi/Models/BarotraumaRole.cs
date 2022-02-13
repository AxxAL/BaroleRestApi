using System;

namespace BaroleRestApi.Models
{
    public class BarotraumaRole
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string BarotraumaJob { get; set; }
        public string Goal { get; set; }
        public string WinCondition { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? Tips { get; set; }
    }
}