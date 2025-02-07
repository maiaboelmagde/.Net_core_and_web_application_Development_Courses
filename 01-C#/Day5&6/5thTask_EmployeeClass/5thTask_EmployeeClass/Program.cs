namespace _5thTask_EmployeeClass
{

    public struct HiringDate
    {
        private int _Day;
        private int _Month;
        private int _Year;

        public HiringDate(int day, int month, int year)
        {
            _Day = day;
            _Month = month;
            _Year = year;
        }

        public override string ToString()
        {
            return $"{_Day}/{_Month}/{_Year}";
        }

        public int Day
        {
            get { return _Day; }
            set
            {

                if (value > 0 && value <= 31)
                    _Day = value;
                else
                    Console.WriteLine("Invalid day value. Enter a valid one.");

            }
        }

        public int Month
        {
            get { return _Month; }
            set
            {

                if (value > 0 && value <= 12)
                    _Month = value;
                else
                    Console.WriteLine("Invalid month value. Enter a valid one.");

            }
        }

        public int Year
        {
            get { return _Year; }
            set
            {

                if (value > 0)
                    _Year = value;
                else
                    Console.WriteLine("Invalid year value. Enter a valid one.");

            }
        }
    }

    public enum Gender
    {
        M,
        F
    }

    public enum SecurityPrivileges : byte
    {
        Guest = 1,
        Developer = 2,
        Secretary = 4,
        DBA = 8,
        SecurityOfficer = Guest | Developer | Secretary | DBA  //15
    }

    public struct Employee : IComparable
    {
        int ID;
        String Name;
        SecurityPrivileges SecurityLevel;
        decimal Salary;
        public HiringDate HireDate;
        Gender Gender;

        public Employee(int id, String _Name, SecurityPrivileges securityLevel, decimal sal, HiringDate hireDate, Gender gender)
        {
            ID = id;
            Name = _Name;
            SecurityLevel = securityLevel;
            Salary = sal;
            HireDate = hireDate;
            Gender = gender;
        }

        public int Id
        {
            get
            {
                return ID;
            }
        }

        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        public string Privileges
        {
            set
            {
                SecurityPrivileges securityLevel;
                if (value == "1" || value == "2" || value == "4" || value == "8" || value == "15")
                {
                    bool isValid = Enum.TryParse(value, out securityLevel) && Enum.IsDefined(typeof(SecurityPrivileges), securityLevel);
                    if (isValid)
                    {
                        Console.WriteLine("Invalid SecurityPrivileges");
                    }

                }
            }
            get
            {
                return SecurityLevel.ToString();
            }
        }

        public decimal salary
        {
            set
            {
                Salary = value > 0 ? value : 0;
            }
            get
            {
                return Salary;
            }
        }

        public string hireDate
        {
            set
            {
                string[] date = value.Split('/');
                if (date.Length == 3)
                {
                    int day = 0, month = 0, year = 0;
                    bool valid = int.TryParse(date[0], out day) && day > 0 && day < 31;
                    valid = valid && int.TryParse(date[1], out month) && month > 0 && month < 12;
                    valid = valid && int.TryParse(date[2], out year) && year > 2015 && year < 2025;
                    if (valid)
                    {
                        HireDate = new HiringDate(day, month, year);
                    }
                    else
                    {
                        Console.WriteLine("invalid Date !!");
                    }
                }
                else
                {
                    Console.WriteLine("invalid Date !!");
                }
            }
            get
            {
                return HireDate.ToString();
            }
        }

        public string gender
        {
            set
            {
                if (value == "M" || value == "F" || value == "m" || value == "f")
                {
                    Gender gender;
                    bool isValid = Gender.TryParse(value.ToUpper(), out gender);
                    if (!isValid)
                    {
                        Console.WriteLine("Invalid gender value.");
                    }
                    else
                    {
                        Gender = gender;
                    }
                }

                else
                    Console.WriteLine("Invalid gender value.");
            }

            get
            {
                if (Gender == Gender.F)
                {
                    return "Female";
                }
                return "Male";
            }
        }

        public string this[string prop]
        {
            get
            {
                if (prop == "Id")
                {
                    return this.Id.ToString();
                }
                else if (prop == "name")
                {
                    return this.Name;
                }
                else if (prop == "gender")
                {
                    return this.Gender.ToString();
                }
                else if (prop == "salary")
                {
                    return this.salary.ToString();
                }
                else if (prop == "Priviliges")
                {
                    return this.SecurityLevel.ToString();
                }
                return "Error while get the property !!";
            }
            set
            {
                bool isValid;
                if (prop == "Id")
                {
                    int newId;
                    isValid = int.TryParse(value, out newId);
                    if (!isValid)
                    {
                        Console.WriteLine("Invalid id");
                    }
                    else
                    {
                        ID = newId;
                    }
                }
                else if (prop == "name")
                {
                    Name = value;
                }
                else if (prop == "gender")
                {
                    gender = value;
                }
                else if (prop == "salary")
                {
                    decimal newSalary;
                    isValid = decimal.TryParse(value, out newSalary);
                    if (!isValid)
                    {
                        Console.WriteLine("Invalid Salary");
                    }
                    else
                    {
                        Salary = newSalary;
                    }

                }
                else if (prop == "Priviliges")
                {
                    Privileges = value;

                }
                else
                    Console.WriteLine($"Error while set this property ! ! .. no prperty named {prop}");

            }

        }

        public override string ToString()
        {
            return $"Name:{Name} ID: {ID}, Security Level: {SecurityLevel}, Salary: {String.Format("{0:0.00}", Salary)}, Hire Date: {HireDate}, Gender: {Gender}";
        }

        public int CompareTo(object? obj)
        {

            if (obj == null) return 1;
            if ((obj is Employee other))
            {
                if (HireDate.Year == other.HireDate.Year)
                {
                    if (HireDate.Month == other.HireDate.Month)
                    {

                        return HireDate.Day.CompareTo(other.HireDate.Day);
                    }
                    return HireDate.Month.CompareTo(other.HireDate.Month);

                }
                return HireDate.Year.CompareTo(other.HireDate.Year);
            }
            return 1;

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees =
{
                new Employee(1, "emp1", SecurityPrivileges.Developer, 3000, new HiringDate(15, 5, 2020), Gender.F),
                new Employee(2, "emp2", SecurityPrivileges.DBA, 4000, new HiringDate(10, 3, 2018), Gender.M),
                new Employee(3, "emp3", SecurityPrivileges.Secretary, 3500, new HiringDate(5, 7, 2022), Gender.M),
                new Employee(4, "emp4", SecurityPrivileges.Guest, 2500, new HiringDate(20, 1, 2019), Gender.M),
                new Employee(5, "emp5", SecurityPrivileges.SecurityOfficer, 5000, new HiringDate(25, 12, 2017), Gender.F)
            };

            Console.WriteLine("Employees before sorting:");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }

            Array.Sort(employees);

            Console.WriteLine("\nEmployees after sorting by Hiring Date:");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }

        }
    }
}

