using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IQuery<T>
    {
        public IEnumerable<T> ObterTodos();
        public T ObterPorId(int id);
    }
}
