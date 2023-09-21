namespace PredictiveSpreadsheet.App.Views;

public partial class UpdateMonth : ContentPage
{
	public UpdateMonth(Lib.ViewModels.UpdateMonthModel model)
	{
		InitializeComponent();
        BindingContext = model;
    }
}