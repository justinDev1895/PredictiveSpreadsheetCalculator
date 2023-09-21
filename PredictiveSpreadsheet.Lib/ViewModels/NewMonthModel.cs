using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PredictiveSpreadsheet.Lib.Services;

namespace PredictiveSpreadsheet.Lib.ViewModels
{
    public class NewMonthModel
    {
        IRowService _rowService;

        public NewMonthModel(IRowService rowService)
        {
            string rowNum;
            _rowService = rowService;

            Model = new MonthModel(_rowService); // Model = new RowModel()

           rowNum = _rowService.GetNewMonthModelRowNum().Result;

            Model.RowNum = rowNum;

            SaveMonthCommand = new Command(() => {
                _rowService.AddMonthModel(Model);
                // ??????

                MessagingCenter.Instance.Send<NewMonthModel, MonthModel>(this, "NewMonth", Model);
                (Application.Current.MainPage as Shell).SendBackButtonPressed();
            });
        } // NewRowModel Constructor

        public MonthModel Model { get; private set; }

        public ICommand SaveMonthCommand { get; private set; }

        
    }
}
