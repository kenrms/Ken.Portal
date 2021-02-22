using Ken.Portal.Web.Models.StudentViews;
using System.Threading.Tasks;

namespace Ken.Portal.Web.Services.StudentViews
{
    public interface IStudentViewService
    {
        ValueTask<StudentView> AddStudentViewAsync(StudentView studentView);
    }
}
