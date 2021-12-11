using System.ComponentModel;

namespace P1207_EX.Models
{
    public class TodoModel
    {
        [DisplayName("List Name: ")]
        public string Name { get; set; }
        [DisplayName("Description: ")]
        public string Description { get; set; }
    }
}
