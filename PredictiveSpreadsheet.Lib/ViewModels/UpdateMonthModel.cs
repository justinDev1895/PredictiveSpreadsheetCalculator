using PredictiveSpreadsheet.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PredictiveSpreadsheet.Lib.ViewModels
{
   // [QueryProperty(nameof(RowNum), "RowNum")]
    public class UpdateMonthModel 
    {
        IRowService _rowService;
        private MonthModel _model;
        public UpdateMonthModel(IRowService rowService, MonthModel model)
        {
            _rowService = rowService;
            // _rowNum = RowNum;

            Model = _model;
           
        }
        public MonthModel Model { get; private set; }

        public ICommand UpdateMonthCommand { get; private set; }
   
      
    }

   
}
