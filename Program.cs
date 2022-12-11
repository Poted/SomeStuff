using System;
using System.Diagnostics;

class Program 
{
    static void Main(string[] args)
    {
        int[]   arr = {1, 3, 6, 4, 1, 2, 919191},
                aar = {0},
                rar = {-1, -2, 0, 1, 91827364
            };
            
        var method = MissingInteger(arr);
        var method2 = MissingInteger(aar);
        var method3 = MissingInteger(rar);

        System.Console.WriteLine(  
            "First method exTime: " + TimeMethod(() => MissingInteger(arr)) + "\n" +
            "Second method exTime: " + TimeMethod(() => MissingInteger(aar)) + "\n" +
            "Third method exTime: " + TimeMethod(() => MissingInteger(rar))
        );

        System.Console.WriteLine(
            " arr: " + MissingInteger(arr) +
            "\n aar: " + MissingInteger(aar) +
            "\n rar: " + MissingInteger(rar)
        );
    }

    static long TimeMethod(Action methodToTime)
    {//Counts time of method passed as a parameter to execute in miliseconds;
        //use with lambda if it has parameters: TimeMethod(() => SomeMethod())
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        methodToTime();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }


    private static int MissingInteger(int[] arr)
    {//returns the lowest integer that is not in the array;

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
    {//Return true if array has only one occurance of int one after each other

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

    public static string ReturnMultipliedChars(string S) 
    {//Returns a chars that are multiplied in a string;

        string ret = string.Empty;

        var cj =
        S.ToLower().GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key).ToList();
       
       ret = string.Join(",", cj.ToArray());
       return ret;
        
    }
}
