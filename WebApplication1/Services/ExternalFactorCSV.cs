using CsvHelper;
using System.Globalization;
using System.Text;
using UploadUI.Model;

namespace UploadUI.Services
{
    public class ExternalFactorCSV : ICsvMemoryStream<ExternalFactors>
    {
        public byte[] GetCsv(ExternalFactors value)
        {
            byte[] result;
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream, Encoding.UTF8, 1024, true))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<ExternalFactorsMap>();
                    csv.WriteRecord(value);
                }
                result = memoryStream.ToArray();
            }

            return result;
        }

    }
}
