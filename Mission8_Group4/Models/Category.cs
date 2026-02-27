using System.ComponentModel.DataAnnotations;

namespace Mission8_Group4.Models;

public class Category
{
    [Key]
    public int id { get; set; }
    
    [Required]
    public string name { get; set; }
    
    // This is used to reference the tasks that the Category is associated with.
    public List<Task>? tasks { get; set; } = new List<Task>();
}