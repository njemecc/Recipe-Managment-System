using Microsoft.AspNetCore.Mvc;
using Refit;
using RMS.SDK;
using RMS.SDK.Application.Client;
using RMS.SDK.Application.Models;
using RMS.SDK.Dto;


namespace RMSTestSdk.Controllers;

public class IngredientController() : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(RMSCategoryCreateDto category)
    {

        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5035")
        };


        var myApi = RestService.For<IRMSApi>(httpClient);
        var client = new RmsSdkClient(myApi);
        
        var result = await client.CreateCategoryAsync(new RmsCategoryCreateRequestModel(category.Name));
        return Ok(result);

    }
}