Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Partial Class Encrypt
    Inherits System.Web.UI.Page

    Protected Sub btnEncrypt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEncrypt.Click
        Dim config As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(My.Request.ApplicationPath)
        Dim section As System.Configuration.ConfigurationSection = config.GetSection("connectionStrings")
        If Not section.SectionInformation.IsProtected Then
            section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider")
            config.Save()

            My.Response.Write("<script language=javascript> alert (""加密成功!"")</script>")
        End If
    End Sub

    Protected Sub btnDecrypt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDecrypt.Click
        Dim config As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(My.Request.ApplicationPath)
        Dim section As System.Configuration.ConfigurationSection = config.GetSection("connectionStrings")
        If section.SectionInformation.IsProtected Then
            section.SectionInformation.UnprotectSection()
            config.Save()
            My.Response.Write("<script language=javascript> alert (""解密成功!"")</script>")
        End If
    End Sub

End Class
