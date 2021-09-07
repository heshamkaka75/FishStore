using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Models
{
    public class FishStoreContext : DbContext
    {
        public FishStoreContext(DbContextOptions<FishStoreContext> options) : base(options)
        {

        }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<Fish> Fishs { get; set; }
        public DbSet<CenterFishAgency> CenterFishAgencies { get; set; }
        public DbSet<AgentOrder> AgentOrders { get; set; }


    }
}
