using MediatR;

namespace BuildingBlocks.CQRS
{
    /// <summary>
    /// Interface que representa uma consulta que será processada pelo MediatR e que retorna um tipo específico de resposta.
    /// </summary>
    /// <typeparam name="TResponse">O tipo da resposta que a consulta retornará.</typeparam>
    public interface IQuery<out TResponse> : IRequest<TResponse>
        where TResponse : notnull
    {
        // Esta interface herda de IRequest<TResponse>, o que permite que consultas sejam enviadas e processadas
        // através do MediatR, retornando uma resposta do tipo TResponse.
        // A restrição "TResponse : notnull" garante que o tipo de resposta não pode ser nulo.
    }
}
