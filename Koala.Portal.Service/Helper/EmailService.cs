using System.Net;
using System.Net.Mail;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Koala.Portal.Service.Helper;

public class EmailService : IEmailService
{
    private readonly EmailSettingViewModel _emailOptions;
    private readonly IMailTemplateService _templateService;
    private readonly ILogger<EmailService> _logger;
    public EmailService(IOptions<EmailSettingViewModel> emailOptions, IMailTemplateService templateService, ILogger<EmailService> logger)
    {
        _templateService = templateService;
        _logger = logger;
        _emailOptions = emailOptions.Value;
    }  
    public async Task<bool> SendResetPasswordEmailAsync(ResetPasswordEmailDto model)
    {
        var mailContent = "";
        var mailTemplateRes = await _templateService.GetByNameAsyc("DefaultTemplate");
        if (!mailTemplateRes.IsSuccess)
        {
            mailContent = $"Şifrenizi sıfırlamak için lütfen <a href=\"{model.ResetLink}\" target=\"_blank\">Buraya</a> tıklayınız";
        }
        else
        {
            mailContent = mailTemplateRes.Data.Content
                .Replace("[[Title]]", "Sistem Bilgisayar Koala Portal")
                .Replace("[[Date]]", DateTime.Now.ToLongDateString())
                .Replace("[[Name]]", model.Name + " " + model.Lastname)
                .Replace("[[Body]]", $"Şifrenizi sıfırlamak için lütfen <a href=\"{model.ResetLink}\" target=\"_blank\">Buraya</a> tıklayınız");
        }

        return await SendEmailAsync(new EmailDto {Content = mailContent, Email = model.Email,Title = "Şifre Sıfırlama Talebi"});

        

    }
    public async Task<bool> SendChangePasswordEmailAsync(CustomEmailDto model)
    {
        var mailContent = "";
        var mailTemplateRes = await _templateService.GetByNameAsyc("DefaultTemplate");
        if (!mailTemplateRes.IsSuccess)
        {
            mailContent = $"Sistem bilgisayar Koala Portal uygulaması üzerinden şifreniz başarıyla değiştirildi";
        }
        else
        {
            mailContent = mailTemplateRes.Data.Content
                .Replace("[[Title]]", "Sistem Bilgisayar Koala Portal")
                .Replace("[[Date]]", DateTime.Now.ToLongDateString())
                .Replace("[[Name]]", model.Name + " " + model.Lastname)
                .Replace("[[Body]]", $"Sistem bilgisayar Koala Portal uygulaması üzerinden şifreniz başarıyla değiştirildi.<br />" +
                                     $"Yeni şifreniz ile sisteme giriş yapabilirsiniz. Bu işlem bilginiz dahilinde gerçekleşmediyse lütfen <a href=\"mailto:yazilim@sistem-bilgi.com\">Yazılım Destek Ekibiyle İletişime Geçiniz.</a>");
        }
        return await SendEmailAsync(new EmailDto {Content = mailContent, Email = model.Email,Title = "Şifreniz Değiştirildi"});

    }

    public async Task<bool> SendProjectEmailAsync(ProjectCustomEmailDto model)
    {
        var mailContent = "";
        var mailTemplateRes = await _templateService.GetByNameAsyc("DefaultTemplate");
        if (!mailTemplateRes.IsSuccess)
        {
            mailContent = $"Sistem bilgisayar Koala Portal uygulaması üzerinden yeni bir proje oluşturuldu";
        }
        else
        {
            var mailBody = $@"{model.CreateUser} tarafından {model.CreateDate} tarihinde oluşturulan projeye <span style=""color: #e74900; text-decoration: underline;""><strong> Proje Yöneticisi</strong></span> olarak atandınız.
                            <br />
                            <table>
                                <tr>
                                    <th style=""width: 100px; color: #e74900; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">Firma Adı</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">:</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""left"">{model.FirmName}</th>
                                </tr>
                                <tr>
                                    <th style=""color: #e74900; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">Firma Yetkilisi</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">:</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""left"">{model.FirmProjectManager}</th>
                                </tr>
                                <tr>
                                    <th style=""color: #e74900; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">Yetkili E-Posta</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">:</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""left""><a href=""mailTo:{model.ProjectManagerEmail}"">{model.ProjectManagerEmail}</a> </th>
                                </tr>
                                <tr>
                                    <th style=""color: #e74900; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">Yetkili Telefonu</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">:</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""left""><a href=""tel:{model.ProjectManagerPhones}"">{model.ProjectManagerPhones}</a></th>
                                </tr>
                                <tr>
                                    <th style=""color: #e74900; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">Proje Kodu</th>
                                    <th style=""color: #v; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">:</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""left"">{model.ProjectCode}</th>
                                </tr>
                                <tr>
                                    <th style=""color: #e74900; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">Proje Adı</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">:</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""left"">{model.ProjectName}</th>
                                </tr>
                                <tr>
                                    <th style=""color: #e74900; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">Proje Açıklaması</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">:</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""left"">{model.ProjectDescription}</th>
                                </tr>
                                <tr>
                                    <th style=""color: #e74900; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">Teslim Tarihi</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">:</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""left"">{model.DueDate}</th>
                                </tr>
                                <tr>
                                    <th style=""color: #e74900; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">Proje Detayı</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""right"">:</th>
                                    <th style=""color: #262626; font-size: 12px; font-weight: normal; font-family: Helvetica, Arial, sans-serif;"" align=""left""><a href=""https://portal.sistem-koala.com/Project/Detail/{model.ProjectId}"">Proje Detayı Sayfası</a></th>
                                </tr> 
                            </table>";
            mailContent = mailTemplateRes.Data.Content
                .Replace("[[Title]]", "Sistem Bilgisayar Koala Portal")
                .Replace("[[Date]]", DateTime.Now.ToLongDateString())
                .Replace("[[Name]]", model.Name + " " + model.Lastname)
                .Replace("[[Body]]",mailBody);
        }
        return await SendEmailAsync(new EmailDto {Content = mailContent, Email = model.Email,Title = "Yeni Proje Bildirimi"});
    }

    private async Task<bool> SendEmailAsync(EmailDto model)
    {
        var smtpClient = new SmtpClient();
        smtpClient.Host = _emailOptions.Host;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Port = 587;
        smtpClient.Credentials = new NetworkCredential(_emailOptions.Email, _emailOptions.Password);
        smtpClient.EnableSsl = false;



        var message = new MailMessage();
        message.From = new MailAddress(_emailOptions.Email);
        message.To.Add(model.Email);
        message.Subject = model.Title;
        message.Body = model.Content;
        message.IsBodyHtml = true;


        try
        {
            await smtpClient.SendMailAsync(message);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"E-Posta gönderilirken Bir Sorunla Karşılaşıldı",new {Hata=ex});
            return false;
        }
    }
  
}