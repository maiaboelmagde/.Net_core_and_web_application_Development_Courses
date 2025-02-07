using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1stTask
{
    internal class Point3D(int x, int y, int z) : IComparable, ICloneable
    {
        //use chaining in constructors
        public Point3D(int n):this(n, n, n)
        {

        }

        public int get_x
        {
            get { return x; }
        }
        public int get_y
        {
            get { return y; }
        }
        public int get_z
        {
            get { return z; }
        }


        public override string ToString()
        {
            return $"Point Coordinates:  ({x}, {y}, {z})";
        }


        //override the Equals Function :
        public override bool Equals(object? obj)
        {
            Point3D point3D = obj as Point3D;
            if (point3D == null) 
                return false;
            if (this.GetType() != point3D.GetType()) return false;
            if(ReferenceEquals(this, point3D)) return true;
            return x == point3D.get_x && y == point3D.get_y && z == point3D.get_z;
        }

        public int CompareTo(object? obj)
        {
            if (obj is not Point3D other)
                throw new ArgumentException("Object is not a Point3D");

            int xComparison = x.CompareTo(other.get_x);
            if (xComparison != 0)
                return xComparison;

            int yComparison = y.CompareTo(other.get_y);
            if (yComparison != 0)
                return yComparison;


            return z.CompareTo(other.get_z);
        }

        public object Clone()
        {
            return new Point3D(x, y, z);
        }
    }
}
