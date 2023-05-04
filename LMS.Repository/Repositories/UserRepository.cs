using LMS.Shared.Entities;
using LMS.Shared.Tools;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repository.Repositories {
    public class UserRepository {

        private readonly RepositoryContext _context;

        public UserRepository(RepositoryContext context) {
            _context = context;
        }

        public User? GetById(Guid id) {

            var result = _context
                .Users
                .Where(x => x.Id == id && x.Deleted == false)
                .AsTracking()
                .FirstOrDefault();

            return result;

        }

        public User? GetByLoginPassword(string login, string passwordNoMd5) {

            var password = PasswordTools.GenerateMD5(passwordNoMd5);

            var result = _context
                .Users
                .Where(x => x.Login == login && x.Password == password && x.Deleted == false)
                .AsNoTracking()
                .FirstOrDefault();

            return result;

        }

        public void Commit() => _context.SaveChanges();

        public void Add(User user) => _context.Users.Add(user);

        

    }
}
