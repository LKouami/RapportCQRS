//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace RapportCQRS.Data.EntityConfigurations
//{
//    public class EmployeeConfiguration : IEntityTypeConfiguration<Domain.Models.SEmployee>
//    {
//        public void Configure(EntityTypeBuilder<Domain.Models.SEmployee> builder)
//        {
//            builder.ToTable("employees");

//            builder.HasKey(b => b.Id);
//            builder.Property(b => b.Id).HasColumnName("employee_id").HasDefaultValueSql("newId()");

//            // builder.Property(b => b.Name).HasColumnName("employee_name").HasMaxLength(255)
//            //     .IsRequired();

//            // builder.Property(e => e.Age).HasColumnName("age").IsRequired();

//            // builder.Property(b => b.Address).HasColumnName("address").HasMaxLength(255).IsRequired();

//            // builder.Property(b => b.Email).HasColumnName("email").HasMaxLength(255).IsRequired();

//            // builder.Property(e => e.PhoneNumber).HasColumnName("phone_number").HasMaxLength(20).IsRequired();

//            // builder.Property(e => e.Created_At).HasColumnName("created_at").IsRequired();

//            // builder.Property(e => e.Updated_At).HasColumnName("updated_at").IsRequired();
//        }
//    }
//}