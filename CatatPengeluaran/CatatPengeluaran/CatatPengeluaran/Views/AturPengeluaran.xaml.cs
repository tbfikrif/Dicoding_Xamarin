using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CatatPengeluaran.Models;

namespace CatatPengeluaran.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AturPengeluaran : ContentPage
    {
        public AturPengeluaran()
        {
            InitializeComponent();

            var vlist = App.DBUtils.AmbilSemuaPengeluaran();
            listData.ItemsSource = vlist;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem ==  null)
            {
                return;
            }
            var vSelUser = (Pengeluaran)e.SelectedItem;
            Navigation.PushAsync(new TampilPengeluaran(vSelUser));
        }

        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new TambahPengeluaran());
        }
    }
}
