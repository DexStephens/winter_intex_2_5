using System.Linq;
using winter_intex_2_5.Models;

namespace winter_intex_2_5.Data.Repositories
{
    public class EFMummyRepository : IMummyRepository
    {public MummyContext Context { get; set; }

        public IQueryable<Analysis> Analysis => Context.Analysis;

        public IQueryable<AnalysisTextile> AnalysisTextiles => Context.AnalysisTextile;

        public IQueryable<Artifactfagelgamousregister> Artifactfagelgamousregisters => Context.Artifactfagelgamousregister;

        public IQueryable<ArtifactfagelgamousregisterBurialmain> ArtifactfagelgamousregisterBurialmains => Context.ArtifactfagelgamousregisterBurialmain;

        public IQueryable<Artifactkomaushimregister> Artifactkomaushimregisters => Context.Artifactkomaushimregister;

        public IQueryable<ArtifactkomaushimregisterBurialmain> ArtifactkomaushimregisterBurialmains => Context.ArtifactkomaushimregisterBurialmain;

        public IQueryable<Biological> Biologicals => Context.Biological;

        public IQueryable<BiologicalC14> BiologicalC14s => Context.BiologicalC14;

        public IQueryable<Bodyanalysischart> Bodyanalysischarts => Context.Bodyanalysischart;

        public IQueryable<Books> Books => Context.Books;

        public IQueryable<Burialmain> Burialmains => Context.Burialmain;

        public IQueryable<BurialmainBiological> BurialmainBiologicals => Context.BurialmainBiological;

        public IQueryable<BurialmainBodyanalysischart> BurialmainBodyanalysischarts => Context.BurialmainBodyanalysischart;

        public IQueryable<BurialmainCranium> BurialmainCrania => Context.BurialmainCranium;
        public IQueryable<BurialmainTextile> BurialmainTextiles => Context.BurialmainTextile;

        public IQueryable<C14> C14s => Context.C14;

        public IQueryable<Color> Colors => Context.Color;

        public IQueryable<ColorTextile> ColorsTextiles => Context.ColorTextile;

        public IQueryable<Cranium> Crania => Context.Cranium;

        public IQueryable<Decoration> Decorations => Context.Decoration;

        public IQueryable<DecorationTextile> DecorationTextiles => Context.DecorationTextile;

        public IQueryable<Dimension> Dimensions => Context.Dimension;

        public IQueryable<DimensionTextile> DimensionTextiles => Context.DimensionTextile;

        public IQueryable<Newsarticle> Newsarticles => Context.Newsarticle;

        public IQueryable<Photodata> Photodatas => Context.Photodata;

        public IQueryable<PhotodataTextile> PhotodatasTextiles => Context.PhotodataTextile;

        public IQueryable<Photoform> Photoforms => Context.Photoform;

        public IQueryable<Structure> Structures => Context.Structure;

        public IQueryable<StructureTextile> StructuresTextiles => Context.StructureTextile;

        public IQueryable<Teammember> Teammembers => Context.Teammember;

        public IQueryable<Textile> Textiles => Context.Textile;

        public IQueryable<Textilefunction> TextilesFunctions => Context.Textilefunction;

        public IQueryable<TextilefunctionTextile> TextilesFunctionsTextiles => Context.TextilefunctionTextile;

        public IQueryable<Yarnmanipulation> Yarnmanipulation => Context.Yarnmanipulation;

        public IQueryable<YarnmanipulationTextile> YarnmanipulationTextiles => Context.YarnmanipulationTextile;

        public EFMummyRepository(MummyContext context)
        {
            Context = context;
        }


    }
}
