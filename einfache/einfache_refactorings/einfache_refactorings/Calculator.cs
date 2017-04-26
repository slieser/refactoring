namespace einfache_refactorings
{
    public class Calculator
    {
        private readonly int[] _werte;

        public Calculator(int[] werte) {
            _werte = werte;
        }

        public int Summe() {
            var result = 0;
            foreach (var i in _werte) {
                result += i;
            }
            return result;
        }



    }

    public class DoIt
    {
        public void Call()
        {
            var calc = new Calculator(new[] { 1, 2, 3, 4 });
            var result = calc.Summe();
        }

    }
}