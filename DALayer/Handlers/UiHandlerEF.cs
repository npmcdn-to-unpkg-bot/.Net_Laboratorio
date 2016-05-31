using DALayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;
using System.Data.Entity.Validation;

namespace DALayer.Handlers
{
    public class UiHandlerEF : IUiHandler
    {
        TenantContext ctx;

        public UiHandlerEF(TenantContext tc) {
            ctx = tc;
        }

        public void createUi(Ui ui)
        {
            Entities.Ui u = new Entities.Ui(ui.css);
            try
            {
                ctx.Ui.Add(u);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void deleteUi(int id)
        {
            var u = (from c in ctx.Ui
                       where c.id == id
                        select c).SingleOrDefault();
            try
            {
                ctx.Ui.Remove(u);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Ui getUi(int id)
        {
            try
            {
                var u = (from c in ctx.Ui
                         where c.id == id
                           select c).SingleOrDefault();

                if (u != null)
                {
                    Ui ui = new Ui(u.id, u.css);
                    return ui;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateUi(Ui ui)
        {
            try
            {
                var uiT = ctx.Ui
                    .Where(w => w.id == ui.id)
                    .SingleOrDefault();

                if (uiT != null)
                {
                    uiT.css = ui.css;
                    ctx.SaveChangesAsync().Wait();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
