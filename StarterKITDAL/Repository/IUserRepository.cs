namespace StarterKITDAL.Repository
{
    public interface IUserRepository
    {
        User Login(User user);
        User GetByUserName(string userName);
        int Save(User user);
    }
}