// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace OtripleS.Web.Api.Models.Meals.Exceptions
{
    public class FailedMealStorageException : Xeption
    {
        public FailedMealStorageException(Exception innerException)
            : base(message: "Failed meal storage error ocurred, contact support.",
                  innerException)
        { }
    }
}
