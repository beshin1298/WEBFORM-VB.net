
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Web.DynamicData
Imports System.Windows.Forms

Public Class _Default
    Inherits Page

    Dim connect As New SqlConnection("Data Source=DESKTOP-3GOF0T0;Initial Catalog=demo_DB;Persist Security Info=True;User ID=sa;Password=123456789;TrustServerCertificate=True")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        LoadPage()
    End Sub

    Protected Sub Insert_Click(sender As Object, e As EventArgs) Handles Insert.Click
        Dim productId As String = txtProductId.Text
        Dim itemName As String = txtItemName.Text
        Dim insertDate As DateTime = txtInsertDate.Text
        Dim unit As Integer = txtUnit.Text
        Dim quanlity As Integer = txtQuanlity.Text
        If txtProductId.Enabled = True Then
            connect.Open()
            Dim command As New SqlCommand("Insert into demo values(@productId, @itemName, @unit, @insertDate, @quanlity)", connect)
            command.Parameters.AddWithValue("@productId", productId)
            command.Parameters.AddWithValue("@itemName", itemName)
            command.Parameters.AddWithValue("@unit", unit)
            command.Parameters.AddWithValue("@insertDate", insertDate)
            command.Parameters.AddWithValue("@quanlity", quanlity)
            command.ExecuteNonQuery()
            MsgBox("Successfully Inserted", MsgBoxStyle.Information, "Message")
            connect.Close()
            LoadPage()
            ResetForm()
        Else
            connect.Open()
            Dim command As New SqlCommand("Update demo SET itemName=@itemName, unit = @unit, insertDate = @insertDate, quanlity = @quanlity WHERE ProductId = @productId", connect)
            command.Parameters.AddWithValue("@productId", productId)
            command.Parameters.AddWithValue("@itemName", itemName)
            command.Parameters.AddWithValue("@unit", unit)
            command.Parameters.AddWithValue("@insertDate", insertDate)
            command.Parameters.AddWithValue("@quanlity", quanlity)
            command.ExecuteNonQuery()
            MsgBox("Successfully update", MsgBoxStyle.Information, "Message")
            connect.Close()
            LoadPage()
            ResetForm()

        End If


    End Sub

    Private Sub LoadPage()
        Dim dt As New DataTable
        connect.Open()
        Dim command As New SqlCommand("Select ProductId as 'Product Id', itemName as 'Name', insertDate as 'Insert DATE', quanlity as 'Quanlity', unit from demo", connect)
        Dim sd As New SqlDataAdapter(command)
        sd.Fill(dt)
        tableData.DataSource = dt
        tableData.DataBind()
        connect.Close()
    End Sub

    Protected Sub tableData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tableData.SelectedIndexChanged


    End Sub

    Private Sub tableData_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles tableData.RowCommand
        Dim productId = tableData.Rows(e.CommandArgument).Cells(0).Text
        Dim itemName = tableData.Rows(e.CommandArgument).Cells(1).Text
        Dim insertDate = tableData.Rows(e.CommandArgument).Cells(2).Text
        Dim unit = tableData.Rows(e.CommandArgument).Cells(3).Text
        Dim quanlity = tableData.Rows(e.CommandArgument).Cells(4).Text
        If e.CommandName.Equals("DeleteItem") Then
            DeleteData(productId)
        ElseIf e.CommandName.Equals("EditItem") Then
            ViewData(productId, itemName, insertDate, quanlity, unit)
        End If

    End Sub

    Private Sub DeleteData(ByVal productId As String)
        connect.Open()
        Dim command As New SqlCommand("Delete from demo where ProductId=@ProductId", connect)
        command.Parameters.AddWithValue("@ProductId", productId)
        command.ExecuteNonQuery()
        MsgBox("Successfully Delete", MsgBoxStyle.Information, "Message")
        connect.Close()
        LoadPage()
    End Sub

    Private Sub ViewData(ByVal productId As String, ByVal itemName As String, ByVal insertDate As DateTime, ByVal quanlity As Integer, ByVal unit As Integer)
        Debug.WriteLine(Left$(insertDate, 10))
        txtProductId.Text = productId
        txtItemName.Text = itemName
        txtInsertDate.Text = insertDate.ToString("yyyy-MM-dd")
        txtUnit.Text = unit
        txtQuanlity.Text = quanlity
        txtProductId.Enabled = False
    End Sub

    Private Sub ResetForm()
        txtProductId.Text = ""
        txtItemName.Text = ""
        txtInsertDate.Text = ""
        txtUnit.Text = ""
        txtQuanlity.Text = ""
        txtProductId.Enabled = True
    End Sub
    Protected Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        ResetForm()
    End Sub

End Class