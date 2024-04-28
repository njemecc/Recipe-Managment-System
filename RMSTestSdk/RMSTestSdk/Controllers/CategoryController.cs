using Microsoft.AspNetCore.Mvc;
using Refit;
using RMS.SDK;
using RMS.SDK.Dto;


namespace RMSTestSdk.Controllers;

public class CategoryController() : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(RMSCategoryCreateDto category)
    {

        // var myApi = RestService.For<IRMSApi>("http://localhost:5035");
        // var result = await myApi.CreateCategoryAsync(new RMSCategoryCreateRequestDto(category));
        // return Ok(result);
        return Ok();
    }
}