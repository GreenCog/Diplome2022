using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Antitriche_diplome.models.ApiModels
{
    public class Antitriche_diplomebackContext : DbContext
    {
        public Antitriche_diplomebackContext(DbContextOptions<Antitriche_diplomebackContext> options)
            : base(options)
        {
        }
        public DbSet<Resultat> Resultats { get; set; }

        public DbSet<ResultatAFK> ResultatAFKs { get; set; }
        public DbSet<ResultatWindow> ResultatWindows { get; set; }
        public DbSet<ResultatWeb> ResultatWebs { get; set; }
        public DbSet<Regle> Regles { get; set; }

    }
}
