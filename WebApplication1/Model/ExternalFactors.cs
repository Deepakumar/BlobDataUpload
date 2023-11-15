using CsvHelper.Configuration;
using System.ComponentModel.DataAnnotations;
using UploadUI.Validator;

namespace UploadUI.Model
{
    public class ExternalFactors
    {
        [Required]
        public bool IfFactor1 { get; set; }

        [Required]
        public bool IfFactor2 { get; set; }

        [Required]
        public bool IfFactor3 { get; set; }

        [Required]
        public bool IfFactor4 { get; set; }

        [Required]
        public bool IfFactor5 { get; set; }


        [ConditionalRequired("IfFactor1")]
        public int Factor1Value { get; set; }

        [ConditionalRequired("IfFactor2")]
        public int Factor2Value { get; set; }

        [ConditionalRequired("IfFactor3")]
        public int Factor3Value { get; set; }

        [ConditionalRequired("IfFactor4")]
        public int Factor4Value { get; set; }

        [ConditionalRequired("IfFactor5")]
        public int Factor5Value { get; set; }
    }

    public class ExternalFactorsMap : ClassMap<ExternalFactors>
    {
        public ExternalFactorsMap()
        {
            Map(m => m.IfFactor1).Name("IfFactor1");
            Map(m => m.Factor1Value).Name("Factor1Value");
            Map(m => m.IfFactor2).Name("IfFactor2");
            Map(m => m.Factor2Value).Name("Factor2Value");
            Map(m => m.IfFactor3).Name("IfFactor3");
            Map(m => m.Factor3Value).Name("Factor3Value");
            Map(m => m.IfFactor4).Name("IfFactor4");
            Map(m => m.Factor5Value).Name("Factor4Value");
            Map(m => m.IfFactor5).Name("IfFactor5");
            Map(m => m.Factor5Value).Name("Factor5Value");
        }
    }
}
