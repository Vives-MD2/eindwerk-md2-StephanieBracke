using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VidyaBase.DAL;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.BLL
{
    public class UserManager : IUser
    {
        private readonly UserDB _userDB = new UserDB();

        public async Task<User> CreateAsync(User entity)
        {
            Console.WriteLine("Creating {0} in manager", entity.Email);
            if (!IsValidEmail(entity.Email))
            {
                entity.Vex = new VidyaException("Invalid Email", ExceptionTypes.Warning);

                Console.WriteLine("email not valid");

                return entity;
            }

            return await _userDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<User>> CreateRangeAsync(List<User> entities)
        {
            return await _userDB.CreateRangeAsync(entities);
        }

        public async Task<User> DeleteAsync(User entity)
        {
            return await _userDB.DeleteAsync(entity);
        }

        public async Task<IEnumerable<User>> GetAsync(int skip, int take)
        {
            return await _userDB.GetAsync(skip, take);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            if (id <= 0)
                return new User() { Vex = new VidyaException("Id is lower than one", ExceptionTypes.Warning) };

            //int nul = 0;
            //int tst = 2 / nul;
            User user = await _userDB.GetByIdAsync(id);
            return user ?? new User() { Vex = new VidyaException("No User Found!", ExceptionTypes.Warning) };
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            if (email == string.Empty)
                return new User() { Vex = new VidyaException("Email invalid", ExceptionTypes.Warning) };

            User user = await _userDB.GetByEmailAsync(email);
            return user ?? new User() { Vex = new VidyaException("No User Found!", ExceptionTypes.Warning) };
        }


        public async Task<int> GetTotalCountAsync()
        {
            return await _userDB.GetTotalCountAsync();
        }

        public async Task<User> UpdateAsync(User entity)
        {
            if (!IsValidEmail(entity.Email))
            {
                entity.Vex = new VidyaException("Invalid Email", ExceptionTypes.Warning);
                return entity;
            }
            return await _userDB.UpdateAsync(entity);
        }

        //https://stackoverflow.com/a/48476318/3701072
        public bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}
