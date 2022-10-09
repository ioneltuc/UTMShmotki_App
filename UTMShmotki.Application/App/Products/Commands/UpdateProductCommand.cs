using AutoMapper;
using MediatR;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Domain;

namespace UTMShmotki.Application.App.Products.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public UpdateProductCommandHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = _repository.GetById<Product>(command.Id);
            _mapper.Map(command, product);
            _repository.UpdateById<Product>();
            return Unit.Value;
        }
    }
}