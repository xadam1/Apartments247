using System;

namespace ApartmentsDAL
{
    public interface IUnitOfWork
    {
        void Commit();
        void RegisterActionAfterCommit(Action action);
    }
}