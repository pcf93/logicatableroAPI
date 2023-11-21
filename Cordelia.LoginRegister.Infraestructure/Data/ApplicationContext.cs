using Cordelia.LoginRegister.Domain.Model;
using Enfonsalaflota.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Cordelia.LoginRegister.Infraestructure.Data;

public class ApplicationContext : DbContext
{
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Message> Message { get; set; }
    public virtual DbSet<FriendRequest> FriendRequest { get; set; }

    public virtual DbSet<Match> Match { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("pcfapi");
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName).IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserEmail).IsUnique();

        modelBuilder.Entity<Message>()
            .HasOne(x => x.MessageSender)
            .WithMany(x => x.SentMessages)
            .HasForeignKey(x => x.MessageSenderId);

        modelBuilder.Entity<Message>()
            .HasOne(x => x.MessageReceiver)
            .WithMany(x => x.ReceivedMessages)
            .HasForeignKey(x => x.MessageReceiverId);

        modelBuilder.Entity<FriendRequest>()
            .HasOne(x => x.FriendRequestReceiver)
            .WithMany(x => x.ReceivedFriendRequests)
            .HasForeignKey(x => x.FriendRequestReceiverId);

        modelBuilder.Entity<FriendRequest>()
            .HasOne(x => x.FriendRequestSender)
            .WithMany(x => x.SentFriendRequests)
            .HasForeignKey(x => x.FriendRequestSenderId);

        modelBuilder.Entity<Match>()
            .HasOne(x => x.Player1)
            .WithMany(x => x.Player1Matches)
            .HasForeignKey(x => x.Player1Id);

        modelBuilder.Entity<Match>()
            .HasOne(x => x.Player2)
            .WithMany(x => x.Player2Matches)
            .HasForeignKey(x => x.Player2Id);

    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) //con este constructor ya pasamos la cadena de conexión al contexto
    {
        //Fluent API - pseudolenguaje que nos permite hacer la configuración sin que el modelo tenga una dependencia externa (no queremos configurar nada en el Domain)



    }

}
