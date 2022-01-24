namespace WebAPI.Repository
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly DataContext _ctx;

        public OfficeRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<OfficeManagement>> GetAll()
        {
            return await _ctx.OfficeManagements.ToListAsync();
        }

        public async Task<OfficeManagement> GetById(int id)
        {
            return await _ctx.OfficeManagements.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<OfficeManagement> Create(OfficeManagement officeManagement)
        {
            _ctx.OfficeManagements.Add(new OfficeManagement
            {
                EmployeeName = officeManagement.EmployeeName,
                Task = officeManagement.Task,
                TaskCompleteBy = officeManagement.TaskCompleteBy,
                IsTaskComplete = officeManagement.IsTaskComplete,

            });
            await _ctx.SaveChangesAsync();
            return officeManagement;

        }

        public async Task<OfficeManagement> Update(OfficeManagement officeManagement)
        {
            var result = await _ctx.OfficeManagements
               .FirstOrDefaultAsync(e => e.Id == officeManagement.Id);

            if (result != null)
            {

                result.EmployeeName = officeManagement.EmployeeName;
                result.Task = officeManagement.Task;
                result.TaskCompleteBy = officeManagement.TaskCompleteBy;
                result.IsTaskComplete = officeManagement.IsTaskComplete;


                await _ctx.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _ctx.OfficeManagements.FindAsync(id);
            _ctx.OfficeManagements.Remove(bookToDelete);
            await _ctx.SaveChangesAsync();
        }
    }
}
