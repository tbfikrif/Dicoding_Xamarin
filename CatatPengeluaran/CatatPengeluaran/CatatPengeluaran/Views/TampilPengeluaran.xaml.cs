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
    public partial class TampilPengeluaran : ContentPage
    {
        Pengeluaran mPengeluaran;
        public TampilPengeluaran(Pengeluaran aPengeluaran)
        {
            InitializeComponent();
            mPengeluaran = aPengeluaran;
            BindingContext = mPengeluaran;
        }

        public void OnEditClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new EditPengeluaran(mPengeluaran));
        }

        public async void OnDeleteClicked()
        {
            bool accepted = await DisplayAlert("Konfirmasi", "Apakah anda yakin menghapus data ?", "Ya", "Tidak");
            if (accepted)
            {
                App.DBUtils.HapusPengeluaran(mPengeluaran);
            }
            await Navigation.PushAsync(new AturPengeluaran());
        }
    }
}
