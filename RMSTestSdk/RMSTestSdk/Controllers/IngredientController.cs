using Microsoft.AspNetCore.Mvc;
using Refit;
using RMS.SDK;
using RMS.SDK.Api.Dto.Ingredient;
using RMS.SDK.Client;
using RMS.SDK.Models;

namespace RMSTestSdk.Controllers;

public class IngredientController:ControllerBase

{
    [HttpPost("createIngredient")]
    public async Task<IActionResult> Create(IngredientCreateDto ingredient)
    {

        var myApi =  RestService.For<IRMSApi>("http://localhost:5035");

        var client = new RmsSdkClient(myApi);
        
        var result = await client.CreateIngredientAsync(new IngredientCreateRequestModel(ingredient.Name));
        return Ok(result);

    }
}   
