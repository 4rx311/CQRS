using System;

namespace CQRS.Domain.SeedWork
{
    public static class ThrowHelper
    {
        public static void Throw(Exception exception)
        {
            throw exception;
        }
    }
}
