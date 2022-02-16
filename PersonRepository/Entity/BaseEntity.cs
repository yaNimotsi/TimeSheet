using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.DB.Entity
{
    public class BaseEntity<TUniqueId> where TUniqueId : struct
    {
        public TUniqueId Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
