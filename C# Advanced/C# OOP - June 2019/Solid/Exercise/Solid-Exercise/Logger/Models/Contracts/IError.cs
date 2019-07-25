using System;
using Logger.Models.Contracts.Enumerations;

namespace Logger.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}