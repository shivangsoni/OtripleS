// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System.Linq;
using FluentAssertions;
using Moq;
using OtripleS.Web.Api.Models.Meals;
using Xunit;

namespace OtripleS.Web.Api.Tests.Unit.Services.Foundations.Meals
{
    public partial class MealServiceTests
    {
        [Fact]
        public void ShouldRetrieveAllMeals()
        {
            // given
            IQueryable<Meal> randomMeals = CreateRandomMeals();
            IQueryable<Meal> selectedMeals = randomMeals;
            IQueryable<Meal> expectedMeals = selectedMeals;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllMeals())
                    .Returns(selectedMeals);

            // when
            IQueryable<Meal> actualMeals =
                this.mealService.RetrieveAllMeals();

            // then
            actualMeals.Should().BeEquivalentTo(expectedMeals);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllMeals(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
