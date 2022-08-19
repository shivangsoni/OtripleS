// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using OtripleS.Web.Api.Models.Meals.Exceptions;
using Xunit;

namespace OtripleS.Web.Api.Tests.Unit.Services.Foundations.Meals
{
    public partial class MealServiceTests
    {
        [Fact]
        public void ShouldThrowCriticalDepdendencyExceptionOnRetrieveAllIfSqlErrorOccurrsAndLogIt()
        {
            // given
            SqlException sqlException = GetSqlException();

            var failedMealStorageException =
                new FailedMealStorageException(sqlException);

            var expectedMealDependencyException =
                new MealDependencyException(failedMealStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllMeals())
                    .Throws(sqlException);

            // when
            Action retrieveAllMealsAction = () =>
                this.mealService.RetrieveAllMeals();

            MealDependencyException actualMealDependencyException =
                Assert.Throws<MealDependencyException>(
                    retrieveAllMealsAction);

            // then
            actualMealDependencyException.Should().BeEquivalentTo(
                expectedMealDependencyException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllMeals(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(
                    SameExceptionAs(expectedMealDependencyException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
