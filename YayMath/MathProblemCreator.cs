using System;

namespace YayMath
{
    public class MathProblemCreator
    {
        const int maxAnswer = 19;

        public static MathProblem CreateProblem ()
        {
            var problem = new MathProblem ();

            var plusMinus = GetRandomNumber (1, 2);

            if (plusMinus == 1)
                CreateAddProblem (problem);
            else
                CreateSubtractProblem (problem);

            return problem;
        }

        static void CreateAddProblem (MathProblem problem)
        {
            var optionSetters = new [] {
                new Action<int> ((val) => problem.Option1 = val),
                new Action<int> ((val) => problem.Option2 = val),
                new Action<int> ((val) => problem.Option3 = val),
            };

            problem.Operand = Operand.Add;

            problem.Value1 = GetRandomNumber (0, maxAnswer);
            problem.Value2 = GetRandomNumber (0, maxAnswer - problem.Value1);

            problem.Answer = problem.Value1 + problem.Value2;

            var incorrect1 = problem.Answer;
            while (incorrect1 == problem.Answer)
                incorrect1 = GetRandomNumber (0, maxAnswer);

            var incorrect2 = problem.Answer;
            while (incorrect2 == problem.Answer || incorrect2 == incorrect1)
                incorrect2 = GetRandomNumber (0, maxAnswer);

            problem.CorrectOption = GetRandomNumber (1, 3);
            optionSetters [problem.CorrectOption - 1] (problem.Answer);

            var curIndex = problem.CorrectOption + 1;
            if (curIndex > 3)
                curIndex = 1;
            optionSetters [curIndex - 1] (incorrect1);

            curIndex++;
            if (curIndex > 3)
                curIndex = 1;
            optionSetters [curIndex - 1] (incorrect2);
        }

        static void CreateSubtractProblem (MathProblem problem)
        {
            var optionSetters = new [] {
                new Action<int> ((val) => problem.Option1 = val),
                new Action<int> ((val) => problem.Option2 = val),
                new Action<int> ((val) => problem.Option3 = val),
            };

            problem.Operand = Operand.Subtract;

            problem.Value1 = GetRandomNumber (0, maxAnswer);
            problem.Value2 = GetRandomNumber (0, problem.Value1);

            problem.Answer = problem.Value1 - problem.Value2;

            var incorrect1 = problem.Answer;
            while (incorrect1 == problem.Answer)
                incorrect1 = GetRandomNumber (0, maxAnswer);

            var incorrect2 = problem.Answer;
            while (incorrect2 == problem.Answer || incorrect2 == incorrect1)
                incorrect2 = GetRandomNumber (0, maxAnswer);

            problem.CorrectOption = GetRandomNumber (1, 3);
            optionSetters [problem.CorrectOption - 1] (problem.Answer);

            var curIndex = problem.CorrectOption + 1;
            if (curIndex > 3)
                curIndex = 1;
            optionSetters [curIndex - 1] (incorrect1);

            curIndex++;
            if (curIndex > 3)
                curIndex = 1;
            optionSetters [curIndex - 1] (incorrect2);
        }

        static readonly Random getrandom = new Random ();
        static readonly object syncLock = new object ();
        static int GetRandomNumber (int min, int max)
        {
            lock (syncLock) { // synchronize
                return getrandom.Next (min, max + 1);
            }
        }
    }
}

