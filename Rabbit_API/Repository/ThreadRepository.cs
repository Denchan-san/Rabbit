﻿using Microsoft.EntityFrameworkCore;
using Rabbit_API.Data;
using Rabbit_API.Models;
using Rabbit_API.Repository.IRepository;

namespace Rabbit_API.Repository
{
    public class ThreadRepository : Repository<Models.Thread>, IThreadRepository
    {
        private readonly ApplicationDbContext _db;
        public ThreadRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Models.Thread> UpdateAsync(Models.Thread entity)
        {
            _db.Threads.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public void Detach(Models.Thread entity)
        {
            var entry = _db.Entry(entity);
            if (entry != null)
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
