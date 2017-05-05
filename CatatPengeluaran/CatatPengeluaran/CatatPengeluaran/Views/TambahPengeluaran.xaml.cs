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
    public partial class TambahPengeluaran : ContentPage
    {
        public TambahPengeluaran()
        {
            InitializeComponent();
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            var pengeluaran = new Pengeluaran()
            {
                namaTransaksi = entNamaTransaksi.Text,
                biayaPengeluaran = Convert.ToDouble(entBiayaTransaksi.Text),
                tanggalPengeluaran = dpTglTransaksi.Date,
                infoPengeluaran = entInfoTransaksi.Text,
            };
            App.DBUtils.SimpanPengeluaran(pengeluaran);
            Navigation.PushAsync(new AturPengeluaran());
        }
    }
}
