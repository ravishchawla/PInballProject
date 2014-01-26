using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


/*
 *Ravish Chawla
 *130214.23
 * 
 **/

namespace Pinball3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            StreamWriter writer;
            bool go = true;

            while (go)
            {
                Console.Out.WriteLine("Type 0 if you want random runs, or 1 if you want specific angles");
                int num = Int32.Parse(Console.In.ReadLine());


                switch (num)
                {

                    case (0):

                        try
                        {
                            Console.Out.WriteLine("This code runs 100 times, so whatever input you give, 100 times that will be run\nsuggested is 1000,000\n\ta text file called out.txt in the home directory of this project will contain the data about these runs with max angles");
                            int runs = Int32.Parse(Console.In.ReadLine());

                            writer = new StreamWriter("out.txt");
                            Pinball pin = new Pinball();

                            writer.WriteLine("100 * " + runs + " runs. \nthe maximum angles from 100 different sets is shown below.");

                            Random gen = new Random();
                            //double angle = .4626753;
                            for (int k = 0; k < 100; k++)
                            {
                                double maxAngle = 0;
                                int count = 0;
                
                                for (int i = 0; i < runs; i++)
                                {
                                    double angle = gen.NextDouble() * 359 + 1;

                                    int max = pin.run(angle);

                                    if (max > count)
                                    {
                                        count = max;
                                        maxAngle = angle;
                                    }



                                }

                                Console.Out.WriteLine(k + ".");
                                if (maxAngle != 0)
                                    writer.WriteLine("Angle " + maxAngle + " hit " + count + " times");
                            }


                            writer.Flush();






                            writer.Close();
                            Console.Out.WriteLine("Tada!");
                        }

                        catch (IOException exe)
                        {
                            Console.Out.WriteLine("someting wong");
                        }

                        break;


                    case (1):
                        Console.Out.WriteLine("enter an angle in degrees\n\tmax angle is 94.5372630745615 degrees");
                        double notradians = double.Parse(Console.In.ReadLine());
                        Pinball pin2 = new Pinball();
                        Console.Out.WriteLine(pin2.run(notradians));
                        List<String> result = pin2.getList();

                        foreach (String v2 in result)
                        {
                            Console.Out.WriteLine(v2);
                        }


                        break;
                }

                Console.Out.WriteLine("try again? type yes or no");
                String go2 = Console.In.ReadLine();
                if (String.Compare(go2, "yes", true) == 0)
                {
                    go = true;
                }

                else
                    go = false;
            }


            
                



        }
    }
}