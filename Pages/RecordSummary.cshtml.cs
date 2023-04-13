using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
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
        public IEnumerable<Photodata> Photos { get; set; }
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
            //get the image information
            var photoDataTextiles = MummyRepository.PhotodatasTextiles.Where(x => x.MainTextileid == SummaryTable.Textileid);
            Photos = MummyRepository.Photodatas.Where(x => photoDataTextiles.Select(x => x.MainPhotodataid).Contains(x.Id));
        }
    }
}
