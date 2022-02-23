using System;
using System.Collections;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Classe utilitária
    /// </summary>
    internal sealed class Util
    {
        /// <summary>
        /// Método que recupera o tipo do primeiro item da enumeração
        /// </summary>
        /// <param name="source">A enumeração</param>
        /// <returns>Type</returns>
        public static Type GetTypeFirstItem(IEnumerable source)
        {
            // recupera o enumerator
            IEnumerator source2 = source.GetEnumerator();

            // move para o primeiro indice
            while (source2.MoveNext())
            {
                // recupera item
                object item = source2.Current;

                // valida
                if (item != null)
                {
                    // retorna o tipo do  item
                    return item.GetType();
                }
            }

            // retorna vazio
            return null;
        }

        /// <summary>
        /// Método que aumenta o enumerable
        /// </summary>
        /// <param name="source">A coleção original</param>
        /// <param name="totalCount">A nova quantidade</param>
        /// <returns>IEnumerable</returns>
        public static IEnumerable CreatePaggedEnumerable(IEnumerable source, int pageIndex, int pageSize, int totalCount)
        {
            // duplica a lista
            IList dest = (IList)source;

            // recupera o tipo do item da lista
            Type type = Util.GetTypeFirstItem(source);

            // se não tem tipo, então não pagina
            if (type == null)
            {
                return source;
            }

            // cria as paginas iniciais vazias
            for (int i = 0; i < (pageIndex * pageSize); i++)
            {
                dest.Insert(0, null);
            }

            // cria paginas finais vazias
            for (int i = dest.Count; i < totalCount; i++)
            {
                dest.Add(null);
            }

            // retorna nova lista
            return dest;
        }
    }
}
