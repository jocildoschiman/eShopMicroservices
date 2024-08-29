using BuildingBlocks.CQRS; 
using Catalog.API.Models;  

namespace Catalog.API.Products.CreateProduct
{
    /// <summary>
    /// Comando para criar um novo produto.
    /// </summary>
    /// <param name="Name">Nome do produto.</param>
    /// <param name="Category">Lista de categorias associadas ao produto.</param>
    /// <param name="Description">Descrição do produto.</param>
    /// <param name="ImageFile">Caminho ou nome do arquivo de imagem do produto.</param>
    /// <param name="Price">Preço do produto.</param>
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;

    /// <summary>
    /// Resultado retornado após a criação do produto.
    /// </summary>
    /// <param name="Id">Identificador único do produto criado.</param>
    public record CreateProductResult(Guid Id);

    /// <summary>
    /// Manipulador do comando CreateProductCommand.
    /// Responsável por processar a criação de um novo produto.
    /// </summary>
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        /// <summary>
        /// Lida com o comando de criação de produto, criando a entidade e salvando-a no banco de dados.
        /// </summary>
        /// <param name="command">O comando que contém os dados necessários para a criação do produto.</param>
        /// <param name="cancellationToken">Token de cancelamento para a operação assíncrona.</param>
        /// <returns>Um objeto CreateProductResult contendo o Id do produto criado.</returns>
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Lógica para criar o produto:

            // Criar a entidade do produto com os dados recebidos no comando.
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            // Salvar no banco de dados (simulação)
            // Aqui será incluída a lógica para persistir a entidade product no banco de dados.
            // Por exemplo, usando um repositório ou contexto de banco de dados.

            // Retornar o resultado da criação, gerando um novo Guid para o produto.
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
