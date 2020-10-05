using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LojaVirtual.DataBase
{
    public class LojaVirtualContext : DbContext
    {
        /*EF -> ORM
         * ORM -> Biblioteca que mapea objetos
         * 
         */
        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<NewsletterEmail> NewsletterEmail { get; set; }

    }
}
