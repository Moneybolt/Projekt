using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    [Table("travel")]
    public class TravelEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Prosze Podać nazwę")]
        public string Name { get; set; }
        
        public string? Start_Date { get; set; }
        
        public string? End_Date { get; set; }
        public string? Start_Place { get; set; }
        public string? End_Place { get; set; }
        public int Participants { get; set; }
        public string Guide { get; set; }
    public int? OrganizationId { get; set; }
    public OrganizationEntity? Organization { get; set; }
}

