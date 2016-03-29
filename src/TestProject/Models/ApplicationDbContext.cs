using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.PlatformAbstractions;

namespace TestProject.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> { }
}
