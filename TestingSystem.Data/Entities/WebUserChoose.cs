using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Data.Entities;
public class WebUserChoose
{
    public Guid Id { get; set; }
    public Guid WebUserId { get; set; }
    public Guid QuestionId { get; set; }
    public Guid AnswerId { get; set; }
    public string AnswerText { get; set; }
    public bool CorrectAnswer { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }

    public Question Question { get; set; }
    public Answer Answer { get; set; }
    public User WebUser { get; set; }
}
