using Enfonsalaflota.Domain.Model;

namespace Cordelia.LoginRegister.Domain.Model;

    public class User
    {
        public int UserId { get; set; }

        public string UserEmail { get; set; } = string.Empty;

        public string UserPassword { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string UserPhone { get; set; } = string.Empty;

        public DateTime UserBirthDate { get; set; }

        public string UserCity {  get; set; } = string.Empty;

    /*propiedad de navegación -- utilizar para relaciones entre entidades

    public UserLanguage UserLanguage { get; set; }

    public UserType UserType { get; set; }*/

        public ICollection<Message> SentMessages { get; set; }

        public ICollection<Message> ReceivedMessages { get; set; }

        public ICollection<FriendRequest> SentFriendRequests { get; set; }

        public ICollection<FriendRequest> ReceivedFriendRequests { get; set; }



}

