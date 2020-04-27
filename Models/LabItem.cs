using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Api.Models
{
    public class LabItem
    {
        [Key]
        public Guid Code { get; set; }
        public Guid? ParentId { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }

        public string Base64 { get; set; }
        public string Extension { get; set; }
        public ItemTypeEum Type { get; set; }
    }
}
