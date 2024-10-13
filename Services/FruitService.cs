using Frutas.Data;
using Frutas.Models;
using Microsoft.EntityFrameworkCore;


namespace Frutas.Services
{
    public class FruitService
    {
        private readonly ApplicationDbContext _context;

        public FruitService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fruit>> GetAllFruitsAsync()
        {
            return await _context.Fruits.ToListAsync();
        }

        public async Task<Fruit?> GetFruitByIdAsync(int id)
        {
            return await _context.Fruits.FindAsync(id);
        }

        public async Task<Fruit> CreateFruitAsync(Fruit fruit)
        {
            _context.Fruits.Add(fruit);
            await _context.SaveChangesAsync();
            return fruit;
        }

        public async Task<Fruit?> UpdateFruitAsync(int id, Fruit updatedFruit)
        {
            var fruit = await _context.Fruits.FindAsync(id);
            if (fruit == null) return null;

            fruit.Nombre = updatedFruit.Nombre;
            await _context.SaveChangesAsync();
            return fruit;
        }

        public async Task<bool> DeleteFruitAsync(int id)
        {
            var fruit = await _context.Fruits.FindAsync(id);
            if (fruit == null) return false;

            _context.Fruits.Remove(fruit);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
