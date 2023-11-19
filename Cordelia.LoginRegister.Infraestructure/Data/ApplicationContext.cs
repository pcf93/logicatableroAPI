using Cordelia.LoginRegister.Domain.Model;
using Enfonsalaflota.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Cordelia.LoginRegister.Infraestructure.Data;

public class ApplicationContext : DbContext
{
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Message> Message { get; set; }
    public virtual DbSet<FriendRequest> FriendRequest { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
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

    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) //con este constructor ya pasamos la cadena de conexión al contexto
    {
        //Fluent API - pseudolenguaje que nos permite hacer la configuración sin que el modelo tenga una dependencia externa (no queremos configurar nada en el Domain)



    }

}
