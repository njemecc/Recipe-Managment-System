﻿namespace RMS.Domain.Entities;

public class RecipeIngrediant
{
    public Guid RecipeId { get; set; }
    public Recipe Recipe { get; set; }

    public Guid IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
}