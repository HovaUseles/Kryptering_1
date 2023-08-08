using Kryptering_2___Safe_Password_Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Repositories
{
    internal class MockGenericRepository<T> : IGenericRepository<T>
        where T : BaseModel
    {
        public List<T> MockData { get; set; }
        public MockGenericRepository()
        {
            MockData = new List<T>();
        }
        public T Add(T model)
        {
            model.Id = Guid.NewGuid();
            MockData.Add(model);
            return model;
        }

        public T Delete(T model)
        {
            T modelToDelete = MockData.FirstOrDefault(m => m == m);
            if(modelToDelete != null)
            {
                MockData.Remove(modelToDelete);
            }
            else
            {
                KeyNotFoundException ex = new KeyNotFoundException();
                ex.Data.Add("Model:", model);
                throw ex;
            }
            return modelToDelete;
        }

        public T[] GetAll()
        {
            return MockData.ToArray();
        }

        public T GetById(object id)
        {
            return MockData.FirstOrDefault(m => m.Id == id);
        }

        public T Update(T model)
        {
            int modelIndex = MockData.IndexOf(model);
            if(modelIndex == -1) 
            {
                KeyNotFoundException ex = new KeyNotFoundException();
                ex.Data.Add("Model:", model);
                throw ex;
            }

            MockData[modelIndex] = model;
            return model;
        }
    }
}
