using Riok.Mapperly.Abstractions;
using RMS.Application.Common.Dto.Category;
using RMS.Domain.Entities;
using RMS.Domain.Enums;

namespace RMS.Application.Common.Mappers;

[Mapper]
public static partial class CategoryMapper
{
    public static  Category FromCreateCategoryDtoToEntity(this CategoryCreateDto dto)
    {
        return new Category("Kategorija", 14);
    }

    public static  CategoryDetailsDto ToCategoryDetailsDto(this Category entity)
    {
        var categoryDetailsDto = new CategoryDetailsDto(entity.Name);

        return categoryDetailsDto;
    }
}