using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PredictiveSpreadsheet.Lib.Services;

namespace PredictiveSpreadsheet.Lib.ViewModels
{
    public class MonthsModel : INotifyPropertyChanged
    {
        // Fields
        string totalRevenue;
        string discountAverage;
        string totalNumSessions;
        string avgClientRate;
        string lossDiscountRevenue;

        // PropertyChangedEvent Handler 
        public event PropertyChangedEventHandler PropertyChanged;
        IRowService _rowService;
        private readonly string mos = "Months";
        private readonly string tRev = "TotalRevenue";
        private readonly string dAvg = "DiscountAverage";
        private readonly string tNumSess = "TotalNumberOfSessions";
        private readonly string aCliRate = "AverageClientRate";
        private readonly string lDisRev = "LossDiscountRevenue";



        private ObservableCollection<MonthModel> initialMonths = new ObservableCollection<MonthModel>();
        public MonthsModel(IRowService rowService)
        {
            // IRowService
            _rowService = rowService;

            // AddRowCommand ---> Go to New Row Page
            AddMonthCommand = new Command(async () =>
            {
                await (Application.Current.MainPage as Shell).GoToAsync("NewMonth");
            });

           

            // RefreshRowsCommand -----> 
            RefreshMonthsCommand = new Command(//async
                execute: async () =>
                {

                    var months = await _rowService.GetMonthModelsAsync();

                    months.ForEach((i) => Months.Add(i));

                }
            );

            // Messaging Center
            MessagingCenter.Instance.Subscribe<NewMonthModel, MonthModel>(this, "NewMonth", async (source, newMonth) =>
            {
                this.Months.Add(newMonth);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tRev));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(dAvg));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tNumSess));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aCliRate));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(lDisRev));
                //     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(mos));
            });

            MessagingCenter.Instance.Subscribe<MonthModel, Int32>(this, "DeleteMonth", async (source, removeIndex) =>
            {
                this.Months.RemoveAt(removeIndex);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tRev));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(dAvg));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tNumSess));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aCliRate));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(lDisRev));
                //   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(mos));
            });
            MessagingCenter.Instance.Subscribe<MonthModel, List<String>>(this, "MonthRowNums", async (source, numList) =>
            {
                int i = 0;
                foreach (MonthModel m in this.Months)
                {
                    m.RowNum = numList[i];
                    i++;
                }

            });

        } // Rowsmodel Constructor

        public ObservableCollection<MonthModel> Months { get; set; } = new ObservableCollection<MonthModel>();

        public ICommand AddMonthCommand { get; set; }

        public ICommand RefreshMonthsCommand { get; set; }

       

        public string TotalRevenue
        {
            get
            {
                string totRev;
                decimal totRevDec = 0.0m;
                decimal val;
                foreach (MonthModel m in this.Months)
                {
                    totRev = m.ClientTotal;
                    totRev = totRev.Remove(0, 1);
                    if (Decimal.TryParse(totRev, out val))
                    {
                        totRevDec += val;
                    }
                }

                totalRevenue = totRevDec.ToString("C2");

                return totalRevenue;
            }
        }

        public string DiscountAverage
        {
            get
            {
                string avgString;
                decimal avgDecimal = 0.0m;
                decimal totalRows = (decimal)this.Months.Count;
                decimal val;
                foreach (MonthModel m in this.Months)
                {
                    avgString = m.DiscountPercentage;
                    avgString = avgString.Remove(2, 2);

                    if (Decimal.TryParse(avgString, out val))
                    {
                        val *= .01m;
                        avgDecimal += val;
                    }
                }
                if (totalRows != 0)
                {
                    avgDecimal /= totalRows;
                }
                discountAverage = avgDecimal.ToString("P0");

                return discountAverage;
            }
        }

        public string TotalNumberOfSessions
        {
            get
            {
                string totNumString;
                int rowTotNum;
                int totNum = 0;
               
                foreach (MonthModel m in this.Months)
                {
                    totNumString = m.NumberOfSessions;
                    rowTotNum = Int32.Parse(totNumString);
                    totNum += rowTotNum;
                   
                }

                return totNum.ToString();
            }
        }
        
        public string AverageClientRate
        {
            get
            {
                string avgString;
                decimal avgClientDecimal = 0.0m;
                decimal totalRows = (decimal)this.Months.Count;
                decimal val;
                foreach (MonthModel m in this.Months)
                {
                    avgString = m.ClientRate;
                    avgString = avgString.Remove(0, 1);

                    if (Decimal.TryParse(avgString, out val))
                    {
                    
                        avgClientDecimal += val;
                    }
                }
                if (totalRows != 0)
                {
                    avgClientDecimal /= totalRows;
                }
                avgClientRate = avgClientDecimal.ToString("C2");

                return avgClientRate;
            }
        }
        
        public string LossDiscountRevenue
        {
            get
            {
                // Sum of Discount Amounts
                string totDiscLoss;
                decimal totDiscLossDecimal = 0.0m;
                decimal val;
                foreach (MonthModel m in this.Months)
                {
                    totDiscLoss = m.DiscountAmount;
                    totDiscLoss = totDiscLoss.Remove(0, 1);
                    if (Decimal.TryParse(totDiscLoss, out val))
                    {
                        totDiscLossDecimal += val;
                    }
                }

                lossDiscountRevenue = totDiscLossDecimal.ToString("C2");

                return lossDiscountRevenue;
            }
        }
        
        /*   public ObservableCollection<MonthModel> Months
           {
               get {

                   int i = 1;

                   foreach (MonthModel m in initialMonths)
                   {
                       m.RowNum = i.ToString();
                       i++;
                   }

                   return initialMonths; 

               }
               set
               {
                   int i = 1;

                   foreach(MonthModel m in value)
                   {
                       m.RowNum = i.ToString();
                       i++;
                   }
                   initialMonths = value;
               }
           }*/




    }
}
