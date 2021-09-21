using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Serialization;

namespace Core.UnitOfWorks
{
    public interface IDapperUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        IsolationLevel IsolationLevel { get; }
        void Commit();

    }
}
