# Template to Pdf converter
[![Build Status](https://travis-ci.org/OleConsignado/otc-template-to-pdf.svg?branch=master)](https://travis-ci.org/OleConsignado/otc-template-to-pdf)

![TemplateToPdf](https://github.com/OleConsignado/otc-template-to-pdf/blob/master/pdf.png)

#Descrição

Biblioteca para preenchimento de pdfs criados como template, todos os itens são adicionados ao template diretamente onde o parâmetro está configurado.

#Exemplo de uso

'''IConversor converter;

'''public ConversorTests()
'''{
'''  converter = new Conversor();
'''}

'''Dictionary<string, string> modeloPDF = new Dictionary<string, string>();
'''modeloPDF.Add("@campo", "valor");

'''public void VerificarConversao()
'''{
'''  Dictionary<string, string> dicionario = CriarDicionario();
'''   string caminhoTemplate = String.Format(@"{0}\{1}", Directory.GetCurrentDirectory(), "Template.pdf");
'''   byte[] templateEditado = converter.ConverterTemplate(dicionario, @caminhoTemplate);
'''   File.WriteAllBytes(@"c:\temp\templateretorno.pdf", templateEditado);      
'''}
