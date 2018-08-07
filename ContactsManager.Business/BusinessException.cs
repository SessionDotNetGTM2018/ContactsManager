using System;

namespace ContactsManager.Business
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        { }
    }
}
