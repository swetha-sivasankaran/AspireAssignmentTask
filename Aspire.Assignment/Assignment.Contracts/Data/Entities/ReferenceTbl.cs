using System;
using System.Collections.Generic;

namespace Assignment.Contracts.Data.Entities{
    public partial class ReferenceTbl
    {
        public ReferenceTbl()
        {
            EmployeeDetailGenderRefs = new HashSet<EmployeeDetail>();
            EmployeeDetailPracticeRefs = new HashSet<EmployeeDetail>();
        }

        public int ReferenceId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string GroupName { get; set; } = null!;

        public virtual ICollection<EmployeeDetail> EmployeeDetailGenderRefs { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetailPracticeRefs { get; set; }
    }
}
