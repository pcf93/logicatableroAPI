using Enfonsalaflota.Domain.Model;

namespace Cordelia.LoginRegister.Domain.Model;

    public class User
    {
        public int UserId { get; set; }

        public string UserEmail { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

    public string UserName { get; set; } = string.Empty;

        public string UserPhone { get; set; } = string.Empty;

        public DateTime UserBirthDate { get; set; }

        public string UserCity {  get; set; } = string.Empty;

    //estos borrarlos en mi modelo
    public Boolean DarkMode { get; set; }

    public int UserLanguageId { get; set; }

    public int UserTypeId { get; set; }

    /*propiedad de navegación -- utilizar para relaciones entre entidades

    public UserLanguage UserLanguage { get; set; }

    public UserType UserType { get; set; }*/

    public ICollection<Message> SentMessages { get; set; }

        public ICollection<Message> ReceivedMessages { get; set; }

        public ICollection<FriendRequest> SentFriendRequests { get; set; }

        public ICollection<FriendRequest> ReceivedFriendRequests { get; set; }

        public ICollection<Match> Player1Matches { get; set; }

        public ICollection<Match> Player2Matches { get; set; }

        public ICollection<Match> WinnerInMatches {  get; set; }

        public ICollection<Match> HasTurnInMatches { get; set; }

}

