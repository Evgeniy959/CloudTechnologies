using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace СountriesGDP.Model
{
    [Table("Table_GDP_2022_year")]
    public class TableGDP
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Country { get; set; }
        [Column("GDP,billion_$")]
        public double VolumeGDP { get; set; }

        public TableGDP() 
        {
            Id = default;
            Rating = default;
            Country = "";
            VolumeGDP = default;
        }
    }
}
