using MediatR;

namespace BuildingBlocks.CQRS
{
    /// <summary>
    /// Representa um comando sem retorno (void) que será processado pelo MediatR.
    /// </summary>
    public interface ICommand : ICommand<Unit>
    {
        // Esta interface herda de ICommand<Unit>, o que significa que é um comando que não retorna um valor significativo.
    }

    /// <summary>
    /// Representa um comando que será processado pelo MediatR e que retorna um tipo específico de resposta.
    /// </summary>
    /// <typeparam name="TResponse">O tipo da resposta que o comando retorna.</typeparam>
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
        // Esta interface herda de IRequest<TResponse>, integrando-se ao MediatR para enviar comandos e receber respostas.
    }
}
