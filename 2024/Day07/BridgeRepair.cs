using System.Data;
using System.Numerics;
using System.Text;

namespace AdventOfCode._2024.Day07
{
    public class BridgeRepair
    {
        private readonly string[] _puzzleData = File.ReadAllLines(@"2024\day07\puzzleData.txt");
        //private readonly string[] _puzzleData = File.ReadAllLines(@"2024\day07\sample.txt");

        public long Part1()
        {
            var total = 0L;

            foreach (var line in _puzzleData)
            {
                var lineParts = line.Split(':');
                var target = long.Parse(lineParts[0]);
                var numbers = lineParts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var numOperators = numbers.Count - 1;
                var totalCombinations = (int)Math.Pow(2, numOperators);

                var expressions = new List<string>();
                for (var i = 0; i < totalCombinations; i++)
                {
                    var expression = numbers[0];
                    for (var j = 0; j < numOperators; j++)
                    {
                        if ((i & (1 << j)) != 0)
                            expression += "*" + numbers[j + 1];
                        else
                            expression += "+" + numbers[j + 1];
                    }

                    expressions.Add(expression);
                }
                
                foreach (var expression in expressions)
                {
                    var foundOperator = false;
                    var smallExpression = "";
                    var calculationTotal = 0L;
                    foreach (var c in expression)
                    {
                        if (char.IsDigit(c))
                        {
                            smallExpression += c;
                        }
                        else
                        {
                            if (foundOperator)
                            {
                                calculationTotal = CalculateExpression(smallExpression);
                                smallExpression = $"{calculationTotal}";
                            }
                            foundOperator = true;
                            smallExpression += $" {c} ";
                        }
                    }

                    calculationTotal = CalculateExpression(smallExpression);
                    if (calculationTotal == target)
                    {
                        total += target;
                        break;
                    }
                }
            }
            return total;

        }

        public long CalculateExpression(string smallExpression)
        {
            var parts = smallExpression.Split(" ");
            var num1 = long.Parse(parts[0]);
            var num2 = long.Parse(parts[2]);
            switch (parts[1])
            {
                case "+": 
                    return num1 + num2;
                case "*":
                    return num1 * num2;
                case "|":
                    return long.Parse($"{num1}{num2}");
                    
            }
            return 0;
        }

        public long Part2()
        {
            var total = 0L;

            foreach (var line in _puzzleData)
            {
                var lineParts = line.Split(':');
                var target = long.Parse(lineParts[0]);
                var numbers = lineParts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var numOperators = numbers.Count - 1;
                var totalCombinations = (int)Math.Pow(3, numOperators);

                var expressions = new List<string>();
                for (var i = 0; i < totalCombinations; i++)
                {
                    var expression = numbers[0];
                    for (var j = 0; j < numOperators; j++)
                    {
                        var operatorIndex = (i / (int)Math.Pow(3, j)) % 3;

                        switch (operatorIndex)
                        {
                            case 0:
                                expression += "+" + numbers[j + 1];
                                break;
                            case 1:
                                expression += "*" + numbers[j + 1];
                                break;
                            case 2:
                                expression += "|" + numbers[j + 1];
                                break;
                        }
                    }

                    expressions.Add(expression);
                }
                
                foreach (var expression in expressions)
                {
                    var foundOperator = false;
                    var smallExpression = "";
                    var calculationTotal = 0L;
                    foreach (var c in expression)
                    {
                        if (char.IsDigit(c))
                        {
                            smallExpression += c;
                        }
                        else
                        {
                            if (foundOperator)
                            {
                                calculationTotal = CalculateExpression(smallExpression);
                                smallExpression = $"{calculationTotal}";
                            }
                            foundOperator = true;
                            smallExpression += $" {c} ";
                        }
                    }

                    calculationTotal = CalculateExpression(smallExpression);
                    if (calculationTotal == target)
                    {
                        total += target;
                        break;
                    }
                }
            }
            return total;
        }

    }
}
