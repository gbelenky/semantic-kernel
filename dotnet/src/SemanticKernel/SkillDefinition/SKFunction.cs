﻿// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel.SemanticFunctions;

namespace Microsoft.SemanticKernel.SkillDefinition;

#pragma warning disable format

/// <summary>
/// Static helpers to create <seealso cref="ISKFunction"/> instances.
/// </summary>
public static class SKFunction
{
    /// <summary>
    /// Create a native function instance, wrapping a native object method
    /// </summary>
    /// <param name="method">Signature of the method to invoke</param>
    /// <param name="target">Object containing the method to invoke</param>
    /// <param name="skillName">SK skill name</param>
    /// <param name="logger">Application logger</param>
    /// <returns>SK function instance</returns>
    public static ISKFunction FromNativeMethod(
        MethodInfo method,
        object? target = null,
        string? skillName = null,
        ILogger? logger = null)
            => NativeFunction.FromNativeMethod(method, target, skillName, logger);

    /// <summary>
    /// Create a native function instance, wrapping a delegate function
    /// </summary>
    /// <param name="nativeFunction">Function to invoke</param>
    /// <param name="skillName">SK skill name</param>
    /// <param name="functionName">SK function name</param>
    /// <param name="description">SK function description</param>
    /// <param name="parameters">SK function parameters</param>
    /// <param name="logger">Application logger</param>
    /// <returns>SK function instance</returns>
    public static ISKFunction FromNativeFunction(
        Delegate nativeFunction,
        string? skillName = null,
        string? functionName = null,
        string? description = null,
        IEnumerable<ParameterView>? parameters = null,
        ILogger? logger = null)
            => NativeFunction.FromNativeFunction(nativeFunction, skillName, functionName, description, parameters, logger);

    /// <summary>
    /// Create a native function instance, given a semantic function configuration.
    /// </summary>
    /// <param name="skillName">Name of the skill to which the function to create belongs.</param>
    /// <param name="functionName">Name of the function to create.</param>
    /// <param name="functionConfig">Semantic function configuration.</param>
    /// <param name="logger">Optional logger for the function.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>SK function instance.</returns>
    public static ISKFunction FromSemanticConfig(
        string skillName,
        string functionName,
        SemanticFunctionConfig functionConfig,
        ILogger? logger = null,
        CancellationToken cancellationToken = default)
            => SemanticFunction.FromSemanticConfig(skillName, functionName, functionConfig, logger, cancellationToken);
}
