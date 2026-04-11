using Microsoft.EntityFrameworkCore;
using YOMA.Models.Tables;

namespace YOMA.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public Context() { }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<BirthPlace> BirthPlaces { get; set; }
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
        public DbSet<StudentParent> StudentParents { get; set; }
        public DbSet<StudentRegistration> StudentRegistrations { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<SubdivisionByYear> SubdivisionByYears { get; set; }
        public DbSet<SumSalaryAdvance> SumSalaryAdvances { get; set; }
        public DbSet<TransportLoadType> TransportLoadTypes { get; set; }
        public DbSet<TypeSalaryAdvance> TypeSalaryAdvances { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPosition> UserPositions { get; set; }
        public DbSet<UserPrime> UserPrimes { get; set; }
    }
}