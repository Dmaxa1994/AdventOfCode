using AdventOfCode._2023.Day01;
using AdventOfCode._2023.Day02;
using AdventOfCode._2023.Day04;

var trebuchet = new Trebuchet();
var cube = new CubeConundrum();

var scratchCard = new Scratchcards();

Console.WriteLine($"Day 1 Part 1 total {trebuchet.GetTotal()}");
Console.WriteLine($"Day 1 Part 2 total {trebuchet.GetTotalWithWords()}");
Console.WriteLine($"Day 2 Part 1 total {cube.GetSumOfValidGames()}");
Console.WriteLine($"Day 2 Part 2 total {cube.GetSumOfPowers()}");
Console.WriteLine($"Day 3 Part 1 total ");
Console.WriteLine($"Day 3 Part 2 total ");
Console.WriteLine($"Day 4 Part 1 total {scratchCard.GetScratchCardTotals()}");
Console.WriteLine($"Day 4 Part 2 total {scratchCard.CalculateTotalNumberOfCards()}");