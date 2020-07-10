Imports System.Windows.Forms

Public Class ADBox2

    Private Const AD_STR_MIN As String = "1900/01/01"

    Public canHoldDownButton As Boolean = True

    Private focusedTextBoxNum As Integer = 0

    Private focusControlFlg As Boolean = False

    Private Const VALUE_UP As Integer = 1
    Private Const VALUE_DOWN As Integer = -1

    Public Event keyDownEnter(ByVal sender As Object, ByVal e As EventArgs)

    Public Event YmdTextChange(ByVal sender As Object, ByVal e As EventArgs)

    Private _mode As Integer
    Public Property Mode() As Integer
        Get
            Return _mode
        End Get
        Set(ByVal value As Integer)
            _mode = value
            If Mode = 1 Then
                btnUp.Visible = False
                btnDown.Visible = False
                dateBox.Visible = False
                Label3.Visible = False
                Me.Size = New Drawing.Size(105, 35)

                Label1.Location = New System.Drawing.Point(43, 11)
                Label1.Text = "年"
                Label2.Location = New System.Drawing.Point(88, 11)
                Label2.Text = "月"
                monthBox.Location = New System.Drawing.Point(65, 8)
                dateBox.Location = New System.Drawing.Point(109, 8)
            ElseIf Mode = 2 Then
                btnUp.Visible = False
                btnDown.Visible = False
                dateBox.Visible = True
                Label3.Visible = False
                Me.Size = New Drawing.Size(113, 35)

                Label1.Location = New System.Drawing.Point(43, 11)
                Label1.Text = "."
                Label2.Location = New System.Drawing.Point(76, 11)
                Label2.Text = "."
                monthBox.Location = New System.Drawing.Point(53, 8)
                dateBox.Location = New System.Drawing.Point(86, 8)
            ElseIf Mode = 3 Then
                btnUp.Visible = True
                btnDown.Visible = True
                dateBox.Visible = False
                Label3.Visible = False
                Me.Size = New Drawing.Size(130, 35)

                Label1.Location = New System.Drawing.Point(43, 11)
                Label1.Text = "年"
                Label2.Location = New System.Drawing.Point(88, 11)
                Label2.Text = "月"
                monthBox.Location = New System.Drawing.Point(65, 8)
                dateBox.Location = New System.Drawing.Point(109, 8)
                btnUp.Location = New System.Drawing.Point(112, 1)
                btnDown.Location = New System.Drawing.Point(112, 17)
            Else
                btnUp.Visible = True
                btnDown.Visible = True
                dateBox.Visible = True
                Label3.Visible = True
                Me.Size = New Drawing.Size(176, 35)

                Label1.Location = New System.Drawing.Point(43, 11)
                Label1.Text = "年"
                Label2.Location = New System.Drawing.Point(88, 11)
                Label2.Text = "月"
                monthBox.Location = New System.Drawing.Point(65, 8)
                dateBox.Location = New System.Drawing.Point(109, 8)
            End If
        End Set
    End Property


    Public Property yearText() As String
        Get
            Return yearBox.Text
        End Get
        Set(value As String)
            yearBox.Text = value
        End Set
    End Property

    Public Property monthText() As String
        Get
            Return monthBox.Text
        End Get
        Set(value As String)
            monthBox.Text = value
        End Set
    End Property

    Public Property dateText() As String
        Get
            Return dateBox.Text
        End Get
        Set(value As String)
            dateBox.Text = value
        End Set
    End Property

    Private Sub ADBox2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.ContextMenu = New ContextMenu()
        yearBox.ContextMenu = New ContextMenu()
        monthBox.ContextMenu = New ContextMenu()
        dateBox.ContextMenu = New ContextMenu()

        setADStr(DateTime.Now.ToString("yyyy/MM/dd"))

        Timer1.Interval = 500
        Timer2.Interval = 500
    End Sub

    Public Sub setADStr(adStr As String)
        clearText()
        If adStr = "" Then
            setADStr(AD_STR_MIN)
            Return
        End If
        Dim adStrArray As String() = Split(adStr, "/")
        yearText = adStrArray(0)
        monthText = adStrArray(1)
        dateText = adStrArray(2)

        '初期値(1900/01/01)より以前のものは全て初期値に設定
        If CInt(yearText) < 1900 Then
            setADStr(AD_STR_MIN)
        End If

        RaiseEvent YmdTextChange(Me, New EventArgs)
    End Sub

    Public Function getADStr() As String
        Return yearText & "/" & monthText & "/" & dateText
    End Function

    Public Function getADymStr() As String
        Return yearText & "/" & monthText
    End Function

    Public Sub clearText()
        yearText = ""
        monthText = ""
        dateText = ""
    End Sub

    Private Function getMonthDaysNum(ByVal yearStr As String, ByVal monthStr As String) As Integer
        Dim daysNum As Integer
        Dim yearStrNum As Integer = Integer.Parse(yearStr)
        Dim monthStrNum As Integer = Integer.Parse(monthStr)
        daysNum = Date.DaysInMonth(yearStrNum, monthStrNum)
        Return daysNum
    End Function

    Private Sub yearBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles yearBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            RaiseEvent keyDownEnter(Me, New EventArgs)
            Return
        End If

        Dim selectedIndex As Integer = yearBox.SelectionStart

        If selectedIndex = 0 Then
            If e.KeyCode = Keys.Right Then
                yearBox.Select(1, 1)
                e.SuppressKeyPress = True
            ElseIf (Keys.D1 <= e.KeyCode AndAlso e.KeyCode <= Keys.D2) OrElse (Keys.NumPad1 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad2) Then
                Dim secondYearNum As Integer = CInt(yearText.Substring(1, 1))
                If Keys.D1 = e.KeyCode OrElse Keys.NumPad1 = e.KeyCode AndAlso secondYearNum <= 8 Then
                    setADStr(AD_STR_MIN)
                Else
                    yearText = If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & yearText.Substring(1, 3)
                    Dim daysNum As Integer = getMonthDaysNum(yearText, monthText)
                    If Integer.Parse(dateText) > daysNum Then
                        dateText = "" & daysNum
                    End If
                End If
                yearBox.Select(1, 1)
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If
        ElseIf selectedIndex = 1 Then
            If e.KeyCode = Keys.Right Then
                yearBox.Select(2, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Left Then
                yearBox.Select(0, 1)
                e.SuppressKeyPress = True
            ElseIf (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9) Then
                Dim firstYearNum As Integer = CInt(yearText.Substring(0, 1))
                If firstYearNum = 1 Then
                    If Keys.D9 = e.KeyCode OrElse e.KeyCode = Keys.NumPad9 Then
                        yearText = firstYearNum & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & yearText.Substring(2, 2)
                        Dim daysNum As Integer = getMonthDaysNum(yearText, monthText)
                        If Integer.Parse(dateText) > daysNum Then
                            dateText = "" & daysNum
                        End If
                        yearBox.Select(2, 1)
                        e.SuppressKeyPress = True
                    Else
                        e.SuppressKeyPress = True
                    End If
                Else
                    yearText = firstYearNum & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & yearText.Substring(2, 2)
                    Dim daysNum As Integer = getMonthDaysNum(yearText, monthText)
                    If Integer.Parse(dateText) > daysNum Then
                        dateText = "" & daysNum
                    End If
                    yearBox.Select(2, 1)
                    e.SuppressKeyPress = True
                End If
            Else
                e.SuppressKeyPress = True
            End If
        ElseIf selectedIndex = 2 Then
            If e.KeyCode = Keys.Right Then
                yearBox.Select(3, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Left Then
                yearBox.Select(1, 1)
                e.SuppressKeyPress = True
            ElseIf (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9) Then
                yearText = yearText.Substring(0, 2) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & yearText.Substring(3, 1)
                Dim daysNum As Integer = getMonthDaysNum(yearText, monthText)
                If Integer.Parse(dateText) > daysNum Then
                    dateText = "" & daysNum
                End If
                yearBox.Select(3, 1)
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If
        ElseIf selectedIndex = 3 Then
            If e.KeyCode = Keys.Right Then
                monthBox.Focus()
                monthBox.Select(0, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Left Then
                yearBox.Select(2, 1)
                e.SuppressKeyPress = True
            ElseIf (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9) Then
                yearText = yearText.Substring(0, 3) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode))
                Dim daysNum As Integer = getMonthDaysNum(yearText, monthText)
                If Integer.Parse(dateText) > daysNum Then
                    dateText = "" & daysNum
                End If
                monthBox.Focus()
                monthBox.Select(0, 1)
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If
        End If

        RaiseEvent YmdTextChange(Me, New EventArgs)
    End Sub

    Private Sub monthBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles monthBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            RaiseEvent keyDownEnter(Me, New EventArgs)
            Return
        End If

        Dim selectedIndex As Integer = monthBox.SelectionStart

        If selectedIndex = 0 Then
            '1文字目(月の10の位)
            If e.KeyCode = Keys.Left Then
                yearBox.Focus()
                yearBox.Select(3, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                monthBox.Select(1, 1)
                e.SuppressKeyPress = True
            ElseIf (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D1) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad1) Then
                If (e.KeyCode = Keys.D1 OrElse e.KeyCode = Keys.NumPad1) AndAlso Integer.Parse(monthText.Substring(1, 1)) >= 3 Then
                    monthText = "12"
                ElseIf (e.KeyCode = Keys.D0 OrElse e.KeyCode = Keys.NumPad0) AndAlso Integer.Parse(monthText.Substring(1, 1)) = 0 Then
                    monthText = "09"
                Else
                    monthText = If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & monthText.Substring(1, 1)
                End If
                Dim daysNum As Integer = getMonthDaysNum(yearText, monthText)
                If Integer.Parse(dateText) > daysNum Then
                    dateText = "" & daysNum
                End If
                monthBox.Select(1, 1)
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If
        ElseIf selectedIndex = 1 Then
            '10の位の文字取得
            Dim firstMonthChar As String = monthText.Substring(0, 1)

            '2文字目（月の１の位）の処理
            If e.KeyCode = Keys.Left Then
                monthBox.Select(0, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                dateBox.Focus()
                dateBox.Select(0, 1)
                e.SuppressKeyPress = True
            ElseIf (firstMonthChar = "0" AndAlso Keys.D1 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (firstMonthChar = "0" AndAlso Keys.NumPad1 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9) OrElse (firstMonthChar = "1" AndAlso Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D2) OrElse (firstMonthChar = "1" AndAlso Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad2) Then

                monthText = monthText.Substring(0, 1) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode))
                Dim daysNum As Integer = getMonthDaysNum(yearText, monthText)
                If Integer.Parse(dateText) > daysNum Then
                    dateText = "" & daysNum
                End If
                If Mode = 1 Then
                    monthBox.Select(1, 1)
                Else
                    dateBox.Focus()
                    dateBox.Select(0, 1)
                End If
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If
        End If

        RaiseEvent YmdTextChange(Me, New EventArgs)
    End Sub

    Private Sub yearBox_GotFocus(sender As Object, e As System.EventArgs) Handles yearBox.GotFocus
        If focusControlFlg = False Then
            yearBox.Select(0, 1)
        End If
        focusedTextBoxNum = 1
    End Sub

    Private Sub monthBox_GotFocus(sender As Object, e As System.EventArgs) Handles monthBox.GotFocus
        focusedTextBoxNum = 2
    End Sub

    Private Sub dateBox_GotFocus(sender As Object, e As System.EventArgs) Handles dateBox.GotFocus
        focusedTextBoxNum = 3
    End Sub

    Private Sub dateBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dateBox.KeyDown

        Dim selectedIndex As Integer = dateBox.SelectionStart
        '入力されている月の日数を取得
        Dim daysNum As Integer = getMonthDaysNum(yearText, monthText)

        If selectedIndex = 0 Then
            '1文字目(日の10の位)
            If e.KeyCode = Keys.Left Then
                monthBox.Focus()
                monthBox.Select(1, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                dateBox.Select(1, 1)
                e.SuppressKeyPress = True
            ElseIf (monthText = "02" AndAlso Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D2) OrElse (monthText = "02" AndAlso Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad2) OrElse (monthText <> "02" AndAlso Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D3) OrElse (monthText <> "02" AndAlso Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad3) Then
                If (e.KeyCode = Keys.D0 OrElse e.KeyCode = Keys.NumPad0) AndAlso dateText.Substring(1, 1) = "0" Then
                    dateText = "09"
                End If

                dateText = If(daysNum <= If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & dateText.Substring(1, 1), daysNum.ToString(), If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & dateText.Substring(1, 1))

                dateBox.Select(1, 1)
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If
        ElseIf selectedIndex = 1 Then
            '10の位の文字取得
            Dim firstDateChar As String = dateText.Substring(0, 1)

            '2文字目（日の１の位）の処理
            If e.KeyCode = Keys.Left Then
                dateBox.Select(0, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                dateBox.Select(1, 1)
                e.SuppressKeyPress = True
            ElseIf (firstDateChar = "0" AndAlso ((Keys.D1 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (Keys.NumPad1 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9))) OrElse
                   (firstDateChar = "1" AndAlso ((Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9))) OrElse
                   (firstDateChar = "2" AndAlso daysNum = 28 AndAlso ((Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D8) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad8))) OrElse
                   (firstDateChar = "2" AndAlso daysNum >= 29 AndAlso ((Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9))) OrElse
                   (firstDateChar = "3" AndAlso daysNum = 30 AndAlso ((Keys.D0 = e.KeyCode) OrElse (Keys.NumPad0 = e.KeyCode))) OrElse
                   (firstDateChar = "3" AndAlso daysNum = 31 AndAlso ((Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D1) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad1))) Then
                dateText = dateText.Substring(0, 1) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode))
                dateBox.Select(1, 1)
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If
        End If

        RaiseEvent YmdTextChange(Me, New EventArgs)
    End Sub

    Private Sub yearBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles yearBox.MouseClick
        Dim selectedIndex As Integer = yearBox.SelectionStart
        If selectedIndex = 4 Then
            yearBox.Select(selectedIndex - 1, 1)
        Else
            yearBox.Select(selectedIndex, 1)
        End If
    End Sub

    Private Sub monthBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles monthBox.MouseClick
        If monthText = "" Then
            yearBox.Focus()
            monthBox.Focus()
            yearBox.Focus()
            Return
        End If

        yearBox.Focus()
        monthBox.Focus()

        Dim selectedIndex As Integer = monthBox.SelectionStart
        If selectedIndex = 2 Then
            monthBox.Select(selectedIndex - 1, 1)
        Else
            monthBox.Select(selectedIndex, 1)
        End If
    End Sub

    Private Sub dateBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dateBox.MouseClick
        If dateText = "" Then
            yearBox.Focus()
            dateBox.Focus()
            yearBox.Focus()
            Return
        End If

        yearBox.Focus()
        dateBox.Focus()

        Dim selectedIndex As Integer = dateBox.SelectionStart
        If selectedIndex = 2 Then
            dateBox.Select(selectedIndex - 1, 1)
        Else
            dateBox.Select(selectedIndex, 1)
        End If
    End Sub

    Private Function getDateTimeObject(ymdStr As String) As DateTime
        Dim ymdArray() As String = ymdStr.Split("/")
        Return New DateTime(CInt(ymdArray(0)), CInt(ymdArray(1)), CInt(ymdArray(2)))
    End Function

    Private Sub yearTextUpDown(upDown As Integer)
        Dim currentInputDateTime As DateTime = getDateTimeObject(getADStr())
        If upDown = VALUE_UP Then
            '年の増加処理
            Dim plusOneYearDateTime As DateTime = currentInputDateTime.AddYears(1)
            setADStr(plusOneYearDateTime.ToString("yyyy/MM/dd"))
        ElseIf upDown = VALUE_DOWN Then
            '年の減少処理
            Dim minusOneYearDateTime As DateTime = currentInputDateTime.AddYears(-1)
            setADStr(minusOneYearDateTime.ToString("yyyy/MM/dd"))
        End If
    End Sub

    Private Sub monthTextUpDown(upDown As Integer)
        Dim currentInputDateTime As DateTime = getDateTimeObject(getADStr())
        Dim firstMonthStr As String = monthText.Substring(0, 1)
        Dim secondMonthStr As String = monthText.Substring(1, 1)
        If upDown = VALUE_UP Then
            '月の増加処理
            Dim plusOneMonthDateTime As DateTime = currentInputDateTime.AddMonths(1)
            setADStr(plusOneMonthDateTime.ToString("yyyy/MM/dd"))
        ElseIf upDown = VALUE_DOWN Then
            '月の減少処理
            Dim minusOneMonthDateTime As DateTime = currentInputDateTime.AddMonths(-1)
            setADStr(minusOneMonthDateTime.ToString("yyyy/MM/dd"))
        End If
    End Sub

    Private Sub dateTextUpDown(upDown As Integer)
        Dim currentInputDateTime As DateTime = getDateTimeObject(getADStr())
        If upDown = VALUE_UP Then
            '日の増加処理
            Dim plusOneDayDateTime As DateTime = currentInputDateTime.AddDays(1)
            setADStr(plusOneDayDateTime.ToString("yyyy/MM/dd"))
        ElseIf upDown = VALUE_DOWN Then
            '日の減少処理
            Dim minusOneDayDateTime As DateTime = currentInputDateTime.AddDays(-1)
            setADStr(minusOneDayDateTime.ToString("yyyy/MM/dd"))
        End If
    End Sub

    Private Sub upText()
        If yearText = "" Then
            Return
        End If

        If focusedTextBoxNum = 1 Then
            '西暦の増加処理
            Dim ss As Integer = yearBox.SelectionStart
            yearTextUpDown(VALUE_UP)
            yearBox.Select(ss, 1)
            focusControlFlg = True
            yearBox.Focus()
            focusControlFlg = False
        ElseIf focusedTextBoxNum = 2 Then
            '月の増加処理
            Dim ss As Integer = monthBox.SelectionStart
            monthTextUpDown(VALUE_UP)
            monthBox.Select(ss, 1)
            monthBox.Focus()
        ElseIf focusedTextBoxNum = 3 Then
            '日の増加処理
            Dim ss As Integer = dateBox.SelectionStart
            dateTextUpDown(VALUE_UP)
            dateBox.Select(ss, 1)
            dateBox.Focus()
        Else
            Return
        End If
    End Sub

    Private Sub downText()
        If yearText = "" Then
            Return
        End If

        If focusedTextBoxNum = 1 Then
            '西暦の減少処理
            Dim ss As Integer = yearBox.SelectionStart
            yearTextUpDown(VALUE_DOWN)
            yearBox.Select(ss, 1)
            focusControlFlg = True
            yearBox.Focus()
            focusControlFlg = False
        ElseIf focusedTextBoxNum = 2 Then
            '月の減少処理
            Dim ss As Integer = monthBox.SelectionStart
            monthTextUpDown(VALUE_DOWN)
            monthBox.Select(ss, 1)
            monthBox.Focus()
        ElseIf focusedTextBoxNum = 3 Then
            '日の減少処理
            Dim ss As Integer = dateBox.SelectionStart
            dateTextUpDown(VALUE_DOWN)
            dateBox.Select(ss, 1)
            dateBox.Focus()
        Else
            Return
        End If
    End Sub

    Private Sub btnUp_MouseDown(sender As Object, e As MouseEventArgs) Handles btnUp.MouseDown
        If canHoldDownButton Then
            upText()
            Timer1.Start()
        Else
            upText()
        End If
    End Sub

    Private Sub btnUp_MouseUp(sender As Object, e As MouseEventArgs) Handles btnUp.MouseUp
        If canHoldDownButton Then
            Timer1.Stop()
            Timer1.Interval = 500
        End If
    End Sub

    Private Sub btnDown_MouseDown(sender As Object, e As MouseEventArgs) Handles btnDown.MouseDown
        If canHoldDownButton Then
            downText()
            Timer2.Start()
        Else
            downText()
        End If
    End Sub

    Private Sub btnDown_MouseUp(sender As Object, e As MouseEventArgs) Handles btnDown.MouseUp
        If canHoldDownButton Then
            Timer2.Stop()
            Timer2.Interval = 500
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        upText()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As System.EventArgs) Handles Timer2.Tick
        Timer2.Interval = 100
        downText()
    End Sub
End Class
