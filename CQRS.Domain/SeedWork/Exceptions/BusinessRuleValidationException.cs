using System;

namespace CQRS.Domain.SeedWork.Exceptions
{
    public class BusinessRuleValidationException : Exception
    {
        public BusinessRuleValidationException(string message) : base(message)
        {
        }
    }
}
