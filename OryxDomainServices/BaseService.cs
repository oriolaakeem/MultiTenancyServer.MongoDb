using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace OryxDomainServices
{


    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Abstract base class for Oryx services. </summary>
    ///
    /// <remarks>   Tayo, 20/03/2018. </remarks>
    ///
    /// <typeparam name="TEntity">  The entity type. </typeparam>
    /// <typeparam name="TId">      The entity ID type. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public abstract class BaseService<TEntity,TId> : BaseReadOnlyService<TEntity, TId> where TEntity : IEntityBase<TId>
    {
        private readonly ILogRepository<TEntity, TId> _repository;
        protected ILogEntityBase<ObjectId> _LogTable;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseBudgetServices{TEntity, TId}"/> class.
        /// </summary>
        ///
        /// <remarks>   Tayo, 20/03/2018. </remarks>
        ///
        /// <param name="repository">   The repository. </param>
        /// <param name="unitOfWork">   The unit of work. </param>
        ///
        /// ### <exception cref="System.ArgumentNullException"> Thrown if repository is null. </exception>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected BaseService(ILogRepository<TEntity, TId> repository, string updateFields = "", bool effectiveDateRequired = false) : base(repository)
        {
            _repository = repository;
            _updateFields = updateFields;
            _effectiveDateRequired = effectiveDateRequired;
        }

        private readonly string _updateFields;
        private readonly bool _effectiveDateRequired = false;
        //protected IEnumerable<Meta<ILookup>> _lookupRepos;

        public string EntityName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseBudgetServices{TEntity, TId}"/> class.
        /// </summary>
        ///
        /// <remarks>   Tayo, 20/03/2018. </remarks>
        ///
        /// <param name="repository">   The repository. </param>
        /// <param name="unitOfWork">   The unit of work. </param>
        ///
        /// ### <exception cref="System.ArgumentNullException"> Thrown if repository is null. </exception>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes the given the entity with the given ID </summary>
        ///
        /// <remarks>   Tayo, 20/03/2018. </remarks>
        ///
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        ///
        /// <param name="id">   The Identifier to remove. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual Task Remove(TId id)
        {
            if (_repository.Get(id) == null)
            {
                throw new KeyNotFoundException(string.Format("{0} with id {1} was not found", typeof(TEntity), id));
            }
            else
            {
               return _repository.Remove(id);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds the specified entity. </summary>
        ///
        /// <remarks>   Tayo, 20/03/2018. </remarks>
        ///
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        ///
        /// <param name="entity">   The entity. </param>
        ///
        /// ### <exception cref="System.ArgumentException"> Thrown if an entity with the same id already
        ///                                                 exists. </exception>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual Task Add(TEntity entity)
        {
            if (_repository.Get(entity.Id) == null)
            {
                throw new ArgumentException(string.Format("{0} with id {1} already exists", typeof(TEntity), entity.Id));
            }
            else
            {
                return _repository.Add(entity);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds the specified entity (not fully implemented) </summary>
        ///
        /// <remarks>   Tayo, 20/03/2018. </remarks>
        ///
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        ///
        /// <param name="entity">           The entity. </param>
        /// <param name="effectiveDate">    The effective date. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual Task Add(TEntity entity, DateTime effectiveDate)
        {
            if (_repository.Get(entity.Id) == null)
            {
                // entity.EffectiveDate = effectiveDate.Date;
               return _repository.Add(entity);
            }
            else
            {
                throw new ArgumentException(string.Format("{0} with id {1} already exists", typeof(TEntity), entity.Id));
            }
        }

        public virtual IEnumerable<TEntity> GetAllIncluding()
        {
            return _repository.GetAll();
        }

        public virtual IEnumerable<TEntity> AllIncluding()
        {
            return _repository.GetAll();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds the specified entity. This should be used by background processed with no 
        ///             user logged in.
        ///              </summary>
        ///
        /// <remarks>   Tayo, 20/03/2018. </remarks>
        ///
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        ///
        /// <param name="entity">   The entity. </param>
        /// <param name="userId">   Identifier for the user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual void Add(TEntity entity, string userId)
        {
            if (_repository.Get(entity.Id) == null)
            {
                entity.CreatedBy = userId;
                _repository.Add(entity);
            }
            else
            {
                throw new ArgumentException(string.Format("{0} with id {1} already exists", typeof(TEntity), entity.Id));
            }
        }


        protected virtual void Validate(TEntity entity)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds the multiple entities </summary>
        ///
        /// <remarks>   Tayo, 20/03/2018. </remarks>
        ///
        /// <param name="entities"> The entities to add. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public virtual Task Add(IEnumerable<TEntity> entities)
        //{
        //    foreach (var item in entities)
        //    {
        //       _repository.Add(item);
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds the multiple entities (Not full implemented)</summary>
        ///
        /// <remarks>   Tayo, 20/03/2018. </remarks>
        ///
        /// <param name="entities">         The entities to add. </param>
        /// <param name="effectiveDate">    The effective date. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public virtual Task Add(IEnumerable<TEntity> entities, DateTime effectiveDate)
        //{
        //    foreach (var item in entities)
        //    {
        //        Add(item, effectiveDate);
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the specified entity. </summary>
        ///
        /// <remarks>   Tayo, 20/03/2018. </remarks>
        ///
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        ///
        /// <param name="entity">   The entity. </param>
        ///
        /// ### <exception cref="System.Collections.Generic.KeyNotFoundException">  Thrown if entity with
        ///                                                                         the given id is not
        ///                                                                         found. </exception>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual Task Update(TEntity entity)
        {
            if (_repository.Get(entity.Id) != null)
            {
                return _repository.Update(entity.Id, entity);

            }
            else
            {
                throw new KeyNotFoundException(string.Format("{0} with id {1} was not found", typeof(TEntity), entity.Id));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the specified entity. To be used in background jobs with no logged in
        ///             user. </summary>
        ///
        /// <remarks>   Tayo, 20/03/2018. </remarks>
        ///
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        ///
        /// <param name="entity">   The entity. </param>
        /// <param name="userId">   Identifier for the user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual void Update(TEntity entity, string userId)
        {
            if (_repository.Get(entity.Id) != null)
            {
                entity.CreatedBy = userId;
                _repository.Update(entity.Id, entity);

            }
            else
            {
                throw new KeyNotFoundException(string.Format("{0} with id {1} was not found", typeof(TEntity), entity.Id));
            }
        }

        protected void UpdateEntityForUpdate(IEntityBase<ObjectId> entity)
        {
            entity.UpdateDate = System.DateTime.Now;

        }

        protected void UpdateTracking(IEntityBase<ObjectId> perm, EntityState state)
        {
            //dataContext.Entry(perm).State = state;

            if (state == EntityState.Added)
            {
                UpdateEntityForAdd(perm);
            }
            else
            {
                this.UpdateEntityForUpdate(perm);
            }
        }

        protected void UpdateEntityForAdd(IEntityBase<ObjectId> perm)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Commits all changes to the database </summary>
        ///
        /// <remarks>   Tayo, 20/03/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public virtual void SaveChanges()
        //{
        //    _unitOfWork.Commit();
        //}

        //  public virtual bool effectiveDateExists(TEntity entity, DateTime effectiveDate)
        //  {
        //      return _repository.Contains(entity.Id, effectiveDate);
        //  }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts string to a unique identifier. </summary>
        ///
        /// <remarks>   Tayo, 20/03/2018. </remarks>
        ///
        /// <param name="id">   The Identifier to remove. </param>
        ///
        /// <returns>   The given data converted to a unique identifier. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public ObjectId ConvertToObjectId(string id)
        //{


        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return ObjectId.NewObjectId();
        //    }
        //    else
        //    {
        //        if (ObjectId.TryParse(id, out ObjectId NewId))
        //        {
        //            return NewId;
        //        }
        //        else
        //        {
        //            return new ObjectId();
        //        }
        //    }


        //}

        public ObjectId ConvertToObjectId(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var NewId = ObjectId.Parse(id);
                return NewId;
            }
            return new ObjectId();
        }



        public virtual IEnumerable<TEntity> All()
        {
            return _repository.GetAll();
        }

        //public virtual IQueryable<TEntity> GetAll()
        //{
        //    return All();
        //}

        //public virtual TEntity Get(ObjectId id)
        //{
        //    return Get(id);
        //}

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.Find(filter);
        }

        public virtual TEntity Single(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.Single(expression);
        }

        public virtual Task Update(ObjectId id, TEntity body)
        {
            return _repository.Update(body);
        }


       
       
        //public override Task Add(TEntity entity)
        //{
        //    if (entity.Id == ObjectId.Empty)
        //    {
        //        entity.Id = ObjectId.GenerateNewId();
        //    }
        //    this.Validate(entity);
        //    base.Add(entity);
        //}
        //public async override Task AddAsync(TEntity entity)
        //{
        //    if (entity.Id == ObjectId.Empty)
        //    {
        //        entity.Id = ObjectId.GenerateNewId();
        //    }
        //    this.Validate(entity);
        //    await base.AddAsync(entity);
        //}

        //public override Task Add(IEnumerable<TEntity> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        if (entity.Id == ObjectId.Empty)
        //        {
        //          return  this.Add(entity);
        //        }
        //        else
        //        {
        //           return this.Update(entity);
        //        }
        //    }
        //}

        //public async override Task AddAsync(IEnumerable<TEntity> entities)
        //{
        //    IList<TEntity> forAdd = new List<TEntity>();
        //    foreach (var entity in entities)
        //    {
        //        if (entity.Id == ObjectId.Empty)
        //        {
        //            forAdd.Add(entity);
        //        }
        //        else
        //        {
        //            this.Update(entity);
        //        }
        //    }
        //    await base.AddAsync(forAdd);
        //}

        public virtual void Add(IEnumerable<TEntity> entities, string UserId)
        {
            foreach (var entity in entities)
            {
                if (entity.Id == null)
                {
                    this.Add(entity, UserId);
                }
            }
        }

        //public override void Add(TEntity entity, DateTime effectiveDate)
        //{
        //    if (entity.Id == ObjectId.Empty)
        //    {
        //        entity.Id = ObjectId.GenerateNewId();
        //        Validate(entity);
        //        base.Add(entity, effectiveDate);
        //    }
        //    else
        //    {

        //        if (!EffectiveDateExists(entity, effectiveDate))
        //        {
        //            Validate(entity);
        //            entity.Id = ObjectId.GenerateNewId();
        //            base.Add(entity, effectiveDate);
        //        }
        //        else
        //        {
        //            throw new KeyNotFoundException(string.Format("{0} with effective date {1} was not found", typeof(TEntity), effectiveDate.ToString()));

        //        }
        //    }
        //}

        //public async override Task AddAsync(TEntity entity, DateTime effectiveDate)
        //{
        //    if (entity.Id == ObjectId.Empty)
        //    {
        //        entity.Id = ObjectId.GenerateNewId();
        //        Validate(entity);
        //        await base.AddAsync(entity, effectiveDate);
        //    }
        //    else
        //    {

        //        if (!EffectiveDateExists(entity, effectiveDate))
        //        {
        //            Validate(entity);
        //            entity.Id = ObjectId.GenerateNewId();
        //            await base.AddAsync(entity, effectiveDate);
        //        }
        //        else
        //        {
        //            throw new KeyNotFoundException(string.Format("{0} with effective date {1} was not found", typeof(TEntity), effectiveDate.ToString()));

        //        }
        //    }
        //}

        //public override Task Update(TEntity entity)
        //{
        //    Validate(entity);
        //    if (!string.IsNullOrEmpty(_updateFields))
        //    {
        //        TEntity dbEntity = this.Get(entity.Id);
        //        if (dbEntity == null)
        //        {
        //            throw new ArgumentException("Must not be empty", "entity");
        //        }
        //        bool lAdd = (_effectiveDateRequired && dbEntity.EffectiveDate != entity.EffectiveDate) ? true : false;

        //        foreach (var item in _updateFields.Split(","))
        //        {
        //            var valueToUpdate = entity.GetType().GetProperty(item).GetValue(entity);
        //            dbEntity.GetType().GetProperty(item).SetValue(dbEntity, valueToUpdate, null);
        //        }
        //        if (lAdd)
        //        {
        //            base.Add(dbEntity);
        //        }
        //        else
        //        {
        //            base.Update(dbEntity);
        //        }
        //    }
        //    else
        //    {
        //        base.Update(entity);
        //    }
        //}

        //public override void Update(TEntity entity, string userId)
        //{
        //    entity.UserSign = userId;
        //    Update(entity);
        //    //Validate(entity);
        //    //if (!string.IsNullOrEmpty(_updateFields))
        //    //{
        //    //    TEntity dbEntity = this.Get(entity.Id);
        //    //    if (dbEntity == null)
        //    //    {
        //    //        throw new ArgumentException("Must not be empty", "entity");
        //    //    }
        //    //    foreach (var item in _updateFields.Split(","))
        //    //    {
        //    //        var valueToUpdate = entity.GetType().GetProperty(item).GetValue(entity);
        //    //        dbEntity.GetType().GetProperty(item).SetValue(dbEntity, valueToUpdate, null);
        //    //    }
        //    //    base.Update(dbEntity, userId);
        //    //}
        //    //else
        //    //{
        //    //    base.Update(entity, userId);
        //    //}
        //}

        //public async Task<dynamic> Search(string entityName, string columns)
        //{

        //    var lookupRepo = _lookupRepos.First(a => a.Metadata["Entity"].Equals(entityName));


        //    var ret = lookupRepo.Value.GetLookup()
        //        .Select($"new({columns})");

        //    return await ret.ToDynamicListAsync();

        //}

        #region Wokflow
        protected virtual void OnEntry()
        {

        }

        protected virtual void OnEntry(ObjectId id)
        {

        }

        protected virtual void OnExit()
        {

        }

        protected virtual void OnExit(ObjectId id)
        {

        }

        protected bool TriggerGuard()
        {
            return true;
        }

        public virtual Object TriggerWorkflow(string id, string trigger)
        {
            return null;
        }

        public virtual Object TriggerWorkflow(string id, string trigger, string Comment)
        {
            return null;
        }

        public virtual Object TriggerWorkflow(TEntity entity, string trigger)
        {
            return null;
        }

        //public virtual Object TriggerWorkflow(TEntity entity, WFTrigger trigger)
        //{
        //    return null;
        //}

        //public virtual void StateMutator(IWorkflowState<ObjectId> workflowState)
        //{

        //}
        #endregion
        #region Upload
        //public virtual string GetTemplateFile(Object obj)
        //{
        //    return CsvTemplate.GetTemplate(obj);
        //}



        //public virtual MemoryStream GetTemplate(bool useForm = false)
        //{
        //    MemoryStream fs = CsvTemplate.GetTemplate<TEntity>(GetAll(), new TEntity(), useForm);
        //    byte[] resultArr = fs.ToArray();
        //    var ms = new MemoryStream(resultArr);
        //    return ms;
        //}


        //public virtual MemoryStream GetTemplate(IQueryable<TEntity> query)
        //{
        //    MemoryStream fs = CsvTemplate.GetTemplate<TEntity>(query, new TEntity(), true);
        //    byte[] resultArr = fs.ToArray();
        //    var ms = new MemoryStream(resultArr);
        //    return ms;
        //}
        //protected byte[] StreamToByteArray(Stream stream)
        //{
        //    if (stream is MemoryStream)
        //        return ((MemoryStream)stream).ToArray();
        //    else
        //    {
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            stream.CopyTo(ms);
        //            return ms.ToArray();
        //        }
        //    }
        //}

        //protected FileStream GetFileStream()
        //{
        //    var fileName = string.Concat("Uploads", "\\", Helpers.RandomString(10), ".csv");

        //    return new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

        //}

        //protected string GetFileName()
        //{
        //    return string.Concat("Uploads", "\\", Helpers.RandomString(10), ".csv");

        //}

        //public IEnumerable<FormAttribute> GetFormAttributes(string form)
        //{
        //    return Helpers.GetFormAttributes(typeof(TEntity), form);
        //}

        //public virtual void StartUpload(string fileName)
        //{
        //    string userId = _repository.GetUser();
        //    BackgroundJob.Enqueue(() => UploadFileAsync(fileName, userId));
        //}

        //public virtual bool UploadFile(IDictionary<string, string> fileNames, string userId)
        //{
        //    return true;
        //}


        //public virtual bool UploadFile(string fileName, string userId)
        //{
        //    var fileHeader = System.IO.File.OpenRead(fileName);
        //    System.IO.TextReader dataFile = new System.IO.StreamReader(fileHeader);
        //    var csv = new CsvReader(dataFile);
        //    //CsvTemplate.AutoMap<()
        //    var c = CsvTemplate.AutoMap<>(true);
        //    csv.Configuration.RegisterClassMap(c);
        //    csv.Configuration.MissingFieldFound = null;
        //    csv.Configuration.HeaderValidated = null;
        //    var records = csv.GetRecords<TEntity>().ToList();
        //    IList<TEntity> forAdd = new List<TEntity>();
        //    foreach (var item in records)
        //    {

        //        if (item.Id == null || item.Id == ObjectId.Empty)
        //        {

        //            forAdd.Add(item);
        //        }
        //        else
        //        {
        //            Update(item, userId);
        //        }
        //    }
        //    Add(forAdd, userId);
        //    SaveChanges();
        //    dataFile.Dispose();
        //    fileHeader.Dispose();

        //    GC.Collect();
        //    System.IO.File.Delete(fileName);

        //    return true;
        //}


        //public async virtual Task<bool> UploadFileAsync(string fileName, string userId)
        //{
        //    var fileHeader = System.IO.File.OpenRead(fileName);
        //    System.IO.TextReader dataFile = new System.IO.StreamReader(fileHeader);
        //    var csv = new CsvReader(dataFile);
        //    //CsvTemplate.AutoMap<()
        //    var c = CsvTemplate.AutoMap<TEntity>(true);
        //    csv.Configuration.RegisterClassMap(c);
        //    csv.Configuration.MissingFieldFound = null;
        //    csv.Configuration.HeaderValidated = null;
        //    var records = csv.GetRecords<TEntity>().ToList();
        //    IList<TEntity> forAdd = new List<TEntity>();
        //    foreach (var item in records)
        //    {

        //        if (item.Id == null || item.Id == ObjectId.Empty)
        //        {

        //            forAdd.Add(item);
        //        }
        //        else
        //        {
        //            Update(item, userId);
        //        }
        //    }
        //    await AddAsync(forAdd, userId);
        //    await SaveChangesAsync();
        //    dataFile.Dispose();
        //    fileHeader.Dispose();

        //    GC.Collect();
        //    System.IO.File.Delete(fileName);

        //    return true;
        //}
        //protected MemoryStream GetZippedTemplate(IDictionary<string, MemoryStream> dict)
        //{
        //    var ms = new MemoryStream();
        //    using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
        //    {
        //        foreach (var item in dict)
        //        {
        //            var streamEntry = archive.CreateEntry(item.Key, CompressionLevel.Fastest);
        //            using (var zipStream = streamEntry.Open())
        //                zipStream.Write(item.Value.ToArray(), 0, item.Value.ToArray().Length);
        //        }
        //    }
        //    ms.Position = 0;
        //    return ms;
        //}

        //public virtual IEnumerable<dynamic> GetDefLookup(string entityName)
        //{
        //    throw new NotImplementedException();
        //}

        //public virtual IEnumerable<dynamic> GetDefLookup(string entityName, string type)
        //{
        //    throw new NotImplementedException();
        //}

        //public virtual TEntity Get(TId id)
        //{
        //    return  _repository.Get(id);
        //}
        #endregion
    }

}
