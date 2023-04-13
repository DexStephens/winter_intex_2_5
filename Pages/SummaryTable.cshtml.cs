using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System;
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
        public IEnumerable<SummaryTable> AllSummaryTables { get; set; }
        public IEnumerable<SummaryTable> CurrentSummaryTables { get; set; }
        public SummaryTableDefaults SummaryTableDefaults { get; set; }
        public SummaryTableFilter SummaryTableFilter { get; set; }
        public bool ApplyFilter { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPageCount { get; set; }
        public bool RePost { get; set; } = false;
        public SummaryTableModel(IMummyRepository mummyRepository)
        {
            MummyRepository = mummyRepository;
        }
        public void OnGet(SummaryTableFilter? filteredSummaryTableFilter, int currentPage = 1)
        {
            CurrentPage = currentPage;
            SummaryTableFilter = filteredSummaryTableFilter ?? new SummaryTableFilter();
            AllSummaryTables = MummyRepository.SummaryTables;
            CurrentSummaryTables = AllSummaryTables.Skip((currentPage - 1) * 50).Take(50);
            SummaryTableDefaults = new SummaryTableDefaults(AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Haircolor)).Select(x => x.Haircolor).Distinct().OrderBy(x => x), AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Structure)).Select(x => x.Structure).Distinct().OrderBy(x => x), AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Ageatdeath)).Select(x => x.Ageatdeath).OrderBy(x => x).Distinct(), AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Headdirection) && x.Headdirection != "N LL").Select(x => x.Headdirection).Distinct().OrderBy(x => x), AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Textilefunction)).Select(x => x.Textilefunction).Distinct().OrderBy(x => x), AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Textilecolor)).Select(x => x.Textilecolor).Distinct().OrderBy(x => x), AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Burialid)).Select(x => x.Burialid).Distinct());
            TotalPageCount = AllSummaryTables.Count() / 50;
        }

        public void OnPost(SummaryTableFilter summaryTableFilter)
        {
            CurrentPage = Convert.ToInt32(Request.Form["currentPage"]);
            if(ModelState.IsValid)
            {
                SummaryTableFilter = summaryTableFilter;
                AllSummaryTables = new SummaryTableService(MummyRepository).FilterSummaryRowItemsByCriteria(summaryTableFilter);
                CurrentSummaryTables = AllSummaryTables.Skip((CurrentPage - 1) * 50).Take(50);
                SummaryTableDefaults = new SummaryTableDefaults(AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Haircolor)).Select(x => x.Haircolor).Distinct().OrderBy(x => x), AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Structure)).Select(x => x.Structure).Distinct().OrderBy(x => x), AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Ageatdeath)).Select(x => x.Ageatdeath).OrderBy(x => x).Distinct(), AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Headdirection) && x.Headdirection != "N LL").Select(x => x.Headdirection).Distinct().OrderBy(x => x), AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Textilefunction)).Select(x => x.Textilefunction).Distinct().OrderBy(x => x), AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Textilecolor)).Select(x => x.Textilecolor).Distinct().OrderBy(x => x), AllSummaryTables.Where(x => !string.IsNullOrWhiteSpace(x.Burialid)).Select(x => x.Burialid).Distinct());
                TotalPageCount = AllSummaryTables.Count() / 50;
                RePost = true;
            }
        }

        public IActionResult OnPostReset()
        {
            RePost = false;
            return RedirectToPage();
        }
    }
}
