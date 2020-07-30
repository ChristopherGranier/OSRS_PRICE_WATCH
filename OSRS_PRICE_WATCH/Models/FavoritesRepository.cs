using OsrsBoxImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_PRICE_WATCH.Models
{
    public interface IFavoritesRepository
    {
        IQueryable<FavoriteModel> Items { get; }
        int SaveFavorite(FavoriteModel item);
    }
    public class FavoritesRepository : IFavoritesRepository
    {
        private ApplicationDbContext context;
        public FavoritesRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<FavoriteModel> Items => context.Favorites;
        public int SaveFavorite(FavoriteModel item)
        {

            if ((context.Favorites.Where(i => i.Username == item.Username)
                    .Select(i => i.Username)
                    .FirstOrDefault() == item.Username) &&
                    (context.Favorites
                    .Where(i => i.ItemID == item.ItemID)
                    .Select(i => i.ItemID)
                    .FirstOrDefault() == item.ItemID))
            {

                if (item.ItemID == null || item.Username == null)
                {

                    return 0;
                }
                return 0;
            }
            else
            {
                context.Add(item);
                context.SaveChanges();
                return 1;
            }
            

            
        }
    }
}
