using System;
using System.Data;

namespace LeanWork.Persistence.Connection
{
    public interface IConnectionDB : IDisposable
    {
        IDbConnection OpenConnection();
        void CloseConnection();
    }
}
