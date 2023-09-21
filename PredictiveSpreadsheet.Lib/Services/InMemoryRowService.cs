using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using PredictiveSpreadsheet.Lib.ViewModels;

namespace PredictiveSpreadsheet.Lib.Services
{
    public class InMemoryRowService : IRowService
    {
        private static List<MonthModel> _monthRows = new List<MonthModel>();
       
        static InMemoryRowService()
        {
            // Rows Could Go Here for Initialization
            // _rows.Add("whatever here");
            

        } // InMemoryRowService() Constructor

        public async Task<List<MonthModel>> GetMonthModelsAsync()
        {
           /* string i = "1";
            int iNum;
            foreach(MonthModel m in _monthRows)
            {
                m.RowNum = i;
                iNum = Int32.Parse(i);
                iNum += 1;
                i = iNum.ToString();
            }*/

            return await Task.FromResult(_monthRows);
        }

        public async Task <string> GetNewMonthModelRowNum()
        {
            int tempRowNum = _monthRows.Count + 1;
            string returnNum = tempRowNum.ToString();
            return await Task.FromResult(returnNum);
        }

        public async Task AddMonthModel(MonthModel model)
        {
            _monthRows.Add(model);
        }     

        public async Task DeleteMonthModel(int index)
        {
            _monthRows.RemoveAt(index);
        }

        public async Task UpdateMonthModel(int index, MonthModel model)
        {
            _monthRows.RemoveAt(index);
            _monthRows.Insert(index, model);
        }

        public async Task <List<String>> UpdateMonthRowNum()
        {
            int iNum = 1;
            List<String> rowNums = new List<String>();
            foreach (MonthModel m in _monthRows)
            {
                m.RowNum = iNum.ToString();
                rowNums.Add(iNum.ToString());
                iNum++;

            }
            return await Task.FromResult(rowNums);
        }

        public async Task<MonthModel> ReturnMonthModel(string rowNum)
        {
            IEnumerable<MonthModel> moModel = from t in _monthRows where t.RowNum.Equals(rowNum) select t;
            MonthModel ret = (MonthModel)moModel;

            return await Task.FromResult(ret);
        }

       
    }
}
