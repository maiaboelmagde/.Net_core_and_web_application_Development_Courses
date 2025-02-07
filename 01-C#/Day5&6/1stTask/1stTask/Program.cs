using System.Drawing;

namespace _1stTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Point3D P = new Point3D(10, 10, 10);
            Console.WriteLine(P.ToString());

            int x = 0, y = 0, z = 0;
            bool validInput = false;
            do
            {
                Console.WriteLine("Enter Point 1 coords in format (x , y , z)");
                string input = Console.ReadLine();
                input = input.Trim(new char[] { '(', ')' });
                string[] parts = input.Split(',');
                if (parts.Length == 3) 
                
                    if (int.TryParse(parts[0].Trim(), out x) &&
                        int.TryParse(parts[1].Trim(), out y) &&
                        int.TryParse(parts[2].Trim(), out z))
                    {
                        validInput = true;
                    }
                
               
                    if (!validInput)
                    Console.WriteLine("Invalid format. Please enter coordinates in the format (x, y, z).");


            } while (!validInput);

            Point3D p1 = new Point3D(x,y,z);
            Console.WriteLine(p1.ToString());


            validInput = false;
            do
            {
                Console.WriteLine("Enter Point 1 coords in format (x , y , z)");
                string input = Console.ReadLine();
                input = input.Trim(new char[] { '(', ')' });
                string[] parts = input.Split(',');
                if (parts.Length == 3)

                    if (int.TryParse(parts[0].Trim(), out x) &&
                        int.TryParse(parts[1].Trim(), out y) &&
                        int.TryParse(parts[2].Trim(), out z))
                    {
                        validInput = true;
                    }


                if (!validInput)
                    Console.WriteLine("Invalid format. Please enter coordinates in the format (x, y, z).");


            } while (!validInput);

            Point3D p2 = new Point3D(x,y,z);
            Console.WriteLine(p2.ToString());

            Console.WriteLine("-----------------------------------Equality----------------------------------------------");
            Point3D p3 = new Point3D(10, 20, 40);
            Point3D p4 = new Point3D(10, 20, 40);
            if (p3 == p4)
            {
                Console.WriteLine("P4 equals P3");
            }
            else
            {
                Console.WriteLine("P4 not equal P3");
            }

            if (p3.Equals(p4))
            {
                Console.WriteLine("P4 equals P3");
            }
            else
            {
                Console.WriteLine("P4 not equal P3");
            }

            Console.WriteLine("-----------------------------------Array----------------------------------------------");
            Point3D[] PointArray = {p1,p2,p3,p4};
            Array.Sort(PointArray);
            for (int i = 0; i < PointArray.Length; i++)
            {
                Console.WriteLine($"{PointArray[i].ToString()}");
            }


        }
    }
}
