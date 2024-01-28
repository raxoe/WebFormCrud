using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Xml.Linq;

namespace VT.EntityFramework
{
    public class DemoDA
    {
        DbTestEntities dbTestEntities = new DbTestEntities();
        public void AddDemo(DemoBO demoBo)
        {

            //TblDemo tblDemo = new TblDemo();
            //if (demoBo.Name != null)
            //{
            //    tblDemo.Name = demoBo.Name;
            //}
            //tblDemo.Category = demoBo.Category;
            //tblDemo.Description = demoBo.Description;


            TblDemo tblDemo = ConvertModelToEntity(demoBo);

            dbTestEntities.TblDemoes.Add(tblDemo);
            dbTestEntities.SaveChanges();
        }

        public List<DemoBO> GetDemo()
        {
            List<DemoBO> lstDemoBO = new List<DemoBO>();
            try
            {
                List<TblDemo> lstTblDemoEntity = dbTestEntities.TblDemoes.ToList();
                lstDemoBO = lstTblDemoEntity.Select(e =>
                new DemoBO() { Id = e.Id, Name = e.Name, Category = e.Category, Description = e.Description })
                    .ToList();

            }
            catch (Exception ex) { throw; }
            return lstDemoBO;
        }

        public DemoBO GetDemoById(int id)
        {
            DemoBO demoBO = new DemoBO();
            try
            {
                TblDemo tblDemoEntity = dbTestEntities.TblDemoes.FirstOrDefault(e => e.Id == id);

                //demoBO.Name = tblDemoEntity.Name;
                //demoBO.Description = tblDemoEntity.Description;
                //demoBO.Category = tblDemoEntity.Category;
                //demoBO.Id = tblDemoEntity.Id;
                demoBO = ConvertEntityToModel(tblDemoEntity);
            }
            catch (Exception ex) { }
            return demoBO;
        }

        public void UpdateDemo(DemoBO demoBO)
        {
            try
            {
                //TblDemo tblDemo = ConvertModelToEntity(demoBO);

                TblDemo tblDemoEntity = dbTestEntities.TblDemoes.FirstOrDefault(e => e.Id == demoBO.Id);                
                tblDemoEntity.Id = demoBO.Id;
                tblDemoEntity.Name = demoBO.Name;
                tblDemoEntity.Category = demoBO.Category;
                tblDemoEntity.Description = demoBO.Description;

                dbTestEntities.SaveChanges();


            }
            catch (Exception ex) { }            
        }

        public void Delete(int id)
        {
            try
            {
                DemoBO demoBO= this.GetDemoById(id);
                TblDemo tblDemo = ConvertModelToEntity(demoBO);

                dbTestEntities.TblDemoes.Remove(tblDemo);
                dbTestEntities.SaveChanges();
            }
            catch (Exception ex) { }
        }


        #region Conversion
        public TblDemo ConvertModelToEntity(DemoBO model)
        {
            return new TblDemo()
            {
                Id = model.Id,
                Name = model.Name,
                Category = model.Category,
                Description = model.Description
            };
        }

        public DemoBO ConvertEntityToModel(TblDemo entity)
        {
            return new DemoBO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Category = entity.Category,
                Description = entity.Description
            };
        }
        #endregion

    }
}
