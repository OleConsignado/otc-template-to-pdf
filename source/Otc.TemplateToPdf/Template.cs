using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;

namespace Otc.TemplateToPdf
{
    [Obsolete("Este pacote eh obsoleto, utilize Otc.PdfTemplate no lugar")]
    public class Template
    {
        public Template(string nome, string extensao, string caminho)
        {
            this.Nome = nome;
            this.Extensao = extensao;
            this.Caminho = caminho;
            this.Parametros = CarregarParametros(caminho);
        }

        public string Nome { get; private set; }

        public string Extensao { get; private set; }

        public string Caminho { get; private set; }

        public Dictionary<string, string> Parametros { get; set; }

        private Dictionary<string, string> CarregarParametros(string caminho)
        {
            PdfReader reader = new PdfReader(caminho);
            AcroFields form = reader.AcroFields;
            Dictionary<string, string> parametros = new Dictionary<string, string>();

            try
            {
                foreach (var item in form.Fields.Keys)
                {
                    parametros.Add(item.ToString(), string.Empty);
                }
            }
            finally
            {
                reader.Close();
            }

            return parametros;
        }
    }
}
