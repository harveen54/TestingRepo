//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GrantAWish.Data_Access_Layer
//{
//    class DAL
//    {
//    }



//    /// <summary>
//    ///     EntityRepositoryBase class
//    /// </summary>
//    /// <typeparam name="T"></typeparam>
//    public class EntityRepositoryBase<T> : IDisposable, IEntityRepository<T> where T : class
//    {
//        #region CONSTANTS

//        /// <summary>
//        /// Creation date field name.
//        /// </summary>
//        private const string DATE_CREATION_FIELD = "DATE_CREATION";

//        /// <summary>
//        /// Modification date field name.
//        /// </summary>
//        private const string DATE_MODIFICATION_FIELD = "DATE_MODIFICATION";

//        /// <summary>
//        /// User creation field name.
//        /// </summary>
//        private const string USER_CREATION_FIELD = "USER_CREATION";

//        /// <summary>
//        /// User modification field name.
//        /// </summary>
//        private const string USER_MODIFICATION_FIELD = "USER_MODIFICATION";

//        #endregion

//        #region INTERNAL
        
//        /// <summary>
//        /// _disposed
//        /// </summary>
//        internal bool _disposed;

//        #endregion

//        #region PRIVATE

//        /// <summary>
//        /// Permit to retrieve the UserId.
//        /// </summary>
//        private string UserID
//        {
//            get
//            {
//                if (OperationContext.Current != null && OperationContext.Current.IncomingMessageProperties != null)
//                {
//                    var customHeader =
//                        OperationContext.Current.IncomingMessageProperties.FirstOrDefault(
//                            f => f.Key == Constant.CustomHeader).Value as
//                        CustomHeader;
//                    if (customHeader != null)
//                    {
//                        return customHeader.GuiUserId;
//                    }
//                }

//                return string.Empty;
//            }
//        }

//        private static int MaxCore
//        {
//            get
//            {
//                try
//                {
//                    int x = Convert.ToInt32(ConfigurationManager.AppSettings["MaxDegreeofParallelism"]);
//                    if (x == 0 || x < -1)
//                    {
//                        x = -1;
//                    }

//                    return x;
//                }
//                catch (Exception)
//                {
//                    return -1;
//                }
//            }
//        }

//        /// <summary>
//        /// Update the property with the corresponding name of an entity object.
//        /// </summary>
//        /// <param name="entity">Entity object</param>
//        /// <param name="propertyName">Property Name</param>
//        /// <param name="value">Value to set</param>
//        private void UpdateProperty(T entity, string propertyName, object value)
//        {
//            PropertyInfo propertyInfo = entity.GetType().GetProperty(propertyName);
//            if (propertyInfo != null)
//            {
//                propertyInfo.SetValue(entity, value);
//            }
//        }
      
//        #endregion

//        #region PROTECTED

//        /// <summary>
//        /// Gets the data context.
//        /// </summary>
//        internal Context DataContext
//        {
//            get { return Context.GetContext(); }
//        }

//        #endregion

//        #region PUBLIC

//        /// <summary>
//        /// Create new instance with T type
//        /// </summary>
//        /// <returns></returns>
//        public T CreateNewInstance()
//        {
//            return DataContext.Set<T>().Create();
//        }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="EntityRepositoryBase<T>" /> class.
//        /// </summary>
//        public EntityRepositoryBase()
//        {
//        }
        
//        public virtual string GetDatabaseName()
//        {
//            if (DataContext != null && DataContext.Database != null && DataContext.Database.Connection != null)
//                return DataContext.Database.Connection.Database;
//            return null;
//        }
//        #endregion

//        #region VIRTUAL

//        /// <summary>
//        ///     Dispose
//        /// </summary>
//        public virtual void Dispose()
//        {
//            //GetDataContext = null;
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        /// <summary>
//        /// Gets all.
//        /// </summary>
//        /// <returns>
//        /// IQueryable<T>
//        /// </returns>
//        public virtual IQueryable<T> GetAll()
//        {
//            try
//            {
//                return DataContext.Set<T>().AsQueryable();
//            }
//            finally
//            {
//            }
//        }

//        /// <summary>
//        /// Count items for specific predicate
//        /// </summary>
//        /// <param name="predicate"></param>
//        /// <returns></returns>
//        public virtual int Count(Expression<Func<T, bool>> predicate)
//                    {
//            return DataContext.Set<T>().Count(predicate);
//                    }

