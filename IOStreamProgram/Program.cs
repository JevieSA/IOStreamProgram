using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IOStreamProgram
{
    //Structure practice
    /**Creating stuct that creates a words array
     * Requests words as input and populates the
     * array and then displays the words in order*/
    struct Words
    {
        public string getWords(string[] str)
        {
            string words_combined = "Your words were: " + str[0] + str[1] + str[2] + str[3] + ".";

            return words_combined;
        }
    };

    class Program
    {
        static void Main(string[] args)
        {
            //Text that displays on first run
            String txt = "Hi there, please 4 words...";
            Console.WriteLine("{0}", txt);

            string more = "n";

            do
            {
                //Write words to string[]
                //Loops 4 times and requests input from user
                string[] str = new string[5];

                for (int i = 0; i < 4; i++)
                {
                    int c = i + 1;
                    Console.WriteLine("Word {0}:", c);
                    str[i] = Console.ReadLine();
                }

                Words w = new Words();
                Console.WriteLine(w.getWords(str));

                try
                {
                    //Creating instance of StreamWriter
                    //Writes data from string[] to file temp.txt
                    //using statement also closes StreamWiter
                    using (StreamWriter sw = new StreamWriter("temp.txt", true))
                    {
                        foreach (string s in str)
                        {
                            sw.WriteLine(s);
                        }
                    }

                    //Creating an instance of StreamReader
                    //Using statement also closes the StreamReader
                    using (StreamReader sr = new StreamReader("temp.txt"))
                    {
                        string line;

                        //Read file until all line are read
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error reading the file");
                    Console.WriteLine("Exception: {0}", e.Message);
                }
                Console.WriteLine("Would you like to add more words?");
                more = Console.ReadLine();

            } while (more.Equals("y", StringComparison.OrdinalIgnoreCase));

                    Console.ReadLine();
            }
    }
    }
