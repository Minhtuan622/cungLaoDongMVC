using cungLaoDong.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cungLaoDong.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<EmployeeFormModel> EmployeeModels { get; set; } = null!;
    public DbSet<MajorModel> MajorModels { get; set; } = null!;
    public DbSet<JobModel> JobModels { get; set; } = null!;
    public DbSet<BusinessIndustryModel> BusinessIndustryModels { get; set; } = null!;
    public DbSet<ProfessionalQualificationsModel> ProfessionalQualificationsModels { get; set; } = null!;
    public DbSet<EconomyStatusModel> EconomyStatusModels { get; set; } = null!;
    public DbSet<UnemployedReasonModel> UnemployedReasonModels { get; set; } = null!;
    public DbSet<JobPositionModel> JobPositionModels { get; set; } = null!;
    public DbSet<UnemployedStatusModel> UnemployedStatusModels { get; set; } = null!;
    public DbSet<UnemployedTimeModel> UnemployedTimeModels { get; set; } = null!;
    public DbSet<EducationLevelModel> EducationLevelModels { get; set; } = null!;
    public DbSet<GeneralEducationLevelModel> GeneralEducationLevelModels { get; set; } = null!;
    public DbSet<AddressModel> AddressModels { get; set; } = null!;
    public DbSet<PeopleModel> PeopleModels { get; set; } = null!;
    public DbSet<PriorityFormModel> PriorityFormModels { get; set; } = null!;
    public DbSet<GeneralEducationLevelsFormModel> GeneralEducationLevelsFormModels { get; set; } = null!;
    public DbSet<HasJobFormModel> HasJobFormModels { get; set; } = null!;
    public DbSet<UnemployedFormModel> UnemployedFormModels { get; set; } = null!;
    public DbSet<StudyingFormModel> StudyingFormModels { get; set; } = null!;
}