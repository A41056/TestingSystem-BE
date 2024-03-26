using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestingSystem.Data.Entities;
public class Question
{
    public Guid Id { get; set; }
    public Guid ExamId { get; set; }
    public int? SortOrder { get; set; }
    public string? Explanation { get; set; }
    public string? Note { get; set; }
    public DateTime? Created { get; set; }
    public bool? IsSingleChoice { get; set; }
    public DateTime? Modified { get; set; }
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
    public virtual Exam Exam { get; set; }

    public virtual ICollection<WebUserChoose> WebUserChooses { get; set; } = new List<WebUserChoose>();
}
