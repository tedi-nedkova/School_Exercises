﻿using System.ComponentModel.DataAnnotations;

namespace Project.Data.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string OptionA { get; set; }

        [Required]
        public string OptionB { get; set; }

        [Required]
        public string OptionC { get; set; }

        [Required]
        public string OptionD { get; set; }

        [Required]
        public string CorrectAnswer { get; set; }

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
