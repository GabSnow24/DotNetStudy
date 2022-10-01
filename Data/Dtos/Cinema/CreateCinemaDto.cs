using System.ComponentModel.DataAnnotations;
namespace estudo_c_.Data.Dtos.Cinema;
public class CreateCinemaDto
{
    
    [Required(ErrorMessage = "O campo nome eh obrigatorio")]
    public string Name {get; set;}
    
    [Required(ErrorMessage = "O campo dono eh obrigatorio")]
    public string Owner { get; set; }

    [Required(ErrorMessage = "O campo telefone eh obrigatorio")]
    public string Phone { get; set; }
    

}