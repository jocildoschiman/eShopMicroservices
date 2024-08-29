using MediatR;

namespace BuildingBlocks.CQRS
{
    /// <summary>
    /// Interface que define um manipulador de consultas (queries) que retorna um tipo específico de resposta.
    /// </summary>
    /// <typeparam name="TQuery">O tipo da consulta que será manipulada.</typeparam>
    /// <typeparam name="TResponse">O tipo da resposta que a consulta retornará.</typeparam>
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
        where TResponse : notnull
    {
        // Esta interface herda de IRequestHandler<TQuery, TResponse>, integrando-se ao MediatR para processar consultas (queries)
        // e retornar uma resposta.
        // O parâmetro "in" especifica que TQuery é um tipo de entrada (contravariância).
        // A restrição "TResponse : notnull" garante que o tipo de resposta não pode ser nulo.
    }
}
