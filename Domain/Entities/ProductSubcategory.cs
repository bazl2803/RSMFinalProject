﻿namespace Domain.Entities
{
    using Abstractions;

    public class ProductSubcategory : Entity<int>
    {
        public string? Name { get; init; }
    }
}