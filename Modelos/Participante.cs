using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AgendaCompromissos.Modelos
{
    public class Participante
    {
        public string NomeCompleto { get; private set; }
        private List<Compromisso> _compromissos = new List<Compromisso>();
        public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();
        public Participante(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
        }
        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (compromisso == null)
            {
                throw new ArgumentNullException(nameof(compromisso), "O compromisso não pode ficar vazio");
            }
            _compromissos.Add(compromisso);
            if (!compromisso.Participantes.Contains(this))
            {
                compromisso.AdicionarParticipante(this); 
            }
        }
        public override string ToString()
        {
            return $"Participante: {NomeCompleto}";
        }
    }
}