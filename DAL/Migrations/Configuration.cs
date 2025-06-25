namespace DAL.Migrations
{
    using DAL.EF;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.LMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.LMSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            if (context.Loans.Any())
                return;

            var random = new Random();

            // Seed 5 loans
            for (int i = 1; i <= 5; i++)
            {
                var loan = new Loan
                {
                    LoanNumber = $"LN-{1000 + i}",
                    Amount = random.Next(5000, 20000),
                    InterestRate = random.Next(5, 15),
                    StartDate = DateTime.Now.AddMonths(-random.Next(1, 12)),
                    TermMonths = 12,
                    Status = "Active"
                };

                context.Loans.Add(loan);
            }

            context.SaveChanges();

            // Seed payments for the first 3 loans
            var loans = context.Loans.Take(3).ToList();

            foreach (var loan in loans)
            {
                for (int j = 0; j < 3; j++)
                {
                    var payment = new Payment
                    {
                        LoanId = loan.Id,
                        Amount = random.Next(500, 1000),
                        PaymentDate = DateTime.Now.AddDays(-random.Next(1, 60))
                    };

                    context.Payments.Add(payment);
                }
            }

            context.SaveChanges();

           
        }
    }
}
