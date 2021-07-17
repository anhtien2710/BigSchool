namespace BigSchool.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attendance")]
    public partial class Attendance
    {
        [Key]
        [Column(Order = 0)]
<<<<<<< HEAD
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
=======
>>>>>>> 2304f3498f000046c9f9a6d29b18559992819ec7
        public int CourseId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Attendee { get; set; }

        public virtual Course Course { get; set; }
    }
}
