﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("Password or email is incorrect")
        {

        }

        public UserNotFoundException(string? message) : base(message)
        {

        }

        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
