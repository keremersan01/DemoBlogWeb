using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlogWeb.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string QuestionBody { get; set; }
        public DateTime AskedTime { get; set; } = DateTime.Now;
        public ICollection<Answer> Answers { get; set; }
    }
}
