using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapportCQRS.API.Helpers
{
    public class CustomBadRequest : ValidationProblemDetails
    {
        private StringBuilder messageBuilder;
        public string Message { get; set; }
        public CustomBadRequest(ActionContext context)
        {
            messageBuilder = new StringBuilder();

            Title = "Error Saving";
            Detail = "Invalid inputs";
            Status = 400;
            ConstructErrorMessages(context);
            Type = context.HttpContext.TraceIdentifier;
        }

        private void ConstructErrorMessages(ActionContext context)
        {
            foreach (var keyModelStatePair in context.ModelState)
            {
                var key = keyModelStatePair.Key;
                var errors = keyModelStatePair.Value.Errors;
                if (errors != null && errors.Count > 0)
                {
                    if (errors.Count == 1)
                    {
                        var errorMessage = GetErrorMessage(errors[0]);
                        Errors.Add(key, new[] { errorMessage });
                        messageBuilder.AppendLine($"{key} : {errorMessage}");
                    }
                    else
                    {
                        var errorMessages = new string[errors.Count];
                        for (var i = 0; i < errors.Count; i++)
                        {
                            errorMessages[i] = GetErrorMessage(errors[i]);
                            messageBuilder.AppendLine($"{key} : {errorMessages[i]}");
                        }
                        Errors.Add(key, errorMessages);
                    }
                }
            }

            Message = messageBuilder.ToString();

        }
        string GetErrorMessage(ModelError error)
        {
            return string.IsNullOrEmpty(error.ErrorMessage) ?
                "The input was not valid." :
            error.ErrorMessage;
        }
    }
}
