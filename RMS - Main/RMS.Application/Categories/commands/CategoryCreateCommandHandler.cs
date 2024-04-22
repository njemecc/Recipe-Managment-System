using MediatR;
using RMS.Application.Common.Dto.Category;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Mappers;

namespace RMS.Application.Categories.commands;

public class CategoryCreateCommandHandler(IPostgresDbContext dbContext) : IRequestHandler<CategoryCreateCommand,CategoryDetailsDto>
{
    public async Task<CategoryDetailsDto> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        // var category =  dbContext.Categories.Add(request.Category.FromCreateCategoryDtoToEntity());
        //
        // await dbContext.SaveChangesAsync(cancellationToken);
        //
        return request.Category.FromCreateCategoryDtoToEntity().ToCategoryDetailsDto();
    }
}