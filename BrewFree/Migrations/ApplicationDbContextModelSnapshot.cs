using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BrewFree.Data;

namespace BrewFree.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BrewFree.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasAnnotation("SqlServer:Schema", "Security");

                    b.HasAnnotation("SqlServer:TableName", "Users");
                });

            modelBuilder.Entity("BrewFree.Data.Models.Brewer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<bool>("Shared");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Brewers");

                    b.HasAnnotation("SqlServer:Schema", "User");

                    b.HasAnnotation("SqlServer:TableName", "Brewers");
                });

            modelBuilder.Entity("BrewFree.Data.Models.Lookups.BrewingMethod", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasMaxLength(2500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Code");

                    b.ToTable("BrewingMethods");

                    b.HasAnnotation("SqlServer:Schema", "Lookup");

                    b.HasAnnotation("SqlServer:TableName", "BrewingMethods");
                });

            modelBuilder.Entity("BrewFree.Data.Models.Lookups.Style", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100);

                    b.Property<decimal?>("AlcoholByVolumeMaximum");

                    b.Property<decimal?>("AlcoholByVolumeMinimum");

                    b.Property<string>("Aroma")
                        .HasMaxLength(2500);

                    b.Property<decimal?>("ColorMaximum");

                    b.Property<decimal?>("ColorMinimum");

                    b.Property<string>("Description")
                        .HasMaxLength(2500);

                    b.Property<string>("Examples")
                        .HasMaxLength(2500);

                    b.Property<decimal?>("FinalGravityMaximum");

                    b.Property<decimal?>("FinalGravityMinimum");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal?>("OriginalGravityMaximum");

                    b.Property<decimal?>("OriginalGravityMinimum");

                    b.HasKey("Code");

                    b.ToTable("Styles");

                    b.HasAnnotation("SqlServer:Schema", "Lookup");

                    b.HasAnnotation("SqlServer:TableName", "Styles");
                });

            modelBuilder.Entity("BrewFree.Data.Models.Lookups.StyleTag", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasMaxLength(2500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("TypeCode")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Code");

                    b.ToTable("StyleTags");

                    b.HasAnnotation("SqlServer:Schema", "Lookup");

                    b.HasAnnotation("SqlServer:TableName", "StyleTags");
                });

            modelBuilder.Entity("BrewFree.Data.Models.Lookups.StyleTagAssociation", b =>
                {
                    b.Property<string>("StyleCode");

                    b.Property<string>("StyleTagCode");

                    b.HasKey("StyleCode", "StyleTagCode");

                    b.HasIndex("StyleTagCode");

                    b.ToTable("StyleTagAssociations");

                    b.HasAnnotation("SqlServer:Schema", "Lookup");

                    b.HasAnnotation("SqlServer:TableName", "StyleTagAssociation");
                });

            modelBuilder.Entity("BrewFree.Data.Models.Recipe", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<string>("BrewerId");

                    b.Property<string>("BrewingMethodCode");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("StyleCode");

                    b.HasKey("Id");

                    b.HasIndex("BrewerId");

                    b.HasIndex("BrewingMethodCode");

                    b.HasIndex("StyleCode");

                    b.ToTable("Recipes");

                    b.HasAnnotation("SqlServer:Schema", "User");

                    b.HasAnnotation("SqlServer:TableName", "Recipes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasAnnotation("SqlServer:Schema", "Security");

                    b.HasAnnotation("SqlServer:TableName", "Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");

                    b.HasAnnotation("SqlServer:Schema", "Security");

                    b.HasAnnotation("SqlServer:TableName", "RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");

                    b.HasAnnotation("SqlServer:Schema", "Security");

                    b.HasAnnotation("SqlServer:TableName", "UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");

                    b.HasAnnotation("SqlServer:Schema", "Security");

                    b.HasAnnotation("SqlServer:TableName", "UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasAnnotation("SqlServer:Schema", "Security");

                    b.HasAnnotation("SqlServer:TableName", "UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");

                    b.HasAnnotation("SqlServer:Schema", "Security");

                    b.HasAnnotation("SqlServer:TableName", "UserTokens");
                });

            modelBuilder.Entity("BrewFree.Data.Models.Brewer", b =>
                {
                    b.HasOne("BrewFree.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BrewFree.Data.Models.Lookups.StyleTagAssociation", b =>
                {
                    b.HasOne("BrewFree.Data.Models.Lookups.Style", "Style")
                        .WithMany("StyleTags")
                        .HasForeignKey("StyleCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BrewFree.Data.Models.Lookups.StyleTag", "StyleTag")
                        .WithMany()
                        .HasForeignKey("StyleTagCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BrewFree.Data.Models.Recipe", b =>
                {
                    b.HasOne("BrewFree.Data.Models.Brewer", "Brewer")
                        .WithMany()
                        .HasForeignKey("BrewerId");

                    b.HasOne("BrewFree.Data.Models.Lookups.BrewingMethod", "BrewingMethod")
                        .WithMany()
                        .HasForeignKey("BrewingMethodCode");

                    b.HasOne("BrewFree.Data.Models.Lookups.Style", "Style")
                        .WithMany()
                        .HasForeignKey("StyleCode");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BrewFree.Data.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BrewFree.Data.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BrewFree.Data.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
