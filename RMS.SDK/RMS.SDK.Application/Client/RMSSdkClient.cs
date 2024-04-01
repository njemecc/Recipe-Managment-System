using RMS.SDK.Application.Extensions;
using RMS.SDK.Application.Models;

namespace RMS.SDK.Application.Client;

public class RmsSdkClient(IRMSApi api) : IRmsSdkClient
{
    public async Task<RmsCategoryCreateResponseModel> CreateCategoryAsync(RmsCategoryCreateRequestModel request)
    {
        var result =  await api.CreateCategoryAsync(request.ToDto());

        return result.ToModel();
    }
}