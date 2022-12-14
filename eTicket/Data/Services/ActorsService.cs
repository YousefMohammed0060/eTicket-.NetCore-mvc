using eTicket.Data.Base;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eTicket.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor> ,IActorService
    {
        

        public ActorsService(AppDbContext context) : base(context) { }
        
    }
}
