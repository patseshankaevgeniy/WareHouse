using System;

namespace WareHouse.Application.Common.Exceptions;

public class AccessViolationException : Exception
{
    public AccessViolationException(string message) : base(message)
    {

    }
}
