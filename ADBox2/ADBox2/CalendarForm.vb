Public Class CalendarForm

    Private adBox As ADBox2

    Private Sub CalendarForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        MonthCalendar.MaxSelectionCount = 1
    End Sub

    Public Sub New(ByVal adBox As ADBox2, ByVal ymdStr As String)
        InitializeComponent()
        Me.adBox = adBox
        If ymdStr <> "" Then
            Dim yearNum As Integer = Integer.Parse(ymdStr.Substring(0, 4))
            Dim monthNum As Integer = Integer.Parse(ymdStr.Substring(5, 2))
            Dim dateNum As Integer = Integer.Parse(ymdStr.Substring(8, 2))
            MonthCalendar.SetDate(New Date(yearNum, monthNum, dateNum))
        End If
    End Sub

    Private Sub MonthCalendar_DateSelected(sender As Object, e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar.DateSelected
        Dim ymdStr As String = MonthCalendar.SelectionRange.Start.ToString("yyyy/MM/dd")
        adBox.setADStr(ymdStr)
        adBox.yearBox.Focus()
        adBox.yearBox.Select(0, 1)
        Me.Close()
    End Sub

End Class