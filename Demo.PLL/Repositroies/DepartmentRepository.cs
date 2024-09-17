using Demo.DAL.Context;
using Demo.DAL.Models;
using Demo.PLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PLL.Repositroies
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MVCDBContext DBContext ;

        public DepartmentRepository(MVCDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public int Add(Department department)
        {
           DBContext.Add(department);
           return DBContext.SaveChanges();
           
        }

        public int Delete(Department department)
        {
            DBContext.Remove(department);
            return DBContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll() =>   DBContext.Departments.ToList();
             
        

        public Department GetByID(int id)
        {
           //var deparment=  DBContext.Departments.Local.Where(d => d.ID == id).FirstOrDefault();
           // if (deparment is null)
           // {
           //     DBContext.Departments.Where(d => d.ID == id).FirstOrDefault();
           // }
           // return deparment;

            return DBContext.Departments.Find(id);
        }

        public int Update(Department department)
        {
            DBContext.Update(department);
            return DBContext.SaveChanges();
        }
    }
}
