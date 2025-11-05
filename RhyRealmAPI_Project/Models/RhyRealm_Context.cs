using Microsoft.EntityFrameworkCore;
using RhyRealmAPI_Project.Models;

namespace RhyRealmAPI_Project.Models
{
    public class RhyRealm_Context : DbContext
    {
        public RhyRealm_Context() 
        { 
        
        }

        public RhyRealm_Context(DbContextOptions<RhyRealm_Context> options) : base(options) { }


        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<ContentAlbum> ContentAlbums { get; set; }
        public virtual DbSet<ContentOrder> ContentOrders { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<PhotoForFeedback> PhotoForFeedbacks { get; set; }
        public virtual DbSet<Rating> Rating { get; set; } 
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StatusOrder> StatusOrders { get; set; }
        public virtual DbSet<TypePerformer> TypePerformers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.HasKey(e => e.IdAlbum);

                entity.Property(e => e.IdAlbum)
                .HasColumnName("ID_Album")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.NameAlbum)
                .HasColumnName("Name_Album")
                .HasMaxLength(100)
                .IsRequired(false);


                entity.Property(e => e.DescriptionAlbum)
                .HasColumnName("Description_Album")
                .HasMaxLength(6)
                .IsRequired(false);


                entity.Property(e => e.PriceAlbum)
                .HasColumnName("Price_Album")
                .HasColumnType("decimal(7,2)")
                .IsRequired(true);


                entity.Property(e => e.Rating)
                .HasColumnName("Rating")
                .HasColumnType("decimal(7,2)")
                .IsRequired(true);

                entity.Property(e => e.PhotoAlbum)
                .HasColumnName("Photo_Album")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasMaxLength(100)
                .IsRequired(false);


                entity.Property(e => e.ArticleNumber)
                .HasColumnName("Article_Number")
                .HasMaxLength(6)
                .IsRequired(false);


                entity.Property(e => e.PerformerId)
                .HasColumnName("Performer_ID")
                .IsRequired(true);

                entity.HasOne(e => e.Performer)
                .WithMany(t => t.Albums)
                .HasForeignKey(e => e.PerformerId)
                .HasConstraintName("FK_Performer")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasCheckConstraint("CH_Price_Album", "Price_Album > 0");
                entity.HasCheckConstraint("CH_Article_Number", "Article_Number like '[0-9]{10}'");
                entity.HasCheckConstraint("CH_Rating", "Rating >= 1 and Rating <= 5");

            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("Content");

                entity.HasKey(e => e.IdContent);

