using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Entities
{
    public class OrganizationEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Regon { get; set; }
        public string? Nip { get; set; }
        public Address? Address { get; set; }
        public ISet<TravelEntity> Travel { get; set; }
    }
}
