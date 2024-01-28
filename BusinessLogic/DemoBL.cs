using BusinessObject;
//using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VT.EntityFramework;

namespace BusinessLogic
{
    public class DemoBL
    {
        public void AddDemo(DemoBO demoBo)
        {
            try
            {
                DemoDA demoDA = new DemoDA();
                demoDA.AddDemo(demoBo);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public List<DemoBO> GetDemo()
        {
            try
            {
                DemoDA demoDA = new DemoDA();
                return demoDA.GetDemo();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DemoBO GetDemoById(int id)
        {
            try
            {
                DemoDA demoDA = new DemoDA();
                return demoDA.GetDemoById(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateDemo(DemoBO demoBO)
        {
            try
            {
                DemoDA demoDA = new DemoDA();
                demoDA.UpdateDemo(demoBO);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                DemoDA demoDA = new DemoDA();
                demoDA.Delete(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
