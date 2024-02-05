using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_nr3.Models
{
    public class Travel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Prosze Podać nazwę")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public string? Start_Date { get; set; }
        [DataType(DataType.Date)]
        public string? End_Date { get; set; }
        public string? Start_Place { get; set; }
        public string? End_Place { get; set; }
        public int Participants { get; set; }
        public string Guide { get; set; }
    }
}
