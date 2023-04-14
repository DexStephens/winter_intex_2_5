using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var filteredSummaryTables = _mummyRepository.SummaryTables.Where(x => !string.IsNullOrEmpty(x.Depth));

            if(summaryTableFilter.TextileColors != null && summaryTableFilter.TextileColors.First() != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => summaryTableFilter.TextileColors.Contains(x.Textilecolor));
            }
            if(summaryTableFilter.Structures != null && summaryTableFilter.Structures.First() != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => summaryTableFilter.Structures.Contains(x.Structure));
            }
            if (summaryTableFilter.DeathAges != null && summaryTableFilter.DeathAges.First() != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => summaryTableFilter.DeathAges.Contains(x.Ageatdeath));
            }
            if (summaryTableFilter.HeadDirections != null && summaryTableFilter.HeadDirections.First() != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => summaryTableFilter.HeadDirections.Contains(x.Headdirection));
            }
            if (summaryTableFilter.TextileFunctions != null && summaryTableFilter.TextileFunctions.First() != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => summaryTableFilter.TextileFunctions.Contains(x.Textilefunction));
            }
            if (summaryTableFilter.HairColors != null && summaryTableFilter.HairColors.First() != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => summaryTableFilter.HairColors.Contains(x.Haircolor));
            }
            if(summaryTableFilter.MinDepth != null || summaryTableFilter.MaxDepth != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => x.Depth != "U");
            }
            if(summaryTableFilter.MinDepth!= null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => Convert.ToDecimal(x.Depth) >= summaryTableFilter.MinDepth);
            }
            if (summaryTableFilter.MaxDepth != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => Convert.ToDecimal(x.Depth) <= summaryTableFilter.MaxDepth);
            }
            if (summaryTableFilter.MinStature != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => x.Estimatestature >= summaryTableFilter.MinStature);
            }
            if (summaryTableFilter.MaxStature != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => x.Estimatestature <= summaryTableFilter.MaxStature);
            }
            if(summaryTableFilter.Male && summaryTableFilter.Female)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => x.Sex == "M" || x.Sex == "F");
            }
            else
            {
                if (summaryTableFilter.Male)
                {
                    filteredSummaryTables = filteredSummaryTables.Where(x => x.Sex == "M");
                }
                else if (summaryTableFilter.Female)
                {
                    filteredSummaryTables = filteredSummaryTables.Where(x => x.Sex == "F");
                }
            }

            //make one for burialid

            return filteredSummaryTables;
        }
        public IEnumerable<SummaryTable> FilterSummaryRowItemsByNotCriteria(SummaryTableFilter summaryTableFilter)
        {
            var filteredSummaryTables = _mummyRepository.SummaryTables.Where(x => !string.IsNullOrEmpty(x.Depth));

            if (summaryTableFilter.TextileColors != null && summaryTableFilter.TextileColors.First() != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => !summaryTableFilter.TextileColors.Contains(x.Textilecolor));
            }
            if (summaryTableFilter.Structures != null && summaryTableFilter.Structures.First() != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => !summaryTableFilter.Structures.Contains(x.Structure));
            }
            if (summaryTableFilter.DeathAges != null && summaryTableFilter.DeathAges.First() != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => !summaryTableFilter.DeathAges.Contains(x.Ageatdeath));
            }
            if (summaryTableFilter.HeadDirections != null && summaryTableFilter.HeadDirections.First() != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => !summaryTableFilter.HeadDirections.Contains(x.Headdirection));
            }
            if (summaryTableFilter.TextileFunctions != null && summaryTableFilter.TextileFunctions.First() != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => !summaryTableFilter.TextileFunctions.Contains(x.Textilefunction));
            }
            if (summaryTableFilter.HairColors != null && summaryTableFilter.HairColors.First() != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => !summaryTableFilter.HairColors.Contains(x.Haircolor));
            }
            if (summaryTableFilter.MinDepth != null || summaryTableFilter.MaxDepth != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => x.Depth != "U");
            }
            if (summaryTableFilter.MinDepth != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => Convert.ToDecimal(x.Depth) <= summaryTableFilter.MinDepth);
            }
            if (summaryTableFilter.MaxDepth != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => Convert.ToDecimal(x.Depth) >= summaryTableFilter.MaxDepth);
            }
            if (summaryTableFilter.MinStature != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => x.Estimatestature <= summaryTableFilter.MinStature);
            }
            if (summaryTableFilter.MaxStature != null)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => x.Estimatestature >= summaryTableFilter.MaxStature);
            }
            if (summaryTableFilter.Male && summaryTableFilter.Female)
            {
                filteredSummaryTables = filteredSummaryTables.Where(x => x.Sex != "M" || x.Sex != "F");
            }
            else
            {
                if (summaryTableFilter.Male)
                {
                    filteredSummaryTables = filteredSummaryTables.Where(x => x.Sex != "M");
                }
                else if (summaryTableFilter.Female)
                {
                    filteredSummaryTables = filteredSummaryTables.Where(x => x.Sex != "F");
                }
            }


            //make one for burialid

            return filteredSummaryTables;
        }
    }
}