//        /// <summary>
//        /// Determines whether [contains] [the specified predicate].
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <returns>
//        /// <c>true</c> if [contains] [the specified predicate]; otherwise, <c>false</c>.
//        /// </returns>
//        public virtual bool Contains(Expression<Func<T, bool>> predicate)
//        {
//            try
//            {
//                return DataContext.Set<T>().Count(predicate) > 0;
//            }
//            catch (Exception ex)
//            {
//                Logger.LogDebugMessage(ex.ToString());
//                throw;
//            }
//            finally
//            {
               
//            }
//        }

//        /// <summary>
//        /// Finds the specified predicate.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <returns></returns>
//        public virtual List<T> Find(Expression<Func<T, bool>> predicate)
//        {
//            try
//            {
//                return DataContext.Set<T>().Where(predicate).ToList();
//            }
//            catch (Exception ex)
//            {
//                Logger.LogDebugMessage(ex.ToString());
//                throw;
//            }
//            finally
//            {
                
//            }
//        }

//        /// <summary>
//        /// Finds the specified predicate.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <returns></returns>
//        public virtual IQueryable<T> FindByQuery(Expression<Func<T, bool>> predicate)
//        {
//            try
//            {
//                return DataContext.Set<T>().Where(predicate);
//            }
//            catch (Exception ex)
//            {
//                Logger.LogDebugMessage(ex.ToString());
//                throw;
//            }
//            finally
//            {
               
//            }
//        }

//        /// <summary>
//        /// Firsts the specified predicate.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <param name="selector"></param>
//        /// <returns>Generic element</returns>
//        public virtual List<TResult> FindSelect<TResult>(Expression<Func<T, bool>> predicate,
//                                                         Expression<Func<T, TResult>> selector)
//        {
//            try
//            {
//                return DataContext.Set<T>().Where(predicate).Select(selector).ToList();
//            }
//            catch (Exception ex)
//            {
//                Logger.LogDebugMessage(ex.ToString());
//                throw;
//            }
//            finally
//            {
               
//            }
//        }

//        /// <summary>
//        /// Singles the specified predicate.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <returns>Generic element</returns>
//        public virtual T Single(Expression<Func<T, bool>> predicate)
//        {
//            try
//            {
//                return DataContext.Set<T>().SingleOrDefault(predicate);
//            }
//            catch (Exception ex)
//            {
//                Logger.LogDebugMessage(ex.ToString());
//                throw;
//            }
//            finally
//            {
              
//            }
//        }

//        /// <summary>
//        /// Firsts the specified predicate.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <returns>Generic element</returns>
//        public virtual T First(Expression<Func<T, bool>> predicate)
//        {
//            try
//            {
//                return DataContext.Set<T>().FirstOrDefault(predicate);
//            }
//#if DEBUG
//            catch (Exception e)
//            {
//                Console.Write(e);
//                return null;
//            }
//#endif
//            finally
//            {
               
//            }
//        }

//        /// <summary>
//        /// Deletes the specified entity.
//        /// </summary>
//        /// <param name="entity">The entity.</param>
//        public virtual void Delete(T entity)
//        {
//            try
//            {
//                if (DataContext.Entry(entity).State == EntityState.Detached)
//                {
//                    Attach(entity);
//                }

//                DataContext.Set<T>().Remove(entity);
//                DataContext.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Logger.LogDebugMessage(ex.ToString());
//                throw;
//            }
//            finally
//            {
             
//            }
//        }

//        /// <summary>
//        /// Find and Bulk Deletes the specified predicate.
//        /// </summary>
//        /// <param name="predicate"></param>
//        public virtual void FindDelete(Expression<Func<T, bool>> predicate)
//        {
//            try
//            {
//                List<T> entityList = DataContext.Set<T>().Where(predicate).ToList();
//                if (entityList.Any())
//                {
                   
//                    int maxCore = MaxCore;
//                    int count = 0;
                    
//                    entityList.ForEach(entity =>
//                        {
//                            count++;
//                            if (DataContext.Entry(entity).State == EntityState.Detached)
//                            {
//                                Attach(entity);
//                            }
//                            DataContext.Set<T>().Remove(entity);

//                            if (count % 1000 == 0)
//                            {
//                                DataContext.SaveChanges();
//                            }
//                        });

//                    DataContext.SaveChanges();
//                }
//            }
//            finally
//            {
               
