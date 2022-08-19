// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Xeptions;

namespace OtripleS.Web.Api.Models.Meals.Exceptions
{
    public class MealDependencyException : Xeption
    {
        public MealDependencyException(Xeption innerException)
            : base(message: "Meal dependency error ocurred, contact support.",
                  innerException)
        { }
    }
}
