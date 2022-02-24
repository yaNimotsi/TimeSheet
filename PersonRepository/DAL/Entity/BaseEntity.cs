using System.ComponentModel.DataAnnotations;

namespace TimeSheet.DB.DAL.Entity
{
    public class BaseEntity<TUniqueId> where TUniqueId : struct
    {
        [Key]
        public TUniqueId Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
