using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KalkulatorBBI.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KBBIPage : ContentPage
    {
        public KBBIPage()
        {
            InitializeComponent();

            btnHitungBBIL.Clicked += BtnHitungBBIL_Clicked;
            btnHitungBBIP.Clicked += BtnHitungBBIP_Clicked;
        }

        private void BtnHitungBBIP_Clicked(object sender, EventArgs e)
        {
            double tinggiBadan = Convert.ToDouble(entTB.Text);
            double beratBadan = Convert.ToDouble(entBB.Text);
            double hasilBrocha = Math.Ceiling((tinggiBadan - 100) - (0.15d * (tinggiBadan - 100)));
            double hasilBMI = Math.Ceiling(beratBadan / ((tinggiBadan * 0.01d) * (tinggiBadan * 0.01d)));
            if (hasilBMI < 18)
            {
                kesimpulan.Text = "Kurus (kurang dari 18)";
            }
            else if (hasilBMI <= 25)
            {
                kesimpulan.Text = "Normal (18 - 25)";
            }
            else if (hasilBMI <= 27)
            {
                kesimpulan.Text = "Kegemukan (25 - 27)";
            }
            else
            {
                kesimpulan.Text = "Obesitas (lebih dari 27)";
            }
            nilaiBMI.Text = hasilBMI.ToString();
            nilaiBrocha.Text = hasilBrocha.ToString();
        }

        private void BtnHitungBBIL_Clicked(object sender, EventArgs e)
        {
            double tinggiBadan = Convert.ToDouble(entTB.Text);
            double beratBadan = Convert.ToDouble(entBB.Text);
            double hasilBrocha = Math.Ceiling((tinggiBadan - 100) - (0.10d * (tinggiBadan - 100)));
            double hasilBMI = Math.Ceiling(beratBadan / ((tinggiBadan * 0.01d) * (tinggiBadan * 0.01d)));
            if (hasilBMI < 17)
            {
                kesimpulan.Text = "Kurus (kurang dari 17)";
            }
            else if (hasilBMI <= 23)
            {
                kesimpulan.Text = "Normal (17 - 23)";
            }
            else if (hasilBMI <= 27)
            {
                kesimpulan.Text = "Kegemukan (23 - 27)";
            }
            else
            {
                kesimpulan.Text = "Obesitas (lebih dari 27)";
            }
            nilaiBMI.Text = hasilBMI.ToString();
            nilaiBrocha.Text = hasilBrocha.ToString();
        }
    }
}
