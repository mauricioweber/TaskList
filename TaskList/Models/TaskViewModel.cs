using System;
using System.ComponentModel.DataAnnotations;

namespace TaskList.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The title is a required field.")]
        public string Title { get; set; }

        public string Description { get; set; }

        public TaskStatusViewModel Status { get; set; }

       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        [Display(Name = "Creation Date")]
        public DateTime? CreationDate { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        [Display(Name = "Edit Date")]
        public DateTime? EditDate { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        [Display(Name = "Concluded Date")]
        public DateTime? ConcludedDate { get; set; }
    }
}