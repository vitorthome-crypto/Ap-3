using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaCompromissos.Modelos
{
    public class Local
    {
        public string Nome { get; private set; }
        public int CapacidadeMaxima { get; private set; }
        public Local(string nome, int capacidadeMaxima)
        {
            Nome = nome;
            CapacidadeMaxima = capacidadeMaxima;
        }
        public bool ValidarCapacidade(int quantidade)
        {
            return quantidade <= CapacidadeMaxima;
        }
        public override string ToString()
        {
            return $"Local: {Nome} (Capacidade: {CapacidadeMaxima})";
        }
    }
}