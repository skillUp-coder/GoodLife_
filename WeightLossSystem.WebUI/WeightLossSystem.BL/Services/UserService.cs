using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.BL.DTO;
using WeightLossSystem.BL.Infrastructure;
using WeightLossSystem.BL.Interface;
using WeightLossSystem.Domain.Entities;
using WeightLossSystem.Domain.Interfaces;
using AutoMapper;

namespace WeightLossSystem.BL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Database;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.Database = unitOfWork;
        }
        public void CreateUser(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ValidationException("Datas not found","");
            
            
            User user = new User
            {
                Email = userDTO.Email,
                Name = userDTO.Name,
                Password = userDTO.Password,
                _RoleId = userDTO._RoleId
            };
            Database.Users.Create(user);
            Database.Save();
        }

        

        public UserDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("Dont found user","");
            var user = Database.Users.Get(id.Value);
            if (user == null)
                throw new ValidationException("Dont found data","");
            return new UserDTO { Email = user.Email,  Name = user.Name, UserId = user.UserId, Password = user.Password, _RoleId = user._RoleId };
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, IList<UserDTO>>(Database.Users.GetAll());
        }
        

        public void Dispose()
        {
            Database.Dispose();
        }

        public bool CheckUser(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ValidationException("Datas are empty", "");
            User user = new User
            {
                Email = userDTO.Email,
                Name = userDTO.Name,
                Password = userDTO.Password,
                _RoleId = userDTO._RoleId
            };
            var datas =  Database.Users.CheckDatas(user);

            if (datas != null) return true;
            
                return false;
        }

        public bool CheckRegister(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ValidationException("Datas are empty", "");
            User user = new User
            {
                Email = userDTO.Email,
                Name = userDTO.Name,
                Password = userDTO.Password,
                _RoleId = userDTO._RoleId
            };
            var datas = Database.Users.CheckDataRegister(user);
            if (datas != null) { return true; }
            else return false;
        }
    }
}
