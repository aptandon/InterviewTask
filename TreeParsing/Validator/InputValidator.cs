namespace TreeParsing.Validator
{
    public static class InputValidator
    {
        public static List<int> ValidateInput(string input)
        {
            var numbers = new List<int>();
            var tokens = input.Split(',');

            foreach (var token in tokens)
            {
                if (int.TryParse(token, out int number) && number > 0)
                {
                    numbers.Add(number);
                }
                else
                {
                    return null;
                }
            }

            return numbers;
        }
    }
}
