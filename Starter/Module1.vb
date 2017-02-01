Module Module1

    Sub Main()

        Dim myPath = My.Application.Info.DirectoryPath
        Dim fname As String = Foo(myPath)

        Console.WriteLine(fname)

        Dim procStartInfo As New ProcessStartInfo
        Dim procExecuting As New Process

        With procStartInfo
            .UseShellExecute = True
            .FileName = fname
            .Verb = "runas" 'add this to prompt for adminrights
            .WorkingDirectory = myPath
        End With

        procExecuting = Process.Start(procStartInfo)

    End Sub


    Private Function Foo(ByVal directory As String)
        For Each filename As String In IO.Directory.GetFiles(directory, "*", IO.SearchOption.AllDirectories)
            Dim fileExtension As String = IO.Path.GetExtension(filename)
            If fileExtension = ".exe" Then
                Return filename.ToString
            End If
        Next
        Return Nothing
    End Function

End Module
