namespace Koala.Portal.Core.CrmModels;

public partial class RL_Notes_Departments
{
    public Guid? DepartmentOid { get; set; }

    public Guid? NotesOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual CT_User_Departments? DepartmentO { get; set; }

    public virtual MT_Notes? NotesO { get; set; }
}
