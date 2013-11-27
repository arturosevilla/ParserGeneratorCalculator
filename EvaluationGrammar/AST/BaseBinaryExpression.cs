using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluationGrammar.AST
{
    public abstract class BaseBinaryExpression : Expression
    {
        private string Operator;
        private Expression Left;
        private Expression Right;
        private delegate int BooleanOperator(int a, int b);

        protected void SetValues(string operator_, Expression left, Expression right)
        {
            Operator = operator_;
            Left = left;
            Right = right;
        }


        private int Sum(int a, int b)
        {
            return a + b;
        }

        private int Multiply(int a, int b)
        {
            return a * b;
        }

        private int Difference(int a, int b)
        {
            return a - b;
        }

        private int Divide(int a, int b)
        {
            return a / b;
        }

        private int Modulo(int a, int b)
        {
            return a % b;
        }

        private BooleanOperator GetOperator()
        {
            switch (Operator)
            {
                case "+":
                    return Sum;
                case "-":
                    return Difference;
                case "*":
                    return Multiply;
                case "/":
                    return Divide;
                case "%":
                    return Modulo;
                default:
                    throw new InvalidOperationException("Unknown operator: " + Operator);
            }
        }

        public override EvaluationResult Evaluate(Environment env)
        {
            var leftEval = Left.Evaluate(env);
            var rightEval = Right.Evaluate(env);
            
            return new EvaluationResult {
                Result = GetOperator()((int)leftEval.Result, (int)rightEval.Result)
            };
        }

    }
}