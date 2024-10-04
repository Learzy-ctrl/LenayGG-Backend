﻿

namespace LGG.LenayGestorGatos.Infraestructure.DataContexts
{
    public class GestorGastosContext : DbContext
    {
        public GestorGastosContext(DbContextOptions<GestorGastosContext> options) : base(options) {}

        #region Generic Dtos DB
        public DbSet<RespuestaDB> respuestaDB { get; set; }
        public DbSet<UsuarioDto> usuarioDto { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("", new MySqlServerVersion(new Version(8, 0, 0)));
            }
        }
    }
}