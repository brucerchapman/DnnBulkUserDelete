using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnn.Modules.BulkUserDelete
{
    public class PingResult
    {
            public bool Success;
            public bool WasAuthorised;
            public string UserName;
            public string Message;
            public string Error;
            public string StackTrace;

    }
}
