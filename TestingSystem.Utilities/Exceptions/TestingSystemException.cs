using TestingSystem.Utilities.Enum;

namespace TestingSystem.Utilities.Exceptions;
public abstract class TestingSystemException : Exception
{
    protected TestingSystemException(ExceptionCategory category, string code, string message, Exception? innerException = null)
    {
        Category = category;
        Code = code;
    }

    public ExceptionCategory Category { get; }
    public string Code { get; }
}
