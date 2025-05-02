using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Commons
{
    public abstract class FullAuditedEntity
    {
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("CreatedBy")]
        public virtual User CreatorUser { get; set; }

        [ForeignKey("LastModifiedBy")]
        public virtual User ModifierUser { get; set; }
    }
}
