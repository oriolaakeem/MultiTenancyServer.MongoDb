using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HRWorkflowGroupRepository : BaseRepository<HRWorkflowGroup, ObjectId>, ILogRepository<HRWorkflowGroup, ObjectId>
    {
        public HRWorkflowGroupRepository(IRepository<HRWorkflowGroup> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }

        public IEnumerable<HRWorkflowStateApprover> GetStateApproverView()
        {
            string sql = string.Format(" Select a.*, b.Name WorkflowStateName, c.Name EmployeeName, " +
                " b.StartState, b.EndState " +
                "from HRWorkflowStateApprovers a left outer join " +
                "(Select a.Id, b.Name, a.StartState, a.EndState    " +
                "from WorkflowStates a join WFStates b  on a.WFStateId = b.id) b on a.WorkFlowStateId = b.Id " +
                "left outer join Employee c on a.EmployeeId = c.Id ");


            return ExecSQL<HRWorkflowStateApprover>(sql);
        }

        public IEnumerable<HRWorkflowGroupView> GetWorkflowGroupView(ObjectId WorkflowGroupId)
        {

            string Id = WorkflowGroupId.ToString();
            string sql = string.Format("Select a.*, b.Name WorkflowName, null WorkflowStateApprovers, " +
                "null WorkflowStateApproversView, null Assignees  " +
                "from HRWorkflowGroups a left outer join Workflows b "
                + " on a.WorkflowId = b.Id Where a.Id = '{0}'", Id);

            return ExecSQL<HRWorkflowGroupView>(sql);
        }

        public IEnumerable<HRWorkflowGroupView> GetWorkflowGroupView()
        {

            string sql = string.Format("Select a.*, b.Name WorkflowName, null WorkflowStateApprovers, " +
                "null WorkflowStateApproversView,  null Assignees  " +
                "from HRWorkflowGroups a left outer join Workflows b "
                + " on a.WorkflowId = b.Id ");

            return ExecSQL<HRWorkflowGroupView>(sql);
        }

        public IEnumerable<HRWorkflowStateApprover> GetStateApproverView(ObjectId WorkflowGroupId)
        {
            string Id = WorkflowGroupId.ToString();
            string sql = string.Format(" Select a.*, b.Name WorkflowStateName, c.Name EmployeeName, " +
                " b.StartState, b.EndState " +
                "from HRWorkflowStateApprovers a left outer join " +
                "(Select a.Id, b.Name, a.StartState, a.EndState    " +
                "from WorkflowStates a join WFStates b  on a.WFStateId = b.id) b on a.WorkFlowStateId = b.Id " +
                "left outer join Employee c on a.EmployeeId = c.Id " +
                " Where a.HRWorkflowGroupId = '{0}'", Id);

            return ExecSQL<HRWorkflowStateApprover>(sql);
        }

        public IEnumerable<HRWorkflowGroupEmployee> GetAssignees()
        {
            string sql = string.Format("Select Id, AssigNee, AssigneeName, HRWorkflowGroupId, CreateDate, UpdateDate, " +
                "EffectiveDate, Status, UserSign, AssignBy  from HRWorkflowGroupEmployees");

            return ExecSQL<HRWorkflowGroupEmployee>(sql);
        }

        public IEnumerable<HRWorkflowGroupEmployee> GetAssignees(ObjectId WorkflowGroupId)
        {
            string Id = WorkflowGroupId.ToString();
            string sql = string.Format("Select * from HRWorkflowGroupEmployees" +
                " Where HRWorkflowGroupId = '{0}'", Id);

            return ExecSQL<HRWorkflowGroupEmployee>(sql);
        }

        public override Task Add(HRWorkflowGroup entity)
        {
            this.UpdateEntityForAdd(entity.WorkflowStateApprovers);
            this.UpdateEntityForAdd(entity.Assignees);
            return base.Add(entity);
        }

        public override Task Update(HRWorkflowGroup entity)
        {
            this.UpdateEntityForUpdate(entity.WorkflowStateApprovers);
            this.UpdateEntityForUpdate(entity.Assignees);
           return base.Update(entity);
        }
    }
}
