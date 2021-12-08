using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
