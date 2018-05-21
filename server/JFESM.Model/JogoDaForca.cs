namespace JFESM.Model {
    public class JogoDaForca {
        public Secreta Secreta1 { get; set; }
        public Secreta Secreta2 { get; set; }
        public Boneco Boneco { get; set; }
        public bool EstaJogando {
            get { return !(Secreta1.EstaVisivel && Secreta2.EstaVisivel) && Boneco.EstaVivo; }
        }

        public JogoDaForca(){
            Secreta1 = new Secreta();
            Secreta1 = new Secreta();
        }

        public void Destacar(char x){
            if(!(Secreta1.Destacar(x) || Secreta1.Destacar(x))){
                Boneco.AdicionarMembro();
            }
        }
    }
}