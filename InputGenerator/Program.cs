using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputGenerator
{
    class Program
    {
        static Random  _Rand = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("How many input files would you like to generate?");
            int Count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many dimensions should the files have?");
            int Dimensions = Convert.ToInt32(Console.ReadLine());
            while ( Dimensions > 3)
            {
                Console.WriteLine("Please select a number between 1 and 3");
                Dimensions = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("What would you like the base filename to be?");
            string FileName = Console.ReadLine();
            for (int _Index = 0; _Index < Count; _Index++)
            {
                int Length;
                int[] Max;
                int[,] Inputs;
                Inputs = Input(Dimensions, out Max, out Length);
                string PathString = String.Concat("C:\\Users\\Shayne\\Desktop\\SSSTestInput\\", FileName, _Index.ToString(), ".bp");
                string InputString = "Objects:";
                using (StreamWriter file = new StreamWriter(PathString))
                {
                    switch (Dimensions)
                    {
                        case 1:
                            file.WriteLine(String.Concat("Max:", Max[0]));
                            for (int _Index1 = 0; _Index1 < Length; _Index1++)
                            {
                                InputString = String.Concat(InputString, Inputs[_Index1, 0].ToString(), ";");
                            }
                            file.WriteLine(InputString);
                            break;
                        case 2:
                            file.WriteLine(String.Concat("Max:", Max[0],",", Max[1]));
                            for (int _Index1 = 0; _Index1 < Length; _Index1++)
                            {
                                InputString = String.Concat(InputString, Inputs[_Index1, 0].ToString(),",", Inputs[_Index1, 1].ToString(), ";");
                            }
                            file.WriteLine(InputString);
                            break;
                        case 3:
                            file.WriteLine(String.Concat("Max:", Max[0], ",", Max[1], ",", Max[2]));
                            for (int _Index1 = 0; _Index1 < Length; _Index1++)
                            {
                                InputString = String.Concat(InputString, Inputs[_Index1, 0].ToString(), ",", Inputs[_Index1, 1].ToString(), ",", Inputs[_Index1, 2].ToString(), ";");
                            }
                            file.WriteLine(InputString);
                            break;
                        default:
                            file.WriteLine(String.Concat("Max:", Max[0]));
                            for (int _Index1 = 0; _Index1 < Length; _Index1++)
                            {
                                InputString = String.Concat(InputString, Inputs[_Index1, 0].ToString(), ";");
                            }
                            file.WriteLine(InputString);
                            break;
                    }
                    file.Close();
                }
            }
        }

        public static int[,]Input(int _Dimensions, out int[] _Max, out int _Length)
        {

            switch (_Dimensions)
            {
                case 1:
                    _Max = new int[1];
                    _Max[0] = _Rand.Next(10, 100);
                    _Length = _Rand.Next(100, 1000);
                    int[,] _Out = new int[_Length, 1];
                    for (int _Index = 0; _Index < _Length; _Index++)
                    {
                        _Out[_Index, 0] = _Rand.Next(1, _Max[0] + 1);
                    }
                    return _Out;
                case 2:
                    _Max = new int[2];
                    _Max[0] = _Rand.Next(40, 200);
                    _Max[1] = _Rand.Next(40, 200);
                    _Length = _Rand.Next(100, 1000);
                    _Out = new int[_Length, 2];

                    for (int _Index = 0; _Index < _Length; _Index++)
                    {
                        _Out[_Index, 0] = _Rand.Next(1, _Max[0] + 1);
                        _Out[_Index, 1] = _Rand.Next(1, _Max[1] + 1);
                    }
                    return _Out;
                case 3:
                    _Max = new int[3];
                    _Max[0] = _Rand.Next(40, 200);
                    _Max[1] = _Rand.Next(40, 200);
                    _Max[2] = _Rand.Next(40, 200);
                    _Length = _Rand.Next(100, 1000);
                    _Out = new int[_Length, 3];

                    for (int _Index = 0; _Index < _Length; _Index++)
                    {
                        _Out[_Index, 0] = _Rand.Next(1, _Max[0] + 1);
                        _Out[_Index, 1] = _Rand.Next(1, _Max[1] + 1);
                        _Out[_Index, 2] = _Rand.Next(1, _Max[2] + 1);
                    }
                    return _Out;
                default:
                    _Max = new int[1];
                    _Max[0] = _Rand.Next(10, 100);
                    _Length = _Rand.Next(100, 1000);
                    _Out = new int[_Length, 1];
                    for (int _Index = 0; _Index < _Length; _Index++)
                    {
                        _Out[_Index, 0] = _Rand.Next(0, _Max[0]);
                    }
                    return _Out;
            }
        }            
    }
}
