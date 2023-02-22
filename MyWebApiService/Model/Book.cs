using System.ComponentModel.DataAnnotations;

namespace MyWebApiService.Model;

public class Book
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

}