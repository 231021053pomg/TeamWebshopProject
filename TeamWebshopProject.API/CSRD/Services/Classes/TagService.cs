using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<Tag> Create(Tag tag)
        {
            var result = await _tagRepository.Create(tag);
            return result;
        }

        public async Task<Tag> Delete(int id)
        {
            var result = await _tagRepository.Delete(id);
            return result;
        }

        public async Task<Tag> Get(int id)
        {
            var result = await _tagRepository.Get(id);
            return result;
        }

        public async Task<List<Tag>> GetAll()
        {
            var result = await _tagRepository.GetAll();
            return result;
        }

        public async Task<Tag> Update(int id, Tag tag)
        {
            var result = await _tagRepository.Update(id, tag);
            return result;
        }
    }
}
