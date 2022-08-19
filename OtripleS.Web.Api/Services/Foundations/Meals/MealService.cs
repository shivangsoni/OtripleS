﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using OtripleS.Web.Api.Brokers.Loggings;
using OtripleS.Web.Api.Brokers.Storages;
using OtripleS.Web.Api.Models.Meals;
using OtripleS.Web.Api.Models.Meals.Exceptions;

namespace OtripleS.Web.Api.Services.Foundations.Meals
{
    public class MealService : IMealService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public MealService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public IQueryable<Meal> RetrieveAllMeals()
        {
            try
            {
                return this.storageBroker.SelectAllMeals();
            }
            catch(SqlException sqlException)
            {
                var failedMealStorageException = new FailedMealStorageException(sqlException);
                var mealDependencyException = new MealDependencyException(failedMealStorageException);
                this.loggingBroker.LogCritical(mealDependencyException);
                throw mealDependencyException;
            }
        }
            
    }
}
