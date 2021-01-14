<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RSALoginTest._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RSA Login Test</title>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jQuery.md5.js" type="text/javascript" ></script>
    <script src="Scripts/BigInt.js" type="text/javascript"></script>
    <script src="Scripts/RSA.js" type="text/javascript"></script>
    <script src="Scripts/Barrett.js" type="text/javascript"></script>
    <script type="text/javascript">
        function cmdEncrypt() {
            setMaxDigits(129);
            var key = new RSAKeyPair("<%=strPublicKeyExponent%>", "", "<%=strPublicKeyModulus%>");
            var pwdMD5Twice = $.md5($.md5($("#txtPassword").attr("value")));
            var pwdRtn = encryptedString(key, pwdMD5Twice);
            $("#encrypted_pwd").attr("value", pwdRtn);
            $("#formLogin").submit();
            return;
        }
    </script>

</head>
<body>
    <form action="Default.aspx" id="formLogin" method="post">
    <div>
        <div>
            User Name:
        </div>
        <div>
            <input id="txtUserName" name="txtUserName" value="<%=postbackUserName%>" type="text" maxlength="16" />
        </div>
        <div>
            Password:
        </div>
        <div>
            <input id="txtPassword" type="password" maxlength="16" />
        </div>
        <div>
            <input id="btnLogin" type="button" value="Login" onclick="return cmdEncrypt()" />
        </div>
    </div>
    <div>
        <input type="hidden" name="encrypted_pwd" id="encrypted_pwd" />
    </div>
    </form>
    <div>
        <%=LoginResult%>
    </div>
</body>
</html>
