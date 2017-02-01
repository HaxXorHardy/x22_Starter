Module Module1

    Sub Main()
        Try
            Dim myPath = My.Application.Info.DirectoryPath                  'get current directory
            Dim fname As String = Foo(myPath)                               'call Function Foo to get filename of xClient

            Console.WriteLine(fname)                                        'testing not visible

            Dim procStartInfo As New ProcessStartInfo                       'Dims to start the xClient as admin
            Dim procExecuting As New Process

            With procStartInfo
                .UseShellExecute = True
                .FileName = fname
                .Verb = "runas"                                              'add this to prompt for adminrights
                .WorkingDirectory = myPath
            End With

            procExecuting = Process.Start(procStartInfo)                     'here we go and start the Process
        Catch ex As Exception
            Console.WriteLine(ex.Message, Environment.NewLine)               'Errorhandling for user debugging
            Console.ReadLine()
        End Try
    End Sub


    Private Function Foo(ByVal directory As String)
        Try
            For Each filename As String In IO.Directory.GetFiles(directory, "*", IO.SearchOption.AllDirectories)        'search for all files in directory
                Dim fileExtension As String = IO.Path.GetExtension(filename)                                            'look for the extension (.exe .txt .bat etc.)
                If fileExtension = ".exe" Then                                                                          'we only need .exe
                    Return filename.ToString                                                                            'return the filename :)
                End If
            Next
            Return Nothing
        Catch ex As Exception
            Console.WriteLine(ex.Message, Environment.NewLine)                                                          'Errorhandling for user debugging
            Console.ReadLine()
            Return Nothing
        End Try
    End Function
End Module
