public static class EmployeeEmailTemplates
{
    public static string BuildWelcomeEmail(string email, string password)
    {
        string companyName = "SmartDesk";
        string loginUrl = "https://your-login-url.com";
        string supportEmail = "support@smartdesk.com";

        return $@"<!doctype html>
<html lang='en'>
<head>
  <meta charset='utf-8' />
  <meta name='viewport' content='width=device-width,initial-scale=1' />
  <title>Welcome to {companyName}</title>
  <style>
    body{{
      background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
      font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
      margin: 0;
      padding: 40px 20px;
    }}
    .container{{
      max-width: 650px;
      margin: 0 auto;
    }}
    .card{{
      background: linear-gradient(to bottom, #ffffff 0%, #f8f9fa 100%);
      border-radius: 20px;
      box-shadow: 0 20px 60px rgba(0, 0, 0, 0.3);
      overflow: hidden;
    }}
    .header{{
      background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
      padding: 50px 40px;
      text-align: center;
      position: relative;
    }}
    .header::before{{
      content: '';
      position: absolute;
      top: 0;
      left: 0;
      right: 0;
      bottom: 0;
      background: url('data:image/svg+xml,<svg width=""100"" height=""100"" xmlns=""http://www.w3.org/2000/svg""><defs><pattern id=""grid"" width=""20"" height=""20"" patternUnits=""userSpaceOnUse""><circle cx=""10"" cy=""10"" r=""1"" fill=""white"" opacity=""0.1""/></pattern></defs><rect width=""100"" height=""100"" fill=""url(%23grid)""/></svg>');
      opacity: 0.3;
    }}
    .logo{{
      font-size: 36px;
      font-weight: 800;
      color: white;
      letter-spacing: -1px;
      margin: 0;
      text-shadow: 0 2px 10px rgba(0,0,0,0.2);
      position: relative;
      z-index: 1;
    }}
    .subtitle{{
      color: rgba(255,255,255,0.9);
      font-size: 16px;
      margin-top: 10px;
      position: relative;
      z-index: 1;
    }}
    .content{{
      padding: 50px 40px;
    }}
    h2{{
      color: #1a202c;
      font-size: 28px;
      font-weight: 700;
      margin: 0 0 20px 0;
      text-align: center;
    }}
    .welcome-text{{
      color: #4a5568;
      font-size: 16px;
      line-height: 1.6;
      text-align: center;
      margin-bottom: 35px;
    }}
    .credentials-box{{
      background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
      border-radius: 16px;
      padding: 35px;
      margin: 30px 0;
      box-shadow: 0 10px 30px rgba(102, 126, 234, 0.3);
      position: relative;
      overflow: hidden;
    }}
    .credentials-box::before{{
      content: '';
      position: absolute;
      top: -50%;
      right: -50%;
      width: 200%;
      height: 200%;
      background: radial-gradient(circle, rgba(255,255,255,0.1) 0%, transparent 70%);
    }}
    .credential-item{{
      background: rgba(255, 255, 255, 0.95);
      border-radius: 12px;
      padding: 20px;
      margin-bottom: 15px;
      position: relative;
      z-index: 1;
      backdrop-filter: blur(10px);
    }}
    .credential-item:last-child{{
      margin-bottom: 0;
    }}
    .credential-label{{
      color: #667eea;
      font-size: 12px;
      font-weight: 700;
      text-transform: uppercase;
      letter-spacing: 1px;
      margin-bottom: 8px;
    }}
    .credential-value{{
      color: #1a202c;
      font-size: 18px;
      font-weight: 600;
      word-break: break-all;
    }}
    .btn-container{{
      text-align: center;
      margin: 40px 0;
    }}
    .btn{{
      display: inline-block;
      padding: 18px 50px;
      background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
      color: white;
      border-radius: 50px;
      text-decoration: none;
      font-weight: 700;
      font-size: 16px;
      box-shadow: 0 10px 30px rgba(102, 126, 234, 0.4);
      transition: all 0.3s ease;
      letter-spacing: 0.5px;
    }}
    .divider{{
      height: 1px;
      background: linear-gradient(to right, transparent, #e2e8f0, transparent);
      margin: 40px 0;
    }}
    .support-section{{
      text-align: center;
      padding: 30px;
      background: #f8f9fa;
      border-radius: 12px;
      margin-top: 30px;
    }}
    .support-text{{
      color: #4a5568;
      font-size: 14px;
      margin-bottom: 10px;
    }}
    .support-link{{
      color: #667eea;
      text-decoration: none;
      font-weight: 600;
    }}
    .footer{{
      text-align: center;
      padding: 30px 40px;
      color: #a0aec0;
      font-size: 13px;
      background: #f8f9fa;
    }}
    .security-badge{{
      display: inline-block;
      background: rgba(102, 126, 234, 0.1);
      color: #667eea;
      padding: 8px 16px;
      border-radius: 20px;
      font-size: 12px;
      font-weight: 600;
      margin-top: 20px;
    }}
  </style>
</head>
<body>
  <div class='container'>
    <div class='card'>
      <div class='header'>
        <h1 class='logo'>{companyName}</h1>
        <p class='subtitle'>Premium Workspace Solutions</p>
      </div>
      
      <div class='content'>
        <h2>🎉 Welcome Aboard!</h2>
        <p class='welcome-text'>
          We're thrilled to have you join our elite team. Your exclusive account has been 
          created with premium access to all features. Get started with your personalized credentials below.
        </p>

        <div class='credentials-box'>
          <div class='credential-item'>
            <div class='credential-label'>Your Email Address</div>
            <div class='credential-value'>{email}</div>
          </div>
          <div class='credential-item'>
            <div class='credential-label'>Temporary Password</div>
            <div class='credential-value'>{password}</div>
          </div>
        </div>

        <div class='security-badge'>
          🔒 Secure & Encrypted Access
        </div>

        <div class='btn-container'>
          <a href='{loginUrl}' class='btn'>Access Your Dashboard</a>
        </div>

        <div class='divider'></div>

        <div class='support-section'>
          <p class='support-text'>
            <strong>Need assistance?</strong> Our dedicated support team is here 24/7
          </p>
          <a href='mailto:{supportEmail}' class='support-link'>{supportEmail}</a>
        </div>
      </div>

      <div class='footer'>
        <p>© {DateTime.UtcNow.Year} {companyName}. All rights reserved.</p>
        <p style='margin-top: 10px; font-size: 12px;'>
          This is a confidential communication. Please do not share your credentials.
        </p>
      </div>
    </div>
  </div>
</body>
</html>";
    }
}