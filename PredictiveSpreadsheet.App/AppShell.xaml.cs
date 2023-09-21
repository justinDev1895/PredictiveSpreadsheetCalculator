namespace PredictiveSpreadsheet.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
           // string RowNum = "0";
            InitializeComponent();
            Routing.RegisterRoute("NewMonth", typeof(Views.NewMonth));
            Routing.RegisterRoute("UpdateMonth", typeof(Views.UpdateMonth));
        }
    }
}