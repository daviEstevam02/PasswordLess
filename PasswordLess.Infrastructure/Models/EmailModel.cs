namespace PasswordLess.Infrastructure.Models;

public sealed record EmailModel(
    string Recievers,
    string Subject,
    string Body
)
{
    public const string CLUB_USER_CREATED_SUBJECT = "PasswordLess Passcode";
    public static string CLUB_USER_CREATED_BODY(string passCode) => @"
                <!DOCTYPE html>
                <html lang=""en"">
                  <head>
                    <meta charset=""UTF-8"" />
                    <title>PasswordLess</title>
                  </head>
                  <body style=""font-family: 'Montserrat', sans-serif"">
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                      <tr>
                        <td width=""260"" valign=""top"" align=""center"">
                          <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""80%"">
                            <tr>
                              <td align=""center"">
                                <img
                                  src=""data:image/png;base64,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""
                                />
                              </td>
                            </tr>
                            <tr style=""background: white"">
                              <td style=""padding: 2rem"">
                                <h2>Código de acesso</h2>
                                <p>
                                  Olá, seja bem-vindo ao sistema PasswordLess, abaixo confira o seu
                                  código de acesso:
                                </p>
                                <h2 align=""center"">"+passCode+@"</h2>
                                <p>O código de acesso irá expirar em 5 minutos!</p>
                              </td>
                            </tr>
                          </table>
                        </td>
                      </tr>
                    </table>
                  </body>
                </html>
            ";
}