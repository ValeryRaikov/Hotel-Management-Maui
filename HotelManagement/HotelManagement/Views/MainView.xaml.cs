using HotelManagement.Stores;

namespace HotelManagement.Views;

public partial class MainView : ContentPage
{
    public MainView()
	{
		InitializeComponent();
    }

    private void MakeReservationBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MakeReservationView());
    }

    private void ViewReservationsBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ReservationListingView());
    }
}