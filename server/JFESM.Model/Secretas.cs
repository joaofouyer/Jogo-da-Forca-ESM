using System;

namespace JFESM.Model {
    public class Secreta {
        private string palavraOriginal;
        private string palavraSecreta;

        public bool EstaVisivel { get { return !palavraSecreta.Contains ("-"); } }

        public string Palavra {
            get {
                return palavraSecreta;
            }
            set {
                if (string.IsNullOrWhiteSpace (value) || value.Contains (" ")) {
                    throw new ArgumentException ("Palavra não pode ser nula ou vazia");
                }
                this.palavraOriginal = value;
                palavraSecreta = EsconderPalvra (value);
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