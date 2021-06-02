using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Database.Context;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class TagRepository : ITagRepository
    {
        private TeamWebshopDbContext _context;
        public TagRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public Task<Tag> Create(Tag tag)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tag>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> Update(int id, Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
