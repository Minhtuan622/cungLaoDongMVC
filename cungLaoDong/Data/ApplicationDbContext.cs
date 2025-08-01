﻿using cungLaoDong.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cungLaoDong.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<EmployeeModel> EmployeeModels { get; set; } = null!;
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
}