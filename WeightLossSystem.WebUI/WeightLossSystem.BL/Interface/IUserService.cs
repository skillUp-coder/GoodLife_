using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.BL.DTO;

namespace WeightLossSystem.BL.Interface
{
    public interface IUserService
    {
        void CreateUser(UserDTO userDTO);
        UserDTO GetUser(int ? id);
        bool CheckUser(UserDTO userDTO);
        bool CheckRegister(UserDTO userDTO);
        IEnumerable<UserDTO> GetUsers();
        void Dispose();
    }
}
