﻿namespace OurStore.Application.Exceptions
{
    public class KeyIsAlreadyExistsException: Exception
    {
        public KeyIsAlreadyExistsException(string msg)
          : base($"{msg}")
        {

        }
    }
}
