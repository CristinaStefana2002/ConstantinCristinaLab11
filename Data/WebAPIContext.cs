using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConstantinCristinaLab11.Models;

namespace ConstantinCristinaLab11.Data
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext (DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ConstantinCristinaLab11.Models.ShopList> ShopList { get; set; } = default!;
    }
}
