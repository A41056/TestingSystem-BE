using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Data.Models.WebUserChoose;
public class CreateOrUpdateWebUserChooseRequest
{
    public Guid? Id { get; set; }
    public Guid? WebUserId { get; set; }
    public Guid? QuestionId { get; set; }
    public Guid? AnswerId { get; set; }
    public string AnswerText { get; set; }
    public bool CorrectAnswer { get; set; }
}
