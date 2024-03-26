using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Data.Entities;
public class Submission
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ExamId { get; set; }
    public DateTime? SubmittedAt { get; set; }
    public double? Score { get; set; }
    public User Student { get; set; }
    public Exam Exam { get; set; }
}
