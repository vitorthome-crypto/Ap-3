using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaCompromissos.Modelos
{
    public class Compromisso
    {
        public DateTime DataHora { get; private set; }
        public string Descricao { get; private set; }
        public Usuario Responsavel { get; private set; }
        public Local Local { get; private set; }
        private List<Participante> _participantes = new List<Participante>();
        public IReadOnlyCollection<Participante> Participantes => _participantes.AsReadOnly();
        private List<Anotacao> _anotacoes = new List<Anotacao>();
        public IReadOnlyCollection<Anotacao> Anotacoes => _anotacoes.AsReadOnly();
        public Compromisso(DateTime dataHora, string descricao, Usuario responsavel, Local local)
        {
            if (dataHora <= DateTime.Now)
            {
                throw new ArgumentException("A data e hora do compromisso devem estar no futuro.", nameof(dataHora));
            }

            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("A descrição do compromisso é obrigatória.", nameof(descricao));
            }
            DataHora = dataHora;
            Descricao = descricao;
            Responsavel = responsavel;
            Local = local;
        }
        public void AdicionarParticipante(Participante participante)
        {
            if (participante == null)
            {
                throw new ArgumentNullException(nameof(participante), "O participante não pode ser nulo.");
            }
            if (Local != null && _participantes.Count >= Local.CapacidadeMaxima)
            {
                throw new InvalidOperationException("Não é possível adicionar mais participantes. A capacidade do local foi atingida.");
            }
            _participantes.Add(participante);
            if (!participante.Compromissos.Contains(this))
            {
                participante.AdicionarCompromisso(this); 
            }
        }
        public void AdicionarAnotacao(string texto)
        {
            if (!string.IsNullOrWhiteSpace(texto))
            {
                _anotacoes.Add(new Anotacao(texto));
            }
        }
        public override string ToString()
        {
            return $"Compromisso: {Descricao} em {DataHora} no local {Local?.Nome} com {Participantes.Count} participantes.";
        }
    }
}