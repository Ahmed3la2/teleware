using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace TeleWare.Api.DTOs.Validations
{
    public class NotEmptyListAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is IList list)
            {
                return list.Count > 0;
            }

            return false;
        }
    }

}