                entity.Property(e => e.IdContent)
                .HasColumnName("ID_Content")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.NameContent)
                .HasColumnName("Name_Content")
                .HasMaxLength(255)
                .IsRequired(true);

            });

            modelBuilder.Entity<ContentAlbum>(entity =>
            {
                entity.ToTable("Content_Album");

                entity.HasKey(e => e.IdContentAlbum);

                entity.Property(e => e.IdContentAlbum)
                .HasColumnName("ID_Content_Album")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.AlbumId)
                .HasColumnName("Album_ID")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.ContentId)
                .HasColumnName("Content_ID")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.HasOne(e => e.Album)
                .WithMany(t => t.ContentAlbums)
                .HasForeignKey(e => e.AlbumId)
                .HasConstraintName("FK_Album_Content")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Content)
               .WithMany(t => t.ContentAlbums)
               .HasForeignKey(e => e.ContentId)
               .HasConstraintName("FK_Content")
               .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<ContentOrder>(entity =>
            {
                entity.ToTable("Content_Order");

                entity.HasKey(e => e.IdContentOrder);

                entity.Property(e => e.IdContentOrder)
                .HasColumnName("ID_Content_Order")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.AlbumId)
                .HasColumnName("Album_ID")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.OrderId)
                .HasColumnName("Order_ID")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.HasOne(e => e.Album)
                .WithMany(t => t.ContentOrders)
                .HasForeignKey(e => e.AlbumId)
                .HasConstraintName("FK_Album")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Order)
               .WithMany(t => t.ContentOrders)
               .HasForeignKey(e => e.OrderId)
               .HasConstraintName("FK_Order")
               .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Delivery>(entity =>
            {
            entity.ToTable("Delivery");

            entity.HasKey(e => e.IdDelivery);

            entity.Property(e => e.IdDelivery)
            .HasColumnName("ID_Delivery")
            .ValueGeneratedOnAdd()
            .IsRequired(true);

            entity.Property(e => e.DeliveryCity)
            .HasColumnName("Delivery_City")
            .HasMaxLength(100)
            .IsRequired(false);


            entity.Property(e => e.PostalCode)
            .HasColumnName("Postal_Code")
            .HasMaxLength(6)
            .IsRequired(false);


            entity.Property(e => e.DeliveryAddress)
            .HasColumnName("Delivery_Address")
            .HasMaxLength(255)
            .IsRequired(false);


            entity.Property(e => e.DeliveryPrice)
            .HasColumnName("Delivery_Price")
            .HasColumnType("decimal(7,2)")
            .IsRequired(true);


            entity.Property(e => e.DeliveryMethodId)
            .HasColumnName("Delivery_Method_ID")
            .IsRequired(true);

            entity.HasOne(e => e.DeliveryMethod)
            .WithMany(t => t.Deliveries)
            .HasForeignKey(e => e.DeliveryMethodId)
            .HasConstraintName("FK_Delivery_Method_ID")
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasCheckConstraint("CH_Postal_Code", "Postal_Code like '[0-9]{6}'");
            entity.HasCheckConstraint("CH_Mark", "Delivery_Price >= 0");


            });

            modelBuilder.Entity<DeliveryMethod>(entity =>
            {
                entity.ToTable("Delivery_Method");

                entity.HasKey(e => e.IdDeliveryMethod);

                entity.Property(e => e.IdDeliveryMethod)
                .HasColumnName("ID_Delivery_Method")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.NameDeliveryMethod)
                .HasColumnName("Name_Delivery_Method")
                .HasMaxLength(50)
                .IsRequired(true);

                entity.HasIndex(e => e.NameDeliveryMethod, "CH_Delivery_Method")
                .IsUnique();



            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.HasKey(e => e.IdFeedback);

                entity.Property(e => e.IdFeedback)
                .HasColumnName("ID_Feedback")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.Mark)
                .HasColumnName("Mark")
                .IsRequired(true);


                entity.Property(e => e.Text)
                .HasColumnName("Text_Feedback")
                .HasMaxLength(255)
                .IsRequired(true);


                entity.Property(e => e.DateCreated)
                .HasColumnName("Date_Created")
                .HasColumnType("date")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(true);

                entity.HasCheckConstraint("CH_Mark", "Mark >=1 and Mark <=5");

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.IdOrder)
                .HasColumnName("ID_Order")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.NumberOrder)
                .HasColumnName("Number_Order")
                .HasMaxLength(10)
                .IsRequired(true);


                entity.Property(e => e.DateCreatedOrder)
                .HasColumnName("Date_Created_Order")
                .HasColumnType("date")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(true);

                entity.Property(e => e.PriceOrder)
                .HasColumnName("Price_Order")
                .HasColumnType("decimal(7,2)")
                .IsRequired(true);


                entity.Property(e => e.UserId)
                .HasColumnName("User_ID")
                .IsRequired(true);


                entity.Property(e => e.DeliveryId)
                .HasColumnName("Delivery_ID")
                .IsRequired(true);

                entity.Property(e => e.StatusOrderId)
                .HasColumnName("Status_Order_ID")
                .IsRequired(true);

                entity.HasOne(e => e.User)
                .WithMany(t => t.Orders)
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("FK_User")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.StatusOrder)
                .WithMany(t => t.Orders)
                .HasForeignKey(e => e.StatusOrderId)
                .HasConstraintName("FK_Status_Order")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Delivery)
                .WithMany(t => t.Orders)
                .HasForeignKey(e => e.DeliveryId)
                .HasConstraintName("FK_Delivery")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasCheckConstraint("CH_Price_Order", "Price_Order > 0");
                entity.HasCheckConstraint("CH_Number_Order", "Number_Order like '[0-9]{10}'");



            });

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.ToTable("Performer");

                entity.HasKey(e => e.IdPerformer);

                entity.Property(e => e.IdPerformer)
                .HasColumnName("ID_Performer")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.NamePerformer)
                .HasColumnName("Name_Performer")
                .HasMaxLength(100)
                .IsRequired(false);


                entity.Property(e => e.PhotoPerformer)
                .HasColumnName("Photo_Performer")
                .HasMaxLength(6)
                .IsRequired(false);


                entity.Property(e => e.isDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnType("bit")
                .IsRequired(false);


                entity.Property(e => e.TypePerformerId)
                .HasColumnName("Type_Performer_ID")
                .IsRequired(true);

                entity.HasOne(e => e.TypePerformer)
                .WithMany(t => t.Performers)
                .HasForeignKey(e => e.TypePerformerId)
                .HasConstraintName("FK_Type_Performer")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => e.NamePerformer, "UQ_Name_Performer")
                .IsUnique();


            });

            modelBuilder.Entity<PhotoForFeedback>(entity =>
            {
                entity.ToTable("Photo_For_Feedback");

                entity.HasKey(e => e.IdPhotoForFeedback);

                entity.Property(e => e.IdPhotoForFeedback)
                .HasColumnName("ID_Photo_For_Feedback")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.Photo)
                .HasColumnName("Photo")
                .HasMaxLength(255)
                .IsRequired(true);

            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.HasKey(e => e.IdRating);

                entity.Property(e => e.IdRating)
                .HasColumnName("ID_Rating")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.AlbumId)
                .HasColumnName("Feedback_ID")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.PhotoForFeedbackId)
                .HasColumnName("Photo_For_Feedback_ID")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.AlbumId)
                .HasColumnName("Album_ID")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.UserId)
                .HasColumnName("User_ID")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.HasOne(e => e.Feedback)
                .WithMany(t => t.Rating)
                .HasForeignKey(e => e.FeedbackId)
                .HasConstraintName("FK_Feedback")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.PhotoForFeedback)
               .WithMany(t => t.Rating)
               .HasForeignKey(e => e.PhotoForFeedbackId)
               .HasConstraintName("FK_Photo_For_Feedback")
               .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Album)
                .WithMany(t => t.Ratings)
                .HasForeignKey(e => e.AlbumId)
                .HasConstraintName("FK_Album_Rating")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.User)
               .WithMany(t => t.Rating)
               .HasForeignKey(e => e.UserId)
               .HasConstraintName("FK_User_Rating")
               .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.HasKey(e => e.IdRole);

                entity.Property(e => e.IdRole)
                .HasColumnName("ID_Role")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.NameRole)
                .HasColumnName("Name_Role")
                .HasMaxLength(50)
                .IsRequired(true);

                entity.HasIndex(e => e.NameRole, "UQ_Name_Role")
                .IsUnique();

            });

            modelBuilder.Entity<StatusOrder>(entity =>
            {
                entity.ToTable("Status_Order");

                entity.HasKey(e => e.IdStatusOrder);

                entity.Property(e => e.IdStatusOrder)
                .HasColumnName("ID_Status_Order")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.NameStatusOrder)
                .HasColumnName("Name_Status_Order")
                .HasMaxLength(50)
                .IsRequired(true);

                entity.HasIndex(e => e.NameStatusOrder, "CH_Status_Order")
                .IsUnique();

            });

            modelBuilder.Entity<TypePerformer>(entity =>
            {
                entity.ToTable("Type_Performer");

                entity.HasKey(e => e.IdTypePerformer);

                entity.Property(e => e.IdTypePerformer)
                .HasColumnName("ID_Type_Performer")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.NameTypePerformer)
                .HasColumnName("Name_Type_Performer")
                .HasMaxLength(50)
                .IsRequired(true);

                entity.HasIndex(e => e.NameTypePerformer, "CH_Type_Performer")
                .IsUnique();

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser)
                .HasColumnName("ID_User")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.SurnameUser)
                .HasColumnName("Surname_User")
                .HasMaxLength(60)
                .IsRequired(false);

                entity.Property(e => e.NameUser)
                .HasColumnName("Name_User")
                .HasMaxLength(60)
                .IsRequired(false);

                entity.Property(e => e.PatronymicNameUser)
                .HasColumnName("Patronymic_Name_User")
                .HasMaxLength(60)
                .IsRequired(false);

                entity.Property(e => e.DateBirthUser)
                .HasColumnName("Date_Birth_User")
                .HasColumnType("date")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(false);


                entity.Property(e => e.EmailUser)
                .HasColumnName("Email_User")
                .HasMaxLength(100)
                .IsRequired(true);

                entity.Property(e => e.PasswordUser)
                .HasColumnName("Password_User")
                .HasMaxLength(200)
                .IsRequired(true);


                entity.Property(e => e.SaltUser)
                .HasColumnName("Salt_User")
                .HasMaxLength(200)
                .IsRequired(true);

                entity.Property(e => e.BonusUser)
                .HasColumnName("Bonus_User")
                .IsRequired(false);


                entity.Property(e => e.RoleId)
                .HasColumnName("Role_ID")
                .IsRequired(true);


                entity.Property(e => e.PhotoUser)
                .HasColumnName("Photo_User")
                .HasMaxLength(256)
                .IsRequired(false);


                entity.HasOne(e => e.Role)
                .WithMany(t => t.User)
                .HasForeignKey(e => e.RoleId)
                .HasConstraintName("FK_Role")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasCheckConstraint("CH_Email_User", "Email_User like '%_@_%.__%'");
                entity.HasCheckConstraint("CH_Bonus_User", "[Bonus_User] >= 0");
                entity.HasCheckConstraint("CH_Password", "len([Password_User]) > 8");



            });
            
        }
        public DbSet<RhyRealmAPI_Project.Models.DeliveryMethod> DeliveryMethod { get; set; } = default!;

    }
}
