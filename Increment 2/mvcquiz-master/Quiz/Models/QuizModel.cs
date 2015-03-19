using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
    public class QuizModel
    {
        public string Question { get; set; }
        public bool? Anwser { get; set; }
        public bool ActualAnwser { get; set; }
    }

    public class QuestionsList
    {

        public QuestionsList()
        {
            questions = new List<QuizModel>();

            questions.Add(new QuizModel { Question = "I prefer one-on-one conversations to group activities.", ActualAnwser=false });
            questions.Add(new QuizModel { Question = "I often prefer to express myself in writing.", ActualAnwser = false });
            questions.Add(new QuizModel { Question = "I enjoy solitude.", ActualAnwser = false });
            questions.Add(new QuizModel { Question = "I seem to care about wealth, fame, and status less than my peers.", ActualAnwser = false });
            questions.Add(new QuizModel { Question = "People tell me that I'm a good listener.", ActualAnwser = false });
            questions.Add(new QuizModel { Question = "I'm not a big risk-taker.", ActualAnwser = false });
            questions.Add(new QuizModel { Question = "I enjoy work that allows me to 'dive in' with few interruptions.", ActualAnwser = false });
            questions.Add(new QuizModel { Question = "People describe me as \"soft-spoken\" or \"mellow.\"", ActualAnwser = false });
            questions.Add(new QuizModel { Question = "I prefer not to show or discuss my work with others until it's finished.", ActualAnwser = false });
            questions.Add(new QuizModel { Question = "I tend to think before I speak.", ActualAnwser = false });
            questions.Add(new QuizModel { Question = "I often let calls go through to voice-mail.", ActualAnwser = false });

        }

        public List<QuizModel> questions { get; set; }
    }
}