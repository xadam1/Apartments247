namespace ApartmentsDAL
{
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork Create();

        IUnitOfWork GetUnitOfWorkInstance();
    }
}