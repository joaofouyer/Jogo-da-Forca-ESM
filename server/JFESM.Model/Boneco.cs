using System.Collections.Generic;

namespace JFESM.Model {
    public class Boneco {
        public int Membros { get; set; }
        public bool EstaVivo { get { return Membros < 5; } }

        public Boneco () {
            Membros = 0;
        }

        public void AdicionarMembro () {
            Membros++;
        }
    }
}