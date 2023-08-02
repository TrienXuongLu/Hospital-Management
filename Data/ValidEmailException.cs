using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data
{
    internal class ValidEmailException : Exception
    {
        public ValidEmailException() : base("Invalid Email")
        {
        }
    }
}
