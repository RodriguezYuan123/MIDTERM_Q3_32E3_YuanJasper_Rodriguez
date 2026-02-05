namespace MIDTERM_Q3_32E3_YuanJasper_Rodriguez.Models;

public record RecipeListResponse(int Id, string Title, string Instructions, List<IngredientDto> Ingredients);