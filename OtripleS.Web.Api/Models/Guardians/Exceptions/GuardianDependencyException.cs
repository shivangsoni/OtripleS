﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace OtripleS.Web.Api.Models.Guardians.Exceptions
{
    public class GuardianDependencyException : Exception
    {
        public GuardianDependencyException(Exception innerException)
            : base(message: "Service dependency error occurred, contact support.", innerException) { }
    }
}
