using System.ComponentModel.DataAnnotations;
namespace estudo_c_.Data.Dtos;
public class ReadFilmDto
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo titulo eh obrigatorio")]
    public string Title { get; set; }

    [Required(ErrorMessage = "O campo diretor eh obrigatorio")]
    public string Director { get; set; }
    public string Genre { get; set; }

    [Range(1, 600, ErrorMessage = "A duracao deve ter no minimo 1 min e no max 600 min")]
    public string Duration { get; set; }

    public DateTime TimeStamp { get; set; }

}