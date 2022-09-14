﻿using ProyectoCafeteria.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.AccesoADatos
{
  
        public class BDContexto : DbContext
        {
            public DbSet<Rol> Rol { get; set; }
            public DbSet<Usuario> Usuario { get; set; }
            public DbSet<Categoria> Categoria { get; set; }
            public DbSet<Producto> Producto { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=JC-PC;Initial Catalog=ProyectoEjemplo;Integrated Security=True");
            }
        }
    }

