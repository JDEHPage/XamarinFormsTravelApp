using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        void registerButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if(passwordEntry.Text == confirmPasswordEntry.Text)
            {
                // We can register the user
            }
            else
            {
                DisplayAlert("Error", "Passwords don't match", "Ok");
            }
        }
    }
}
