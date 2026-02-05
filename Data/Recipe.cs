using System.ComponentModel.DataAnnotations;
namespace MIDTERM_Q3_32E3_YuanJasper_Rodriguez.Data;
public class Recipe
{
    [Key] public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string InternalComments { get; set; } = string.Empty; // Secret info!
    public string Instruction { get; set; } = string.Empty;
    public List<Ingredient> Ingredients { get; set; } = new();
}
