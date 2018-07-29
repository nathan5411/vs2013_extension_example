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
            data = new List<Models.LogModel>() ;
            
            for ( int i = 0 ; i < 10000 ; i++ )
            {
                data.Add(new Models.LogModel()
                {
                    productName = "p" + i.ToString(),
                    fileName = "f" + i.ToString(),
                    time = "t" + i.ToString(),
                    level = "l" + i.ToString(),
                    line = i.ToString(),
                    text = "error message - " + i.ToString()
                });
            }

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

        public void Clear()
        {
            data = new List<Models.LogModel>();
            displayData = data;
        }

        public void Filter()
        {
            //TODO filter
        }

    }
}
