using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YOMA.Models.Tables;

namespace YOMA.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public Context() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.PARENT_1)
                .WithMany()  // Ou .WithOne() si one-to-one, ajustez selon votre modèle
            .HasForeignKey(s => s.PARENT_1_ID);  // Remplacez par la FK réelle

            modelBuilder.Entity<Student>()
                .HasOne(s => s.PARENT_2)
                .WithMany()  // Ou .WithOne() si one-to-one, ajustez selon votre modèle
            .HasForeignKey(s => s.PARENT_2_ID);  // Remplacez par la FK réelle
                            
            modelBuilder.Entity<Student>()
                .HasIndex(u => u.MATRICULE)
            .IsUnique(); // Indiquer que le champs Email est unique dans la table Student

            modelBuilder.Entity<User>()
                .HasIndex(u => u.MATRICULE)
            .IsUnique(); // Indiquer que le champs Email est unique dans la table User

            modelBuilder.Entity<UserEmail>()
                .HasIndex(u => u.EMAIL)
            .IsUnique(); // Indiquer que le champs Email est unique dans la table UserEmail

            modelBuilder.Entity<BookRental>()
                .ToTable(t => t.HasCheckConstraint(
                "CK_Order_DateRange",
                "\"RETURN_DATE\" > \"RENTAL_DATE\""
            ));

            modelBuilder.Entity<Book>()
                .ToTable(t => t.HasCheckConstraint(
                "CK_QteRange",
                "\"QTE_TOTAL\" > 0"
            ));

            base.OnModelCreating(modelBuilder);


            // Applique la conversion UTC à toutes les propriétés DateTime
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.Kind == DateTimeKind.Utc ? v : DateTime.SpecifyKind(v, DateTimeKind.Utc),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(dateTimeConverter);
                    }
                }
            }
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<BusFess> BusFesses { get; set; }
        public DbSet<BusPayment> BusPayments { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<GasStation> GasStations { get; set; }
        public DbSet<HighSchoolOption> HighSchoolOptions { get; set; }
        public DbSet<HightSchoolAssignment> HightSchoolAssignments { get; set; }
        public DbSet<KindergartenSchoolAssignment> KindergartenSchoolAssignments { get; set; }
        public DbSet<MiddleSchoolAssignment> MiddleSchoolAssignments { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<NoteHightSchool> NoteHightSchools { get; set; }
        public DbSet<NoteMiddleSchool> NoteMiddleSchools { get; set; }
        public DbSet<NoteMonth> NoteMonths { get; set; }
        public DbSet<NotePrimary> NotePrimaries { get; set; }
        public DbSet<OtherPrime> OtherPrimes { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<ParentType> ParentTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PrimarySchoolAssignment> PrimarySchoolAssignments { get; set; }
        public DbSet<ProfessionalQualification> ProfessionalQualifications { get; set; }
        public DbSet<SalaryAdvance> SalaryAdvances { get; set; }
        public DbSet<SalaryStatus> SalaryStatuses { get; set; }
        public DbSet<SchoolBus> SchoolBuses { get; set; }
        public DbSet<SchoolEducation> SchoolEducations { get; set; }
        public DbSet<SchoolFess> SchoolFesses { get; set; }
        public DbSet<SchoolPayment> SchoolPayments { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentRegistration> StudentRegistrations { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<SubdivisionByYear> SubdivisionByYears { get; set; }
        public DbSet<SumSalaryAdvance> SumSalaryAdvances { get; set; }
        public DbSet<TransportLoadType> TransportLoadTypes { get; set; }
        public DbSet<TypeSalaryAdvance> TypeSalaryAdvances { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPosition> UserPositions { get; set; }
        public DbSet<UserPrime> UserPrimes { get; set; }
        public DbSet<TypePrime> TypePrimes { get; set; }
        public DbSet<MonthOfSalary> MonthOfSalaries { get; set; }
        public DbSet<MonthlySalaryAssignment> MonthlySalaryAssignments { get; set; }
        public DbSet<PayrollValidation> PayrollValidations { get; set; }
        public DbSet<ExamClass> ExamClasses { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserEmail> UserEmails { get; set; }
        public DbSet<ForgotUserPassword> ForgotUserPasswords { get; set; }
        public DbSet<StudentSchoolStatusOfCare> StudentSchoolStatusOfCares { get; set; }
        public DbSet<StudentBusStatusOfCare> StudentBusStatusOfCares { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<BookRental> BookRentals { get; set; }
        public DbSet<BusRegistration> BusRegistrations { get; set; }
        public DbSet<StudentFolder> StudentFolders { get; set; }
    }
}