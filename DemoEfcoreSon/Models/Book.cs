using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoEfcoreSon.Models;

public class Book
{
    [Key]
    public int BookId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int PageNumber { get; set; }
    [Required]
    public string Author { get; set; }
    [Required] 
    public int ShopId { get; set; }
    [ForeignKey("ShopId")]
    public Shop Shop { get; set; }
}