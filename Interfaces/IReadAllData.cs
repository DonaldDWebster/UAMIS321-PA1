using System.Collections.Generic;
using UAMIS321_PA3.Models;

namespace UAMIS321_PA3.Interfaces
{
    public interface IReadAllData
    {
         public List<Post> GetAllPosts();
    }
}