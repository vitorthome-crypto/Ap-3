using System;
using AgendaCompromissos.Modelos;
namespace AgendaCompromissos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Sistema de Compromissos");
            Console.Write("Informe o seu nome: ");
            string nomeUsuario = Console.ReadLine();
            Usuario usuario = new Usuario(nomeUsuario);
            while (true)
            {
                Console.WriteLine("\nOpcoes:");
                Console.WriteLine("1. Agendar Compromisso");
                Console.WriteLine("2. Compromissos marcados");
                Console.WriteLine("3. Sair");
                Console.Write("Selecione uma opcao: ");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        RegistrarCompromisso(usuario);
                        break;
                    case "2":
                        MostrarCompromissos(usuario);
                        break;
                    case "3":
                        Console.WriteLine("Saindo");
                        return;
                    default:
                        Console.WriteLine("Invalido");
                        break;
                }
            }
        }
        static void RegistrarCompromisso(Usuario usuario)
        {
            try
            {
                Console.Write("Informe data e hora do compromisso dd/mm/yyyy e hh:mm: ");
                DateTime dataHora = DateTime.Parse(Console.ReadLine());
                Console.Write("Descrição: ");
                string descricao = Console.ReadLine();
                Console.Write("Local: ");
                string nomeLocal = Console.ReadLine();
                Console.Write("Capacidade maxima: ");
                int capacidade = int.Parse(Console.ReadLine());
                Local local = new Local(nomeLocal, capacidade);
                Compromisso compromisso = new Compromisso(dataHora, descricao, usuario, local);
                Console.Write("Quantos participantes quer adicionar? ");
                int numParticipantes = int.Parse(Console.ReadLine());
                for (int i = 0; i < numParticipantes; i++)
                {
                    Console.Write($"Nome do participante {i + 1}: ");
                    string nomeParticipante = Console.ReadLine();
                    Participante participante = new Participante(nomeParticipante);
                    compromisso.AdicionarParticipante(participante);
                }
                Console.Write("Quantas anotacoes deseja adicionar? ");
                int numAnotacoes = int.Parse(Console.ReadLine());
                for (int i = 0; i < numAnotacoes; i++)
                {
                    Console.Write($"Texto da anotação {i + 1}: ");
                    string textoAnotacao = Console.ReadLine();
                    compromisso.AdicionarAnotacao(textoAnotacao);
                }
                usuario.AdicionarCompromisso(compromisso);
                Console.WriteLine("Compromisso registrado");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
        static void MostrarCompromissos(Usuario usuario)
        {
            Console.WriteLine($"\nCompromissos de {usuario.NomeCompleto}:");
            if (usuario.Compromissos.Count == 0)
            {
                Console.WriteLine("Nenhum compromisso.");
            }
            else
            {
                foreach (var compromisso in usuario.Compromissos)
                {
                    Console.WriteLine(compromisso);
                    foreach (var anotacao in compromisso.Anotacoes)
                    {
                        Console.WriteLine($"  - {anotacao}");
                    }
                    foreach (var participante in compromisso.Participantes)
                    {
                        Console.WriteLine($"  - {participante}");
                    }
                }
            }
        }
    }
}