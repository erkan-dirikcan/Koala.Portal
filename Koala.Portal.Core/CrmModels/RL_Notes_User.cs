namespace Koala.Portal.Core.CrmModels;

public partial class RL_Notes_User
{
    public Guid? NotesOid { get; set; }

    public Guid? UserOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Notes? NotesO { get; set; }

    public virtual ST_User? UserO { get; set; }
}
