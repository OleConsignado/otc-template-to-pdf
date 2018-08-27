
using iTextSharp.text;
using iTextSharp.text.pdf;
using Otc.TemplateToPdf;
using Otc.TemplateToPdf.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ConverterObjectToPDF
{
    public class Conversor : IConversor
    {
        private Template Template { get; set; }

        private void CarregarTemplate(string caminhoTemplate)
        {
            if (string.IsNullOrWhiteSpace(caminhoTemplate))
                throw new ArgumentNullException("O caminho do template não pode ser nulo ou vazio");
            if (!File.Exists(caminhoTemplate))
                throw new FileNotFoundException("Arquivo não foi encontrado no caminho", caminhoTemplate);
            this.Template = new Template(Path.GetFileName(caminhoTemplate), Path.GetExtension(caminhoTemplate), caminhoTemplate);
        }

        public byte[] ConverterTemplate(Dictionary<string, string> dados, string caminhoTemplate)
        {
            return this.ConverterTemplate(dados, caminhoTemplate, (List<DadosImagem>)null);
        }

        public byte[] ConverterTemplate(Dictionary<string, string> dados, string caminhoTemplate, List<DadosImagem> imagens)
        {
            this.CarregarTemplate(caminhoTemplate);
            if (dados == null) 
                throw new ArgumentNullException(nameof(dados));
            if (dados.Count != this.Template.Parametros.Count)
                throw new ArgumentOutOfRangeException("Número de parâmetros de entrada de dados diferente do número de parâmetros do template");
            string empty = string.Empty;
            foreach (string key in dados.Keys)
            {
                string item = key;
                if (!this.Template.Parametros.Any<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>)(x => x.Key == item)))
                    empty += string.Format("[{0}]", (object)item.ToString());
            }
            if (!string.IsNullOrEmpty(empty))
                throw new Exception(string.Format("Os parâmetros {0} não existem no template", (object)empty));
            this.Template.Parametros = dados;
            return this.RetornarArrayBytesTemplate(imagens);
        }

        private byte[] RetornarArrayBytesTemplate(List<DadosImagem> imagens)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfStamper pdfStamper = new PdfStamper(new PdfReader(this.Template.Caminho), (Stream)memoryStream);
                AcroFields acroFields = pdfStamper.AcroFields;
                foreach (KeyValuePair<string, string> parametro in this.Template.Parametros)
                    acroFields.SetField(parametro.Key, parametro.Value);
                foreach (DadosImagem imagen in imagens)
                {
                    if (imagen.Barcode)
                    {
                        Barcode128 barcode128 = new Barcode128();
                        barcode128.Code = imagen.AtributosImagem;
                        iTextSharp.text.Image instance = iTextSharp.text.Image.GetInstance(barcode128.CreateDrawingImage(Color.Black, Color.White), BaseColor.White);
                        pdfStamper.GetOverContent(1).AddImage(instance, (float)Convert.ToInt32((double)instance.Width * 0.98), 0.0f, 0.0f, instance.Height, 25f, 445f);
                    }
                    else
                    {
                        iTextSharp.text.Image instance = iTextSharp.text.Image.GetInstance(imagen.Imagem, BaseColor.White);
                        pdfStamper.GetOverContent(1).AddImage(instance, instance.Width, 0.0f, 0.0f, instance.Height, (float)imagen.PosicaoVertical, (float)imagen.PosicaoHorizontal);
                    }
                }
                pdfStamper.FormFlattening = true;
                pdfStamper.Close();
                return memoryStream.ToArray();
            }
        }
    }
}
