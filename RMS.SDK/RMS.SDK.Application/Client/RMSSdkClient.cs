using RMS.SDK.Application.Client;
using RMS.SDK.Application.Extensions;
using RMS.SDK.Application.Models;
using RMS.SDK.Extensions;
using RMS.SDK.Models;

namespace RMS.SDK.Client;

public class RmsSdkClient(IRMSApi api) : IRmsSdkClient
{
    public async Task<RmsCategoryCreateResponseModel> CreateCategoryAsync(RmsCategoryCreateRequestModel request)
    {
        var result =  await api.CreateCategoryAsync(request.ToDto());

        return result.ToModel();
    }




    public async Task<IngredientCreateResponseModel> CreateIngredientAsync(IngredientCreateRequestModel request)
    {

        var result = await api.CreateIngredientAsync(request.ToDto());

        return result.ToModel();

    }
}