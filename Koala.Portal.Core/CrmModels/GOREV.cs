namespace Koala.Portal.Core.CrmModels;

public partial class GOREV
{
    public string? TANIM { get; set; }

    public string? FIRMA { get; set; }

    public string? ATANAN { get; set; }

    public DateTime? BASLANGIC_TARIHI { get; set; }

    public int? YIL { get; set; }

    public int? AY { get; set; }

    public DateTime? TAMAMLANMA_TARIHI { get; set; }

    public int? TAMAMLANMA_YUZDESI { get; set; }

    public string GOREV_DURUMU { get; set; } = null!;

    public string? DESTEKID { get; set; }

    public string? YAPILAN_ISLEM { get; set; }

    public string? DESTEK_DURUM { get; set; }

    public string? ANAKATEGORI { get; set; }

    public string? ALTKATEGORI { get; set; }

    public string? TUR { get; set; }

    public DateTime? DESTEK_BASLANGIC_TARIHI { get; set; }

    public DateTime? DESTEK_TAMAMLANMA_TARIHI { get; set; }
}
