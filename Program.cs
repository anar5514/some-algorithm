using System;
using System.Collections.Generic;

namespace PashaBankCup
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>()
            {
                "000000001111111100000110",
                "000000110000111100000110"
            };

            var result = closestColor(list);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static List<string> closestColor(List<string> pixels)
        {
            var count = pixels.Count;
            var binaryPixelsList = pixels;

            // colors which the most minimal distance..
            var resultSet = new List<string>();

            // each pixel.....
            for (int i = 0; i < count; i++)
            {
                var pixelColor = GetRGBValues(binaryPixelsList[i]);

                var totalArray = new List<double>()
                {
                    FindDistanceFrom(pixelColor, new int[] { 0, 0, 0 }),
                    FindDistanceFrom(pixelColor, new int[] { 255, 255, 255 }),
                    FindDistanceFrom(pixelColor, new int[] { 255, 0, 0 }),
                    FindDistanceFrom(pixelColor, new int[] { 0, 255, 0 }),
                    FindDistanceFrom(pixelColor, new int[] { 0, 0, 255 })
                };

                var originalArray = new List<double>(totalArray);

                // it is sort operation (to get minimal value)
                totalArray.Sort();
                var minimumDistance = totalArray[0];

                var resultColorWord = string.Empty;

                // configure whether value belong to what color
                switch (originalArray.FindIndex(x => x == minimumDistance))
                {
                    case 0:
                        resultColorWord = "Black";
                        break;
                    case 1:
                        resultColorWord = "White";
                        break;
                    case 2:
                        resultColorWord = "Red";
                        break;
                    case 3:
                        resultColorWord = "Green";
                        break;
                    case 4:
                        resultColorWord = "Blue";
                        break;
                }

                resultSet.Add(resultColorWord);
            }

            return resultSet;


            double FindDistanceFrom(int[] inputPixelValues, int[] controlPixelValues)
            {
                // control for pure white
                // inputPixelValues[0] - red value of input pixel
                // inputPixelValues[1] - green value of input pixel
                // inputPixelValues[2] - blue value of input pixel

                // control for pure white red
                var red = inputPixelValues[0] - controlPixelValues[0];
                // control for pure white green
                var green = inputPixelValues[1] - controlPixelValues[1];
                // control for pure white blue
                var blue = inputPixelValues[2] - controlPixelValues[2];

                var result1 = Math.Pow(red, 2);
                var result2 = Math.Pow(green, 2);
                var result3 = Math.Pow(blue, 2);

                var distance = Math.Sqrt(result1 + result2 + result3);

                return distance;
            }


            int[] GetRGBValues(string pixel)
            {
                //var first = Convert.ToInt32(pixel[0]);
                //var second = Convert.ToInt32(pixel[1]);
                //var third = Convert.ToInt32(pixel[2]);

                int[] rgbvalues = new int[3];

                for (int i = 0, z = 0; z < rgbvalues.Length; i += 8, z++)
                {
                    int num = Convert.ToInt32(pixel.Substring(i, 8));
                    int dec_value = 0;

                    // Initializing base1 
                    // value to 1, i.e 2^0 
                    int base1 = 1;

                    int temp = num;
                    while (temp > 0)
                    {
                        int last_digit = temp % 10;
                        temp = temp / 10;

                        dec_value += last_digit * base1;

                        base1 = base1 * 2;
                    }

                    rgbvalues[z] = dec_value;
                }

                return rgbvalues;

            }
        }

        public static void fizzBuzz(int n)
        {
            for (int i = 1; i < n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (i % 5 == 0)
                    Console.WriteLine("Buzz");
                else if (i % 3 != 0 && i % 5 != 0)
                    Console.WriteLine(i);
            }
        }
    }


    class GFG
    {
        public static int binaryToDecimal(int n)
        {
            int num = n;
            int dec_value = 0;

            // Initializing base1 
            // value to 1, i.e 2^0 
            int base1 = 1;

            int temp = num;
            while (temp > 0)
            {
                int last_digit = temp % 10;
                temp = temp / 10;

                dec_value += last_digit * base1;

                base1 = base1 * 2;
            }

            return dec_value;
        }
    }
}
