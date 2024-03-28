using Riok.Mapperly.Abstractions;
using RMS.Application.Common.Dto.Category;
using RMS.Domain.Entities;

namespace RMS.Application.Common.Mappers;

[Mapper]
public static partial class CategoryMapper
{
    public static partial Category FromCreateCategoryDtoToEntity(this CategoryCreateDto dto);

    public static  CategoryDetailsDto ToCategoryDetailsDto(this Category entity)
    {
        var categoryDetailsDto = new CategoryDetailsDto(entity.Name);

        return categoryDetailsDto;
    }
}