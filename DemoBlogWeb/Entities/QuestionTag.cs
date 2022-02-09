using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlogWeb.Models
{
    public class QuestionTag
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(15)]
        public string Name { get; set; }
        
    }
}
