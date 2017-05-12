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
    public partial class EditPengeluaran : ContentPage
    {
        Pengeluaran mPilihPengeluaran;
        public EditPengeluaran(Pengeluaran aPilihPengeluaran)
        {
            InitializeComponent();
            mPilihPengeluaran = aPilihPengeluaran;
            BindingContext = mPilihPengeluaran;
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            mPilihPengeluaran.namaTransaksi = entNamaPengeluaran.Text;
            mPilihPengeluaran.biayaPengeluaran = Convert.ToDouble(entBiayaPengeluaran.Text);
            mPilihPengeluaran.tanggalPengeluaran = entTanggalPengeluaran.Text;
            mPilihPengeluaran.infoPengeluaran = entInfoPengeluaran.Text;
            App.DBUtils.EditPengeluaran(mPilihPengeluaran);
            Navigation.PushAsync(new AturPengeluaran());
            var existingPage = Navigation.NavigationStack.ToList();
            foreach (var pages in existingPage)
            {
                Navigation.RemovePage(pages);
            }
        }
    }
}
