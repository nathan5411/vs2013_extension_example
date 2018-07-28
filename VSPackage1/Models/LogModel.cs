using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.VSPackage1.Models
{
    class LogModel
    {
        public string productName { get; set; }
        public string fileName { get; set; }
        public string time { get; set; }
        public string level { get; set; }
        public string line { get; set; }
        public string text { get; set; }

        public LogModel()
        {
            productName = "";
            fileName = "";
            time = "";
            level = "";
            line = "";
            text = "";
        }
    }
}
