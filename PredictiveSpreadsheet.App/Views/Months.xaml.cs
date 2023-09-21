namespace PredictiveSpreadsheet.App.Views;

public partial class Months : ContentPage
{
	public Months(Lib.ViewModels.MonthsModel model)
	{
		InitializeComponent();
		BindingContext = model;
		model.RefreshMonthsCommand.Execute(null);
	}
}