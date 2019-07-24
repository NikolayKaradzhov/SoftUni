using System;
using System.Collections.Generic;
using System.Text;
using Logger.Models.Contracts.Enumerations;

namespace Logger.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        void Append(IError error);
    }
}