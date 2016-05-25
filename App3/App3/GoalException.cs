using System;

namespace App2.classes
{
    internal class GoalException : Exception
    {
        public GoalException()
        {
        }

        public GoalException(string message) : base(message)
        {
        }

        public GoalException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}