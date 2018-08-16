using Otc.TemplateToPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            Dictionary<string, string> tUModeloDeContrato = new Dictionary<string, string>();
            tUModeloDeContrato.Add("@IdentificadorProspect", "60D27F1D-A60C-41A4-A05C-4A5C333354E7");
            tUModeloDeContrato.Add("@LocalEmissao", "Bpv Sales Promoter And Collecting Ltda");
            tUModeloDeContrato.Add("@DataEmissao", "13/03/2017");
            tUModeloDeContrato.Add("@NomeEmitente", "André Mendes Marcondes");
            tUModeloDeContrato.Add("@CPFEmitente", "065.648.946-43");
            tUModeloDeContrato.Add("@RGEmitente", "MG-10.697.616");
            tUModeloDeContrato.Add("@EnderecoEmitente", "Rua Padre Pedro Evangelista");
            tUModeloDeContrato.Add("@NumeroEmitente", "181");
            tUModeloDeContrato.Add("@ComplementoEmitente", "Ap: 203");
            tUModeloDeContrato.Add("@BairroEmitente", "Coração Eucarístico");
            tUModeloDeContrato.Add("@CidadeEmitente", "Belo Horizonte");
            tUModeloDeContrato.Add("@EstadoEmitente", "MG");
            tUModeloDeContrato.Add("@CEPEmitente", "30.535-490");
            tUModeloDeContrato.Add("@CheckBoxINSS", "Yes");
            tUModeloDeContrato.Add("@CheckBoxFederal", "Yes");
            tUModeloDeContrato.Add("@CheckBoxEstadual", "Yes");
            tUModeloDeContrato.Add("@CheckBoxMunicipal", "Yes");
            tUModeloDeContrato.Add("@CheckBoxOutras", "Yes");
            tUModeloDeContrato.Add("@MargemConsignavel", "R$ 99.999,99 - Noventa e nove mil, novecentos e noventa e nove reais e noventa e nove centavos");
            tUModeloDeContrato.Add("@ValorIOF", "6% do valor do contrato");
            tUModeloDeContrato.Add("@TaxaJurosAM", "99,99");
            tUModeloDeContrato.Add("@TaxaJurosAA", "99,99");
            tUModeloDeContrato.Add("@CustoEfetivoTotalAM", "99,99");
            tUModeloDeContrato.Add("@CustoEfetivoTotalAN", "99,99");
            tUModeloDeContrato.Add("@CheckBoxSeguroSim", "No");
            tUModeloDeContrato.Add("@CheckBoxSeguroNao", "Yes");
            tUModeloDeContrato.Add("@TCC", "R$ 99.999,99");
            tUModeloDeContrato.Add("@Seguradora", "Teste Seguradora");
            tUModeloDeContrato.Add("@OutrasTarifas", "R$ 0,00");
            tUModeloDeContrato.Add("@TipoSeguro", "Teste Tipo Seguro");
            tUModeloDeContrato.Add("@CheckBoxOrdemPagamento", "No");
            tUModeloDeContrato.Add("@CheckBoxCreditoConta", "Yes");
            tUModeloDeContrato.Add("@Banco", "014");
            tUModeloDeContrato.Add("@Agencia", "3193");
            tUModeloDeContrato.Add("@ContaCorrente", "01015048-9");
            tUModeloDeContrato.Add("@VersaoPaginaUm", "1.0");
            tUModeloDeContrato.Add("@DataPaginaUm", "13/03/2017");
            tUModeloDeContrato.Add("@VersaoPaginaDois", "1.0");
            tUModeloDeContrato.Add("@DataPaginaDois", "13/03/2017");
            tUModeloDeContrato.Add("@NumeroGUIPaginaDois", "60D27F1D-A60C-41A4-A05C-4A5C333354E7");
            tUModeloDeContrato.Add("@VersaoPaginaTres", "1.0");
            tUModeloDeContrato.Add("@DataPaginaTres", "13/03/2017");
            tUModeloDeContrato.Add("@NumeroGUIPaginaTres", "60D27F1D-A60C-41A4-A05C-4A5C333354E7");

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
