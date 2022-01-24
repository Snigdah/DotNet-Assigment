namespace WebAPI.Repository
{
    public interface IOfficeRepository
    {

        Task<List<OfficeManagement>> GetAll();
        Task<OfficeManagement> GetById(int id);
        Task<OfficeManagement> Create(OfficeManagement officeManagement);
        Task<OfficeManagement> Update(OfficeManagement officeManagement);
        Task Delete(int id);
    }
}
