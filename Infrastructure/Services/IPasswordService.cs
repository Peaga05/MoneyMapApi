using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IPasswordService
    {
        public string EncryptPassword(string password);
        public bool ValidedPassword(string password, string hashPassword);
    }
}
