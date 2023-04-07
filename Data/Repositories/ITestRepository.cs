using System.Linq;
using winter_intex_2_5.Models;

namespace winter_intex_2_5.Data.Repositories
{
    public interface ITestRepository
    {
        IQueryable<TestTable> Tests { get; }
    }
}
