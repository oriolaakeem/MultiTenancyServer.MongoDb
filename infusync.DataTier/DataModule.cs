using Autofac;
using infusync.DataTier.Repositories;
using infusync.DataTier.Repositories.GeneralServices;
using infusync.DataTier.Repositories.HMO;
using infusync.DataTier.Repositories.OndgoRepos;
using infusync.DataTier.Repositories.Repos;

namespace infusync.DataTier
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            /*
                HMS Repositories
            */

            //builder.RegisterType(typeof(ODDbContext))
            //  .As(typeof(IODDbContext))
            //  .InstancePerLifetimeScope();

            //builder.RegisterGeneric(typeof(BaseRepository<>))
            //    .As(typeof(IRepository<>))
            //    .InstancePerLifetimeScope();

            builder.RegisterType<LabelRepository>();
            builder.RegisterType<ModulesRepository>();
            builder.RegisterType<UIComponentRepository>();

            builder.RegisterType<AppointmentRepository>();
            builder.RegisterType<ApprovalHistoryRepository>();
            builder.RegisterType<AssociationEntityRepository>();
            builder.RegisterType<AssociationTypeRepository>();
            builder.RegisterType<BiographicalInfoRepository>();
            builder.RegisterType<BusinessUnitRepository>();
            builder.RegisterType<CaseNoteRepository>();
            builder.RegisterType<ContactInfoRepository>();
            builder.RegisterType<DepartmentRepository>();
            builder.RegisterType<DependantInfoRepository>();
            builder.RegisterType<DivisionRepository>();
            builder.RegisterType<DynamicGroupRepository>();
            builder.RegisterType<FormControlOptionRepository>();
            builder.RegisterType<HRApprovalHistoryRepository>();
            builder.RegisterType<HRApprovalPathRepository>();
            builder.RegisterType<HRWorkflowGroupRepository>();
            builder.RegisterType<HRWorkflowInstanceRepository>();
            builder.RegisterType<HRWorkflowSetupRepository>();
            builder.RegisterType<HRWorkflowStateApproversUsersRepository>();
            builder.RegisterType<JobDesRepository>();
            builder.RegisterType<JobInfoRepository>();
            builder.RegisterType<JobRepository>();
            builder.RegisterType<JunctionObjectRepository>();
            builder.RegisterType<LaboratoryRepository>();
            builder.RegisterType<MenuRepository>();
            builder.RegisterType<MessageTemplateRepository>();
            builder.RegisterType<NotificationRepository>();
            builder.RegisterType<OrganisationalInfoRepository>();
            builder.RegisterType<PatientQueueRepository>();
            builder.RegisterType<PatientRepository>();
            builder.RegisterType<PersonalizationRepository>();
            builder.RegisterType<PersonInfoRepository>();
            builder.RegisterType<PositionRepository>();
            builder.RegisterType<ProfileInfoRepository>();
            builder.RegisterType<RoleRepository>();
            builder.RegisterType<SectionRepository>();
            builder.RegisterType<SecurableRepository>();
            builder.RegisterType<SubBusinessUnitRepository>();
            builder.RegisterType<TileRepository>();
            builder.RegisterType<TimeInfoRepository>();
            builder.RegisterType<TodoRepository>();
            builder.RegisterType<TriggerRepository>();
            builder.RegisterType<VariableRepository>();
            builder.RegisterType<WFPermittedTriggerRepository>();
            builder.RegisterType<WorkflowNextStateRepository>();
            builder.RegisterType<WFStateRepository>();
            builder.RegisterType<WorkflowStateRepository>();
            builder.RegisterType<EmployeeRepository>();



            builder.RegisterType<CompanyRepository>();
            builder.RegisterType<IndividualRepository>();
            builder.RegisterType<InvoiceLineItemRepository>();
            builder.RegisterType<InvoiceRepository>();
            builder.RegisterType<LoanRepository>();
            builder.RegisterType<StaffAccountRepository>();
            builder.RegisterType<StaffLoanAccountRepository>();
            builder.RegisterType<TenureRepository>();
            builder.RegisterType<UserRepository>();
            builder.RegisterType<UserProfileRepository>();
            builder.RegisterType<LoanRepaymentRepository>();
            builder.RegisterType<LoanSettingRepository>();
            builder.RegisterType<PermissionRepository>();

            builder.RegisterType<WorkflowRepository>();
            //builder.RegisterType<PersonalizationRepository>();
            builder.RegisterType<ApplicationRoleRepository>();

            /*
                HMO Repositories
            */

            builder.RegisterType<EnrolleeRepository>();
            builder.RegisterType<HospitalRepository>();
            builder.RegisterType<AttendanceRepository>();
            builder.RegisterType<AuthorizationRepository>();
            builder.RegisterType<BillRepository>();
            builder.RegisterType<CapitationRepository>();
            builder.RegisterType<ChangeRepository>();
            builder.RegisterType<CreditNoteRepository>();
            builder.RegisterType<DebitNoteRepository>();
            builder.RegisterType<HospitalRepository>();
            builder.RegisterType<PlanBenefitsRepository>();
            builder.RegisterType<PlanGroupsRepository>();
            builder.RegisterType<PlanRepository>();
            builder.RegisterType<ServiceGroupRepository>();
            builder.RegisterType<ServiceCategoryRepository>();
            builder.RegisterType<TarrifRepository>();
            builder.RegisterType<SubscriptionRepository>();
        }
    }
}
