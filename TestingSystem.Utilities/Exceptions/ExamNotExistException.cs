using TestingSystem.Utilities.Enum;

namespace TestingSystem.Utilities.Exceptions;
public class ExamNotExistException : TestingSystemException
{
    public ExamNotExistException() : base(ExceptionCategory.NotFound, "E404", "Exam not found.")
    { }
}
