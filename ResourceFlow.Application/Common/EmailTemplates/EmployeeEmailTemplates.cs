public static class EmployeeEmailTemplates
{
  public static string BuildWelcomeEmail(string email, string password)
  {
    string companyName = "SmartDesk";
    string loginUrl = "https://your-login-url.com";
    string supportEmail = "smartdesk.companyy@gmail.com";

    return $@"<!doctype html>
<html lang='en'>
<head>
  <meta charset='utf-8' />
  <meta name='viewport' content='width=device-width,initial-scale=1' />
  <title>Welcome to {companyName}</title>
  <style>
    @import url('https://fonts.googleapis.com/css2?family=Circular+Sp:wght@300;400;500;700;900&display=swap');
    
    @keyframes fadeIn {{
      from {{ opacity: 0; transform: translateY(20px); }}
      to {{ opacity: 1; transform: translateY(0); }}
    }}
    
    @keyframes glow {{
      0%, 100% {{ box-shadow: 0 0 20px rgba(30, 215, 96, 0.3); }}
      50% {{ box-shadow: 0 0 40px rgba(30, 215, 96, 0.5); }}
    }}

    * {{
      margin: 0;
      padding: 0;
      box-sizing: border-box;
    }}
    
    body {{
      background: #000000;
      font-family: 'Circular Sp', -apple-system, BlinkMacSystemFont, 'Helvetica Neue', Arial, sans-serif;
      margin: 0;
      padding: 40px 20px;
      min-height: 100vh;
    }}
    
    .container {{
      max-width: 600px;
      margin: 0 auto;
      animation: fadeIn 0.6s ease-out;
    }}
    
    .card {{
      background: #121212;
      border-radius: 8px;
      overflow: hidden;
    }}
    
    .header {{
      padding: 60px 40px 40px;
      text-align: center;
      background: linear-gradient(180deg, #1ed760 0%, #1db954 100%);
    }}
    
    .logo {{
      font-size: 42px;
      font-weight: 900;
      color: #000000;
      letter-spacing: -1px;
      margin: 0 0 8px 0;
    }}
    
    .subtitle {{
      color: #000000;
      font-size: 14px;
      font-weight: 500;
      letter-spacing: 1px;
      opacity: 0.8;
    }}
    
    .content {{
      padding: 48px 40px;
    }}
    
    h2 {{
      color: #ffffff;
      font-size: 32px;
      font-weight: 900;
      margin: 0 0 12px 0;
      letter-spacing: -0.5px;
    }}
    
    .welcome-text {{
      color: #b3b3b3;
      font-size: 16px;
      line-height: 1.6;
      margin-bottom: 40px;
    }}
    
    .credentials-box {{
      background: #181818;
      border-radius: 8px;
      padding: 32px;
      margin: 32px 0;
    }}
    
    .credential-item {{
      margin-bottom: 24px;
    }}
    
    .credential-item:last-child {{
      margin-bottom: 0;
    }}
    
    .credential-label {{
      color: #b3b3b3;
      font-size: 12px;
      font-weight: 700;
      text-transform: uppercase;
      letter-spacing: 1.5px;
      margin-bottom: 8px;
    }}
    
    .credential-value {{
      color: #1ed760;
      font-size: 18px;
      font-weight: 700;
      word-break: break-all;
      font-family: 'Courier New', monospace;
    }}
    
    .btn-container {{
      text-align: center;
      margin: 40px 0;
    }}
    
    .btn {{
      display: inline-block;
      padding: 16px 48px;
      background: #1ed760;
      color: #000000;
      border-radius: 500px;
      text-decoration: none;
      font-weight: 700;
      font-size: 16px;
      letter-spacing: 0.5px;
      transition: all 0.3s ease;
      animation: glow 2s ease-in-out infinite;
    }}
    
    .btn:hover {{
      background: #1fdf64;
      transform: scale(1.04);
    }}
    
    .divider {{
      height: 1px;
      background: #282828;
      margin: 40px 0;
    }}
    
    .info-text {{
      color: #b3b3b3;
      font-size: 14px;
      line-height: 1.8;
      text-align: center;
      margin: 24px 0;
    }}
    
    .support-section {{
      text-align: center;
      padding: 32px;
      background: #181818;
      border-radius: 8px;
      margin-top: 32px;
    }}
    
    .support-title {{
      color: #ffffff;
      font-size: 18px;
      font-weight: 700;
      margin-bottom: 8px;
    }}
    
    .support-text {{
      color: #b3b3b3;
      font-size: 14px;
      margin-bottom: 16px;
    }}
    
    .support-link {{
      color: #1ed760;
      text-decoration: none;
      font-weight: 700;
      font-size: 14px;
    }}
    
    .support-link:hover {{
      text-decoration: underline;
    }}
    
    .footer {{
      text-align: center;
      padding: 32px;
      color: #6a6a6a;
      font-size: 12px;
      background: #000000;
    }}
    
    .footer-logo {{
      color: #ffffff;
      font-weight: 900;
      font-size: 16px;
      margin-bottom: 16px;
    }}
    
    .footer-links {{
      margin: 16px 0;
    }}
    
    .footer-link {{
      color: #b3b3b3;
      text-decoration: none;
      margin: 0 12px;
      font-size: 12px;
      font-weight: 500;
    }}
    
    .footer-link:hover {{
      color: #1ed760;
    }}
    
    .security-badge {{
      display: inline-block;
      color: #1ed760;
      font-size: 12px;
      font-weight: 700;
      margin-top: 16px;
      opacity: 0.8;
    }}
    
    @media (max-width: 600px) {{
      .content {{
        padding: 32px 24px;
      }}
      
      .header {{
        padding: 48px 24px 32px;
      }}
      
      .logo {{
        font-size: 32px;
      }}
      
      h2 {{
        font-size: 24px;
      }}
      
      .credentials-box {{
        padding: 24px;
      }}
    }}
  </style>
</head>
<body>
  <div class='container'>
    <div class='card'>
      <div class='header'>
        <h1 class='logo'>{companyName}</h1>
        <p class='subtitle'>PREMIUM WORKSPACE</p>
      </div>
      
      <div class='content'>
        <h2>Welcome aboard</h2>
        <p class='welcome-text'>
          Your account is ready. We've set up everything you need to get started with full access to your workspace.
        </p>

        <div class='credentials-box'>
          <div class='credential-item'>
            <div class='credential-label'>Email</div>
            <div class='credential-value'>{email}</div>
          </div>
          <div class='credential-item'>
            <div class='credential-label'>Temporary Password</div>
            <div class='credential-value'>{password}</div>
          </div>
          <div class='security-badge'>🔒 Secure & Encrypted</div>
        </div>

        <div class='btn-container'>
          <a href='{loginUrl}' class='btn'>Get Started</a>
        </div>

        <div class='divider'></div>

        <p class='info-text'>
          You'll be prompted to change your password on first login.<br/>
          Keep your credentials secure and don't share them with anyone.
        </p>

        <div class='support-section'>
          <div class='support-title'>Need help?</div>
          <p class='support-text'>Our team is here for you 24/7</p>
          <a href='mailto:{supportEmail}' class='support-link'>{supportEmail}</a>
        </div>
      </div>

      <div class='footer'>
        <div class='footer-logo'>{companyName}</div>
        <p>© {DateTime.UtcNow.Year} {companyName}. All rights reserved.</p>
        
        <div class='footer-links'>
          <a href='#' class='footer-link'>Privacy</a>
          <a href='#' class='footer-link'>Terms</a>
          <a href='#' class='footer-link'>Support</a>
        </div>
      </div>
    </div>
  </div>
</body>
</html>";
  }
}