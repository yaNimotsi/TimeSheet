using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.DB.Entity
{
    [Table("User", Schema = "TimeSheet")]
    public sealed class User : BaseEntity<int>
    {
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
