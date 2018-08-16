using Otc.TemplateToPdf;
using Otc.TemplateToPdf.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace ConverterObjectToPDF.Tests
{

    public class ConversorTests
    {
        IConversor converter;

        public ConversorTests()
        {
            converter = new Conversor();
        }

        private Dictionary<string, string> CriarDicionario()
        {
            Dictionary<string, string> tUModeloDeContrato = new Dictionary<string, string>
            {
                { "@IdentificadorProspect", "60D27F1D-A60C-41A4-A05C-4A5C333354E7" },
                { "@LocalEmissao", "Bpv Sales Promoter And Collecting Ltda" },
                { "@DataEmissao", "13/03/2017" },
                { "@NomeEmitente", "André Mendes Marcondes" },
                { "@CPFEmitente", "065.648.946-43" },
                { "@RGEmitente", "MG-10.697.616" },
                { "@EnderecoEmitente", "Rua Padre Pedro Evangelista" },
                { "@NumeroEmitente", "181" },
                { "@ComplementoEmitente", "Ap: 203" },
                { "@BairroEmitente", "Coração Eucarístico" },
                { "@CidadeEmitente", "Belo Horizonte" },
                { "@EstadoEmitente", "MG" },
                { "@CEPEmitente", "30.535-490" },
                { "@CheckBoxINSS", "Yes" },
                { "@CheckBoxFederal", "Yes" },
                { "@CheckBoxEstadual", "Yes" },
                { "@CheckBoxMunicipal", "Yes" },
                { "@CheckBoxOutras", "Yes" },
                { "@MargemConsignavel", "R$ 99.999,99 - Noventa e nove mil, novecentos e noventa e nove reais e noventa e nove centavos" },
                { "@ValorIOF", "6% do valor do contrato" },
                { "@TaxaJurosAM", "99,99" },
                { "@TaxaJurosAA", "99,99" },
                { "@CustoEfetivoTotalAM", "99,99" },
                { "@CustoEfetivoTotalAN", "99,99" },
                { "@CheckBoxSeguroSim", "No" },
                { "@CheckBoxSeguroNao", "Yes" },
                { "@TCC", "R$ 99.999,99" },
                { "@Seguradora", "Teste Seguradora" },
                { "@OutrasTarifas", "R$ 0,00" },
                { "@TipoSeguro", "Teste Tipo Seguro" },
                { "@CheckBoxOrdemPagamento", "No" },
                { "@CheckBoxCreditoConta", "Yes" },
                { "@Banco", "014" },
                { "@Agencia", "3193" },
                { "@ContaCorrente", "01015048-9" },
                { "@VersaoPaginaUm", "1.0" },
                { "@DataPaginaUm", "13/03/2017" },
                { "@VersaoPaginaDois", "1.0" },
                { "@DataPaginaDois", "13/03/2017" },
                { "@NumeroGUIPaginaDois", "60D27F1D-A60C-41A4-A05C-4A5C333354E7" },
                { "@VersaoPaginaTres", "1.0" },
                { "@DataPaginaTres", "13/03/2017" },
                { "@NumeroGUIPaginaTres", "60D27F1D-A60C-41A4-A05C-4A5C333354E7" }
            };

            return tUModeloDeContrato;
        }

        [Fact]
        public void VerificarConversao()
        {
            // Arrage
            Dictionary<string, string> dicionario = CriarDicionario();
            string caminhoTemplate = String.Format(@"{0}\{1}", Directory.GetCurrentDirectory(), "Template.pdf");

            byte[] templateEditado = converter.ConverterTemplate(dicionario, @caminhoTemplate);
            File.WriteAllBytes(@"c:\temp\templateretorno.pdf", templateEditado);

            Assert.True(templateEditado.Count() > 0);
        }
    }
}
