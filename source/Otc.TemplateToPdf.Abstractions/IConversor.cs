using System;
using System.Collections.Generic;

namespace Otc.TemplateToPdf.Abstractions
{
    [Obsolete("Este pacote eh obsoleto, utilize Otc.PdfTemplate.Abstractions no lugar")]
    public interface IConversor
    {        
        Byte[] ConverterTemplate(Dictionary<string, string> dados, string caminho);
        Byte[] ConverterTemplate(Dictionary<string, string> dados, string caminho, List<object> imagens);
    }
}
