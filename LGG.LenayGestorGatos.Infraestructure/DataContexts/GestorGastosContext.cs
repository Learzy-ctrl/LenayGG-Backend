namespace LGG.LenayGestorGatos.Infraestructure.DataContexts
{
    public class GestorGastosContext : DbContext
    {
        public GestorGastosContext(DbContextOptions<GestorGastosContext> options) : base(options) {}

        #region Generic Dtos DB
        public DbSet<RespuestaDB> respuestaDB { get; set; }
        public DbSet<UsuarioDto> usuarioDto { get; set; }
        public DbSet<WalletDto> walletDto { get; set; }
        public DbSet<GastoDto> gastoDto { get; set; }
        public DbSet<IngresoDto> ingresoDto {  get; set; }
        public DbSet<CategoriaDto> categoriaDto { get; set; }
        public DbSet<GastosPorCategoriaDto> gastosPorCategoriaDtos { get; set; }
        public DbSet<NotificationDto> notificationDto { get; set; }   
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GastoDto>().HasNoKey();
            modelBuilder.Entity<GastosPorCategoriaDto>().HasNoKey();
            modelBuilder.Entity<NotificationDto>().HasNoKey();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("", new MySqlServerVersion(new Version(9, 0, 0)));
            }
        }
    }
}