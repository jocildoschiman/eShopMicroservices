namespace Catalog.API.Products.CreateProduct
{
    /// <summary>
    /// Definição do comando de requisição para criação de produto, que representa os dados necessários.
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Category"></param>
    /// <param name="Description"></param>
    /// <param name="ImageFile"></param>
    /// <param name="Price"></param>
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

    /// <summary>
    /// Definição do comando de resposta para criação de produto, que representa o resultado após a criação.
    /// </summary>
    /// <param name="Id"></param>
    public record CreateProductResponse(Guid Id);

    /// <summary>
    /// Classe responsável por definir o endpoint para a criação de produtos.
    /// </summary>
    public class CreateProductEndpoint : ICarterModule
    {
        /// <summary>
        /// Método responsável por adicionar as rotas de endpoint à aplicação.
        /// </summary>
        /// <param name="app"></param>
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            // Mapeia o endpoint para o método HTTP POST na rota "/products".
            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                // Converte o objeto de requisição em um comando apropriado usando o Mapster.
                var command = request.Adapt<CreateProductCommand>();

                // Envia o comando através do MediatR para ser processado.
                var result = await sender.Send(command);

                // Converte o resultado em uma resposta apropriada usando o Mapster.
                var response = result.Adapt<CreateProductResponse>();

                // Retorna a resposta com o status 201 Created, incluindo a URL do recurso criado.
                return Results.Created($"/products/{response.Id}", response);
            })
                // Define um nome amigável para o endpoint.
                .WithName("CreateProduct")
                // Define que este endpoint produz uma resposta com status 201 Created.
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                // Define que este endpoint pode produzir uma resposta com status 400 Bad Request em caso de erro.
                .ProducesProblem(StatusCodes.Status400BadRequest)
                // Adiciona um sumário descritivo para o endpoint.
                .WithSummary("Create Product")
                // Adiciona uma descrição detalhada para o endpoint.
                .WithDescription("Create Product");
        }
    }
}
