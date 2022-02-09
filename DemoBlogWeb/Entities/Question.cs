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
        [Required, MaxLength(150)]
        public string Title { get; set; }
        [Required,MaxLength(30000), Display(Name = "Question Body")]
        public string QuestionBody { get; set; }
        public DateTime AskedTime { get; set; } = DateTime.Now;
        public ICollection<Answer> Answers { get; set; }
        [Required]
        public QuestionTag QuestionTag { get; set; }
    }
}
