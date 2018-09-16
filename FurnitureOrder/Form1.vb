' Two types of furniture, chairs and sofa
' Price of chair is $350, price of sofa is 925, sales tax is 5%
' Write program that creates an invoice for an order. Display using process order button (calculate everything with a function)
' Clear form button clears the form (put this in a function)
' Quit button exits the form
' The invoice number consists of the capitalized first two letters of the customers last name, followed by the last four digits of the zip code. 
' Make a method to create the invoice number
' The name displayed on the invoice is the proper order (first name, last name)

Public Class frmFurnitureOrder
    ' Create constants for the prices
    Dim chairPrice As Double = 350.0
    Dim sofaPrice As Double = 925
    Dim salesTax As Double = 0.05

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        ' Define variables
        Dim numOfChairs As Integer
        Dim numOfSofas As Integer

        Dim totalCost As Double

        Dim name As String
        Dim address As String
        Dim cityStateZip As String
        Dim invoiceNumber As String

        ' Get inputs and assign values to variables
        If Integer.TryParse(txtChairs.Text, numOfChairs) And Integer.TryParse(txtSofas.Text, numOfSofas) And txtName.Text <> "" And txtAddress.Text <> "" And txtCity.Text <> "" Then
            name = txtName.Text
            address = txtAddress.Text
            cityStateZip = txtCity.Text

            ' Run functions to process the invoice number and invoice
            totalCost = CalculateTotalInvoice(numOfChairs, numOfSofas)
            invoiceNumber = CreateInvoiceNumber(name, cityStateZip)
            ' Display the order 


        Else
            MessageBox.Show("Please enter valid inputs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtAddress.Clear()
        txtChairs.Clear()
        txtCity.Clear()
        txtName.Clear()
        txtSofas.Clear()
    End Sub

    ' Methods
    Function CreateInvoiceNumber(name As String, zip As String) As String
        ' The invoice number consists of the capitalized first two letters of the customers last name, followed by the last four digits of the zip code. 
        ' We will need to parse out the last name and get the first 2 letters, then the last 4 digits of zip



    End Function
    Function CalculateTotalInvoice(chairs As Integer, sofas As Integer) As Double
        Dim totalChairCost As Double
        Dim totalSofaCost As Double
        Dim totalAmount As Double = (totalChairCost * chairPrice) + (totalSofaCost * sofaPrice)

        Return totalAmount + (totalAmount * salesTax)
    End Function
    Function ReorderName() As String
    End Function



End Class
