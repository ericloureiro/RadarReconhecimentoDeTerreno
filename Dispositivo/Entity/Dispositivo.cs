using System;
using System.Collections.Generic;


namespace Dispositivo
{
    public class Dispositivo
    {
        public List<String> Mensagens = new List<String>();
        public int EixoX { get; set; }
        public int EixoY { get; set; }
        public int[,] MatrizAgua { get; set; }
        public int[,] MatrizObstaculo { get; set; }
        public int[,] MatrizMinaTerrestre { get; set; }
        public int ValorLivre { get; set; }
        public int ValorObstaculo { get; set; }
        public int ValorProfundidadeMaxima { get; set; }
        public int ValorMaximoMinaTerrestre { get; set; }
    }
}


