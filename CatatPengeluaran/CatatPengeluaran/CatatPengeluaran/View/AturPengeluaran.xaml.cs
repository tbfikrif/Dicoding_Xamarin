using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CatatPengeluaran.Models;

namespace CatatPengeluaran.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AturPengeluaran : ContentPage
    {
        public AturPengeluaran()
        {
            InitializeComponent();

            var vlist = App.DBUtils.AmbilSemuaPengeluaran();
            listData.ItemsSource = vlist;

            double id = 0;

            foreach (var total in vlist)
            {
                id += total.biayaPengeluaran;
            }

            Application.Current.Properties["totalPengeluaran"] = id;


            lblbTotal.Text = Convert.ToString(Application.Current.Properties["totalPengeluaran"]);
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
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