//            }
//        }

//        /// <summary>
//        /// Find and Bulk Deletes the specified predicate.
//        /// </summary>
//        /// <param name="predicate"></param>
//        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
//        {
//            try
//            {
//                var dbSet = DataContext.Set<T>();
//                dbSet.RemoveRange(dbSet.Where(predicate));
//                DataContext.SaveChanges();
//            }
//            finally
//            {

//            }
//        }

//        /// <summary>
//        /// Adds the specified entity.
//        /// </summary>
//        /// <param name="entity">The entity.</param>
//        public virtual void Add(T entity)
//        {
//            try
//            {
//                // Update technical fields
//                this.UpdateProperty(entity, USER_CREATION_FIELD, this.UserID);
//                this.UpdateProperty(entity, DATE_CREATION_FIELD, DateTime.Now);
               
//                DataContext.Set<T>().Add(entity);
//                DataContext.SaveChanges();
//            }
//            catch (DbEntityValidationException e)
//            {
//                foreach (var eve in e.EntityValidationErrors)
//                {
//                    Logger.LogDebugMessage(string.Format(CultureInfo.InvariantCulture,
//                                                         "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
//                                                         eve.Entry.Entity.GetType().Name, eve.Entry.State));
//                    foreach (var ve in eve.ValidationErrors)
//                    {
//                        Logger.LogDebugMessage(string.Format(CultureInfo.InvariantCulture,
//                                                             "- Property: \"{0}\", Error: \"{1}\"",
//                                                             ve.PropertyName, ve.ErrorMessage));
//                    }
//                }
//                Logger.LogTechnicalError(e);
//                DataContext.Set<T>().Remove(entity);
//                throw;
//            }
//            catch (Exception ex)
//            {
//                Logger.LogDebugMessage(ex.ToString());
//                DataContext.Set<T>().Remove(entity);
//                throw;
//            }
//            finally
//            {
               
//            }
//        }

//        /// <summary>
//        /// Attaches the specified entity.
//        /// </summary>
//        /// <param name="entity">The entity.</param>
//        public virtual void Attach(T entity)
//        {
//            DataContext.Set<T>().Attach(entity);
//        }

//        /// <summary>
//        /// Attaches the specified entity.
//        /// </summary>
//        public virtual void SaveChanges()
//        {
//            DataContext.SaveChanges();
//        }

//        /// <summary>
//        /// Edits the specified entity.
//        /// </summary>
//        /// <param name="entity">The entity.</param>
//        public virtual void Edit(T entity)
//        {
//            try
//            {
//                // Update technical fields
//                this.UpdateProperty(entity, USER_MODIFICATION_FIELD, this.UserID);
//                this.UpdateProperty(entity, DATE_MODIFICATION_FIELD, DateTime.Now);

//               if (DataContext.Entry(entity).State == EntityState.Unchanged)
//               {
//                   DataContext.Entry(entity).State = EntityState.Detached;
//               }
               
//                DataContext.Entry(entity).State = EntityState.Modified;
//                DataContext.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Logger.LogDebugMessage(ex.ToString());
//                throw;
//            }
//            finally
//            {
               
//            }
//        }

//        /// <summary>
//        ///     Selects the specified predicate.
//        /// </summary>
//        /// <param name="selector"></param>
//        /// <returns>Generic element</returns>
//        public virtual List<TResult> Select<TResult>(Expression<Func<T, TResult>> selector)
//        {
//            try
//            {
//                return DataContext.Set<T>().Select(selector).ToList();
//            }
//            catch (Exception ex)
//            {
//                Logger.LogDebugMessage(ex.ToString());
//                throw;
//            }
//            finally
//            {
                
//            }
//        }

//        public virtual void Refresh()
//        {
//            Context context = DataContext;
//            context.Dispose();
//        }

//        /// <summary>
//        ///     Add  Bulk data to the Database
//        /// </summary>
//        /// <param name="entityList"></param>
//        public virtual void AddBulk(List<T> entityList)
//        {
//            Context context = DataContext;
//            DbSet<T> dbset = context.Set<T>();
           
//            try
//            {
//                if (entityList.Any())
//                {
//                    int count = 0;
                   
//                    entityList.ForEach(entity =>
//                        {
//                            try
//                            {
//                                    count++;

