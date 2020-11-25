using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class PostDetailPage : ContentPage
    {
        Post selectedPost;

        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();

            this.selectedPost = selectedPost;

            experienceEntry.Text = selectedPost.Experience;
            venueLabel.Text = selectedPost.VenueName;
            categoryLabel.Text = selectedPost.CategoryName;
            addressLable.Text = $"Address: {selectedPost.Address}";
            longitudeLabel.Text = $"Longitude: {selectedPost.Longitude}";
            latitudeLabel.Text = $"Latitude: {selectedPost.Latitude}";
            distanceLabel.Text = $"Distance: {selectedPost.Distance} m";

        }

        async void updateButton_Clicked(System.Object sender, System.EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;

            await App.MobileService.GetTable<Post>().UpdateAsync(selectedPost);
            await DisplayAlert("Sucess", "Expreience succesfully updated", "Ok");

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Post>();
            //    int rows = conn.Update(selectedPost);

            //    if (rows > 0)
            //    {
            //        DisplayAlert("Sucess", "Expreience succesfully Updated", "Ok");
            //    }
            //    else
            //    {
            //        DisplayAlert("Faliure", "Expreience failed to update", "Ok");
            //    }
            //}

        }

        async void deleteButton_Clicked(System.Object sender, System.EventArgs e)
        {

            await App.MobileService.GetTable<Post>().DeleteAsync(selectedPost);
            await DisplayAlert("Sucess", "Expreience succesfully deleted", "Ok");

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Post>();
            //    int rows = conn.Delete(selectedPost);

            //    if (rows > 0)
            //    {
            //        DisplayAlert("Sucess", "Expreience succesfully Deleted", "Ok");
            //    }
            //    else
            //    {
            //        DisplayAlert("Faliure", "Expreience failed to delete", "Ok");
            //    }
            //}
        }
    }
}
