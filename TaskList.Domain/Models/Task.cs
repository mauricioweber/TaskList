using System;
using System.ComponentModel.DataAnnotations;

namespace TaskList.Domain.Models
{
    public class Task
    {
        [Key] public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? ConcludedDate { get; set; }
    }
}