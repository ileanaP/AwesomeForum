using AweForum.Data.Static;
using AweForum.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                #region PopulateCategoriesTable
                if (!context.Categories.Any())
                {
                    var categoriesObj = new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Meta",
                            OrderNr = 1
                        },
                        new Category()
                        {
                            Name = "Fashion & Lifestyle",
                            OrderNr=2
                        },
                        new Category()
                        {
                            Name = "Media & Leisure",
                            OrderNr = 3
                        },
                        new Category()
                        {
                            Name = "Annals",
                            OrderNr = 4
                        },

                    };

                    context.Categories.AddRange(categoriesObj);
                    context.SaveChanges();
                }
                #endregion

                #region PopulateForumsTable
                if (!context.Forums.Any())
                {
                    context.Forums.AddRange(new List<Forum>()
                    {
                        new Forum()
                        {
                            Name= "Rules and announcements",
                            TopicCount = 0,
                            OrderNr = 1,
                            CategoryId = 13
                        },
                        new Forum()
                        {
                            Name= "Welcome",
                            TopicCount = 0,
                            OrderNr = 2,
                            CategoryId = 13
                        },
                        new Forum()
                        {
                            Name= "LGBTQ+",
                            TopicCount = 0,
                            OrderNr = 1,
                            CategoryId = 14
                        },
                        new Forum()
                        {
                            Name= "Food",
                            TopicCount = 0,
                            OrderNr = 2,
                            CategoryId = 14
                        },
                        new Forum()
                        {
                            Name= "Vintage Fashion",
                            TopicCount = 0,
                            OrderNr = 3,
                            CategoryId = 14
                        },
                        new Forum()
                        {
                            Name= "Current Trends",
                            TopicCount = 0,
                            OrderNr = 4,
                            CategoryId = 14
                        },
                        new Forum()
                        {
                            Name= "Music",
                            TopicCount = 0,
                            OrderNr = 1,
                            CategoryId = 15
                        },
                        new Forum()
                        {
                            Name= "Cinema & TV",
                            TopicCount = 0,
                            OrderNr = 2,
                            CategoryId = 15
                        },
                        new Forum()
                        {
                            Name= "Art & Hobby",
                            TopicCount = 0,
                            OrderNr = 3,
                            CategoryId = 15
                        },
                        new Forum()
                        {
                            Name= "Archive",
                            TopicCount = 0,
                            OrderNr = 1,
                            CategoryId = 16
                        },
                        new Forum()
                        {
                            Name= "Recycle Bin",
                            TopicCount = 0,
                            OrderNr = 2,
                            CategoryId = 16
                        }
                    });
                    context.SaveChanges();
                }
                #endregion

            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                #region PopulateUserRolesTable
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Administrator))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Administrator));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.Moderator))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Moderator));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.Banned))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Banned));
                }
                #endregion

                #region PopulateUsersTable
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                
                string adminUserEmail = "admin@aweforum.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "BigBoss",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "uSeRpa$5");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Administrator);
                }

                string modUserEmail = "mod@aweforum.com";
                var modUser = await userManager.FindByEmailAsync(modUserEmail);
                if (modUser == null)
                {
                    var newModUser = new AppUser()
                    {
                        UserName = "Constable",
                        Email = modUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newModUser, "uSeRpa$5");
                    await userManager.AddToRoleAsync(newModUser, UserRoles.Moderator);
                }

                string appUserEmail = "user@aweforum.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "RegularGal",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "uSeRpa$5");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

                string bannedUserEmail = "banned@aweforum.com";
                var bannedUser = await userManager.FindByEmailAsync(bannedUserEmail);
                if (bannedUser == null)
                {
                    var newBannedUser = new AppUser()
                    {
                        UserName = "Insurgent",
                        Email = bannedUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newBannedUser, "uSeRpa$5");
                    await userManager.AddToRoleAsync(newBannedUser, UserRoles.Banned);
                }
                #endregion
            }
        }
    }
}
