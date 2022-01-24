using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI.Repository
{
    public class DapperOfficeRepo
    {
        private string connectionString;

        public DapperOfficeRepo()
        {
            connectionString = @"server=DESKTOP-PF8F4H7;Database=superherodb;trusted_Connection = True; MultipleActiveResultSets=True";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        //The list of all tasks or the list of everyone in our system.
        //Everyone Details and All list
        public IEnumerable<OfficeManagement> Get()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM OfficeManagements";
                dbConnection.Open();
                return dbConnection.Query<OfficeManagement>(sQuery);
            }
        }

        //Given a person’s name let that person know his tasks for a day.
        //Assistant task 
        public IEnumerable<OfficeManagement> GetByName(string TaskCompleteBy)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM OfficeManagements WHERE TaskCompleteBy=@TaskCompleteBy";
                dbConnection.Open();
                return dbConnection.Query<OfficeManagement>(sQuery, new { TaskCompleteBy = TaskCompleteBy }).ToList();
            }
        }


        //Given a person’s name let that person know his requested task for a day
        //Individual Employee details
        public OfficeManagement GetByEmployeeName(string EmployeeName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM OfficeManagements WHERE EmployeeName=@EmployeeName";
                dbConnection.Open();
                return dbConnection.Query<OfficeManagement>(sQuery, new { EmployeeName = EmployeeName }).FirstOrDefault();
            }
        }

        // Given a person’s name, show us the list of tasks completed by that person.
        //Enter Assistent name WHERE IsTaskComplete == yes
        //Bonous Task
        public IEnumerable<OfficeManagement> GetAssistantCompletedTask(string TaskCompleteBy)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM OfficeManagements WHERE TaskCompleteBy=@TaskCompleteBy
                                AND  IsTaskComplete='yes' OR
                                      IsTaskComplete='YES' OR
                                      IsTaskComplete='Yes' OR
                                      IsTaskComplete='yEs' OR
                                      IsTaskComplete='yeS' ";

                dbConnection.Open();
                return dbConnection.Query<OfficeManagement>(sQuery, new {TaskCompleteBy = TaskCompleteBy}).ToList();
            }
        }

    }
}
