using org.mariuszgromada.math.mxparser;

namespace MathParser
{
    public class Parser
    {
        private Function _func;

        public int ArgumentsNumber => _func.getArgumentsNumber();

        public Parser()
        {
            _func = new Function("");
        }

        public void ConvertFunc(string expression)
            => _func = new Function(expression);

        public double Calculate(params double[] parametres)
        {
            if(parametres.Length != _func.getArgumentsNumber())
            {
                throw new ArgumentException("the number of parameters does not match");
            }

            double result = _func.calculate(parametres);

            if (Double.IsNaN(result))
            {
                throw new ArgumentException("Incorrect function");
            }

            return result;
        }

        public string ArgumentName(int index) => _func.getParameterName(index);
    }
}