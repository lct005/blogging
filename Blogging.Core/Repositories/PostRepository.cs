using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blogging.Core.Objects;
using NHibernate;
using NHibernate.Linq;

namespace Blogging.Core.Repositories
{
    public interface IPostRepository
    {
        IList<Post> GetListPosts(int pageNo, int pageSize);
        IList<Post> GetListPosts(string search, int pageNo, int pageSize);
        IList<Post> GetListPosts(int pageNo, int pageSize, string sortColumn, bool sortByAscending);

        IList<Post> GetListPostsByTag(string tagSlug, int pageNo, int pageSize);
        IList<Post> GetListPostsByCategory(string categorySlug, int pageNo, int pageSize);

        Post GetPost(int year, int month, string titleSlug);
        Post GetPost(int id);

    }

    public class PostRepository : IPostRepository
    {
        private readonly ISession _session;

        public PostRepository(ISession session)
        {
            this._session = session;
        }

        public IList<Post> GetListPosts(int pageNo, int pageSize)
        {
            var query = _session.Query<Post>()
                                .Where(p=>p.Published)
                                .OrderByDescending(p => p.PostedOn)
                                .Skip(pageNo * pageSize)
                                .Take(pageSize)
                                .Fetch(p => p.Category);

            query.FetchMany(p => p.Tags).ToFuture();

            return query.ToFuture().ToList();
        }

        public IList<Post> GetListPosts(string search, int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IList<Post> GetListPosts(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            throw new NotImplementedException();
        }

        public IList<Post> GetListPostsByTag(string tagSlug, int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IList<Post> GetListPostsByCategory(string categorySlug, int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int year, int month, string titleSlug)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int id)
        {
            throw new NotImplementedException();
        }
    }
}
