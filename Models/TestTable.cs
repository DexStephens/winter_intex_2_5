using System.ComponentModel.DataAnnotations;

namespace winter_intex_2_5.Models
{
    public class TestTable
    {
        [Key]
        public int TestId { get; set; }
        public string TestName { get; set; }
    }
}
