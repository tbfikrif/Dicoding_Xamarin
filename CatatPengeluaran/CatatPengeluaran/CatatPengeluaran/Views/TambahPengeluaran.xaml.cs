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
        double biayaPengeluaran;
        public TambahPengeluaran()
        {
            InitializeComponent();
            String tanggalSekarang = DateTime.Now.Date.ToString("d/M/yyyy");
            entTanggalTransaksi.Text = tanggalSekarang;
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            
            var pengeluaran = new Pengeluaran()
            {
                namaTransaksi = entNamaTransaksi.Text,
                biayaPengeluaran = Convert.ToDouble(entBiayaTransaksi.Text),
                tanggalPengeluaran = entTanggalTransaksi.Text,
                infoPengeluaran = entInfoTransaksi.Text,
            };

            biayaPengeluaran = pengeluaran.totalPengeluaran + Convert.ToDouble(entBiayaTransaksi.Text);

            pengeluaran.totalPengeluaran = biayaPengeluaran;

            App.DBUtils.SimpanPengeluaran(pengeluaran);
            Navigation.PushAsync(new AturPengeluaran());
            var existingPage = Navigation.NavigationStack.ToList();
            foreach (var pages in existingPage)
            {
                Navigation.RemovePage(pages);
            }
        }
    }
}
