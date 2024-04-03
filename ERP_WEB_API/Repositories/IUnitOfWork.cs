namespace ERP_WEB_API.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        ICompinfsRepository Comp { get; }
        void Saved();
    }
}
