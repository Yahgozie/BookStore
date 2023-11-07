using BookStore.Web.Models;
using BookStore.Web.Models.Dto;

namespace BookStore.Web.Services.Interface
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
