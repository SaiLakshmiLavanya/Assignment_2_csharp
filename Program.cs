/*self-reflection:
1] The time-complexity constraints have been challenging and difficult.
2]I could come up with some simple logics for some problems . However some questions still had complicated loops . Further, as I am more comfortable with lists I 
usually incorporate lists where it is not required as it makes it easy for me to work around
3] Awareness about dictionary and group by clauses have been obtained
4] All corner cases have been thoroughly checked
5]Time taken:15 hrs
*/


using System;
using System.Collections.Generic;
using System.Linq;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int max = nums.Length - 1;
                int min = 0;
                int mid = 0;
                /*This while loop uses the Binary search algorithm to search the position of the target
                or the closest position before or after which target can be inserted*/
                while (min <= max)
                {
                    mid = (min + max) / 2;
                    if (nums[mid] < target)
                    {
                        min = mid + 1;
                    }
                    else if (nums[mid] > target)
                    {
                        max = mid - 1;
                    }
                    else
                    {
                        break;
                    }

                }
                int position = 0;
                /*If the mid position that is present after the last iteration of while loop is the position where target is present then that position 
                 is returned or else if the mid position that is present after the last iteration of while loop has a value less than the target then the number 
                 must be inserted at mid+1 position and if the value at mid position is greater than the target value then that value gets inserted at mid position
                 that is present after the last iteration of while loop*/
                if (nums[mid] == target)
                {
                    position = mid;
                }
                else if (nums[mid] < target)
                {
                    position = mid + 1;

                }
                else
                {
                    position = mid;
                }
                return position;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                //This loop replaces all the special characters in my input string
                foreach (var c in paragraph)
                {
                    if (c == '"' || c == '?' || c == '.' || c == ';' || c == '!' || c == ',' || c == '\'')

                    {
                        paragraph = paragraph.Replace(Convert.ToString(c), " ");
                    }

                }
                /*This converts all the characters in my input string to lower case(This is done since the frequency of word must be calculated w.r.t word
                 and not w.r.t to upper or lower case*/
                paragraph = paragraph.ToLower();
                //This splits all the words and spaces seperated by a single space and after splitting each value is populated into a string array
                string[] new_s = paragraph.Split(" ");

                /*The GroupBy function puts all the same words and spaces into one group i.e., if ball is repeated twice in my string then the word ball is put into
                single group and this group count will be 2 since the word ball is repeated twice*/
                var frequency = new_s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                /*if the key value(i.e., words) is present in the banned array then those words and their corresponding count is removed from my dictionary frequency
                and also after replacing the special characters with a single space there might be words seperated by more than one space but these spaces are
                due to replacement of special characters and are not to be counte while calculating frequency hence the extra spaces frequency is also remove*/
                foreach (var item in frequency)
                {
                    if (banned.Contains(item.Key) || item.Key == "")
                    {
                        frequency.Remove(item.Key);
                    }


                }

                //This loop checks for which key (i.e., for which word )the frequency or count is maximum and that is returned from this method
                string final = " ";
                foreach (var item in frequency)
                {
                    if (item.Value == frequency.Values.Max())
                    {
                        final = item.Key;
                    }
                }
                return final;

                //write your code here.


            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                int maxvalue = arr.Max();
                int[] count = new int[maxvalue];
                /*This for loop iterates through my array and if the element of the array in a particular iteration is 1 then the count at 0th index is incremented by 1.
                 Similarly, the count of 2's in my array is populated at index 1 in my count array */

                for (int i = 0; i < arr.Length; i++)
                {

                    count[arr[i] - 1] = count[arr[i] - 1] + 1;
                }
                List<int> new_lst = new List<int> { };
                /*If the frequency of the number in the array is equal to the number then those numbers are added to the new_lst array and these numbers are
                 considered as lucky numbers*/
                for (int i = 0; i < count.Length; i++)
                {
                    if (count[i] == i + 1)
                    {
                        new_lst.Add(count[i]);
                    }
                }
                //The maximum of lucky numbers is obtained from this loop and if there are no lucky numbers in the array then -1 is returned 
                if (new_lst.Count != 0)
                {
                    return new_lst.Max();
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            int count = 0;
            string new_secret = "";
            string new_guess = "";
            try
            {
                //write your code here.

                for (int i = 0; i < secret.Length; i++)
                {
                    //This if loop will increment the count variable in case the secret word and guess word have the same number at the same position
                    if (secret[i] == guess[i])
                    {
                        count = count + 1;
                    }
                    //The strings new_secret and new_guess will have numbers other than the ones that are present in both strings (secret and guess) at the same location
                    else
                    {
                        new_secret = new_secret + secret[i];
                        new_guess = new_guess + guess[i];
                    }

                }
                int common = 0;
                foreach (char c in new_secret)
                {
                    /*foreach character in new_secret this loop checks whether that character is present in new_guess or not. If it is present then that character 
                     is removed from the new_guess to make sure that if new_secret has the number twice then new_guess must also have the number twice.Further
                    every time the new_guess contains the character in new_secret the variable common that contains the count of common characters that are not present 
                    at the same location is incremented by 1*/
                    if (new_guess.Contains(c))
                    {

                        new_guess = new_guess.Remove(new_guess.IndexOf(c), 1);
                        common = common + 1;
                    }
                }
                string final = "";
                //count is number of common characters at same location and common is number of common characters but at different locations
                final = Convert.ToString(count) + "A" + Convert.ToString(common) + "B";
                return final;


            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int index = 0;
                //Assigns the last index of the character at 0 to the variable last_index
                int last_index = s.LastIndexOf(s[0]);
                List<int> lengths = new List<int> { };
                /*  This outer if else loop checks if the first character is equal to the last character. If the first and last character are same then the 
                    length of string is returned*/
                if (s[0] != s[s.Length - 1])
                {
                    //The while loop is executed while the last_index variable value is less than the index of last character
                    while (last_index < s.Length - 1)
                    {
                        /*checks if the last index of all the characters between the index and current last_index value is less than the current last_index value.In case
                         the last index value of the character between the index and current last_index value is greater than the last_index variable value then the last_index 
                        value is moved forward to the last index value of that character*/
                        for (int i = index + 1; i < last_index; i++)
                        {
                            if (s.LastIndexOf(s[i]) < last_index)
                            {
                                continue;
                            }
                            else
                            {
                                last_index = s.LastIndexOf(s[i]);
                            }
                        }
                        //the length of the partitioned string is added to the list lengths 
                        lengths.Add(last_index - index + 1);
                        /*This loop is added to make sure that the process repeats until the string is partioned till the end. The process is repeated for the
                        remaining string after each partition is made*/
                        if (last_index < s.Length - 1)
                        {
                            index = last_index + 1;
                            last_index = s.LastIndexOf(s[index]);
                            /* In case the last index of the first character of my current partition is the last index of the string then no more partitions are required.
                            Hence,we break out of the while loop after adding the length of my last partition to the lengths array*/
                            if (last_index == s.Length - 1)
                            {
                                lengths.Add(last_index - index + 1);
                                break;

                            }
                        }
                    }
                    //The length of partitioned parts is returned
                    return lengths;
                }
                //This else loop returns the length of string in case my first and last character are same
                else
                {
                    List<int> len = new List<int> { s.Length };
                    return len;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                string reference = "abcdefghijklmnopqrstuvwxyz";
                int sum = 0;
                int count = 0;
                foreach (char c in s)
                {
                    /*The pixel width corresponding to the character in s is added to the sum variable and if adding the pixel width of that 
                    character makes the sum variable greater than 100 then it moves to the else loop*/
                    if (sum + widths[reference.IndexOf(c)] <= 100)
                    {
                        sum = sum + widths[reference.IndexOf(c)];
                    }
                    /*When adding the pixel width of a character makes the sum variable greater than 100 then the sum is again initiated to zero and the process continues.
                     Also pixel width exceeds 100 means that the 100 pixels have already been filled in one line hence we must go to the next line which means
                    that the line count stored in count variable increments by 1*/
                    else
                    {
                        sum = 0;
                        sum = sum + widths[reference.IndexOf(c)];
                        count = count + 1;

                    }
                }


                //write your code here.

                //The count of number of lines and the sum of pixels in last line is returned
                return new List<int>() { count + 1, sum };
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                int l = bulls_string10.Length;
                /*Each time an opening and corresponding closing bracket is encountered it is replaced by a null character thereby putting together
                the brackets present on either side of these opening and closing pair together. Again if these are a pair of opening and corresponding closing bracket
                then again they are replaced by null character and the process repeats*/
                for (int i = 0; i < l / 2; i++)
                {
                    bulls_string10 = bulls_string10.Replace("()", "");
                    bulls_string10 = bulls_string10.Replace("{}", "");
                    bulls_string10 = bulls_string10.Replace("[]", "");
                }

                //write your code here.
                /*After replacing all the opening and corresponding closing pairs with null if the bulls_string 10 becomes empty then true is returned since
                such string has valid parenthesis*/
                if (bulls_string10 == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                string alphabets = "abcdefghijklmnopqrstuvwxyz";
                string[] Morse = new String[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                List<string> coded_string = new List<string> { };
                //The outer foreach loop iterates through the items in the words array
                foreach (var item in words)
                {
                    string new_item = "";
                    /*This foreach loop iterates through each character in the item in words array and it replaces the alphabets in the words with 
                    their corresponding Morse code*/
                    foreach (char c in item)
                    {
                        int index = alphabets.IndexOf(c);
                        new_item = new_item + Morse[index];


                    }
                    //The coded word is added to the coded_string list
                    coded_string.Add(new_item);
                }
                //All same codes are put under a group and the count of number of groups i..e, number of unique morse codes is returned using the frequency.count
                var frequency = coded_string.GroupBy(x => x);
                return frequency.Count();
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                //write your code here.
                return 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}