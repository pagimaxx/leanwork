using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Manipulator
    {
        // Levando em conta que o problema de collatz não tem uma solução matemática lógica, a unica forma de resolve-lo sistemicamente
        // é atravéz do teste utilizando força bruta.
        public uint CalcularSequenciaMaxima2(uint ValorMinimo, uint ValorMaximo)
        {
            if (ValorMaximo <= ValorMinimo)
                throw new Exception("O valor máximo deve ser maior que o valor mínimo.");

            var resultado = new List<uint>();

            while (ValorMaximo > 1)
            {
                var aux = new List<uint>() {
                    ValorMaximo
                };

                while (aux.Last() != 1)
                {
                    if (aux.Last() % 2 != 0)
                        aux.Add((aux.Last() * 3) + 1);
                    else
                        aux.Add(aux.Last() / 2);
                }

                if (aux.Count() > resultado.Count())
                    resultado = aux;

                ValorMaximo--;
            } 

            return resultado.First();
        }

        public List<int> FiltrarImpares(List<int> lista)
        {
            if (lista == null || lista.Count() == 0)
                throw new Exception("A lista informada é nula ou está vazia.");

            return lista.FindAll(n => n % 2 != 0);
        }

        public List<int> FiltrarItensAusentes(List<int> listaVerificacao, List<int> listaTarget)
        {
            if (listaVerificacao == null || listaVerificacao.Count() == 0)
                throw new Exception("A lista de verificação é nula ou está vazia.");

            if (listaVerificacao == null || listaTarget.Count() == 0)
                throw new Exception("A lista de verificação é nula ou está vazia.");

            return listaVerificacao.FindAll(n => !listaTarget.Contains(n));
        }
    }
}
