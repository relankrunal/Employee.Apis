namespace Employee.Infrastructure
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DbContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public DbContext? CreateDbContext(DbContextName contextType)
        {
            switch (contextType)
            {
                case DbContextName.TrainingToolDbContext:
                    return _serviceProvider.GetRequiredService<TrainingToolDbContext>();
                case DbContextName.TrainingDbContext:
                    return _serviceProvider.GetRequiredService<TrainingDbContext>();
                case DbContextName.DataScienceDbContext:
                    return _serviceProvider.GetRequiredService<DataScienceDbContext>();
                case DbContextName.QMDbContext:
                    return _serviceProvider.GetRequiredService<QMDbContext>(); 
                default:
                    return default;
            }
        }
    }
}