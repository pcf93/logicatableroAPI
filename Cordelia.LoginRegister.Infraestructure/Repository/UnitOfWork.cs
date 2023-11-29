using Cordelia.LoginRegister.Application.Repository;
using Cordelia.LoginRegister.Application.Services.Abstraction;
using Cordelia.LoginRegister.Domain.Model;
using Cordelia.LoginRegister.Infraestructure.Data;
using Cordelia.LoginRegister.Infraestructure.Repository;
using Enfonsalaflota.Domain.Model;

namespace Cordelia.LoginRegister.Application.Services.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext _dbContext;
        private GenericRepository<User> _userRepository;
        private GenericRepository<Message> _messageRepository;
        private GenericRepository<FriendRequest> _friendRequestRepository;
        private GenericRepository<Match> _matchRepository;
        private GenericRepository<MatchMessage> _matchMessageRepository;

        public UnitOfWork(ApplicationContext dbContext)
        {
            _dbContext = dbContext;

        }

        public IGenericRepository<User> GetUserRepository()
        {

                if (_userRepository == null)
                {
                    _userRepository = new GenericRepository<User>(_dbContext);
                }
                return _userRepository;

        }

        public IGenericRepository<Message> GetMessageRepository()
        {
  
                if (_messageRepository == null)
                {
                    _messageRepository = new GenericRepository<Message>(_dbContext);
                }
                return _messageRepository;

        }

        public IGenericRepository<FriendRequest> GetFriendRequestRepository()
        {

            if (_friendRequestRepository == null)
            {
                _friendRequestRepository = new GenericRepository<FriendRequest>(_dbContext);
            }
            return _friendRequestRepository;

        }

        public IGenericRepository<Match> GetMatchRepository()
        {

            if (_matchRepository == null)
            {
                _matchRepository = new GenericRepository<Match>(_dbContext);
            }
            return _matchRepository;

        }

        public IGenericRepository<MatchMessage> GetMatchMessageRepository()
        {

            if (_matchMessageRepository == null)
            {
                _matchMessageRepository = new GenericRepository<MatchMessage>(_dbContext);
            }
            return _matchMessageRepository;

        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected async Task Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    await _dbContext.DisposeAsync();
                }
            }
            disposed = true;
        }

        public async void Dispose()
        {
            await Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
