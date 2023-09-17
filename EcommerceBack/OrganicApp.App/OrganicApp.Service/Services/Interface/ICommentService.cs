using OrganicApp.Core.Entities;
using OrganicApp.Service.Utilities.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.Services.Interface
{
    public interface ICommentService
    {
        Task<Paginate<Comment>> AllComments(string search, int page, int take);
        Task<List<Comment>> ProductComment(int id);
        Task CreateAsync(Comment model);
        Task RemoveAsync(int id);
    }
}
