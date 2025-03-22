using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APILabs.Filters
{
    public class studentResultFilterAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                if (objectResult.Value is APILabs.Models.Student student)
                {
                    if (string.IsNullOrEmpty(student.Image))
                    {
                        student.Image = "default.jpg";
                    }

                    if (string.IsNullOrEmpty(student.PhoneNum))
                    {
                        student.PhoneNum = "Not Provided";
                    }
                }
            }
        }
    }
}

