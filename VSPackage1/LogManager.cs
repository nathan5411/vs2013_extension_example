using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.VSPackage1.Models;

namespace Company.VSPackage1
{
    class LogManager
    {
        private List<LogModel> data;
        private List<LogModel> displayData;

        public LogManager()
        {
        }

        public void Parse(string path)
        {
            data = new List<Models.LogModel>() {
                new Models.LogModel() {
                    productName = "p1",
                    fileName = "f1",
                    time = "t1",
                    level = "l1",
                    line = "234",
                    text = "error message"
                }
            };

            displayData = data;
        }

        public List<LogModel> getDisplayData()
        {
            return displayData;
        }

        public LogModel getOneLog(int index)
        {
            if (index > this.displayData.Count)
            {
                return null;
            }

            return this.displayData[index];
        }

        public void Filter()
        {
            //TODO filter
        }

    }
}
