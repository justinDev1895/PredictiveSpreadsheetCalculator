using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveSpreadsheet.Lib.ViewModels
{
    public class Row : INotifyPropertyChanged
    {
        // Fields      //
        private string rowNum;
        private string clientName;
        private string serviceName;
        private string clientRate;
        private string actualRate;
        private string minutes;
        private string numberOfSessions;
        private string credit;
        private readonly string cliCost = "ClientCostPerSession";
        private readonly string actCost = "ActualCostPerSession";
        private readonly string cliTot = "ClientTotal";
        private readonly string actTot = "ActualTotal";
        private readonly string disAmt = "DiscountAmount";
        private readonly string disPerc = "DiscountPercentage";
        private readonly string crt = "Credit";
        private readonly string ttlACredit = "TotalAfterCredit";


        // PropertyChangedEvent Handler 
        public event PropertyChangedEventHandler PropertyChanged;

        // Properties
        // User Input
        public string RowNum
        {
            get { return rowNum; }
            set { rowNum = value; }
        }
        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }
        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }

        // User Values
        public string ClientRate
        {
            get { return clientRate; }
            set
            {

                if (clientRate != value)
                {
                    if (value.Contains('$'))
                    {
                        clientRate = value;
                    }
                    else
                    {
                        clientRate = "$" + value;
                    }
                    //  clientRate = value;                   
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(cliCost));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(actCost));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(cliTot));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(actTot));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(disAmt));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(disPerc));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(crt));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ttlACredit));
                }

            }

        }
        public string ActualRate
        {
            get { return actualRate; }
            set
            {
                if (actualRate != value)
                {
                    if (value.Contains('$'))
                    {
                        actualRate = value;
                    }
                    else
                    {
                        actualRate = "$" + value;
                    }
                    //actualRate = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(cliCost));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(actCost));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(cliTot));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(actTot));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(disAmt));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(disPerc));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(crt));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ttlACredit));
                }

            }

        }
        public string Minutes
        {
            get { return minutes; }
            set
            {
                if (minutes != value)
                {
                    minutes = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(cliCost));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(actCost));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(cliTot));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(actTot));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(disAmt));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(disPerc));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(crt));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ttlACredit));
                }

            }

        }
        public string NumberOfSessions
        {
            get { return numberOfSessions; }
            set
            {
                if (numberOfSessions != value)
                {
                    numberOfSessions = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(cliCost));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(actCost));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(cliTot));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(actTot));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(disAmt));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(disPerc));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(crt));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ttlACredit));
                }

            }

        }

        public string Credit
        {
            get { return credit; }
            set
            {

                if (credit != value)
                {
                    if (value.Contains('$'))
                    {
                        credit = value;
                    }
                    else
                    {
                        credit = "$" + value;
                    }
                    // actualRate = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(cliCost));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(actCost));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(cliTot));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(actTot));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(disAmt));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(disPerc));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(crt));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ttlACredit));
                }

            }
        }
        // Calculated Values
        public string ClientCostPerSession
        {
            get
            {
                return CalculateClientCostPerSession();
            }
        }
        private string CalculateClientCostPerSession()
        {
            decimal cli;
            string clientRateString = ClientRate;
            string minutesString = Minutes;
            decimal cliRate;
            decimal clientRatePerSession = 0.00m;

            string clientCostPerSessionString;
            int minutesInteger;

            if (string.IsNullOrEmpty(minutesString))
            {
                minutesInteger = 0;
            }
            else
            {
                minutesInteger = Int32.Parse(minutesString);
            }

            if (string.IsNullOrEmpty(clientRateString))
            {
                // cliRate = 0.00m;
            }
            else
            {
                if (clientRateString.Contains('$'))
                {
                    clientRateString = clientRateString.Remove(0, 1);
                    if (Decimal.TryParse(clientRateString, out cli))
                    {
                        cliRate = cli;

                        clientRatePerSession = (minutesInteger * cliRate) / 60; // /60
                    }
                }
                else
                {
                    if (Decimal.TryParse(clientRateString, out cli))
                    {
                        cliRate = cli;

                        clientRatePerSession = (minutesInteger * cliRate) / 60; // /60
                    }
                }


            }






            clientCostPerSessionString = clientRatePerSession.ToString("C2");
            return clientCostPerSessionString;
        }
        public string ActualCostPerSession
        {
            get
            {
                return CalculateActualCostPerSession();
            }
        }
        private string CalculateActualCostPerSession()
        {
            decimal num;
            string actRateString = ActualRate;
            decimal actRateDecimal = 0.00m;
            decimal ratePerSession = 0.00m;

            string actualCostPerSessionString;
            int minutesInteger;

            if (string.IsNullOrEmpty(Minutes))
            {
                minutesInteger = 0;
            }
            else
            {
                minutesInteger = Int32.Parse(Minutes);
            }

            if (string.IsNullOrEmpty(actRateString))
            {
                actRateDecimal = 0.00m;
            }
            else
            {
                if (actRateString.Contains('$'))
                {
                    actRateString = actRateString.Remove(0, 1);
                    if (Decimal.TryParse(actRateString, out num))
                    {
                        actRateDecimal = num;

                        ratePerSession = (minutesInteger * actRateDecimal) / 60; // /60
                    }
                }
                else
                {
                    if (Decimal.TryParse(actRateString, out num))
                    {
                        actRateDecimal = num;

                        ratePerSession = (minutesInteger * actRateDecimal) / 60; // /60
                    }
                }
            }

            actualCostPerSessionString = ratePerSession.ToString("C2");
            return actualCostPerSessionString;

        }
        public string ClientTotal
        {
            get
            {
                return CalculateClientTotal();
            }
        }
        private string CalculateClientTotal()
        {
            decimal clientCostPerSessionDecimal;
            decimal cli;
            string numberOfSessionsString = NumberOfSessions;
            string clientCostPerSessionString = ClientCostPerSession;
            string check;
            int numberOfSessionsInteger = 0;
            decimal monthlyTotal;
            string monthlyTotalString;

            check = Minutes;


            if (string.IsNullOrEmpty(numberOfSessionsString))
            {
                // numberOfSessionsInteger stays 0
            }
            else
            {
                numberOfSessionsInteger = Int32.Parse(numberOfSessionsString);
            }



            if (string.IsNullOrEmpty(clientCostPerSessionString))
            {
                monthlyTotal = 0.0m;
            }
            else
            {
                if (clientCostPerSessionString.Contains('$'))
                {
                    clientCostPerSessionString = clientCostPerSessionString.Remove(0, 1);
                    // decimal try parse
                    if (decimal.TryParse(clientCostPerSessionString, out cli))
                    {
                        clientCostPerSessionDecimal = cli;
                        monthlyTotal = clientCostPerSessionDecimal * numberOfSessionsInteger;
                    }
                    else
                    {
                        monthlyTotal = 0.0m;
                    }
                }
                else
                {
                    // decimal try parse
                    if (decimal.TryParse(clientCostPerSessionString, out cli))
                    {
                        clientCostPerSessionDecimal = cli;
                        monthlyTotal = clientCostPerSessionDecimal * numberOfSessionsInteger;
                    }
                    else
                    {
                        monthlyTotal = 0.0m;
                    }
                }
            }



            monthlyTotalString = monthlyTotal.ToString("C2");
            return monthlyTotalString;
        }
        public string ActualTotal
        {
            get
            {
                return CalculateActualTotal();
            }
        }
        private string CalculateActualTotal()
        {
            decimal actualCostPerSessionDecimal;
            decimal act;
            string numberOfSessionsString = NumberOfSessions;
            string actualCostPerSessionString = ActualCostPerSession;
            int numberOfSessionsInteger = 0;
            decimal monthlyTotal;
            string monthlyTotalString;


            if (string.IsNullOrEmpty(numberOfSessionsString))
            {
                // numberOfSessionsInteger stays 0
            }
            else
            {
                numberOfSessionsInteger = Int32.Parse(numberOfSessionsString);
            }



            if (string.IsNullOrEmpty(actualCostPerSessionString))
            {
                monthlyTotal = 0.0m;
            }
            else
            {
                if (actualCostPerSessionString.Contains('$'))
                {
                    actualCostPerSessionString = actualCostPerSessionString.Remove(0, 1);
                    // decimal try parse
                    if (decimal.TryParse(actualCostPerSessionString, out act))
                    {
                        actualCostPerSessionDecimal = act;
                        monthlyTotal = actualCostPerSessionDecimal * numberOfSessionsInteger;
                    }
                    else
                    {
                        monthlyTotal = 0.0m;
                    }
                }
                else
                {
                    // decimal try parse
                    if (decimal.TryParse(actualCostPerSessionString, out act))
                    {
                        actualCostPerSessionDecimal = act;
                        monthlyTotal = actualCostPerSessionDecimal * numberOfSessionsInteger;
                    }
                    else
                    {
                        monthlyTotal = 0.0m;
                    }
                }
            }



            monthlyTotalString = monthlyTotal.ToString("C2");
            return monthlyTotalString;
        }
        public string DiscountAmount
        {
            get
            {
                return CalculateDiscountAmount();
            }
        }
        private string CalculateDiscountAmount()
        {
            decimal actualTotal = 0.00m;
            decimal act;
            decimal clientTotal = 0.00m;
            decimal cli;
            string actualTotalString = ActualTotal;
            string clientTotalString = ClientTotal;
            decimal discountAmount;
            string discountAmountString;


            // Null Check && Remove $ Signs && Assign Decimal Values
            if (string.IsNullOrEmpty(actualTotalString))
            {
                actualTotalString = "0.00";
            }
            else
            {

            }
            // Remove Dollar Signs
            if (actualTotalString.Contains('$'))
            {
                actualTotalString = actualTotalString.Remove(0, 1);
                if (Decimal.TryParse(actualTotalString, out act))
                {
                    actualTotal = act;
                }

            }
            else
            {
                if (Decimal.TryParse(actualTotalString, out act))
                {
                    actualTotal = act;
                }

            }

            // Null Check && Remove $ Signs && Assign Decimal Values
            if (string.IsNullOrEmpty(clientTotalString))
            {
                clientTotalString = "0.00";
            }
            else
            {

            }
            // Remove Dollar Signs
            if (clientTotalString.Contains('$'))
            {
                clientTotalString = clientTotalString.Remove(0, 1);
                if (Decimal.TryParse(clientTotalString, out cli))
                {
                    clientTotal = cli;
                }

            }
            else
            {
                if (Decimal.TryParse(clientTotalString, out cli))
                {
                    clientTotal = cli;
                }

            }




            discountAmount = actualTotal - clientTotal;
            discountAmountString = discountAmount.ToString("C2");

            return discountAmountString;
        }
        public string DiscountPercentage
        {
            get
            {
                return CalculateDiscountPercentage();
            }
        }
        private string CalculateDiscountPercentage()
        {
            string clientRateString = ClientRate;
            string actualRateString = ActualRate;
            decimal cli;
            decimal act;
            decimal clientDecimalRate;
            decimal actualDecimalRate;
            decimal percentageCalculate;
            string percentString;



            if (string.IsNullOrEmpty(clientRateString))
            {
                clientDecimalRate = 0.00m;

            }
            else
            {
                if (clientRateString.Contains('$'))
                {
                    clientRateString = clientRateString.Remove(0, 1);
                }
                if (Decimal.TryParse(clientRateString, out cli))
                {
                    clientDecimalRate = cli;
                }
                else
                {
                    clientDecimalRate = 0.00m;
                }
            }

            if (string.IsNullOrEmpty(actualRateString))
            {
                actualDecimalRate = 265.00m;
            }
            else
            {
                if (actualRateString.Contains('$'))
                {
                    actualRateString = actualRateString.Remove(0, 1);
                }
                if (Decimal.TryParse(actualRateString, out act))
                {
                    actualDecimalRate = act;
                }
                else
                {
                    actualDecimalRate = 265.00m;
                }
            }




            try
            {
                if (((1 - (clientDecimalRate / actualDecimalRate)) < 1))
                {
                    percentageCalculate = 1 - (clientDecimalRate / actualDecimalRate);
                }
                else
                {
                    percentageCalculate = 0.00m;
                }




            }
            catch (DivideByZeroException)
            {
                percentageCalculate = 0.00m;
            }




            percentString = percentageCalculate.ToString("P0", CultureInfo.InvariantCulture);
            return percentString;
        }

        public string TotalAfterCredit
        {
            get
            {
                return CalculateTotalAfterCredit();
            }
        }
        private string CalculateTotalAfterCredit()
        {
            string clientMonthlyTotal = ClientTotal;
            string credit = Credit;
            decimal cliTot;
            decimal crdt;
            decimal creditDecimal = 0.0m;
            decimal totalDecimal;
            decimal clientMonthlyTotalDecimal = 0.0m;
            string totalAfterCreditString;

            if ((string.IsNullOrEmpty(clientMonthlyTotal)))
            {
                clientMonthlyTotal = "0.00";
                clientMonthlyTotalDecimal = 0.0m;
            }
            else
            {
                if (clientMonthlyTotal.Contains('$'))
                {
                    clientMonthlyTotal = clientMonthlyTotal.Remove(0, 1);
                    if (Decimal.TryParse(clientMonthlyTotal, out cliTot))
                    {
                        clientMonthlyTotalDecimal = cliTot;
                    }
                    else
                    {
                        clientMonthlyTotalDecimal = 0.0m;
                    }
                }
            }

            if ((string.IsNullOrEmpty(credit)))
            {
                credit = "0.00";
                creditDecimal = 0.0m;
            }
            else
            {
                if (credit.Contains('$'))
                {
                    credit = credit.Remove(0, 1);
                    if (Decimal.TryParse(credit, out crdt))
                    {
                        creditDecimal = crdt;
                    }
                    else
                    {
                        creditDecimal = 0.0m;
                    }
                }
            }


            totalDecimal = clientMonthlyTotalDecimal - creditDecimal;
            totalAfterCreditString = totalDecimal.ToString("C2");

            return totalAfterCreditString;
        }
    }
}
