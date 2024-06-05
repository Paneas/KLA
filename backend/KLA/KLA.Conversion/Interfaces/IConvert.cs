using KLA.Models.Resposne;

namespace KLA.Conversion.Interfaces
{
    public interface IConvert
    {
        ConverNumberResponse ConvertNumberToWords(string value);
    }
}
