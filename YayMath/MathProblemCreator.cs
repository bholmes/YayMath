using System;

namespace YayMath
{
    public class MathProblemCreator
    {
        const int maxAnswer = 19;
        const int maxMultiplicand = 9;
        const int maxMultiplier = 12;

        public static MathProblem CreateProblem (MathProblemType problemType)
        {
            var problem = new MathProblem ();

            switch (problemType)
            {
                case MathProblemType.PositiveAdditionOrSubtraction:
                    if (RandomBranch ())
                        CreateAddProblem (problem);
                    else
                        CreateSubtractProblem (problem);
                    break;
                case MathProblemType.SignedAdditionOrSubrtaction:
                    CreateSignedAdditionOrSubtractionProblem (problem);
                    break;
                case MathProblemType.PositiveMultiplication:
                    CreatePositiveMultiplicationProblem (problem);
                    break;
                case MathProblemType.SignedMultiplication:
                    CreateSignedMultiplicationProblem (problem);
                    break;
                default:
                    throw new NotImplementedException ();
            }

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

        static void CreateSignedAdditionOrSubtractionProblem (MathProblem problem)
        {
            var optionSetters = new[] {
                new Action<int> ((val) => problem.Option1 = val),
                new Action<int> ((val) => problem.Option2 = val),
                new Action<int> ((val) => problem.Option3 = val),
            };

            problem.Operand = RandomBranch () ? Operand.Add : Operand.Subtract;

            problem.Value1 = GetRandomNumber (-maxAnswer/2, maxAnswer/2);
            problem.Value2 = GetRandomNumber (-maxAnswer/2, maxAnswer/2);

            problem.Answer = problem.Value1 + (problem.Value2 * (problem.Operand == Operand.Add ? 1 : -1));

            var incorrect1 = problem.Answer;
            while (incorrect1 == problem.Answer)
                incorrect1 = GetRandomNumber (-maxAnswer, maxAnswer);

            var incorrect2 = problem.Answer;
            while (incorrect2 == problem.Answer || incorrect2 == incorrect1)
                incorrect2 = GetRandomNumber (-maxAnswer, maxAnswer);

            problem.CorrectOption = GetRandomNumber (1, 3);
            optionSetters[problem.CorrectOption - 1] (problem.Answer);

            var curIndex = problem.CorrectOption + 1;
            if (curIndex > 3)
                curIndex = 1;
            optionSetters[curIndex - 1] (incorrect1);

            curIndex++;
            if (curIndex > 3)
                curIndex = 1;
            optionSetters[curIndex - 1] (incorrect2);
        }

        static void CreatePositiveMultiplicationProblem (MathProblem problem)
        {
            var optionSetters = new[] {
                new Action<int> ((val) => problem.Option1 = val),
                new Action<int> ((val) => problem.Option2 = val),
                new Action<int> ((val) => problem.Option3 = val),
            };

            problem.Operand = Operand.Multiply;

            problem.Value1 = GetRandomNumber (2, maxMultiplicand);
            problem.Value2 = GetRandomNumber (2, maxMultiplier);

            problem.Answer = problem.Value1 * problem.Value2;

            int createWrongAnswer (int avoid)
            {
                var stuff = RandomBranch () ? (problem.Value1, problem.Value2) : (problem.Value2, problem.Value1);

                var incorrect = problem.Answer;
                while (incorrect == problem.Answer || incorrect == avoid || incorrect == 0)
                    incorrect = stuff.Item1 * GetRandomNumber (stuff.Item2 - 2, stuff.Item2 + 2);

                return incorrect;
            }

            var incorrect1 = createWrongAnswer (problem.Answer);
            var incorrect2 = createWrongAnswer (incorrect1);

            problem.CorrectOption = GetRandomNumber (1, 3);
            optionSetters[problem.CorrectOption - 1] (problem.Answer);

            var curIndex = problem.CorrectOption + 1;
            if (curIndex > 3)
                curIndex = 1;
            optionSetters[curIndex - 1] (incorrect1);

            curIndex++;
            if (curIndex > 3)
                curIndex = 1;
            optionSetters[curIndex - 1] (incorrect2);
        }

        static void CreateSignedMultiplicationProblem (MathProblem problem)
        {
            CreatePositiveMultiplicationProblem (problem);

            problem.Value1 = RandomBranch () ? problem.Value1 : -problem.Value1;
            problem.Value2 = RandomBranch () ? problem.Value2 : -problem.Value2;

            problem.Answer = problem.Value1 * problem.Value2;

            if (problem.CorrectOption == 1)
            {
                problem.Option1 = problem.Answer;
                if (RandomBranch ())
                {
                    problem.Option2 = RandomBranch () ? -problem.Answer : -problem.Option3;
                }
                else
                {
                    problem.Option3 = RandomBranch () ? -problem.Answer : -problem.Option2;
                }
            }
            else if (problem.CorrectOption == 2)
            {
                problem.Option2 = problem.Answer;
                if (RandomBranch ())
                {
                    problem.Option1 = RandomBranch () ? -problem.Answer : -problem.Option3;
                }
                else
                {
                    problem.Option3 = RandomBranch () ? -problem.Answer : -problem.Option1;
                }
            }
            else if (problem.CorrectOption == 3)
            {
                problem.Option3 = problem.Answer;
                if (RandomBranch ())
                {
                    problem.Option1 = RandomBranch () ? -problem.Answer : -problem.Option2;
                }
                else
                {
                    problem.Option2 = RandomBranch () ? -problem.Answer : -problem.Option1;
                }
            }
        }

        static readonly Random getrandom = new Random ();
        static readonly object syncLock = new object ();
        static int GetRandomNumber (int min, int max)
        {
            lock (syncLock) { // synchronize
                return getrandom.Next (min, max + 1);
            }
        }

        static bool RandomBranch ()
        {
            return GetRandomNumber (1, 2) == 1;
        }
    }
}

