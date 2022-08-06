namespace HelloWorld
{
    //reference
    //https://www.youtube.com/watch?v=MK-NZ4hN7rs
    //https://gist.github.com/Schachte/87d7c0165a584f26b3ad7845f8010387

    public class SlidingWindow
    {
        public static void Main(string[] args){
            
             Console.WriteLine("FIRST question.......");
            Console.WriteLine(GetMaxSumOfSubArrayOfSizeK(new int[]{4,3,2,5,1,6,8,3,2,7}, 3));
            
            Console.WriteLine(" ");
            Console.WriteLine("2ND question.......");
            Console.WriteLine(GetSmallestSubArrSize(new int[]{4,2,2,7,8,1,2,8,10}, 8));
            

            Console.WriteLine(" ");
            Console.WriteLine("3RD question.......");
            Console.WriteLine(LongestSubstringKDistinct("HHHKKABC",2));
        }

        /*****
        * find the maximium sum of subarray of  a fixed size K
        */
        public static int GetMaxSumOfSubArrayOfSizeK(int[] arr, int k)
        {
            int maxVal = 0;
            int current = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                current += arr[i];

                //hit window size
                if(i >= k-1)
                {
                    maxVal = Math.Max(maxVal,current);

                    //substract the 1 item from the total
                    current -= arr[i - (k-1)];
                }
            }

            return maxVal;
        }


        /*****
        * find the smallest subarray with the given sum
        * smallest subarray = smallest window
        **/
        public static int GetSmallestSubArrSize(int[] arr, int k)
        {
            int minWindowSize = int.MaxValue;
            int currWindowSum = 0;
            int windowStartIndex = 0;

            for(int WindowEndIndex = 0; WindowEndIndex < arr.Length; WindowEndIndex++)
            {
                currWindowSum +=arr[WindowEndIndex];

                //isit greater or equal than the target sum, k
                while(currWindowSum >= k)
                {
                    //get the window size
                    minWindowSize = Math.Min(minWindowSize,(WindowEndIndex - windowStartIndex +1));
                    
                    //substract left side
                    currWindowSum -= arr[windowStartIndex];

                    //increase start index
                    windowStartIndex++;
                }
            }
            return minWindowSize;
        }

        public static int LongestSubstringKDistinct(string str, int k)
        {
            int windowStart = 0;
            int maxLength = 0;

            Dictionary<char,int> charDict= new Dictionary<char, int>();

            for(int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                //
                char rightChar = str[windowEnd];
                
                //addd to dict the char and the count
                if (charDict.ContainsKey(rightChar)){
                       charDict[rightChar]  = charDict[rightChar] + 1;
                }
                else{
                    charDict[rightChar]  = 1;
                }

                //while the number of distinct character is more than what we want
                while (charDict.Count > k) 
                {
                    //get the char, becuase its the key, from the left side of window
                    char leftChar = str[windowStart];

                    //reduce count from dict
                    charDict[leftChar]  = charDict[leftChar] - 1;

                    //remove the item from dict
                    if(charDict[leftChar] == 0)
                    {
                        charDict.Remove(leftChar);
                    }

                    windowStart++;
                }

                 maxLength = Math.Max(maxLength, windowEnd - windowStart + 1); 
            }


                return maxLength;
        }

    }

    
}