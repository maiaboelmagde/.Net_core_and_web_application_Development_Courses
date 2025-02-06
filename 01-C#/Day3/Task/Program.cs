namespace Task
{
    public struct HiringDate
    {
        int Day;
        int Month;
        int Year;

        public HiringDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }

    public enum Gender
    {
        M,
        F
    }

    [Flags]
    public enum SecurityPrivileges : byte
    {
        Guest = 1,
        Developer = 2,
        Secretary = 4,
        DBA = 8,
        SecurityOfficer = Guest | Developer | Secretary | DBA
    }

    public struct Employee
    {
        int ID;
        SecurityPrivileges SecurityLevel;
        decimal Salary;
        HiringDate HireDate;
        Gender Gender;

        public Employee(int id, SecurityPrivileges securityLevel, decimal salary, HiringDate hireDate, Gender gender)
        {
            ID = id;
            SecurityLevel = securityLevel;
            Salary = salary;
            HireDate = hireDate;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Security Level: {SecurityLevel}, Salary: {String.Format("{0:C}", Salary)}, Hire Date: {HireDate}, Gender: {Gender}";
        }

        public string DisplaySalary()
        {
            return String.Format("{0:C}", Salary);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] EmpArr = new Employee[3];

            for (int i = 0; i < EmpArr.Length; i++)
            {
                Console.WriteLine($"Enter details for Employee {i + 1}:");

                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Security Level (Guest=1, Developer=2, Secretary=4, DBA=8, SecurityOfficer=15): ");
                SecurityPrivileges securityLevel = (SecurityPrivileges)byte.Parse(Console.ReadLine());

                Console.Write("Salary: ");
                decimal salary = decimal.Parse(Console.ReadLine());

                Console.Write("Hire Date (Day): ");
                int day = int.Parse(Console.ReadLine());

                Console.Write("Hire Date (Month): ");
                int month = int.Parse(Console.ReadLine());

                Console.Write("Hire Date (Year): ");
                int year = int.Parse(Console.ReadLine());

                HiringDate hireDate = new HiringDate(day, month, year);

                Console.Write("Gender (M/F): ");
                Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine().ToUpper());

                EmpArr[i] = new Employee(id, securityLevel, salary, hireDate, gender);
            }

            Console.WriteLine("\nEmployee Details:");
            foreach (var emp in EmpArr)
            {
                Console.WriteLine(emp.ToString());
            }
        }

    }
    
}
