using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingRace.DAL;
using TheAmazingRace.Models;

namespace TheAmazingRace.BLL
{
    public class RoleService: BaseService<Role>
    {
        private RoleRepo repo = new RoleRepo();

        public RoleService()
        {
            this.Repo = repo;
        }
    }
}
