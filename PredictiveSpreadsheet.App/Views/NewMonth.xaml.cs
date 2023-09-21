namespace PredictiveSpreadsheet.App.Views;

public partial class NewMonth : ContentPage
{
	public NewMonth(Lib.ViewModels.NewMonthModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}