using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace apymentapi.Models
{
    public class PaymentDetailContext : DbContext
    {
        
            public PaymentDetailContext(DbContextOptions options) : base(options)
            {

            }

        public DbSet<PaymentDetailS> PaymentDetails { get; set; }

    }
}

