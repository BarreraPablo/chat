using Chat.Repositories;

namespace Chat.Interfaces
{
    public interface IUnitOfWork
    {
        UserRepository UserRepository { get; }

        void Commit();
        void BeginTransaction();
        void Open();
        void Rollback();
    
}
}
