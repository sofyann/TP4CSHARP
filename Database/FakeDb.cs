using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public abstract class FakeDb<T> where T : Entity
    {
        private List<T> datas;
        private int idSeq;
        public FakeDb (List<T> datas)
        {
            this.datas = datas;
        }

        public FakeDb(List<T> datas, int idSeq)
        {
            this.datas = datas;
            this.idSeq = idSeq;
        }
        public List<T> GetAll()
        {
            return this.datas;
        }

        public T Get(int id)
        {
            return this.datas.FirstOrDefault(i => i.Id == id);
        }

        public void Set(T entity)
        {
            if (entity.Id == 0)
            {
                Add(entity);
            } else
            {
                Edit(entity);
            }
        }

        private void Add(T entity)
        {
            entity.Id = idSeq++;
            this.datas.Add(entity);
        }

        private void Edit(T entity)
        {
            this.datas[this.datas.FindIndex(i => i.Id == entity.Id)] = entity;
        }

        public void Delete(int id)
        {
            T entity = this.datas.FirstOrDefault(i => i.Id == id);
            if (entity != null)
            {
                this.datas.Remove(entity);
            }
        }
    }
}
