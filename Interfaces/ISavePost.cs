using UAMIS321_PA3.Models;

namespace UAMIS321_PA3
{
    public interface ISavePost
    {
        public void savePost(Post myPost);

        public void createPost(Post myPost);
        
    }
}