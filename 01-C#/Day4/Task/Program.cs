
namespace Task
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

    public struct Employee
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
                }else if(prop == "name")
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
                    
                }else 
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
                if(HireDate.Year == other.HireDate.Year)
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

    public class EmployeeSearch 
    {
        int[] NationalIDs;
        Employee[] Employees;

        public EmployeeSearch(int[] ids, Employee[]emps)
        {
            NationalIDs = ids;
            Employees = emps;
        }

        
        public Employee? ById(int id)                                 /////////////// Nullable(?) to make it possible to return null (good point)
        {
            for (int i = 0; i < Employees.Length; i++)
            {
                if (Employees[i].Id == id) return Employees[i];
            }
            return null;
        }

        public Employee[] ByName(string name)
        {
            int count = 0;
            int[] indices = new int[Employees.Length];
            for (int i = 0; i < Employees.Length; i++)
            {
                if (Employees[i].name == name)
                {
                    indices[count++] = i;
                }
            }
            Employee[] Result = new Employee[count];
            for (int i = 0; i < count; i++)
            {
                Result[i] = Employees[indices[i]];
            }
            return Result;
        }

        public Employee[] byHiringDate(string date)
        {
            int count = 0;
            int[] indices = new int[Employees.Length];
            for (int i = 0; i < Employees.Length; i++)
            {
                if (Employees[i].hireDate == date)
                {
                    indices[count++] = i;
                }
            }
            Employee[] Result = new Employee[count];
            for (int i = 0; i < count; i++)
            {
                Result[i] = Employees[indices[i]];
            }
            return Result;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isValidInput;
            Employee[] employeeArray;
            int[] IDs;
            int numberOfEmployees;
            


            do
            {
                Console.Write("Enter the number of employees: ");
                isValidInput = int.TryParse(Console.ReadLine(), out numberOfEmployees) && numberOfEmployees >= 0;
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
            } while (!isValidInput);

            employeeArray = new Employee[numberOfEmployees];
            IDs = new int[numberOfEmployees];

            for (int i = 0; i < numberOfEmployees; i++)
            {
                Console.WriteLine($"\nEnter details for Employee {i + 1}:");

                SecurityPrivileges securityLevel; 
                decimal sal; 
                Gender gender;
                String name;
                int id;
                HiringDate hireDate = new HiringDate(1,1,2025); 


                ///        Id
                do
                {
                    Console.WriteLine("Enter the ID ");
                    isValidInput = int.TryParse(Console.ReadLine(), out id);
                    if (isValidInput)
                    {
                        for(int j = 0; j < i && isValidInput; j++)
                        {
                            if(IDs[j] == id)
                            {
                                isValidInput = false;
                            }
                        }
                    }
                    if (!isValidInput)
                    {
                        Console.WriteLine("Invalid ID num");
                    }
                }while (!isValidInput);
                

                ////////////////////////////////////////////////////
                ///           Name
                Console.WriteLine("Name : ");
                name = Console.ReadLine();

                ////////////////////////////////////////////////////////
                //                SecurityPrivileges
                do
                {
                    Console.Write("Security Level (Guest=1, Developer=2, Secretary=4, DBA=8, SecurityOfficer=15): ");
                    isValidInput = SecurityPrivileges.TryParse(Console.ReadLine(), out securityLevel);

                    if (!isValidInput)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid security level.");
                    }
                } while (!isValidInput);

                ////////////////////////////////////////////////
                //                  Salary
                do
                {
                    Console.Write("Salary: ");
                    isValidInput = decimal.TryParse(Console.ReadLine(), out sal) && sal > 0;
                    if (!isValidInput)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid salary.");
                    }
                } while (!isValidInput);

                ///////////////////////////////////////////////////////////
                //                      HiringDate
                String value;
                do
                {
                    Console.WriteLine("Enter the date in format 'dd-mm-yyyy'");
                    value = Console.ReadLine();
                    string[] date = value.Split('-');
                    if (date.Length == 3)
                    {
                        int day = 0, month = 0, year = 0;
                        isValidInput = int.TryParse(date[0], out day) && day > 0 && day < 31;
                        isValidInput = isValidInput && int.TryParse(date[1], out month) && month > 0 && month <= 12;
                        isValidInput = isValidInput && int.TryParse(date[2], out year) && year >= 2000 && year <= 2025;
                        if (isValidInput)
                        {
                            hireDate = new HiringDate(day, month, year);
                        }
                    }
                    else
                    {
                        isValidInput = false;
                    }

                    if (!isValidInput)
                    {
                        Console.WriteLine("Invalid date");
                    }

                }while (!isValidInput);
                
                ////////////////////////////////////////
                ///           Gender
                do
                {
                    Console.Write("Gender (M/F): ");
                    isValidInput = Gender.TryParse(Console.ReadLine().ToUpper(), out gender);
                    if (!isValidInput)
                    {
                        Console.WriteLine("Invalid Input");
                    }
                } while (!isValidInput);

                employeeArray[i] = new Employee(id,name,securityLevel,sal,hireDate,gender);
                IDs[i] = id;
            }
            ///////// just to check indexer
            if(employeeArray[0]["gender"] == "M")
            {
                employeeArray[0]["gender"] = "F";
            }
            else
            {
                employeeArray[0]["gender"] = "F";
            }


            for (int i = 0; i < employeeArray.Length; i++)
            {
                Console.WriteLine($"Info of employee {i+1}");
                Console.WriteLine(employeeArray[i].ToString());
                Console.WriteLine(IDs[i].ToString());
            }


            Console.WriteLine("----------------------Result of EmployeeSearch.byHiringDate (1-1-2001)----------------------------");
            EmployeeSearch search = new EmployeeSearch(IDs,employeeArray);
            HiringDate checKThisDate = new HiringDate(1,1,2001);
            Employee[] SearchHiringDate= search.byHiringDate(checKThisDate.ToString());
            for (int i = 0;i < SearchHiringDate.Length;i++)
            {
                Console.WriteLine(SearchHiringDate[i].ToString());
            }

            Console.WriteLine("----------------------Result of EmployeeSearch.byHiringDate (10-10-2001)----------------------------");
            HiringDate checKThisDate2 = new HiringDate(10, 10, 2001);
            Employee[] SearchHiringDate2 = search.byHiringDate(checKThisDate2.ToString());
            for (int i = 0; i < SearchHiringDate2.Length; i++)
            {
                Console.WriteLine(SearchHiringDate2[i].ToString());
            }

            Console.WriteLine("----------------------Result of EmployeeSearch.byName (mai)----------------------------");
            Employee[] SearchNameResult = search.ByName("mai");
            if (SearchNameResult == null)
            {
                Console.WriteLine("There's no Employees with this name");
            }
            else
            {
                for (int i = 0; i < SearchNameResult.Length; i++)
                {
                    Console.WriteLine(SearchNameResult[i].ToString());
                }
            }

            Console.WriteLine("----------------------Result of EmployeeSearch.byName ()----------------------------");
            Console.WriteLine("Enter the name you wanna search for : ");
            string checKThisName = Console.ReadLine();
            Employee[] SearchName = search.ByName(checKThisName);

            
            for (int i = 0; i < SearchName.Length; i++)
            {
                Console.WriteLine(SearchName[i].ToString());
            }
           

            Console.WriteLine("----------------------Result of EmployeeSearch.byID ()----------------------------");
            Console.WriteLine("Enter the Id you wanna search for : ");
            int checKThisID;
            
            isValidInput = int.TryParse(Console.ReadLine(), out checKThisID);
            if (isValidInput)
            {
                Employee? SearchID = search.ById(checKThisID);
                if(SearchID == null)
                {
                    Console.WriteLine("No emplyees with this ID");
                }
                else
                {
                    
                    Console.WriteLine(SearchID.ToString());
                    
                }
               
            }
        }
    }
}
