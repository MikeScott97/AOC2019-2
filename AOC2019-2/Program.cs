using System;

namespace AOC2019_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;
            int ender = 0;
            while(ender != 19690720)
            {
                ender = Parser(Values(), x, y);
                Console.WriteLine(ender);
                if (x == 99)
                {
                    x = 0;
                    y++;
                }else if(ender == 19690720)
                {
                    break;
                }
                else
                {
                    x++;
                }
            }

            Console.WriteLine($"X = {x}, Y = {y}");
            Console.WriteLine($"{100* x + y}");
            Console.ReadKey();
        }

        private static int Parser(int[] values, int x, int y)
        {
            int position = 0;
            int temp = 0;
            bool end = false;
            values[1] = x;
            values[2] = y;

            while(position <= values.Length && end == false)
            {

                switch (values[position])
                {
                    case 1:
                        temp = values[values[position + 1]] + values[values[position + 2]];
                        values[values[position + 3]] = temp;
                        position += 4;
                        break;
                    case 2:
                        temp = values[values[position + 1]] * values[values[position + 2]];
                        values[values[position + 3]] = temp;
                        position += 4;
                        break;
                    case 99:
                        end = true;
                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        end = true;
                        break;
                }
            }
            return values[0];
        }

        private static int[] Values()
        {
            string numbers = @"""1,12,2,3,1,1,2,3,1,3,4,3,1,5,0,3,2,1,6,19,1,19,6,23,2,23,6,27,2,6,27,31,2,13,31,35,1,9,35,39,2,10,39,43,1,6,43,47,1,13,47,51,2,6,51,55,2,55,6,59,1,59,5,63,2,9,63,67,1,5,67,71,2,10,71,75,1,6,75,79,1,79,5,83,2,83,10,87,1,9,87,91,1,5,91,95,1,95,6,99,2,10,99,103,1,5,103,107,1,107,6,111,1,5,111,115,2,115,6,119,1,119,6,123,1,123,10,127,1,127,13,131,1,131,2,135,1,135,5,0,99,2,14,0,0""";
            numbers = numbers.Trim('\"');
            string[] valueStr = numbers.Split(',');
            int[] valueInt = new int[valueStr.Length];
            for (int x = 0; x < valueInt.Length; x++)
            {
                valueInt[x] = Convert.ToInt32(valueStr[x]);
            }
            return valueInt;
        }
    }
}
