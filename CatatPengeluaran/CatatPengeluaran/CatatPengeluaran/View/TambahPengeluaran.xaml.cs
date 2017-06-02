using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CatatPengeluaran.Models;
using System.Diagnostics;

namespace CatatPengeluaran.View
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
                namaTransaksi = Convert.ToString(entNamaTransaksi.Text),
                biayaPengeluaran = Convert.ToDouble(entBiayaTransaksi.Text),
                tanggalPengeluaran = Convert.ToString(entTanggalTransaksi.Text),
                infoPengeluaran = Convert.ToString(entInfoTransaksi.Text),
                totalPengeluaran = 0
            };

            List<Pengeluaran> temp = App.DBUtils.AmbilSemuaPengeluaran();
            foreach (var total in temp)
            {
                pengeluaran.totalPengeluaran += total.biayaPengeluaran;
            }

            pengeluaran.totalPengeluaran = pengeluaran.totalPengeluaran + pengeluaran.biayaPengeluaran;
            Debug.WriteLine("Total Expense: " + pengeluaran.totalPengeluaran);

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
