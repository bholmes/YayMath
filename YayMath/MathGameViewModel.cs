using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace YayMath
{
    public class MathGameViewModel : SimpleViewModel
    {
        const string selectAnswerMessage = "Select the correct answer.";
        const string correctAnswerMessage = "Correct!";
        const string incorrectAnswerMessage = "Incorrect.  Please try again.";

        MathProblemViewModel currentProblem;
        ISoundPlayer soundPlayer;

        public MathGameViewModel (MathProblemType problemType = MathProblemType.PositiveAdditionOrSubtraction)
        {
            this.problemType = problemType;
            CreateProblem ();
            Task.Run (() => soundPlayer = DependencyService.Get<ISoundPlayer> ());
            SelectAnswer = new Command<int> ((val) => OnSelectAnswer (val).NoWarning ());
        }

        public ICommand SelectAnswer { get; private set; }

        public MathProblemViewModel CurrentProblem {
            get {
                return currentProblem;
            }
            set {
                if (currentProblem == value)
                    return;
                currentProblem = value;
                RaisePropertyChanged ();
            }
        }

        MathProblemType problemType;
        public MathProblemType ProblemType
        {
            get
            {
                return problemType;
            }
            set
            {
                if (problemType == value)
                    return;
                problemType = value;
                CreateProblem ();
                RaisePropertyChanged ();
            }
        }

        string status;
        public string Status {
            get {
                return status;
            }
            set {
                if (status == value)
                    return;
                status = value;
                RaisePropertyChanged ();
            }
        }

        bool readyForAnswer;
        public bool ReadyForAnswer {
            get {
                return readyForAnswer;
            }
            set {
                if (readyForAnswer == value)
                    return;
                readyForAnswer = value;
                RaisePropertyChanged ();
            }
        }

        void CreateProblem ()
        {
            var lproblem = MathProblemCreator.CreateProblem (ProblemType);
            CurrentProblem = new MathProblemViewModel (lproblem);
            Status = selectAnswerMessage;

            ReadyForAnswer = true;
        }

        async Task OnSelectAnswer (int value)
        {
            if (CurrentProblem.Answer == value) {
                Status = correctAnswerMessage;
                ReadyForAnswer = false;

                soundPlayer?.PlayYay ();

                await Task.Delay (1500);

                CreateProblem ();
            } else {
                Status = incorrectAnswerMessage;
                soundPlayer?.PlayBoo ();
            }
        }
    }
}

