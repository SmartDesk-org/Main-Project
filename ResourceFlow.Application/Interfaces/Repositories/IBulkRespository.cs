using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;

public interface IAdvancedBulkRepository
{
    Task BulkInsertUsersAsync(List<User> users);
    Task BulkInsertEmployeesAsync(List<Employees> employees);
}
