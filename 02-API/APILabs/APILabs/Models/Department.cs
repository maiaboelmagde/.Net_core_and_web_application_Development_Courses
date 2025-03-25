namespace APILabs.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string location { get; set; }
        public string MngName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}

