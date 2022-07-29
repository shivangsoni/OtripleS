// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System.Linq;
using OtripleS.Web.Api.Models.Meals;

namespace OtripleS.Web.Api.Services.Foundations.Meals
{
    public interface IMealService
    {
        IQueryable<Meal> RetrieveAllMeals();
    }
}
