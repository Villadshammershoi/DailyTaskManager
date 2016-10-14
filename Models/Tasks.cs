namespace DailyTaskMang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tasks
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public DateTime? EndTime { get; set; }

        public int FK_Categories { get; set; }

        public DateTime? StartTime { get; set; }

        [ForeignKey("FK_Categories")]
        public virtual Categories Categories { get; set; }
    }
}
