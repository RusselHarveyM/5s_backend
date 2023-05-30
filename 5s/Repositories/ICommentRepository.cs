using _5s.Model;

namespace _5s.Repositories
{
    public interface ICommentRepository
    {
        public Task<int> CreateComment(Comment comment);
        public Task<IEnumerable<Comment>> GetAllComment();
        public Task<Comment> GetCommentById(int id);
        public Task<int> UpdateComment(int id, Comment updateComment);
        public Task DeleteComment(int id);

    }
}
