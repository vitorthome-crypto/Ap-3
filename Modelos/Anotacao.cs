using System;
namespace AgendaCompromissos.Modelos
{
    public class Anotacao
    {
        public string Texto { get; private set; }
        public DateTime Data_Criacao { get; private set; }
        public Anotacao(string texto)
        {
            Texto = texto;
            Data_Criacao = DateTime.Now;
        }
        public override string ToString()
        {
            return $"Anotação: {Texto} (Criada em: {Data_Criacao})";
        }
    }
}