using System;
using Xamarin.Forms;

namespace YayMath
{
    public partial class MathGamePage : ContentPage
    {
        public MathGamePage ()
        {
            InitializeComponent ();

            BindingContext = new MathGameViewModel ();
        }
    }


}

