using iTextSharp.text.pdf;
using Otc.TemplateToPdf.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Otc.TemplateToPdf
{
    public class Conversor : IConversor
    {
        #region [ Propriedades ]
        private Template Template { get; set; }
        #endregion

        #region [ Métodos Públicos ]

        #region [ Carregar Template ]
        private void CarregarTemplate(string caminhoTemplate)
        {
            //Verifica a string do caminho se está nula ou vazia
            if (string.IsNullOrWhiteSpace(caminhoTemplate))
                throw new ArgumentNullException("O caminho do template não pode ser nulo ou vazio");

            //Verifica se o arquivo existe no caminho informado
            if (!File.Exists(caminhoTemplate))
                throw new FileNotFoundException("Arquivo não foi encontrado no caminho", caminhoTemplate);

            this.Template = new Template(Path.GetFileName(caminhoTemplate), Path.GetExtension(caminhoTemplate), caminhoTemplate);
        }
        #endregion

        #region [ Realizar Converter ]

        public Byte[] ConverterTemplate(Dictionary<string, string> dados, string caminhoTemplate)
        {
            CarregarTemplate(caminhoTemplate);

            if (dados == null)
                throw new ArgumentNullException("dados");

            if (dados.Count != Template.Parametros.Count)
                throw new ArgumentOutOfRangeException("Número de parâmetros de entrada de dados diferente do número de parâmetros do template");


            string parametrosErrados = string.Empty;

            foreach (var item in dados.Keys)
            {
                if (!Template.Parametros.Any(x => x.Key == item))
                    parametrosErrados += String.Format("[{0}]", item.ToString());
            }

            if (!string.IsNullOrEmpty(parametrosErrados))
                throw new Exception(String.Format("Os parâmetros {0} não existem no template", parametrosErrados));

            Template.Parametros = dados;

            return RetornarArrayBytesTemplate();
        }

        #endregion

        #endregion

        #region [ Métodos Privados ]

        #region [ Realizar Converter ]
        private Byte[] RetornarArrayBytesTemplate()
        {
            PdfReader reader = new PdfReader(Template.Caminho);
            using (MemoryStream ms = new MemoryStream())
            {
                PdfStamper stamper = new PdfStamper(reader, ms);
                AcroFields campos = stamper.AcroFields;

                foreach (var item in Template.Parametros)
                {
                    campos.SetField(item.Key, item.Value);
                }

                stamper.FormFlattening = true;
                stamper.Close();

                return ms.ToArray();
            }
        }
        #endregion

        #endregion
    }
}
