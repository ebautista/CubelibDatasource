
Namespace My
    
    'This class allows you to handle specific events on the settings class:
    ' The SettingChanging event is raised before a setting's value is changed.
    ' The PropertyChanged event is raised after a setting's value is changed.
    ' The SettingsLoaded event is raised after the setting values are loaded.
    ' The SettingsSaving event is raised before the setting values are saved.
    Partial Friend NotInheritable Class MySettings

        Private Sub MySettings_SettingsLoaded(sender As Object, e As Configuration.SettingsLoadedEventArgs) Handles Me.SettingsLoaded
            Debug.Print("Loading runtime source...")
            Debug.Print(My.Settings.SadbelConnectionString)
            Dim path As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & objProp.getDatabasePath & "\mdb_sadbel.mdb;Persist Security Info=True;Encrypt Password=False;Mask Password=False;Jet OLEDB:Database Password=wack2"
            My.Settings.SadbelConnectionString.Replace(".\", objProp.getDatabasePath & "\")
            Debug.Print(My.Settings.SadbelConnectionString)
        End Sub
    End Class
End Namespace
