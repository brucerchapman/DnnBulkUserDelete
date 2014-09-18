using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnn.Modules.BulkUserDelete
{
    public class ActionRequest
    {
        public string actionName;
        public int actionNumber;
        bool testRun;
        bool stopOnError;
    }
}
