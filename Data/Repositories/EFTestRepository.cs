using System.Linq;
using winter_intex_2_5.Models;

namespace winter_intex_2_5.Data.Repositories
{
    public class EFTestRepository : ITestRepository
    {
        public RDSContext Context { get; set; }
        public EFTestRepository(RDSContext context) 
        {
            Context = context;
        }
        public IQueryable<TestTable> Tests => Context.tests;
    }
}
