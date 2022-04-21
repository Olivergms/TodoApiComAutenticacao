using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface IQuery<T>
    {
        public IEnumerable<T> ObterTodos();
        public T ObterPorId(int id);
    }
}
