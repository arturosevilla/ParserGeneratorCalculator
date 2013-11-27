using EvaluationGrammar.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluationGrammar
{
    public class Environment
    {
        private Dictionary<string, int?> variables;

        public Environment()
        {
            variables = new Dictionary<string, int?>();
        }

        public int GetValue(string variable)
        {
            try
            {
                int? valueOfVar = variables[variable];
                if (valueOfVar == null)
                {
                    throw new UninitializedVariableUseException(variable);
                }
                return valueOfVar.Value;
            }
            catch (KeyNotFoundException)
            {
                throw new UndefinedVariableException(variable);
            }
        }

        public void DefineVariable(string variable)
        {
            if (variables.ContainsKey(variable))
            {
                throw new VariableRedefinitionException(variable);
            }
            variables[variable] = null;
        }

        public void AssignValue(string variable, int value)
        {
            if (!variables.ContainsKey(variable))
            {
                throw new UndefinedVariableException(variable);
            }
            variables[variable] = value;
        }
    }
}