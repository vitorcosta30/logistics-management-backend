using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Domain.Requests;
using logistics_management_backend.Domain.Shared;
using logistics_management_backend.DTO.Requests;
using logistics_management_backend.Infrastructure.Products;
using logistics_management_backend.Infrastructure.Requests;

namespace logistics_management_backend.Services.Requests;

public class RequestService : IRequestService
{
    private readonly IUnitOfWork _unitOfwork;
    private readonly IRequestRepository _repo;
    private readonly IProductRepository _productRepository;

    
    
    public RequestService(IUnitOfWork unitOfWork, IRequestRepository repository, IProductRepository productRepository){
        this._unitOfwork = unitOfWork;
        this._repo = repository;
        this._productRepository = productRepository;
    }

    public async Task<List<RequestDTO>> getAllAsync()
    {
        var list = await this._repo.GetAllAsync();
        List<RequestDTO> res = list.ConvertAll<RequestDTO>(req => RequestMapper.toDTO(req));
        return res;
    }

    public async Task<List<RequestDTO>> getAllToBeProcessedAsync()
    {
        var list = await this._repo.getAllToBeProcessedAsync();
        List<RequestDTO> res = list.ConvertAll<RequestDTO>(req => RequestMapper.toDTO(req));
        return res;    
    }

    public Task<List<RequestItemDTO>> getProductsInRequestAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestDTO> addRequest(RequestItemDTO[] items)
    {
        RequestItemList listOfItems = new RequestItemList();
        for (int i = 0; i < items.Length; i++)
        {
            Product product = this._productRepository.GetByIdAsync(items[i].product.Id).Result;
            if (product == null)
            {
                
            }
            listOfItems.addItem(new RequestItem(product,items[i].quantity));
        }

        Request req = new Request(listOfItems);
        await this._repo.AddAsync(req);
        await this._unitOfwork.CommitAsync();
        return RequestMapper.toDTO(req);

    }
}