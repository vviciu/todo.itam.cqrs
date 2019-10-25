using System;
using System.ComponentModel.DataAnnotations;

namespace todo.item.model.Model
{
    public class TodoItem
    {
        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Dead line")]
        [Required]
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
    }
}
