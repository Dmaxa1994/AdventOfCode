using System.Data;
using System.Numerics;
using System.Text;

namespace AdventOfCode._2024.Day09
{
    public class DiskDefrag
    {
        private readonly string _puzzleData = File.ReadAllText(@"2024\day09\puzzleData.txt");
        //private readonly string _puzzleData = File.ReadAllText(@"2024\day09\sample.txt");

        public long Part1()
        {
            var diskData = AnalyzeDisk();
            var defragged = MoveBlock(diskData.data, diskData.emptySpace);
            return GetCheckSum(defragged, false);

        }

        public long GetCheckSum(string defragged, bool ignoreDots)
        {
            var total = 0L;
            var j = 0;
            for (var i = 3; i < defragged.Length; i+=4)
            {
                var h = $"{defragged[i - 3]}{defragged[i - 2]}{defragged[i - 1]}{defragged[i]}";
                if (h.Contains("."))
                {
                    if (ignoreDots)
                    {
                        j++;
                        continue;
                    }

                    return total;
                }

                var d = long.Parse(h, System.Globalization.NumberStyles.HexNumber);

                total += d * j;
                j++;
            }

            return total;
        }

        public string MoveBlock(string data, List<int> emptySpace)
        {
            var revData = string.Join("", data.Reverse());
            var defragged = new StringBuilder(data);
            var totalEmptySpace = emptySpace.Count * 4;
            for (var i = 3; i < revData.Length;i +=4)
            {
                var h =  string.Join("", $"{revData[i-3]}{revData[i-2]}{revData[i-1]}{revData[i]}".Reverse());
                if (h == "....") continue;
                var position = emptySpace[0];
                defragged[position] = h[0];
                defragged[position+1] = h[1];
                defragged[position+2] = h[2];
                defragged[position+3] = h[3];
                emptySpace.RemoveAt(0);
                if (!emptySpace.Any())
                    break;
            }

            var a = defragged.ToString();
            var b = a.Substring(0, data.Length - totalEmptySpace);
            var d = b += "".PadRight(totalEmptySpace, '.');
            return d;
        }

        public (string data, List<int> emptySpace, Dictionary<string, (int startPos, int chunkCount)>) AnalyzeDisk()
        {
            var fragmented = "";
            var emptySpace = new List<int>();
            var j = 0;
            var spaceCount = 0;
            var items = new Dictionary<string, (int startPos, int chunkCount)>();
            
            for (var i = 0; i < _puzzleData.Length; i++)
            {
                var empty = false;
                var c = _puzzleData[i];
                var count = int.Parse($"{c}");
                if (i % 2 == 0)
                {
                    for (var f = 0; f < count; f++)
                    {
                        var frag = $"{j:X4}";
                        if (items.ContainsKey(frag))
                        {
                            var t = items[frag];
                            t.chunkCount++;
                            items[frag] = t;
                        }
                        else
                        {
                            items.Add(frag, (spaceCount, 1));
                        }
                        fragmented += frag;
                    }
                    j++;
                }
                else
                {
                    for (var f = 0; f < count; f++)
                    {
                        fragmented += "....";
                    }
                    empty = true;
                }

                for (var k = 0; k < count; k++)
                {
                    if (empty)
                    {
                        emptySpace.Add(spaceCount);
                    }
                    spaceCount+= 4;
                }
            }

            return (fragmented, emptySpace, items);
        }

        public string MoveFile((string data, List<int> emptySpace, Dictionary<string, (int startPos, int chunkCount)> dict) diskData)
        {
            var revData = string.Join("", diskData.data.Reverse());
            var defragged = new StringBuilder(diskData.data);
            var sameFile = true;
            var filePart = "";
            var chunkCount = 0;
            for (var i = 3; i < revData.Length;i +=4)
            {
                var h =  string.Join("", $"{revData[i-3]}{revData[i-2]}{revData[i-1]}{revData[i]}".Reverse());
                
                if (h == "....") continue;
                if (filePart == h || filePart == "")
                {
                    filePart = h;
                    chunkCount++;
                    sameFile = true;
                }
                else
                {
                    sameFile = false;
                }

                if (sameFile) continue;

                var startPos = FindDataWriteStartPos(chunkCount * 4, diskData.emptySpace);
                if (startPos != -1)
                {
                    var item = diskData.dict[filePart];
                    var length = item.chunkCount * 4;
                    var origStartPos = item.startPos;
                    var position = diskData.emptySpace[startPos];

                    if (origStartPos > position)
                    {

                        for (var k = 0; k < length; k++)
                        {
                            defragged[origStartPos + k] = '.';
                        }

                        for (var j = 0; j < chunkCount; j++)
                        {
                            position = diskData.emptySpace[startPos];
                            defragged[position] = filePart[0];
                            defragged[position + 1] = filePart[1];
                            defragged[position + 2] = filePart[2];
                            defragged[position + 3] = filePart[3];
                            diskData.emptySpace.RemoveAt(startPos);
                            if (!diskData.emptySpace.Any())
                                break;
                        }
                    }
                }

                chunkCount = 1;
                filePart = h;
            }

            var a = defragged.ToString();
            return a;
        }

        private int FindDataWriteStartPos(int fileSize, List<int> diskDataEmptySpace)
        {
            if (fileSize == 4) return 0;

            var startPos = -1;
            var length = 4;
            for (var i = 1; i < diskDataEmptySpace.Count; i++)
            {
                if (diskDataEmptySpace[i] == diskDataEmptySpace[i - 1] + 4)
                {
                    length += 4;
                }
                else
                {
                    length = 4;
                }

                if (length >= fileSize)
                {
                    startPos = i - ((fileSize/4)-1);
                    break;
                }
            }

            return startPos;
        }

        public long Part2()
        {
            var diskData = AnalyzeDisk();
            var defragged = MoveFile(diskData);
            return GetCheckSum(defragged, true);
        }

    }
}
