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

        public MathProblemType ProblemType
        {
            get {
                return (BindingContext as MathGameViewModel).ProblemType;
            }
            set {
                (BindingContext as MathGameViewModel).ProblemType = value;
            }
        }
    }
}

