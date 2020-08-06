using OsrsBoxImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OSRS_PRICE_WATCH.Models
{
    public interface IFavoritesRepository
    {
        IQueryable<FavoriteModel> Items { get; }
        int SaveFavorite(FavoriteModel item);

        FavoriteModel DeleteFavorite(FavoriteModel item);
    }

    public class FavoritesRepository : IFavoritesRepository
    {
        private ApplicationDbContext context;
        public FavoritesRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<FavoriteModel> Items => context.Favorites.FromSqlRaw("SELECT * FROM dbo.Favorites");
        public int SaveFavorite(FavoriteModel item)
        {
            int temp = this.Items.Where(i => i.Username == item.Username).Where(i => i.ItemID == item.ItemID).Count();
            //if((context.Favorites.FromSqlRaw("Select Username, ItemID FROM dbo.Favorites WHERE username = '" + item.Username + "' AND itemId = '" + item.ItemID + "'")).Count() > 0)
            //{
                
            //}
            if (temp > 0)
            {

                if (item.ItemID == null || item.Username == null)
                {

                    return 2;
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

        public FavoriteModel DeleteFavorite(FavoriteModel item)
        {
            FavoriteModel dbEntry = context.Favorites.FirstOrDefault(i => i.FavoritesID == item.FavoritesID);
            context.Remove(dbEntry);
            context.SaveChanges();
            return dbEntry;
            
        }
    }
}
