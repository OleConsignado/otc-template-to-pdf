using System;
using System.Collections.Generic;

namespace Otc.TemplateToPdf
{
    public interface IConversor
    {        
        Byte[] ConverterTemplate(Dictionary<string, string> dados, string caminho);
    }
}
