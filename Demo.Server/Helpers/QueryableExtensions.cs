using Demo.Shared.DTOs;

namespace Demo.Server.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>( this IQueryable<T> queryable, PaginacionDTO paginacion)
        {
            var q = queryable
                .Skip((paginacion.Pagina - 1) * paginacion.CantidadRegistros)
                .Take(paginacion.CantidadRegistros);

            return q;
        }
    }
}
