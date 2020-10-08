using System;
using System.Collections.Generic;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            GetPermissions();
        }

        private async void GetPermissions()
        {
			try
			{
				var status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationPermission>();
				if (status != PermissionStatus.Granted)
				{
					if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
					{
						await DisplayAlert("Need location", "We need access to your location", "OK");
					}

					status = await CrossPermissions.Current.RequestPermissionAsync<LocationPermission>();
				}

				if (status == PermissionStatus.Granted)
				{
					locationsMap.IsShowingUser = true;
				}
				else
                {
					await DisplayAlert("Need location", "We need access to your location", "OK");
				}

			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", ex.Message, "Ok");
			}


		}
    }
}
