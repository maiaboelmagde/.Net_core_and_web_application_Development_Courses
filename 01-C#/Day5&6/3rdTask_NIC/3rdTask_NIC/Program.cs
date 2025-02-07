namespace _3rdTask_NIC
{
    using System;
    using System.Net.NetworkInformation;

    public enum NICType
    {
        Ethernet,
        TokenRing
    }

    public class NIC
    {
        private static NIC _instance;
        private static readonly object _lock = new object();

        public string Manufacturer { get; private set; }
        public string MACAddress { get; private set; }
        public NICType Type { get; private set; }

        private NIC()
        {
            Manufacturer = "Unknown";
            MACAddress = "00:00:00:00:00:00";
            Type = NICType.Ethernet;
        }

        public static NIC GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NIC();
            }
            return _instance;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"MAC Address: {MACAddress}");
            Console.WriteLine($"Type: {Type}");
        }
    }

    class Program
    {
        static void Main()
        {
            NIC myNIC = NIC.GetInstance();
            myNIC.DisplayInfo();

            NIC anotherNIC = NIC.GetInstance();
            Console.WriteLine(Object.ReferenceEquals(myNIC, anotherNIC));
        }
    }

}
