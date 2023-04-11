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

        public List<SummaryTableRowItem> OriginalLoadBurials()
        {
            List<Burialmain> burialMains = _mummyRepository.Burialmains.Take(25).ToList();
            List<BurialmainTextile> burialMainTextiles = _mummyRepository.BurialmainTextiles.Where(x => burialMains.Select(x => x.Burialid).Contains(x.MainBurialmainid)).ToList();
            List<Textile> textiles = _mummyRepository.Textiles.Where(x => burialMainTextiles.Select(x => x.MainTextileid).Contains(x.Id)).ToList();

            List<ColorTextile> colorTextiles = _mummyRepository.ColorsTextiles.Where(x => textiles.Select(x => x.Id).Contains(x.MainTextileid)).ToList();
            List<StructureTextile> structureTextiles = _mummyRepository.StructuresTextiles.Where(x => textiles.Select(x => x.Id).Contains(x.MainTextileid)).ToList();
            List<TextilefunctionTextile> textilefunctionTextiles = _mummyRepository.TextilesFunctionsTextiles.Where(x => textiles.Select(x => x.Id).Contains(x.MainTextileid)).ToList();

            List<BurialmainBodyanalysischart> burialmainBodyanalysischarts = _mummyRepository.BurialmainBodyanalysischarts.Where(x => burialMains.Select(x => x.Burialid).Contains(x.MainBurialmainid)).ToList();

            List<SummaryTableRowItem> summaryTableRowItems = new List<SummaryTableRowItem>();
            foreach(var burial in burialMains)
            {
                SummaryTableRowItem summaryTableRowItem = new SummaryTableRowItem(burial, _mummyRepository.Colors.Where(x => colorTextiles.Select(x => x.MainColorid).Contains(x.Id)).ToList(), _mummyRepository.TextilesFunctions.Where(x => textilefunctionTextiles.Select(x => x.MainTextilefunctionid).Contains(x.Id)).ToList(), _mummyRepository.Bodyanalysischarts.Where(x => burialmainBodyanalysischarts.Select(x => x.MainBodyanalysischartid).Contains(x.Id)).ToList(), _mummyRepository.Structures.Where(x => structureTextiles.Select(x => x.MainStructureid).Contains(x.Id)).ToList());
                summaryTableRowItems.Add(summaryTableRowItem);
            }
            return summaryTableRowItems;
        }
    }
}
