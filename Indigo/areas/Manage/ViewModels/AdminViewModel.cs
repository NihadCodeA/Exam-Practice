using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Indigo.Areas.Manage.ViewModels
{
    public class AdminViewModel
    {
        public class LoginViewModel
        {
            [System.ComponentModel.DataAnnotations.Required]
            public string UserName { get; set; }
            [Microsoft.Build.Framework.Required]
            [MinLength(7)]
            public string Password { get; set; }
        }
    }
}
}
