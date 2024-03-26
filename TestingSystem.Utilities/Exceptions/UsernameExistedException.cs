using TestingSystem.Utilities.Enum;

namespace TestingSystem.Utilities.Exceptions;
public class UsernameExistedException : TestingSystemException
{
    public UsernameExistedException() : base(ExceptionCategory.Error, "UE409", "Username already exist.")
    {
    }
}
