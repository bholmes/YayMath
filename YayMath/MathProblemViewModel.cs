using System;

namespace YayMath
{
    public class MathProblemViewModel : SimpleViewModel
    {
        MathProblem mathProblem;

        public MathProblemViewModel (MathProblem mathProblem)
        {
            this.mathProblem = mathProblem;
        }

        public int Value1 => mathProblem.Value1;
        public int Value2 => mathProblem.Value2;
        public Operand Operand  => mathProblem.Operand;
        public int Answer => mathProblem.Answer;
        public int Option1 => mathProblem.Option1;
        public int Option2 => mathProblem.Option2;
        public int Option3 => mathProblem.Option3;
        public int CorrectOption => mathProblem.CorrectOption;
    }
}

