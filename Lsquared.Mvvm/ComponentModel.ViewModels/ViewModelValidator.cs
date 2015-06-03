// <copyright file="ViewModelValidator.cs" company="LSQUARED">
// Copyright © 2008-2014
// </copyright>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

namespace Lsquared.ComponentModel.ViewModels
{
    public static class ViewModelValidator
    {
        public static bool TryValidateObject(object instance, ValidationContext context, ICollection<ValidationResult> results)
        {
            Check.IsNotNull(instance, "instance");
            Check.IsNotNull(context, "context");
            Check.IsNotNull(results, "results");

            // Check all properties.
            foreach (var property in instance.GetType().GetProperties())
            {
                // Retrieve display name of the property.
                var display = property.GetCustomAttribute<DisplayAttribute>(true);
                context.DisplayName = display == null ? property.Name : display.GetName();

                // Set property name.
                context.MemberName = property.Name;

                // Retrieve property value.
                var value = property.GetValue(instance, new object[0]);

                // Validate for each ValidationAttribute.
                var attributes = property.GetCustomAttributes<ValidationAttribute>(true);
                foreach (var attribute in attributes.Reverse())
                {
                    var result = attribute.GetValidationResult(value ?? string.Empty, context);
                    if (result != null)
                    {
                        results.Add(result);
                    }
                }
            }

            // Check for custom validation.
            var validatableObject = instance as IValidatableObject;
            if (validatableObject != null)
            {
                foreach (var result in validatableObject.Validate(context))
                {
                    if (result != null)
                    {
                        results.Add(result);
                    }
                }
            }

            return !results.Any();
        }
    }
}
