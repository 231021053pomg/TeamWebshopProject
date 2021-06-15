using Microsoft.EntityFrameworkCore;
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
        private readonly TeamWebshopDbContext _context;
        public TagRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> Create(Tag tag)
        {
           tag.CreatedAt = DateTime.Now;
           _context.Tags.Add(tag);
           await _context.SaveChangesAsync();

            return tag;
        }

        public async Task<Tag> Delete(int id)
        {
            var tag = await _context.Tags
                .FirstOrDefaultAsync(t => t.Id == id);
            if (tag != null || tag.DeletedAt == null)
	        {
                tag.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();

               
	        }
            return tag;
        }

        public async Task<Tag> Get(int id)
        {
            return await _context.Tags
                .Where(t => t.DeletedAt == null)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Tag>> GetAll()
        {
            return await _context.Tags
                .Where(t => t.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Tag> Update(int id, Tag updatedTag)
        {
           var tag = await _context.Tags
                .FirstOrDefaultAsync(t => t.Id == id);
            if (tag != null)
	        {
                tag.EditedAt = DateTime.Now;

                if (updatedTag.Name != null)
                    tag.Name = updatedTag.Name;

                _context.Update(tag);
                await _context.SaveChangesAsync();
	            

	            
	        }
            return tag;
        }
    }
}
