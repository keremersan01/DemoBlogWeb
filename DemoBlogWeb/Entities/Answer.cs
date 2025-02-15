﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlogWeb.Models
{
    public class Answer
    {
		[Key]
		public int Id { get; set; }
		[Required]
		public string AnswerBody { get; set; }
		public DateTime AnswerTime { get; set; } = DateTime.Now;
		[Required, MaxLength(30000), Display(Name = "Answer Body")]
		public Question Question { get; set; }

	}
}
