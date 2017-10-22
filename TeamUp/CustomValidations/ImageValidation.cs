using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace TeamUp.CustomValidations
{
    public class ImageValidation : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
                return ValidationResult.Success;

            if (value.GetType() != typeof(HttpPostedFileWrapper))
                throw new Exception("Essa validação aceita apenas objetos do tipo HttpPostedFileBase.");

            HttpPostedFileWrapper file = value as HttpPostedFileWrapper;

            if (Path.GetExtension(file.FileName) != ".jpg")
                return new ValidationResult("A extensão da imagem deve ser jpg.");

            if ((file.ContentLength / Math.Pow(1024, 2)) > 4.0)
                return new ValidationResult("A imagem deve ter menos de 4 MB.");

            return ValidationResult.Success;
        }


    }
}