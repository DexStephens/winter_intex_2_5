using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using winter_intex_2_5.Data.Repositories;
using winter_intex_2_5.Models;
using winter_intex_2_5.Services;

namespace winter_intex_2_5.Pages
{
    public class SummaryTableModel : PageModel
    {
        public IMummyRepository MummyRepository { get; set; }
        public IEnumerable<SummaryTable> SummaryTables { get; set; }
        public SummaryTableDefaults SummaryTableDefaults { get; set; }
        public SummaryTableFilter SummaryTableFilter { get; set; }
        public bool ApplyFilter { get; set; }
        public SummaryTableModel(IMummyRepository mummyRepository)
        {
            MummyRepository = mummyRepository;
        }
        public void OnGet(SummaryTableFilter? filteredSummaryTableFilter)
        {
            SummaryTableFilter = filteredSummaryTableFilter ?? new SummaryTableFilter();
            SummaryTables = MummyRepository.SummaryTables;
            SummaryTableDefaults = new SummaryTableDefaults(MummyRepository.Burialmains.Select(x => x.Haircolor).Distinct().OrderBy(x => x).ToList(), MummyRepository.Structures.Select(x => x.Value).Distinct().OrderBy(x => x), MummyRepository.Burialmains.Select(x => x.Ageatdeath).OrderBy(x => x).Distinct().ToList(), MummyRepository.Burialmains.Select(x => x.Headdirection).Distinct().OrderBy(x => x).ToList(), MummyRepository.TextilesFunctions.Select(x => x.Value).Distinct().OrderBy(x => x).ToList(), MummyRepository.Colors.Select(x => x.Value).Distinct().OrderBy(x => x).ToList(), SummaryTables.Select(x => x.Burialid).Distinct());
        }

        public void OnPost(SummaryTableFilter summaryTableFilter)
        {
            if(ModelState.IsValid)
            {
                SummaryTableFilter = summaryTableFilter;
                SummaryTableDefaults = new SummaryTableDefaults(MummyRepository.Burialmains.Select(x => x.Haircolor).Distinct().OrderBy(x => x).ToList(), MummyRepository.Structures.Select(x => x.Value).Distinct().OrderBy(x => x), MummyRepository.Burialmains.Select(x => x.Ageatdeath).OrderBy(x => x).Distinct().ToList(), MummyRepository.Burialmains.Select(x => x.Headdirection).Distinct().OrderBy(x => x).ToList(), MummyRepository.TextilesFunctions.Select(x => x.Value).Distinct().OrderBy(x => x).ToList(), MummyRepository.Colors.Select(x => x.Value).Distinct().OrderBy(x => x).ToList(), SummaryTables.Select(x => x.Burialid).Distinct());
                SummaryTables = new SummaryTableService(MummyRepository).FilterSummaryRowItemsByCriteria(summaryTableFilter);
            }
        }
    }
}
