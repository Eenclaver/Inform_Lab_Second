using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScndLB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }
        private async void tstBtnClick(object sender, EventArgs args)
        {
            var mp = new test();
            await Navigation.PushModalAsync(mp);
        }

        private async void researchBtnClick(object sender, EventArgs args)
        {
            var mp = new Research();
            await Navigation.PushModalAsync(mp);
        }
    }
}
