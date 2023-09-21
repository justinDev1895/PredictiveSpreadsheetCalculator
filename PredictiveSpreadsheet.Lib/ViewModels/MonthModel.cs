using PredictiveSpreadsheet.Lib.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PredictiveSpreadsheet.Lib.ViewModels
{
    public class MonthModel : Row, INotifyPropertyChanged
    {
        IRowService _rowService;

        public MonthModel(IRowService rowService)
        {
            _rowService = rowService;
            // Update MonthCommand ---> Go to New Row Page
            UpdateMonthCommand = new Command(async () =>
            {
                await (Application.Current.MainPage as Shell).GoToAsync("UpdateMonth");
                // I need this instance of MonthModel to go to UpdateMonthModel
                
            });

            DeleteMonthCommand = new Command(() =>
            {
                //Update the new rowNums

                /******************/
                int removeIndex;
                string rowNumString = this.RowNum;
                List<String> numList = new List<String>();

                if (string.IsNullOrEmpty(rowNumString))
                {
                   // removeIndex = 1;
                }
                else
                {
                    removeIndex = Int32.Parse(rowNumString);
                    removeIndex -= 1;
                    _rowService.DeleteMonthModel(removeIndex);
                    _rowService.UpdateMonthRowNum();

                   numList = _rowService.UpdateMonthRowNum().Result;

                    MessagingCenter.Instance.Send<MonthModel, Int32>(this, "DeleteMonth", removeIndex);
                    MessagingCenter.Instance.Send<MonthModel, List<String>>(this, "MonthRowNums", numList);
                }


                
               
            });
        }

        // Fields
        
        private string selectedWeek; 
        public string SelectedWeek
        {
            get { return selectedWeek; }
            set { selectedWeek = value; }
        }
     

        public ICommand DeleteMonthCommand { get; private set; }

        public ICommand UpdateMonthCommand { get; private set; }


    }
}

