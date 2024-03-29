using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Data.Models.Answer;
public class CreateOrUpdateAnswerRequest 
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public Guid? QuestionId { get; set; }
    public bool? Correct { get; set; }
    public int? SortOrder { get; set; }
}
