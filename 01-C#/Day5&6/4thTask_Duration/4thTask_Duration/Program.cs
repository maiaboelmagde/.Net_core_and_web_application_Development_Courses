namespace _4thTask_Duration
{
    public class Duration
    {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        public Duration(int hours, int minutes, int seconds)
        {
            NormalizeDuration(hours, minutes, seconds);
        }

        public Duration(int totalSeconds)
        {
            NormalizeDuration(0, 0, totalSeconds);
        }

        private void NormalizeDuration(int hours, int minutes, int seconds)
        {
            int totalSeconds = hours * 3600 + minutes * 60 + seconds;

            Hours = totalSeconds / 3600;
            totalSeconds %= 3600;
            Minutes = totalSeconds / 60;
            Seconds = totalSeconds % 60;
        }

        public override bool Equals(object? obj)
        {
            Duration duration = obj as Duration;
            if (duration == null)
                return false;
            if (this.GetType() != duration.GetType()) 
                return false;
            if (ReferenceEquals(this, duration)) 
                return true;

            return Hours == duration.Hours && Minutes == duration.Minutes && Seconds == duration.Seconds;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }

        public override string ToString()
        {
            if (Hours == 0)
            {
                if(Minutes == 0)
                {
                    return $"Seconds :{Seconds}";
                }
                else
                {
                    return $"Minutes :{Minutes}, Seconds :{Seconds}";
                }
            }
            return $"Hours: {Hours}, Minutes :{Minutes}, Seconds :{Seconds}";
        }



        ///////////////////////////////Operators overloading///////////////////////////


        public int ToSeconds() { return (Hours * 3600) + (Minutes * 60) + Seconds; }

        public static Duration operator +(Duration duration1, Duration duration2)
        {
            return new Duration(duration1.ToSeconds() + duration2.ToSeconds());
        }

        public static Duration operator +(int seconds, Duration duration)
        {
            return new Duration(duration.ToSeconds()+seconds);
        }
        
        public static Duration operator +(Duration duration, int seconds)
        {
            return new Duration(duration.ToSeconds()+seconds);
        }

        public static Duration operator -(Duration duration1, Duration duration2)
        {
            int seconds = duration1.ToSeconds() - duration2.ToSeconds();
            if (seconds < 0)
            {
                Console.WriteLine("Duration can't be less than 0");
                return null;
            }
            return new Duration(seconds);
        }

        public static Duration operator -(int _seconds, Duration duration)
        {
            int seconds = _seconds - duration.ToSeconds();
            if (seconds < 0)
            {
                Console.WriteLine("Duration can't be less than 0");
                return null;
            }
            return new Duration(seconds);
        }

        public static Duration operator -(Duration duration, int _seconds)
        {
            int seconds = _seconds - duration.ToSeconds();
            if (seconds < 0)
            {
                Console.WriteLine("Duration can't be less than 0");
                return null;
            }
            return new Duration(seconds);
        }


        public static Duration operator ++(Duration duration)
        {
            return new Duration(duration.ToSeconds() + 60);
        }

        public static Duration operator --(Duration duration)
        {
            return new Duration(duration.ToSeconds() - 60);
        }

        public static bool operator >(Duration d1, Duration d2)
        {
            return d1.ToSeconds() > d2.ToSeconds();
        }

        public static bool operator <(Duration d1, Duration d2)
        {
            return d1.ToSeconds() < d2.ToSeconds();
        }

        public static bool operator <=(Duration d1, Duration d2)
        {
            return d1.ToSeconds() <= d2.ToSeconds();
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            return d1.ToSeconds() >= d2.ToSeconds();
        }

        public static bool operator true(Duration d)
        {
            return d.ToSeconds() > 0;
        }

        public static bool operator false(Duration d)
        {
            return d.ToSeconds() == 0;
        }

        public static explicit operator DateTime(Duration d)
        {
            return new DateTime().AddSeconds(d.ToSeconds());
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Duration D1 = new Duration(1, 10, 15);
            Console.WriteLine("1");
            Console.WriteLine(D1.ToString());

            Duration D2 = new Duration(3600);
            Console.WriteLine("2");
            Console.WriteLine(D2.ToString());

            Duration D3 = new Duration(7800);
            Console.WriteLine("3");
            Console.WriteLine(D3.ToString());

            Duration D4 = new Duration(666);
            Console.WriteLine("4");
            Console.WriteLine(D4.ToString());


            Duration D5 = new Duration(1, 10, 15);
            Duration D6 = new Duration(780);

            Duration D7 = D5 + D6;
            Console.WriteLine("5");
            Console.WriteLine(D7.ToString());

            D7 = D5 + 7800;
            Console.WriteLine("6");
            Console.WriteLine(D7.ToString());

            D7 = 666 + D7;
            Console.WriteLine("7");
            Console.WriteLine(D7.ToString());

            D7 = D5++;
            Console.WriteLine("8");
            Console.WriteLine(D7.ToString());

            D7 = --D6;
            Console.WriteLine("9");
            Console.WriteLine(D7.ToString());

            
            D5 -= D6;
            Console.WriteLine("10");
            Console.WriteLine(D5?.ToString());
            

            Console.WriteLine("11");
            if (D7 > D6)
                Console.WriteLine("D5 is greater than D6");
            

            if (D7 <= D6)
                Console.WriteLine("D5 is less than or equal to D6");
            

            Console.WriteLine("13");
            if (D5)
                Console.WriteLine("D5 is valid");

            DateTime Obj = (DateTime)D5;
            Console.WriteLine("14");
            Console.WriteLine(Obj); 

        }
    }
    
}
