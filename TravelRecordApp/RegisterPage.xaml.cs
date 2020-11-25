using System;
using System.Collections.Generic;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void registerButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if(passwordEntry.Text == confirmPasswordEntry.Text)
            {
                // We can register the user
                Users user = new Users()
                {
                    Email = emailEntry.Text,
                    Password = passwordEntry.Text
                };

                await App.MobileService.GetTable<Users>().InsertAsync(user);
                await DisplayAlert("Congratulations", "You are Registered", "Ok");
            }
            else
            {
                DisplayAlert("Error", "Passwords don't match", "Ok");
            }
        }
    }
}
