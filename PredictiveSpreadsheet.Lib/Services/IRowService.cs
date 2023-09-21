using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PredictiveSpreadsheet.Lib.ViewModels;


namespace PredictiveSpreadsheet.Lib.Services
{
    public interface IRowService
    {
        Task<List<MonthModel>> GetMonthModelsAsync(); // Get List of Rows

        Task <string> GetNewMonthModelRowNum();
        Task<List<String>> UpdateMonthRowNum();

        Task<MonthModel> ReturnMonthModel(string rowNum);
        Task AddMonthModel(MonthModel model); // Add Row
        Task DeleteMonthModel(int index); // Delete RowModel
        Task UpdateMonthModel(int index, MonthModel model); // Update RowModel

        
    }
}
