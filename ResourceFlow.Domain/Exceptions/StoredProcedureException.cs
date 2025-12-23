using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace ResourceFlow.Domain.Exceptions
    {
        public class StoredProcedureException : Exception
        {
            public StoredProcedureException() { }

            public StoredProcedureException(string message)
                : base(message) { }

            public StoredProcedureException(string message, Exception innerException)
                : base(message, innerException) { }
        }
    }


