using Microsoft.EntityFrameworkCore;
using ShopBom.Colors;
using ShopBom.Customers;
using ShopBom.Images;
using ShopBom.IntermediaryProductTypes;
using ShopBom.Orders;
using ShopBom.ProductColors;
using ShopBom.ProductPromotions;
using ShopBom.Products;
using ShopBom.ProductSizes;
using ShopBom.ProductTypes;
using ShopBom.Promotions;
using ShopBom.Sizes;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace ShopBom.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class ShopBomDbContext : 
        AbpDbContext<ShopBomDbContext>,
        IIdentityDbContext,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */
        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<IntermediaryProductType> IntermediaryProductTypes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductPromotion> ProductPromotions { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Image> Images { get; set; }
        #region Entities from the modules

        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */

        //Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }
        
        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion
        
        public ShopBomDbContext(DbContextOptions<ShopBomDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigureBackgroundJobs();
            builder.ConfigureIdentity();
            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside here */

            builder.Entity<Product>(b =>
            {
                b.ToTable(ShopBomConsts.DbTablePrefix + "Products", ShopBomConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
                b.Property(x => x.Name).IsRequired();
                b.Property(x => x.Price).IsRequired();
                b.HasOne<Color>().WithMany().HasForeignKey(x => x.IdColor).IsRequired();
                b.HasOne<Size>().WithMany().HasForeignKey(x => x.IdSize).IsRequired();
                b.HasOne<ProductType>().WithMany().HasForeignKey(x => x.IdProductType).IsRequired();
            });
            builder.Entity<Size>(b =>
            {
                b.ToTable(ShopBomConsts.DbTablePrefix + "Sizes", ShopBomConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
                b.Property(x => x.Name).IsRequired().HasMaxLength(3000);
            });
            builder.Entity<Promotion>(b =>
            {
                b.ToTable(ShopBomConsts.DbTablePrefix + "Promotions", ShopBomConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
                b.Property(x => x.Name).IsRequired();
                b.Property(x => x.Percent).IsRequired();
                b.Property(x => x.Begin);
                b.Property(x => x.End);
                b.HasOne<Product>().WithMany().HasForeignKey(x => x.IdProduct).IsRequired();
            });
            builder.Entity<ProductType>(b =>
            {
                b.ToTable(ShopBomConsts.DbTablePrefix + "ProductTypes", ShopBomConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
                b.Property(x => x.Name).IsRequired().HasMaxLength(3000);
            });
            builder.Entity<Order>(b =>
            {
                b.ToTable(ShopBomConsts.DbTablePrefix + "Orders", ShopBomConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
                b.Property(x => x.Name).IsRequired();
                b.Property(x => x.PhoneNumber).IsRequired();
                b.Property(x => x.Address).IsRequired();
                b.Property(x => x.Email);
                b.Property(x => x.Name);
            });

            builder.Entity<Customer>(b =>
            {
                b.ToTable(ShopBomConsts.DbTablePrefix + "Customers", ShopBomConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
                b.Property(x => x.Name).IsRequired();
                b.Property(x => x.PhoneNumber).IsRequired();
                b.Property(x => x.Address).IsRequired();
                b.Property(x => x.Email);
            });
            builder.Entity<Color>(b =>
            {
                b.ToTable(ShopBomConsts.DbTablePrefix + "Colors", ShopBomConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
                b.Property(x => x.Name).IsRequired();
            });
              builder.Entity<IntermediaryProductType>(b =>
            {
                b.ToTable(ShopBomConsts.DbTablePrefix + "IntermediaryProductTypes", ShopBomConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
                b.HasOne<Product>().WithMany().HasForeignKey(x => x.IdProduct).IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.HasOne<ProductType>().WithMany().HasForeignKey(x => x.IdProductType).IsRequired().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<ProductColor>(b =>
            {
                b.ToTable(ShopBomConsts.DbTablePrefix + "ProductColors", ShopBomConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
                b.HasOne<Product>().WithMany().HasForeignKey(x => x.IdProduct).IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.HasOne<Color>().WithMany().HasForeignKey(x => x.IdColor).IsRequired().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<ProductPromotion>(b =>
            {
                b.ToTable(ShopBomConsts.DbTablePrefix + "ProductPromotions", ShopBomConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
                b.HasOne<Product>().WithMany().HasForeignKey(x => x.IdProduct).IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.HasOne<Color>().WithMany().HasForeignKey(x => x.IdPromotion).IsRequired().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<ProductSize>(b =>
            {
                b.ToTable(ShopBomConsts.DbTablePrefix + "ProductSizes", ShopBomConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
                b.HasOne<Product>().WithMany().HasForeignKey(x => x.IdProduct).IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.HasOne<Color>().WithMany().HasForeignKey(x => x.IdSize).IsRequired().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<Image>(b =>
            {
                b.ToTable(ShopBomConsts.DbTablePrefix + "Images", ShopBomConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
                b.Property(x => x.URl).IsRequired();;
                b.HasOne<Product>().WithMany().HasForeignKey(x => x.IdProduct).IsRequired().OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
