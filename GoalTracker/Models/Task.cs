using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoalTracker.Models
{
    [Table("dbo.Tasks")]
    public class Task
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }
        [Display(Name = "Completion Date")]
        [DataType(DataType.Date)]
        public DateTime ? CompletionDate { get; set; }
        public int ? Difficulty { get; set; }
        public string InsertUser { get; set; }
        public string Type { get; set; }
        public string Tag { get; set; }
    }
}