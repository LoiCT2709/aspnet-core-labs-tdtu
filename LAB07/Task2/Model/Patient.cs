namespace Task2.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string NamePatient { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address{ get; set; }
        public string PhoneNumber{get; set; }
        public int  DepartmentID { get; set; } //Khóa ngoại
        public Department Department { get; set; }
    }
}
