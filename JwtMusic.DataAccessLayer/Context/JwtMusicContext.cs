using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DataAccessLayer.Context
{
	public class JwtMusicContext : IdentityDbContext<AppUser, AppRole, int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-3OD251U\\SQLEXPRESS; initial catalog=JwtMusicDb; integrated security=true; trustServerCertificate=true");
		}

		public DbSet<Banner> Banners { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<CountDown> CountDowns { get; set; }
		public DbSet<DjInfo> DjInfos { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Song> Songs { get; set; }
	}
}
