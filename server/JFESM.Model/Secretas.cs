using System;

namespace JFESM.Model {
    public class Secreta {
        private string palavraOriginal;
        private string palavraSecreta;

        public bool EstaVisivel { get { return !palavraSecreta.Contains ("-"); } }

        public Secreta (string palavra) {
            if (string.IsNullOrWhiteSpace (palavra) || palavra.Contains (" ")) {
                throw new ArgumentException ("Palavra não pode ser nula ou vazia");
            }
            this.palavraOriginal = palavra;
            palavraSecreta = EsconderPalvra (palavra);
        }
        public string Palavra {
            get {
                return palavraSecreta;
            }
        }

        public bool Destacar (char x) {
            bool Acertou = false;
            if (palavraOriginal.Contains (x.ToString ())) {
                palavraSecreta = string.Empty;
                for (int i = 0; i < palavraOriginal.Length; i++) {
                    if (palavraOriginal[i] == x) {
                        palavraSecreta += x;
                    } else {
                        palavraSecreta += "-";
                    }
                }
                Acertou = true;
            }

            return Acertou;
        }

        private string EsconderPalvra (string palavra) {
            var escondida = string.Empty;
            for (int i = 0; i < palavra.Length; i++) {
                escondida += "-";
            }
            return escondida;
        }
    }
}