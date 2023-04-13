using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using winter_intex_2_5.Data.Repositories;
using winter_intex_2_5.Models;

namespace winter_intex_2_5.Pages
{
    public class RecordSummaryModel : PageModel
    {
        public int Id { get; set; }
        public IMummyRepository MummyRepository { get; set; }
        public SummaryTable SummaryTable { get; set; }
        public RecordSummaryModel(IMummyRepository mummyRepository)
        {
            MummyRepository = mummyRepository;
        }
        public void OnGet()
        {

        }

        public void OnPost(long burialId)
        {
            SummaryTable = MummyRepository.SummaryTables.First(x => x.Id == burialId);
        }
    }
}
