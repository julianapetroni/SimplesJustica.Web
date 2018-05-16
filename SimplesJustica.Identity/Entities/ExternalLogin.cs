using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SimplesJustica.Identity.Entities
{
    public class ExternalLogin : IdentityUserLogin<Guid>
    {
    }
}