using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.ViewModels;

public class InputActorViewModel
{
    [Required]
    [ShortNameOrLastName(4, 4)]
    public string Name { get; set; }
    
    [Required]
    [ShortNameOrLastName(4, 4)]
    public string LastName { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
}