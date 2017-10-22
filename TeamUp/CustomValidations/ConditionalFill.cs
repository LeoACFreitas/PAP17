using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamUp.CustomValidations
{
    public class ConditionalFill : ValidationAttribute
    {

        private String targetPropertyName;

        public ConditionalFill(String targetPropertyName)
        {
            this.targetPropertyName = targetPropertyName;

            if (String.IsNullOrEmpty(ErrorMessage))
                ErrorMessage = "O campo " + targetPropertyName + " deve ser preenchido.";
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null || (value.GetType() == typeof(string) && value.ToString() == ""))
                return ValidationResult.Success;

            Type type = validationContext.ObjectType;
            object targetValue = type.GetProperty(targetPropertyName).GetValue(validationContext.ObjectInstance);
            bool isTargetString = type.GetProperty(targetPropertyName).PropertyType == typeof(string);            

            if (targetValue == null || (isTargetString && value.ToString() == ""))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }

    }
}