using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Data.Access.DAL
{
    /// <summary>
    /// Реализация шаблона UnitOfWork
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        private OMSDbContext _context;
        // инъекция DbContext
        public EFUnitOfWork(OMSDbContext context)
        {
            _context = context;
        }
        // todo: сформулирвать комментарии и дописать
        /// <summary>
        /// Метод Query принимает объект Т и возвращает 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<T> Query<T>(T obj) where T : class => _context.Set<T>();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="token"></param>
        public async void Add<T>(T obj, CancellationToken token)
            where T : class
        {
            await this._context.Set<T>().AddAsync(obj, token);
            await this._context.SaveChangesAsync(); 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="token"></param>
        public void Update<T>(T obj, CancellationToken token) 
            where T : class
        {
            this._context.Set<T>()
            .Update(obj);
        }
        // todo: реализовать Soft Delete
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="token"></param>
        public void Delete<T>(T obj, CancellationToken token) 
            where T : class
        {
            this._context.Set<T>().Remove(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}