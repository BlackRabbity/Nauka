using FizzBuzzNET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzNET.Data
{
    public class FizzbuzzContext : DbContext
    {
        public DbSet<Fizzbuzz> Fizzbuzz { get; set; }
        public FizzbuzzContext(DbContextOptions options) : base(options) { }

    }
}
