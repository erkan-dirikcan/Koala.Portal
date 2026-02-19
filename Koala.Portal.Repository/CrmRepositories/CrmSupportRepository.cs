using System.Linq.Expressions;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.CrmRepositories;

public class CrmSupportRepository : ICrmSupportRepository
{
    SistemCrmContext _context;
    public readonly DbSet<MT_Ticket> _dbSet;

    public CrmSupportRepository(SistemCrmContext context)
    {
        _context = context;
        _dbSet = context.Set<MT_Ticket>();
    }
    public IQueryable<MT_Ticket?> Where(Expression<Func<MT_Ticket, bool>> predicate)
    {
        var retVal= _dbSet
            .Include(x => x.TicketContactNavigation)
            .Include(x => x.TicketStateNavigation)
            .Include(x => x.TicketFirmNavigation)
            .Include(x => x.AssignedDepartmentNavigation)
            .Include(x => x.TicketContactNavigation.PO_Phone_Number)
            .Include(x => x.TicketFirmNavigation.PO_Phone_Number)
            .Where(predicate);
        return retVal;
    }
    public async Task AddAsyc(MT_Ticket model)
    {
        await _context.AddAsync(model);
        var ticketAssign = new ST_Ticket_Assign
        {
            Oid = Tools.CreateGuid(),
            AssignedDepartment = model.AssignedDepartment,
            AssignedTo = model.AssignedTo,
            Description ="",
            GCRecord=null,
            Notes="",
            OptimisticLockField=1,
            TicketOid= model.Oid,
            _CreatedBy = model._CreatedBy,
            _CreatedDateTime = model._CreatedDateTime,
            _LastModifiedBy = model._LastModifiedBy,
            _LastModifiedDateTime = model._LastModifiedDateTime
        };
        _context.ST_Ticket_Assign.Add(ticketAssign);
        await _context.SaveChangesAsync();
    }
    public async Task<MT_Ticket?> FindByOidAsync(string oid)
    {
        var oidGuid = new Guid(oid);
        var res = await _dbSet
            .Include(x => x.TicketMainCategoryNavigation)
            .Include(x => x.TicketSubCategoryNavigation)
            .Include(x => x.TicketTypeNavigation)
            .Include(x => x.TicketFirmNavigation)
            .Include(x => x.TicketContactNavigation)
            .Include(x => x.AssignedDepartmentNavigation)
            .Include(x => x.AssignedToNavigation)
            .FirstOrDefaultAsync(x => x.Oid == oidGuid);
        return res;
    }
    public async Task<MT_Ticket?> FindByTickeyIdAsync(string ticketId)
    {
        var res = await _dbSet
            .Include(x => x.TicketMainCategoryNavigation)
            .Include(x => x.TicketSubCategoryNavigation)
            .Include(x => x.TicketTypeNavigation)
            .Include(x => x.TicketFirmNavigation)
            .Include(x => x.TicketContactNavigation)
            .Include(x => x.AssignedDepartmentNavigation)
            .Include(x => x.AssignedToNavigation)
            .FirstOrDefaultAsync(x => x.TicketId.Equals(ticketId,StringComparison.CurrentCultureIgnoreCase));
        return res;
    }
    public void UpdateTicket(MT_Ticket model)
    {
        _context.Entry(model).State = EntityState.Modified;        
        _context.SaveChanges();
    }

}