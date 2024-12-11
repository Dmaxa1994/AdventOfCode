using AdventOfCode._2015.Day01;
using AdventOfCode._2015.Day02;
using AdventOfCode._2015.Day03;
using AdventOfCode._2015.Day04;
using AdventOfCode._2015.Day05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    public class AoC2015
    {
        public void Do2015()
        {
            var floorsSample = new Floors(@"2015\day01\sample.txt");
            var floors = new Floors(@"2015\day01\puzzleData.txt");
            
            Console.WriteLine($"2015 Day 01 Part 1 total: {floorsSample.Part1()}");
            Console.WriteLine($"2015 Day 01 Part 1 total: {floors.Part1()}");
            Console.WriteLine($"2015 Day 01 Part 2 total: {floorsSample.Part2()}");
            Console.WriteLine($"2015 Day 01 Part 2 total: {floors.Part2()}");

            
            var wrappingSample = new Wrapping(@"2015\day02\sample.txt");
            var wrapping = new Wrapping(@"2015\day02\puzzleData.txt");
            Console.WriteLine($"2015 Day 02 Part 1 sample total: {wrappingSample.Part1()}");
            Console.WriteLine($"2015 Day 02 Part 1 total: {wrapping.Part1()}");
            Console.WriteLine($"2015 Day 02 Part 2 sample total: {wrappingSample.Part2()}");
            Console.WriteLine($"2015 Day 02 Part 2 total: {wrapping.Part2()}");

            var deliverySample = new Delivery(@"2015\day03\sample.txt");
            var delivery = new Delivery(@"2015\day03\puzzleData.txt");
            Console.WriteLine($"2015 Day 03 Part 1 sample total: {deliverySample.Part1()}");
            Console.WriteLine($"2015 Day 03 Part 1 total: {delivery.Part1()}");
            Console.WriteLine($"2015 Day 03 Part 2 sample total: {deliverySample.Part2()}");
            Console.WriteLine($"2015 Day 03 Part 2 total: {delivery.Part2()}");

            //var cryptoMiningSample = new CryptoMining(@"2015\day04\sample.txt");
            //var crypto = new CryptoMining(@"2015\day04\puzzleData.txt");
            //Console.WriteLine($"2015 Day 04 Part 1 sample total: {cryptoMiningSample.Part1()}");
            //Console.WriteLine($"2015 Day 04 Part 1 total: {crypto.Part1()}");
            //Console.WriteLine($"2015 Day 04 Part 2 sample total: {cryptoMiningSample.Part2()}");
            //Console.WriteLine($"2015 Day 04 Part 2 total: {crypto.Part2()}");
            Console.WriteLine("Skipping day 4 it takes forever");

            var listCheckingSample = new ListChecking(@"2015\day05\sample.txt");
            var listChecking = new ListChecking(@"2015\day05\puzzleData.txt");
            Console.WriteLine($"2015 Day 05 Part 1 sample total: {listCheckingSample.Part1()}");
            Console.WriteLine($"2015 Day 05 Part 1 total: {listChecking.Part1()}");
            Console.WriteLine($"2015 Day 05 Part 2 sample total: {listCheckingSample.Part2()}");
            Console.WriteLine($"2015 Day 05 Part 2 sample total: {listChecking.Part2()}");
        }
    }
}
