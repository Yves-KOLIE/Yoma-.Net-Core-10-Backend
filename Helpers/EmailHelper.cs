using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using YOMA.Models;

namespace YOMA.Helpers
{
    public static class EmailHelper
    {
        private const string SmtpHost = "smtp.gmail.com";
        private const int SmtpPort = 465;
        private const string SmtpUser = "worldsoftwaredevelopmentcenter@gmail.com";
        private const string SmtpPass = "apmqnkyutpradpnd";

        public static string GenerateCode()
        {
            return Random.Shared.Next(0, 10000).ToString("D4");
        }

        public static async Task<bool> SendResetPasswordEmailAsync(string receiverEmail, string codeGenerated, DateTime expireDate)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("GROUPE SCOLAIRE YOMA", SmtpUser));
                message.To.Add(MailboxAddress.Parse(receiverEmail));
                message.Subject = "GROUPE SCOLAIRE YOMA : Changement du mot de passe";
                var expiryTime = expireDate.ToString("HH\\h mm\\min ss\\s", System.Globalization.CultureInfo.InvariantCulture);

                var htmlBody = $@"
                    <!DOCTYPE html>
                    <html lang=""fr"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                        <title>Réinitialisation Mot de Passe - GROUPE SCOLAIRE YOMA</title>
                        <style type=""text/css"">
                            .container {{ max-width: 600px !important; margin: 0 auto !important; }}
                            .header-gradient {{ background: linear-gradient(135deg, #1e3a8a 0%, #3b82f6 100%) !important; }}
                            .code-box {{ 
                                animation: pulse 2s infinite !important;
                                transition: all 0.3s ease !important;
                            }}
                            .code-box:hover {{ transform: scale(1.02) !important; }}
                            @media screen and (max-width: 600px) {{
                                .container {{ width: 100% !important; padding: 10px !important; }}
                                .code-large {{ font-size: 28px !important; }}
                            }}
                            @keyframes pulse {{
                                0% {{ box-shadow: 0 0 0 0 rgba(59,130,246,0.7); }}
                                70% {{ box-shadow: 0 0 0 15px rgba(59,130,246,0); }}
                                100% {{ box-shadow: 0 0 0 0 rgba(59,130,246,0); }}
                            }}
                        </style>
                    </head>
                    <body style=""margin: 0; padding: 20px; background-color: #f4f4f4; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;"">
                        <table role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" class=""container"" style=""background-color: #ffffff; border-radius: 12px; box-shadow: 0 8px 24px rgba(0,0,0,0.12);"">
                            
                            <tr>
                                <td style=""padding: 40px 30px 25px; text-align: center; color: #ffffff;"" class=""header-gradient"">
                                    <h1 style=""margin: 0 0 8px; font-size: 26px; font-weight: 700; letter-spacing: 1px;"">GROUPE SCOLAIRE YOMA</h1>
                                    <p style=""margin: 0; font-size: 15px; opacity: 0.95; font-weight: 400;"">Plateforme Éducative Sécurisée</p>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style=""padding: 45px 40px;"">
                                    <h2 style=""color: #1e3a8a; font-size: 22px; margin: 0 0 25px; font-weight: 600; line-height: 1.3;"">Réinitialisation de votre mot de passe</h2>
                                    
                                    <div style=""text-align: center; margin: 35px 0;"" class=""code-box"">
                                        <div style=""background: #f8fafc; border: 4px solid #3b82f6; border-radius: 16px; padding: 35px 25px; display: inline-block; box-shadow: 0 8px 24px rgba(59,130,246,0.15);"">
                                            <p style=""margin: 0 0 20px; font-size: 16px; color: #64748b; font-weight: 500;"">Votre code de vérification :</p>
                                            <div style=""font-size: 40px; font-weight: 800; color: #1e3a8a; letter-spacing: 10px; font-family: 'Courier New', 'Consolas', monospace; text-transform: uppercase; line-height: 1;"" class=""code-large"">{codeGenerated}</div>
                                        </div>
                                    </div>
                                    
                                    <div style=""text-align: center; margin: 30px 0; padding: 25px; background: #fef3c7; border: 2px solid #f59e0b; border-radius: 10px; box-shadow: 0 4px 12px rgba(245,158,11,0.15);"">
                                        <p style=""margin: 0 0 5px; font-size: 16px; color: #92400e; font-weight: 500;"">
                                            <strong>⏰ Important :</strong> Ce code expire à
                                        </p>
                                        <div style=""font-size: 22px; color: #dc2626; font-weight: 700; font-family: 'Courier New', monospace;"">{expiryTime}</div>
                                    </div>
                                    
                                    <div style=""margin: 35px 0; padding: 25px; background: #f0fdf4; border-left: 5px solid #10b981; border-radius: 0 12px 12px 0; box-shadow: 0 4px 12px rgba(16,185,129,0.1);"">
                                        <p style=""margin: 0 0 15px; font-size: 16px; color: #065f46; font-weight: 600;"">📋 Comment utiliser ce code :</p>
                                        <ul style=""margin: 0; padding-left: 25px; font-size: 15px; color: #047857; line-height: 1.6;"">
                                            <li>Copiez ce code et collez-le dans l'application web/mobile</li>
                                            <li>Créez un nouveau mot de passe sécurisé (8+ caractères)</li>
                                            <li>Ce code est <strong>unique et à usage unique</strong></li>
                                        </ul>
                                    </div>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style=""padding: 30px 40px 40px; background-color: #f8fafc; border-top: 1px solid #e2e8f0;"">
                                    <h3 style=""margin: 0 0 12px; font-size: 17px; color: #374151; font-weight: 600;"">🔒 Sécurité de votre compte</h3>
                                    <p style=""margin: 0 0 18px; font-size: 14px; color: #6b7280; line-height: 1.5;"">
                                        Vous avez reçu cet email car une demande de réinitialisation a été effectuée pour votre compte.<br>
                                        <strong>Si ce n'était pas vous,</strong> ignorez cet email ou contactez notre support immédiatement.
                                    </p>
                                    
                                    <div style=""text-align: center; padding-top: 25px; border-top: 1px solid #e5e7eb;"">
                                        <p style=""margin: 0 0 10px; font-size: 13px; color: #9ca3af; font-style: italic;"">
                                            <strong>NB :</strong> Ceci est un message automatique généré par notre système. Ne pas y répondre.
                                        </p>
                                        <p style=""margin: 0; font-size: 13px; color: #6b7280; line-height: 1.4;"">
                                            © 2026 <strong>GROUPE SCOLAIRE YOMA</strong>. Tous droits réservés.<br>
                                            <a href=""mailto:support@yoma-ecole.com"" style=""color: #3b82f6; text-decoration: none; font-weight: 500;"">support@yoma-ecole.com</a> | 
                                            <a href=""https://www.yoma-ecole.com"" style=""color: #3b82f6; text-decoration: none; font-weight: 500;"">www.yoma-ecole.com</a>
                                        </p>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </body>
                    </html>"
                ;

                message.Body = new TextPart("html") { Text = htmlBody };

                using var client = new SmtpClient();
                await client.ConnectAsync(SmtpHost, SmtpPort, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(SmtpUser, SmtpPass);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> IsvalidCode(string receiverEmail, Context _context)
        {
            var now = DateTime.UtcNow; 
            var validCode = await _context.ForgotUserPasswords
                .Where(x => EF.Functions.Like(x.EMAIL.ToLower(), receiverEmail.ToLower()))
            .FirstOrDefaultAsync(x => x.EXPIRE_DATE > now);
            return validCode != null;
        }

    }
}