using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode._2015.Day04
{
    public class CryptoMining(string puzzlePath)
    {
        private readonly string _puzzleData = File.ReadAllText(puzzlePath);

        public int Part1()
        {
            return FindAppendedNumber("00000");
        }

        private int FindAppendedNumber(string target)
        {
            var i = 0;
            using var md5 = MD5.Create();
            while (true)
            {
                var input = $"{_puzzleData}{i}";
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                if (sb.ToString().StartsWith(target))
                    return i;

                i++;
            }
        }

        public int Part2()
        {
            return FindAppendedNumber("000000");
        }

    }
}
