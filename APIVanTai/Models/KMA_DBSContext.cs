using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIBlog.Models
{
    public partial class KMA_DBSContext : DbContext
    {
        public KMA_DBSContext()
        {
        }

        public KMA_DBSContext(DbContextOptions<KMA_DBSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessAdminSite> AccessAdminSites { get; set; }
        public virtual DbSet<AccessAdminSiteRole> AccessAdminSiteRoles { get; set; }
        public virtual DbSet<AccessLog> AccessLogs { get; set; }
        public virtual DbSet<AccessWebModule> AccessWebModules { get; set; }
        public virtual DbSet<AccessWebModuleRole> AccessWebModuleRoles { get; set; }
        public virtual DbSet<AdminSite> AdminSites { get; set; }
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<AdvertisementPosition> AdvertisementPositions { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ContentImage> ContentImages { get; set; }
        public virtual DbSet<ContentRelated> ContentRelateds { get; set; }
        public virtual DbSet<ContentType> ContentTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<ModuleNavigation> ModuleNavigations { get; set; }
        public virtual DbSet<Navigation> Navigations { get; set; }
        public virtual DbSet<ProgressOfTopic> ProgressOfTopics { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<RegisterTopic> RegisterTopics { get; set; }
        public virtual DbSet<Speciality> Specialitys { get; set; }
        public virtual DbSet<SubscribeNotice> SubscribeNotices { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<UploadFile> UploadFiles { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<WebCategory> WebCategories { get; set; }
        public virtual DbSet<WebConfig> WebConfigs { get; set; }
        public virtual DbSet<WebContact> WebContacts { get; set; }
        public virtual DbSet<WebContent> WebContents { get; set; }
        public virtual DbSet<WebContentCategory> WebContentCategories { get; set; }
        public virtual DbSet<WebContentUpload> WebContentUploads { get; set; }
        public virtual DbSet<WebModule> WebModules { get; set; }
        public virtual DbSet<WebRedirect> WebRedirects { get; set; }
        public virtual DbSet<WebSimpleContent> WebSimpleContents { get; set; }
        public virtual DbSet<WebSlide> WebSlides { get; set; }
        public virtual DbSet<WebpagesMembership> WebpagesMemberships { get; set; }
        public virtual DbSet<WebpagesOauthMembership> WebpagesOauthMemberships { get; set; }
        public virtual DbSet<WebpagesRole> WebpagesRoles { get; set; }
        public virtual DbSet<WebpagesUsersInRole> WebpagesUsersInRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=KMA_DBS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccessAdminSite>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AdminSiteId).HasColumnName("AdminSiteID");

                entity.HasOne(d => d.AdminSite)
                    .WithMany()
                    .HasForeignKey(d => d.AdminSiteId)
                    .HasConstraintName("FK_AccessPermissions_AdminSites");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AccessPermissions_UserProfile");
            });

            modelBuilder.Entity<AccessAdminSiteRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.AdminSiteId })
                    .HasName("PK_AccessAdminSitesRole");

                entity.ToTable("AccessAdminSiteRole");

                entity.Property(e => e.AdminSiteId).HasColumnName("AdminSiteID");
            });

            modelBuilder.Entity<AccessLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Action).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<AccessWebModule>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.WebModuleId).HasColumnName("WebModuleID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AccessWebModules_UserProfile");

                entity.HasOne(d => d.WebModule)
                    .WithMany()
                    .HasForeignKey(d => d.WebModuleId)
                    .HasConstraintName("FK_AccessWebModules_WebModules");
            });

            modelBuilder.Entity<AccessWebModuleRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.WebModuleId })
                    .HasName("PK_AccessWebModulesRole");

                entity.ToTable("AccessWebModuleRole");

                entity.Property(e => e.WebModuleId).HasColumnName("WebModuleID");
            });

            modelBuilder.Entity<AdminSite>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccessKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Img).HasMaxLength(255);

                entity.Property(e => e.ImgActive).HasMaxLength(255);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Url).HasMaxLength(255);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_AdminSites_AdminSites");
            });

            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdvertisementPositionId).HasColumnName("AdvertisementPositionID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Culture).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Link).HasMaxLength(255);

                entity.Property(e => e.Media).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Target)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Video).HasMaxLength(500);

                entity.HasOne(d => d.AdvertisementPosition)
                    .WithMany(p => p.Advertisements)
                    .HasForeignKey(d => d.AdvertisementPositionId)
                    .HasConstraintName("FK_Advertisements_AdvertisementPositions1");
            });

            modelBuilder.Entity<AdvertisementPosition>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Uid)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UID");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });


            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<ContentImage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.WebContentId).HasColumnName("WebContentID");

                entity.HasOne(d => d.WebContent)
                    .WithMany(p => p.ContentImages)
                    .HasForeignKey(d => d.WebContentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ContentImages_WebContents");
            });

            modelBuilder.Entity<ContentRelated>(entity =>
            {
                entity.HasKey(e => new { e.MainId, e.RelatedId });

                entity.Property(e => e.MainId).HasColumnName("MainID");

                entity.Property(e => e.RelatedId).HasColumnName("RelatedID");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Main)
                    .WithMany(p => p.ContentRelatedMains)
                    .HasForeignKey(d => d.MainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContentRelateds_WebContents");

                entity.HasOne(d => d.Related)
                    .WithMany(p => p.ContentRelatedRelateds)
                    .HasForeignKey(d => d.RelatedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContentRelateds_WebContents1");
            });

            modelBuilder.Entity<ContentType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Controller).HasMaxLength(255);

                entity.Property(e => e.Entity).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsoCode).HasMaxLength(10);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(191);

                entity.Property(e => e.ProvinceId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ProvinceID");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ModuleNavigation>(entity =>
            {
                entity.HasKey(e => new { e.WebModuleId, e.NavigationId });

                entity.Property(e => e.WebModuleId).HasColumnName("WebModuleID");

                entity.Property(e => e.NavigationId).HasColumnName("NavigationID");

                entity.HasOne(d => d.Navigation)
                    .WithMany(p => p.ModuleNavigations)
                    .HasForeignKey(d => d.NavigationId)
                    .HasConstraintName("FK_ModuleNavigations_Navigations");

                entity.HasOne(d => d.WebModule)
                    .WithMany(p => p.ModuleNavigations)
                    .HasForeignKey(d => d.WebModuleId)
                    .HasConstraintName("FK_ModuleNavigations_WebModules");
            });

            modelBuilder.Entity<Navigation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Key)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

           

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(191);
            });

           

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<SubscribeNotice>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

          
            modelBuilder.Entity<UploadFile>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Link).IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserProf__1788CC4CC234D91B");

                entity.ToTable("UserProfile");

                entity.Property(e => e.Avatar).HasMaxLength(255);

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.DateBorn).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.Mobile).HasMaxLength(255);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.SpecialityId).HasColumnName("SpecialityID");

                entity.Property(e => e.UserName).HasMaxLength(255);

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK_UserProfile_Specialitys");
            });

            modelBuilder.Entity<WebCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Body).HasColumnType("ntext");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ctype).HasColumnName("CType");

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.MetaDescription).HasMaxLength(500);

                entity.Property(e => e.MetaKeywords).HasMaxLength(500);

                entity.Property(e => e.MetaTitle).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_WebCategories_WebCategories");
            });

            modelBuilder.Entity<WebConfig>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WebContact>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Body).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.Mobile).HasMaxLength(255);

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.WebModuleId).HasColumnName("WebModuleID");
            });

            modelBuilder.Entity<WebContent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Body).HasColumnType("ntext");

                entity.Property(e => e.CountView).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Event).HasColumnType("datetime");

                entity.Property(e => e.Icon).HasMaxLength(255);

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.Link).HasMaxLength(255);

                entity.Property(e => e.LinkVideo).HasMaxLength(255);

                entity.Property(e => e.MetaDescription).HasMaxLength(500);

                entity.Property(e => e.MetaKeywords).HasMaxLength(500);

                entity.Property(e => e.MetaTitle).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.SeoTitle).HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Uid)
                    .HasMaxLength(255)
                    .HasColumnName("UID");

                entity.Property(e => e.WebModuleId).HasColumnName("WebModuleID");

                entity.HasOne(d => d.WebModule)
                    .WithMany(p => p.WebContents)
                    .HasForeignKey(d => d.WebModuleId)
                    .HasConstraintName("FK_WebContents_WebModules");
            });

            modelBuilder.Entity<WebContentCategory>(entity =>
            {
                entity.HasKey(e => new { e.WebCategoryId, e.WebContentId });

                entity.Property(e => e.WebCategoryId).HasColumnName("WebCategoryID");

                entity.Property(e => e.WebContentId).HasColumnName("WebContentID");

                entity.HasOne(d => d.WebCategory)
                    .WithMany(p => p.WebContentCategories)
                    .HasForeignKey(d => d.WebCategoryId)
                    .HasConstraintName("FK_WebContentCategories_WebCategories");

                entity.HasOne(d => d.WebContent)
                    .WithMany(p => p.WebContentCategories)
                    .HasForeignKey(d => d.WebContentId)
                    .HasConstraintName("FK_WebContentCategories_WebContents");
            });

            modelBuilder.Entity<WebContentUpload>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.FullPath).HasMaxLength(255);

                entity.Property(e => e.MetaTitle).HasMaxLength(255);

                entity.Property(e => e.MimeType).HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Uid)
                    .HasMaxLength(255)
                    .HasColumnName("UID");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.InverseFolder)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_WebContentUploads_WebContentUploads1");
            });

            modelBuilder.Entity<WebModule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActiveArticle).HasMaxLength(255);

                entity.Property(e => e.Body).HasColumnType("ntext");

                entity.Property(e => e.CodeColor).HasMaxLength(255);

                entity.Property(e => e.ContentTypeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ContentTypeID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Culture).HasMaxLength(50);

                entity.Property(e => e.Icon).HasMaxLength(255);

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.Img).HasMaxLength(255);

                entity.Property(e => e.ImgActive).HasMaxLength(255);

                entity.Property(e => e.IndexLayout).HasMaxLength(255);

                entity.Property(e => e.IndexView).HasMaxLength(255);

                entity.Property(e => e.MetaDescription).HasMaxLength(500);

                entity.Property(e => e.MetaKeywords).HasMaxLength(500);

                entity.Property(e => e.MetaTitle).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.PublishDetailLayout).HasMaxLength(255);

                entity.Property(e => e.PublishDetailView).HasMaxLength(255);

                entity.Property(e => e.PublishIndexLayout).HasMaxLength(255);

                entity.Property(e => e.PublishIndexView).HasMaxLength(255);

                entity.Property(e => e.SeoTitle).HasMaxLength(255);

                entity.Property(e => e.SubQuerys).HasMaxLength(255);

                entity.Property(e => e.Target).HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Uid)
                    .HasMaxLength(255)
                    .HasColumnName("UID");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("URL");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.WebModules)
                    .HasForeignKey(d => d.ContentTypeId)
                    .HasConstraintName("FK_WebModules_ContentTypes");
            });

            modelBuilder.Entity<WebRedirect>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("URL");

                entity.Property(e => e.WebModuleId).HasColumnName("WebModuleID");

                entity.HasOne(d => d.WebModule)
                    .WithMany(p => p.WebRedirects)
                    .HasForeignKey(d => d.WebModuleId)
                    .HasConstraintName("FK_WebRedirects_WebModules");
            });

            modelBuilder.Entity<WebSimpleContent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Body).HasColumnType("ntext");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Culture).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Link).HasMaxLength(255);

                entity.Property(e => e.MetaDescription).HasMaxLength(500);

                entity.Property(e => e.MetaKeywords).HasMaxLength(500);

                entity.Property(e => e.MetaTitle).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WebSlide>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Culture).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.Link).HasMaxLength(255);

                entity.Property(e => e.MetaDescription).HasMaxLength(500);

                entity.Property(e => e.MetaKeywords).HasMaxLength(500);

                entity.Property(e => e.MetaTitle).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Target)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WebpagesMembership>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__webpages__1788CC4C1FCF8010");

                entity.ToTable("webpages_Membership");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.ConfirmationToken).HasMaxLength(128);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.IsConfirmed).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastPasswordFailureDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordSalt).HasMaxLength(128);

                entity.Property(e => e.PasswordVerificationToken).HasMaxLength(128);

                entity.Property(e => e.PasswordVerificationTokenExpirationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<WebpagesOauthMembership>(entity =>
            {
                entity.HasKey(e => new { e.Provider, e.ProviderUserId })
                    .HasName("PK__webpages__F53FC0EDEBC41D2D");

                entity.ToTable("webpages_OAuthMembership");

                entity.Property(e => e.Provider).HasMaxLength(30);

                entity.Property(e => e.ProviderUserId).HasMaxLength(100);
            });

            modelBuilder.Entity<WebpagesRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__webpages__8AFACE1A7B71FC1C");

                entity.ToTable("webpages_Roles");

                entity.HasIndex(e => e.RoleName, "UQ__webpages__8A2B61603027F0EA")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Title).HasMaxLength(256);
            });

            modelBuilder.Entity<WebpagesUsersInRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("webpages_UsersInRoles");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_UserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
