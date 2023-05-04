using LMS.Repository.Repositories;
using LMS.Shared.Entities;
using LMS.Shared.Requests.Users;
using LMS.Shared.Tools;

namespace LMS.Service.Services {
    public class UserService {

        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository) {
            _userRepository = userRepository;
        }

        public User GetById(string id) {

            var user = _userRepository.GetById(new Guid(id));

            if (user == null)
                throw new Exception("User not found.");

            return user;

        }

        public User GetByLoginPassword(string login, string passwordNoMd5) {

            var user = _userRepository.GetByLoginPassword(login, passwordNoMd5);

            if (user == null)
                throw new Exception("Incorrect username or password");

            if (user.Situation != Shared.Enums.UserSituation.Active)
                throw new Exception("User situation is not active.");

            return user;

        }

        public User Add(UserAddRequest newUser) {

            var user = AutoConvertEntity.Convert<UserAddRequest, User>(newUser, new User());

            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.UtcNow;

            user.Password = PasswordTools.GenerateMD5(user.Password);

            _userRepository.Add(user);

            _userRepository.Commit();

            return user;

        }

        public void Update(UserUpdateRequest oldUser) {

            var user = _userRepository.GetById(oldUser.Id);

            if (user == null)
                throw new Exception("User not found.");

            if (user.Deleted)
                throw new Exception("It's not possible to update this user because they have been deleted.");

            user = AutoConvertEntity.Convert<UserUpdateRequest, User>(oldUser, user);

            user.UpdatedAt = DateTime.UtcNow;

            _userRepository.Commit();

        }

        public void Delete(string id) {

            var user = _userRepository.GetById(new Guid(id));

            if (user == null)
                throw new Exception("User not found.");

            user.Deleted = true;
            user.DeletedAt = DateTime.UtcNow;

            _userRepository.Commit();

        }


    }
}
