using System;

namespace CEMEX.Data.Infrastructure
{
    public interface IDbFactory: IDisposable
    {
        CemexContext Init();
    }
}
