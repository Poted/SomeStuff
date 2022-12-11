using System;
using System.Diagnostics;

class Program 
{
    static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();
        int[]   arr = {1, 3, 6, 4, 1, 2, 919191}, //5
        //              1, 1, 2, 3, 4, x, 6
                aar = {0},          //4
                rar = {-1, -2, 0, 1, 91827364};           //1

            
            
        System.Console.WriteLine(
            TimeMethod(() => Method1(1)) + 
            " arr: " + TimeMethod(() => MissingInteger(arr)) +
            "\n aar: " + MissingInteger(aar) +
            "\n rar: " + MissingInteger(rar)
            );

        

    }

    static void Method1(int a)
    {
        int i = 0;
        int i2 = i + 1;

    }


    static long TimeMethod(Action methodToTime)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        methodToTime();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }


    private static int MissingInteger(int[] arr)
    {
        HashSet<uint> hs = new HashSet<uint>();
        var orderedArray = arr.OrderBy(x => x);
        int ret = new int();
        if(arr != null)
        {
            foreach (int a in orderedArray)
            {
                try 
                {
                    if(hs.Add(Convert.ToUInt32(a)))
                    {
                        ret = a + 1;
                    }
                }
                catch (Exception)
                {
                    ret = 1;
                }
                
                if(!arr.Contains(ret))
                return ret;            
            }
        }
        return ret;
    }

    private static bool PermCheck(int[] arr)
    {
        // //Sample input:
        // int[]   arr = {1, 2, 4, 5, 89, 144, 3}, //false
        //         aar = {1, 2, 5, 4, 3},          //true
        //         rar = {1, 2, 1, 3, 4};          //false
        // System.Console.WriteLine(
        //     " arr: " + PermCheck(arr) +
        //     "\n aar: " + PermCheck(aar) +
        //     "\n rar: " + PermCheck(rar)
        //     );

        if (arr != null)
        {
            HashSet<int> hs = new HashSet<int>();
            foreach (int a in arr)
            {
                if (!hs.Contains(a))
                hs.Add(a);
                else return false;
            }
            
            if(hs.Count() != arr.Max())
            return false;
        }


        return true;
    }

    public static string ReturnMultipliedChars(string S) {

        string ret = string.Empty;

        var cj =
        S.ToLower().GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key).ToList();
       
       ret = string.Join(",", cj.ToArray());
       return ret;
        
    }
}