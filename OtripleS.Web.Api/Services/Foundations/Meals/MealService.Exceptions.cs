// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OtripleS.Web.Api.Models.Meals;
using OtripleS.Web.Api.Models.Meals.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xeptions;

namespace OtripleS.Web.Api.Services.Foundations.Meals
{
    public partial class MealService
    {
        private delegate ValueTask<Meal> ReturningMealFunction();
        private delegate IQueryable<Meal> ReturningQueryableMealFunction();

        private IQueryable<Meal> TryCatch(ReturningQueryableMealFunction returningQueryableMealFunction)
        {
            try
            {
                return returningQueryableMealFunction();
            }
            catch (SqlException sqlException)
            {
                var failedMealStorageException = new FailedMealStorageException(sqlException);
                var mealDependencyException = new MealDependencyException(failedMealStorageException);
                loggingBroker.LogCritical(mealDependencyException);
                throw mealDependencyException;
            }
        }
    }
}