//                                // Update technical fields
//                                this.UpdateProperty(entity, USER_CREATION_FIELD, this.UserID);
//                                this.UpdateProperty(entity, DATE_CREATION_FIELD, DateTime.Now);

//                                dbset.Add(entity);
//                                    if (count % 1000 == 0)
//                                    {
//                                         context.SaveChanges();
//                                    }
                                
//                            }
//                            catch (DbEntityValidationException e)
//                            {
//                                foreach (var eve in e.EntityValidationErrors)
//                                {
//                                    Logger.LogDebugMessage(string.Format(CultureInfo.InvariantCulture,
//                                                                         "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
//                                                                         eve.Entry.Entity.GetType().Name,
//                                                                         eve.Entry.State));
//                                    foreach (var ve in eve.ValidationErrors)
//                                    {
//                                        Logger.LogDebugMessage(string.Format(CultureInfo.InvariantCulture,
//                                                                             "- Property: \"{0}\", Error: \"{1}\"",
//                                                                             ve.PropertyName, ve.ErrorMessage));
//                                    }
//                                }
//                                Logger.LogTechnicalError(e);
//                                dbset.Remove(entity);
//                                throw;
//                            }
//                            catch (Exception e)
//                            {
//                                var trace = e.StackTrace;
//                                dbset.Remove(entity);
//                                throw e;
//                            }
//                        });

//                    context.SaveChanges();
//                }
//            }
//            finally
//            {
                
//            }
//        }

//        /// <summary>
//        ///     Add  Bulk data to the Database
//        /// </summary>
//        /// <param name="entityList"></param>
//        public virtual void AddRange(List<T> entityList)
//        {
//            try
//            {
//                foreach (T entity in entityList)
//                {
//                    // Update technical fields
//                    this.UpdateProperty(entity, USER_CREATION_FIELD, this.UserID);
//                    this.UpdateProperty(entity, DATE_CREATION_FIELD, DateTime.Now);
//                }

//                DataContext.Set<T>().AddRange(entityList);
//                DataContext.SaveChanges();
//            }
//            finally
//            {

//            }
//        }

//        public virtual void EditBulk(List<T> entityList)
//        {
//            Context context = DataContext;
//            DbSet<T> dbset = DataContext.Set<T>();
           
//            try
//            {
//                if (entityList.Any())
//                {
//                    int count = 0;

//                    entityList.ForEach(entity =>
//                        {
//                            try
//                            {
//                                count++;
//                                //dbset.Attach(entity);
//                                if (context.Entry(entity).State == EntityState.Detached)
//                                {
//                                    dbset.Attach(entity);
//                                }

//                                // Update technical fields
//                                this.UpdateProperty(entity, USER_MODIFICATION_FIELD, this.UserID);
//                                this.UpdateProperty(entity, DATE_MODIFICATION_FIELD, DateTime.Now);

//                                context.Entry(entity).State = EntityState.Modified;
//                                if (count % 1000 == 0)
//                                {
//                                    context.SaveChanges();
//                                }
//                            }
//                            catch (DbEntityValidationException e)
//                            {
//                                foreach (var eve in e.EntityValidationErrors)
//                                {
//                                    Logger.LogDebugMessage(string.Format(CultureInfo.InvariantCulture,
//                                                                         "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
//                                                                         eve.Entry.Entity.GetType().Name,
//                                                                         eve.Entry.State));
//                                    foreach (var ve in eve.ValidationErrors)
//                                    {
//                                        Logger.LogDebugMessage(string.Format(CultureInfo.InvariantCulture,
//                                                                             "- Property: \"{0}\", Error: \"{1}\"",
//                                                                             ve.PropertyName, ve.ErrorMessage));
//                                    }
//                                }
//                                Logger.LogTechnicalError(e);
//                                throw;
//                            }
//                            catch (Exception ex)
//                            {
//                                throw ex;
//                            }
//                        });

//                    context.SaveChanges();
//                }
//            }
//            finally
//            {
                
//            }
//        }

//        /// <summary>
//        ///     Releases unmanaged and - optionally - managed resources
//        /// </summary>
//        /// <param name="disposing">
//        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
//        /// </param>
//        protected virtual void Dispose(bool disposing)
//        {
//            if (!_disposed)
//            {
//                if (disposing)
//                {
                    
//                    //GetDataContext.Dispose();
//                }
//            }

//            _disposed = true;
//        }

//        #endregion

//    }
//}
