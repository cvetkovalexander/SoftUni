namespace MusicHub.Data;

using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

public class MusicHubDbContext : DbContext
{
    public MusicHubDbContext()
    {
    }

    public MusicHubDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Song> Songs { get; set; } = null!;
    public virtual DbSet<Performer> Performers { get; set; } = null!;
    public virtual DbSet<Album> Albums { get; set; } = null!;
    public virtual DbSet<SongPerformer> SongsPerformers { get; set; } = null!;
    public virtual DbSet<Producer> Producers { get; set; } = null!;
    public virtual DbSet<Writer> Writers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder
                .UseSqlServer(Configuration.ConnectionString);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<SongPerformer>(e =>
        {
            e.HasKey(sp => new { sp.SongId, sp.PerformerId });
        });


        base.OnModelCreating(builder);
    }
}
