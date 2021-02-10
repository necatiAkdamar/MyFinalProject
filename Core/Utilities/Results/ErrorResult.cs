using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)//2 parametreli gelirse success de çalışır demek this kısmı ile
        {
            
        }

        public ErrorResult():base(false)
        {
            
        }
    }
}
