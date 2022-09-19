using System.ComponentModel.DataAnnotations;
namespace estudo_c_.Models;
public class Film
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo titulo eh obrigatorio")]
    public string Title {get; set;}
    
    [Required(ErrorMessage = "O campo diretor eh obrigatorio")]
    public string Director { get; set; }
    public string Genre { get; set; }
    
    [Range(1,600, ErrorMessage = "A duracao deve ter no minimo 1 min e no max 600 min")]
    public string Duration { get; set; }

    public void Deconstruct(out int _Id, out string _Title, out string _Director, out string _Genre, out string _Duration){
        _Id = this.Id;
        _Title = this.Title;
        _Director = this.Director;
        _Genre = this.Genre;
        _Duration = this.Duration;
    }
}