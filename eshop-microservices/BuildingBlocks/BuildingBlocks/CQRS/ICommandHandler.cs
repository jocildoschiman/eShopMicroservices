using MediatR;

namespace BuildingBlocks.CQRS
{
    /// <summary>
    /// Interface que define um manipulador de comandos que não retorna um valor significativo.
    /// </summary>
    /// <typeparam name="TCommand">O tipo do comando que será manipulado.</typeparam>
    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {
        // Esta interface herda de ICommandHandler<TCommand, Unit>, indicando que o manipulador de comandos não retornará um valor significativo (void).
    }

    /// <summary>
    /// Interface que define um manipulador de comandos que retorna um tipo específico de resposta.
    /// </summary>
    /// <typeparam name="TCommand">O tipo do comando que será manipulado.</typeparam>
    /// <typeparam name="TResponse">O tipo da resposta que o comando retornará.</typeparam>
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse : notnull
    {
        // Esta interface herda de IRequestHandler<TCommand, TResponse>, permitindo que comandos sejam processados e uma resposta seja retornada.
        // O parâmetro "in" especifica que TCommand é um tipo de entrada (contravariância).
        // A restrição "TResponse : notnull" garante que o tipo de resposta não pode ser nulo.
    }
}
