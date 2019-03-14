using System;
using System.Linq;
using System.Linq.Expressions;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.CaseNotes;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class CaseNoteRepository : BaseRepository<CaseNote, ObjectId>, ILogRepository<CaseNote, ObjectId>
    {
        public CaseNoteRepository(IRepository<CaseNote> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }

       
    }
}
