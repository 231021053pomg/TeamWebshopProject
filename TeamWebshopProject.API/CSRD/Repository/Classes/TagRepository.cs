using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class TagRepository : ITagRepository
    {
        public Task<Tag> GetName()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetTag(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tag>> GetTagsList()
        {
            throw new NotImplementedException();
        }
    }
}
