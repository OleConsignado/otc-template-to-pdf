using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf;
using Otc.TemplateToPdf.Abstractions;
using Xunit;

namespace Otc.TemplateToPdf.Tests
{
    public class ConversorImagemTests
    {
        readonly IConversor converter;

        public ConversorImagemTests()
        {
            converter = new Conversor();
        }

        private Dictionary<string, string> CriarDicionario()
        {
            Dictionary<string, string> tUModeloDeContrato = new Dictionary<string, string>
            {
                { "N_BANCO", "347" },
                { "PREFIXO", "033-7" },
                { "LINHA_DIGITAVEL", "03399.76284 52800.000730 40529.901015 7 0000000" },
                { "PAGADOR", "ALETHIA GERLANE FERNANDES LEITE   010.695.984-02\nRUA DESEMBARGADOR JOSE, 1726,   Sta Delmira\nMossoro - RN \nCEP: 59615270   " },
                { "NOSSO_NUMERO", "065.648.946-43" },
                { "NUMERO_DOCUMENTO", "065.648.946-43" },
                { "DT_VENCIMENTO", "17/08/2018" },
                { "VLR_DOCUMENTO", "35.656,64" },
                { "BENEFICIARIO", "30.535-490" },
                { "AGENCIA_BENEFICIARIA", "181" },
                { "N_BANCO2", "347" },
                { "PREFIXO2", "033-7" },
                { "LINHA_DIGITAVEL2", "È03399.76284Ì52800.000730Ì40529.901015Ì7Ì0000000:ËÍ" },
                { "AGENCIA_RECEBEDORA", "Belo Horizonte" },
                { "DT_VENCIMENTO2", "17/08/2018" },
                { "BENEFICIARIO2", "30.535-490" },
                { "AGENCIA_BENEFICIARIA2", "\n181" },
                { "DT_DOCUMENTO", "Yes" },
                { "NUMERO_DOCUMENTO2", "065.648.946-43" },
                { "NOSSO_NUMERO2", "065.648.946-43" },
                { "DT_PROCES", "Yes" },
                { "VALOR", "Yes" },
                { "VLR_DOCUMENTO2", "35.656,64" },
                { "INSTRUCOES", "Yes" },
                { "PAGADOR2", "ALETHIA GERLANE FERNANDES LEITE\nRUA DESEMBARGADOR JOSE, 1726,   Sta Delmira\nMossoro - RN \nCEP: 59615270   " }
            };

            return tUModeloDeContrato;
        }

        [Fact]
        public void VerificarConversao()
        {
            // Arrage
            Dictionary<string, string> dicionario = CriarDicionario();
            string caminhoTemplate = String.Format(@"{0}\{1}", Directory.GetCurrentDirectory(), "TemplateBoleto.pdf");

            List<DadosImagem> testeImagem = new List<DadosImagem>
            {
                new DadosImagem() { AtributosImagem = "03399000000000000009762852800000733268360101", Barcode = true, PosicaoHorizontal = 50, PosicaoVertical = 465 }
            };

            //byte[] templateEditado = converter.ConverterTemplate(dicionario, @caminhoTemplate, testeImagem);
            //File.WriteAllBytes(string.Format(@"c:\temp\TemplateBoleto_{0}.pdf", DateTime.Now.ToString("yy-MM-dd-ss")), templateEditado);

            //Assert.IsTrue(templateEditado.Count() > 0);
        }

        public System.Drawing.Image GerarBarcode(string code)
        {

            Barcode128 bc = new Barcode128
            {
                Code = code
            };
            //bc.Font = null;

            return bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);
        }
    }
}
