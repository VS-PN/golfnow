using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Golfnow
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void OnLogIn(System.Object sender, System.EventArgs e)
        {
            if (UsernameField.Text == "admin" && PasswordField.Text == "adminadmin")
            {
                Console.WriteLine("Successful login");
                Navigation.PushModalAsync(new TeeTimesList(), true);
            }
            else
            {
                Console.WriteLine("Failed login");
            }
        }
    }
}
