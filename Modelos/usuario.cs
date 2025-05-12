using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AgendaCompromissos.Modelos
{
    public class Usuario
    {
        public string NomeCompleto { get; private set; }
        private List<Compromisso> _compromissos = new List<Compromisso>();
        public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();
        public Usuario(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
        }
        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (compromisso == null)
            {
                throw new ArgumentNullException(nameof(compromisso), "O compromisso não pode estar vazio.");
            }
            _compromissos.Add(compromisso);
        }
        public override string ToString()
        {
            return $"Usuário: {NomeCompleto}";
        }
    }
}