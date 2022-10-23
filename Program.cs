using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;

namespace MenuConsoleApp
{
    internal class Program
    {
        private const int PADDING_LEFT_RIGHT = 2;
       private  static  int choseOptions = 0;



        static void Main(string[] args)
        {

            ArrayList list = new ArrayList() { "Opcja1", "3", "rt", "Opcja 2", "Bardzo długa opcja", "Opcja 4", "o ja", "OMG to działa" };
            
            while (true)
            {
                //initial settings
                Console.CursorVisible = false;
                int lengthOfLongest = maxElementlength(list);
                int startHeight = (Console.WindowHeight / 2) - (list.Count / 2);
                int startWidth = (Console.WindowWidth / 2) - (lengthOfLongest / 2);
                Console.SetCursorPosition(startWidth, startHeight);



                drawTopOfFrame(lengthOfLongest);
      
          
                Console.SetCursorPosition(startWidth, ++startHeight);

                for (int i = 0; i < list.Count; i++)
                {
                    StringBuilder row = new StringBuilder("");
                    row.Append("│");


                    for (int j = 0; j < (lengthOfLongest - (list[i] as string).Length) / 2; j++)
                    {
                        row.Append(" ");
                    }

                    row.Append(list[i] as string);


                    for (int j = 0; j < Math.Ceiling((float)(lengthOfLongest - (list[i] as string).Length) / 2); j++)
                    {
                        row.Append(" ");
                    }
                    row.Append("│");

                    if (choseOptions == i)
                    {
                        drawLabel();
                    }
                    else
                    {
                        defaultConsole();
                    }




                    Console.Write(row.ToString());
                    defaultConsole();



                    row = new StringBuilder("");
                    Console.SetCursorPosition(startWidth, ++startHeight);


                }
                
                drawBottomOfFrame(lengthOfLongest);

                Thread.Sleep(1000 / 60); //60fps


                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow: if (choseOptions < list.Count - 1) { choseOptions++; } break;
                    case ConsoleKey.UpArrow: if (choseOptions > 0) { choseOptions--; } break;
                    case ConsoleKey.Escape: Environment.Exit(0); break;
                    case ConsoleKey.Enter: break;
                    default: wrongKey(); break;




                }
                Console.Clear();


            }

        }



        private static void drawTopOfFrame(int width)
        {

            Console.Write("┌");
            for (int i = 0; i < width; i++)
            {
                Console.Write("─");
            }
            Console.Write("┐");

        }

        private static void drawBottomOfFrame(int width)
        {
            Console.Write("└");
            for (int i = 0; i < width; i++)
            {
                Console.Write("─");
            }
            Console.Write("┘");
        }

        private static int maxElementlength(ArrayList list)
        {
            int c = 0;

            foreach (string x in list)
            {
                if (x.Length > c) { c = x.Length + PADDING_LEFT_RIGHT; }
            }
            return c;
        }
        private static void drawLabel()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        private static void defaultConsole()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

        }
        private static void wrongKey()
        {

            string errorMessage = "Wcisnieto nie prawidłowy klawisz";
            int startHeight = (Console.WindowHeight / 2);
            int startWidth = (Console.WindowWidth / 2) - (errorMessage.Length / 2);

            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Console.SetCursorPosition(startWidth, startHeight);



                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(errorMessage);

                Console.Beep();

                Thread.Sleep(100);




            }



            defaultConsole();
        }
       

    }
}
