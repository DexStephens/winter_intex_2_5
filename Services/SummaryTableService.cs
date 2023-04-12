using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using winter_intex_2_5.Data.Repositories;
using winter_intex_2_5.Models;

namespace winter_intex_2_5.Services
{
    public class SummaryTableService
    {
        private IMummyRepository _mummyRepository;

        public SummaryTableService(IMummyRepository mummyRepository)
        {
            _mummyRepository = mummyRepository;
        }

        public IEnumerable<SummaryTable> FilterSummaryRowItemsByCriteria(SummaryTableFilter summaryTableFilter)
        {
            var filteredSummaryTables = _mummyRepository.SummaryTables;

            if(summaryTableFilter.TextileColors != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => summaryTableFilter.TextileColors.Contains(x.Textilecolor));
            }
            if(summaryTableFilter.Structures != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => summaryTableFilter.Structures.Contains(x.Structure));
            }
            if (summaryTableFilter.DeathAges != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => summaryTableFilter.DeathAges.Contains(x.Ageatdeath));
            }
            if (summaryTableFilter.HeadDirections != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => summaryTableFilter.HeadDirections.Contains(x.Headdirection));
            }
            //make one for burialid
            if (summaryTableFilter.TextileFunctions != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => summaryTableFilter.TextileFunctions.Contains(x.Textilefunction));
            }
            if (summaryTableFilter.HairColors != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => summaryTableFilter.HairColors.Contains(x.Hair));
            }

            return filteredSummaryTables;
        }
    }
}
