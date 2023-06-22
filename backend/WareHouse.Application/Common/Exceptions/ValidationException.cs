using System;

namespace WareHouse.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message)
    {

    }
}
