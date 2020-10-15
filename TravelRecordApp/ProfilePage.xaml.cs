using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using System.Linq;

namespace TravelRecordApp
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var postTable = conn.Table<Post>().ToList();

                //var categories = (from p in postTable
                //                  orderby p.CategoryId
                //                  select p.CategoryName).Distinct().ToList();

                //This is the same as the first Linq categories query just shorter syntax
                var categories2 = postTable.OrderBy(p => p.CategoryId).Select(p => p.CategoryName).Distinct().ToList();

                Dictionary<string, int> categoryCount = new Dictionary<string, int>();

                foreach(var category in categories2)
                {
                    //var count = (from post in postTable
                    //             where post.CategoryName == category
                    //             select post).ToList().Count;

                    //This is the same as the first count Linq query just shorter syntax
                    var count2 = postTable.Where(p => p.CategoryName == category).ToList().Count;

                    categoryCount.Add(category, count2);
                }

                categoryListView.ItemsSource = categoryCount;

                postCountLable.Text = postTable.Count.ToString();
            }
        } 
    }
}
