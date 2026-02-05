using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MIDTERM_Q3_32E3_YuanJasper_Rodriguez.Data;
using MIDTERM_Q3_32E3_YuanJasper_Rodriguez.Models;
using ResourceApi.Data;
using ResourceApi.Models;
namespace MIDTERM_Q3_32E3_YuanJasper_Rodriguez.Controllers
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RecipesController(ResourceDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var entities = await context.Recipes.Include(r => r.Ingredients).ToListAsync();

        // Map Entities to DTOs to hide 'InternalComments'
        var responses = entities.Select(e => new RecipeListResponse(
            e.Id, e.Title, e.Instruction, new List<IngredientDto>()
        ));
        return Ok(responses);
    }
}
