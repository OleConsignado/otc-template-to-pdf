namespace Otc.TemplateToPdf
{
    public class DadosImagem
    {
        public DadosImagem() { 
}
        public DadosImagem(string atributosImagem, System.Drawing.Image imagem, bool barcode, int posicaoHorizontal, int posicaoVertical)
        {
            this.AtributosImagem = atributosImagem;
            this.Barcode = barcode;
            this.Imagem = imagem;
            this.PosicaoHorizontal = posicaoHorizontal;
            this.PosicaoVertical = PosicaoVertical;
        }

        public string AtributosImagem { get; set; }
        public System.Drawing.Image Imagem { get; set; }
        public bool Barcode { get; set; }
        public int PosicaoHorizontal { get; set; }
        public int PosicaoVertical { get; set; }
    }
}