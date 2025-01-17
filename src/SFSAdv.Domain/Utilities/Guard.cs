﻿using SFSAdv.Domain.Abstractions.Exceptions;

namespace SFSAdv.Domain.Utilities;

public static class Guard
{
    public static void AgainstNegative(decimal value, string parameterName)
    {
        if (value < 0)
            throw new DomainValidationException($"{parameterName} cannot be negative.");
    }

    public static void AgainstNegative(double value, string parameterName)
    {
        if (value < 0)
            throw new DomainValidationException($"{parameterName} cannot be negative.");
    }

    public static void AgainstNegative(int value, string parameterName)
    {
        if (value < 0)
            throw new DomainValidationException($"{parameterName} cannot be negative.");
    }

    public static void AgainstEmpty(Guid? value, string parameterName)
    {
        if (value is null || value == Guid.Empty)
            throw new DomainValidationException($"{parameterName} cannot be empty.");
    }

    public static void AgainstNullOrEmpty(string? value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainValidationException($"{parameterName} cannot be null or empty.");
    }

    public static void AgainstNull(object? value, string parameterName)
    {
        if (value is null)
            throw new DomainValidationException($"{parameterName} cannot be null or empty.");
    }
}