namespace TimeSheet.DB.Entitys
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
