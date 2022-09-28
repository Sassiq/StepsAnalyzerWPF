using StepsAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepsAnalyzer.Interfaces
{
    public interface IUserSerializer
    {
        public void Serialize(IEnumerable<User> users, string path);
    }
}
