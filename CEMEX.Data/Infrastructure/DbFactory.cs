namespace CEMEX.Data.Infrastructure
{
    public class DbFactory:Disposable, IDbFactory
    {
        CemexContext dbContext;

        public CemexContext Init()
        {
            return dbContext ?? (dbContext = new CemexContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }   
    }
}
