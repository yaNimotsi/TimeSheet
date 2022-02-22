using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TimeSheet.DB.Entity
{
    public class BaseEntity<TUniqueId> where TUniqueId : struct
    {
        [Key]
        public TUniqueId Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
