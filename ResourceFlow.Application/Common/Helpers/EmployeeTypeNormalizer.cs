using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Common.Helpers
{
    public class EmployeeTypeNormalizer
    {
       
            public static string Normalize(string input)
            {
                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException("Employee type is required.");

                return Regex
                    .Replace(input, @"[^A-Za-z]", "") // removes spaces, underscores, symbols
                    .ToUpper();
            }
        
    }
}
