using System;
using System.ComponentModel;

namespace P1207_EX.Models
{
    public class SponsorModel
    {
        [DisplayName("Sponsor Id: ")]
        public int Id { get; set; }
        [DisplayName("First Name: ")]
        public string FirstName { get; set; }
        [DisplayName("Surname: ")]
        public string Surname { get; set; }
        [DisplayName("Sponsored Money: ")]
        public int Amount { get; set; }
        [DisplayName("Sponsored Animal Id: ")]
        public int AnimalId { get; set; }
    }
}
