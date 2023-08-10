using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.SeriesNumberPool
{
    public class SeriesNumber : BaseModel
    {
        [Key]
        public long SeriesNumberId { get; set; }
        public string SeriesNumberName { get; set; }
    }
}
