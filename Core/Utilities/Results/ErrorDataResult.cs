using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)//data ve message dönder
        {

        }

        public ErrorDataResult(T data) : base(data, false)//data dönder
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)//message dönder
        {

        }
        public ErrorDataResult() : base(default, false)//hiçbirşey dönderme default seçeneğin
        {

        }
    }
}
