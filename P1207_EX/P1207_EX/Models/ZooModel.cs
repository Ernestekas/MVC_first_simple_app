using System.ComponentModel;

namespace P1207_EX.Models
{
    public class ZooModel
    {
        [DisplayName("Animal Id: ")]
        public int Id { get; set; }
        [DisplayName("Animal Name: ")]
        public string Name { get; set; }
        [DisplayName("Description: ")]
        public string Description { get; set; }
        [DisplayName("Age: ")]
        public int Age { get; set; }
        [DisplayName("Gender: ")]
        public string Gender { get; set; }
    }
}
