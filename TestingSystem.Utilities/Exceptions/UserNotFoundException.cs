using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Utilities.Enum;

namespace TestingSystem.Utilities.Exceptions;
public class UserNotFoundException : TestingSystemException
{
    public UserNotFoundException() : base(ExceptionCategory.NotFound, "U404", "User not found.")
    { }
}
