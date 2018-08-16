using System;
using System.Collections.Generic;

namespace Otc.TemplateToPdf.Abstractions
{
    public interface IConversor
    {        
        Byte[] ConverterTemplate(Dictionary<string, string> dados, string caminho);
    }
}
