using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8_Group4.Models;

public class Task
{
    [Key] [Required]
    public int id { get; set; }
    
    [Required]
    public string name  { get; set; }
    
    // If no dueDate is provided then load the database with a null value
    public DateTime? dueDate { get; set; } = null;

    [Required]
    public int quadrant { get; set; }
    
    [ForeignKey("Category")]
    public int categoryId { get; set; }
    
    // Default completed values to false (since it's probably new and unfinished)
    public bool completed { get; set; } = false;
}
